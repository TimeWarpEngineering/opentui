namespace TsToCs.Core.Generation;

using TsToCs.Core.Analysis;
using TsToCs.Core.IR;
using TsToCs.Core.Parsing.TsAstModel;

public class TypeMapper
{
    private readonly AnalysisResult _analysis;

    private static readonly Dictionary<string, IrTypeRef> PrimitiveMap = new()
    {
        ["string"] = IrTypeRef.String,
        ["number"] = IrTypeRef.Double,
        ["boolean"] = IrTypeRef.Bool,
        ["void"] = IrTypeRef.Void,
        ["any"] = IrTypeRef.Dynamic,
        ["unknown"] = IrTypeRef.Object,
        ["never"] = IrTypeRef.Void,
        ["null"] = IrTypeRef.Nullable(IrTypeRef.Object),
        ["undefined"] = IrTypeRef.Nullable(IrTypeRef.Object),
        ["object"] = IrTypeRef.Object,
        ["bigint"] = IrTypeRef.Long,
    };

    private static readonly Dictionary<string, string> CollectionMap = new()
    {
        ["Map"] = "Dictionary",
        ["Set"] = "HashSet",
        ["Array"] = "List",
        ["ReadonlyArray"] = "IReadOnlyList",
        ["ReadonlyMap"] = "IReadOnlyDictionary",
        ["ReadonlySet"] = "IReadOnlyCollection",
        ["WeakMap"] = "Dictionary",
        ["WeakSet"] = "HashSet",
    };

    public TypeMapper(AnalysisResult analysis)
    {
        _analysis = analysis;
    }

    public IrTypeRef MapType(SerializedType? type)
    {
        if (type is null) return IrTypeRef.Dynamic;

        return type.Kind switch
        {
            "string" => IrTypeRef.String,
            "number" => IrTypeRef.Double,
            "boolean" => IrTypeRef.Bool,
            "void" => IrTypeRef.Void,
            "any" => IrTypeRef.Dynamic,
            "unknown" => IrTypeRef.Object,
            "never" => IrTypeRef.Void,
            "null" => IrTypeRef.Nullable(IrTypeRef.Object),
            "undefined" => IrTypeRef.Nullable(IrTypeRef.Object),
            "literal" => MapLiteralType(type),
            "array" => IrTypeRef.Array(MapType(type.ElementType)),
            "tuple" => MapTupleType(type),
            "union" => MapUnionType(type),
            "intersection" => MapIntersectionType(type),
            "typeReference" => MapTypeReference(type),
            "function" => MapFunctionType(type),
            "enum" or "enumLiteral" => MapEnumType(type),
            "typeParameter" => MapTypeParameter(type),
            "object" => MapObjectType(type),
            "conditional" => MapConditionalType(type),
            "templateLiteral" => IrTypeRef.String,
            _ => IrTypeRef.Dynamic,
        };
    }

    private IrTypeRef MapLiteralType(SerializedType type)
    {
        return type.Value switch
        {
            string => IrTypeRef.String,
            long or int or double => IrTypeRef.Double,
            bool => IrTypeRef.Bool,
            _ => IrTypeRef.Object,
        };
    }

    private IrTypeRef MapTupleType(SerializedType type)
    {
        if (type.Types is null || type.Types.Count == 0) return IrTypeRef.Object;
        var elements = type.Types.Select(MapType).ToArray();
        return IrTypeRef.Generic("ValueTuple", elements);
    }

    private IrTypeRef MapUnionType(SerializedType type)
    {
        if (type.Types is null || type.Types.Count == 0) return IrTypeRef.Dynamic;

        var nonNullTypes = type.Types.Where(t => t.Kind is not "null" and not "undefined").ToList();
        var isNullable = type.Types.Count > nonNullTypes.Count;

        if (nonNullTypes.Count == 1)
        {
            var mapped = MapType(nonNullTypes[0]);
            return isNullable ? IrTypeRef.Nullable(mapped) : mapped;
        }

        // Check if this union has been classified
        if (type.Text is not null && _analysis.UnionStrategies.TryGetValue(type.Text, out var strategy))
        {
            return strategy switch
            {
                UnionTypeStrategy.DimensionValue => new IrTypeRef { Name = "DimensionValue", Kind = IrTypeRefKind.Named },
                _ => IrTypeRef.Dynamic,
            };
        }

        // All string literals → use string
        if (nonNullTypes.All(t => t.Kind == "literal" && t.Value is string))
            return isNullable ? IrTypeRef.Nullable(IrTypeRef.String) : IrTypeRef.String;

        return IrTypeRef.Dynamic;
    }

    private IrTypeRef MapIntersectionType(SerializedType type)
    {
        if (type.Types is null || type.Types.Count == 0) return IrTypeRef.Dynamic;
        return MapType(type.Types[0]);
    }

    private IrTypeRef MapTypeReference(SerializedType type)
    {
        var name = type.Name ?? type.Text ?? "object";

        if (PrimitiveMap.TryGetValue(name, out var primitive))
            return primitive;

        if (name == "Promise" || name == "PromiseLike")
        {
            var resultType = type.TypeArguments?.Count > 0 ? MapType(type.TypeArguments[0]) : null;
            return IrTypeRef.Task(resultType);
        }

        if (CollectionMap.TryGetValue(name, out var collectionName))
        {
            var typeArgs = type.TypeArguments?.Select(MapType).ToArray() ?? System.Array.Empty<IrTypeRef>();
            return IrTypeRef.Generic(collectionName, typeArgs);
        }

        if (name == "Record")
        {
            var keyType = type.TypeArguments?.Count > 0 ? MapType(type.TypeArguments[0]) : IrTypeRef.String;
            var valueType = type.TypeArguments?.Count > 1 ? MapType(type.TypeArguments[1]) : IrTypeRef.Object;
            return IrTypeRef.Dictionary(keyType, valueType);
        }

        if (name == "Partial" || name == "Required" || name == "Readonly")
        {
            return type.TypeArguments?.Count > 0 ? MapType(type.TypeArguments[0]) : IrTypeRef.Object;
        }

        if (name == "Omit" || name == "Pick")
        {
            return type.TypeArguments?.Count > 0 ? MapType(type.TypeArguments[0]) : IrTypeRef.Object;
        }

        var result = new IrTypeRef { Name = name, Kind = IrTypeRefKind.Named };
        if (type.TypeArguments is { Count: > 0 })
        {
            result = result with { TypeArguments = type.TypeArguments.Select(MapType).ToList() };
        }

        return result;
    }

    private IrTypeRef MapFunctionType(SerializedType type)
    {
        if (type.Signatures is null || type.Signatures.Count == 0)
            return new IrTypeRef { Name = "Action", Kind = IrTypeRefKind.Named };

        var sig = type.Signatures[0];
        var returnType = MapType(sig.ReturnType);
        var paramTypes = sig.Parameters?.Select(p => MapType(p.Type)).ToList() ?? new();

        if (returnType.Kind == IrTypeRefKind.Void && returnType.Name == "void")
        {
            return paramTypes.Count == 0
                ? new IrTypeRef { Name = "Action", Kind = IrTypeRefKind.Named }
                : IrTypeRef.Generic("Action", paramTypes.ToArray());
        }

        var allTypes = paramTypes.Append(returnType).ToArray();
        return IrTypeRef.Generic("Func", allTypes);
    }

    private IrTypeRef MapEnumType(SerializedType type)
    {
        return new IrTypeRef { Name = type.Name ?? "int", Kind = IrTypeRefKind.Named };
    }

    private IrTypeRef MapTypeParameter(SerializedType type)
    {
        return new IrTypeRef { Name = type.Name ?? "T", Kind = IrTypeRefKind.Named };
    }

    private IrTypeRef MapObjectType(SerializedType type)
    {
        if (type.Properties is not null && type.Properties.Count > 0)
            return IrTypeRef.Object;

        return IrTypeRef.Object;
    }

    private IrTypeRef MapConditionalType(SerializedType type)
    {
        if (type.TrueType is not null)
            return MapType(type.TrueType);

        return IrTypeRef.Dynamic;
    }
}
