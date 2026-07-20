namespace TsToCs.Core.IR;

public record IrTypeRef
{
    public string Name { get; init; } = "";
    public string? Namespace { get; init; }
    public List<IrTypeRef> TypeArguments { get; init; } = new();
    public bool IsNullable { get; init; }
    public bool IsArray { get; init; }
    public IrTypeRef? ArrayElementType { get; init; }
    public IrTypeRefKind Kind { get; init; } = IrTypeRefKind.Named;

    public static readonly IrTypeRef Void = new() { Name = "void", Kind = IrTypeRefKind.Void };
    public static readonly IrTypeRef String = new() { Name = "string", Kind = IrTypeRefKind.Primitive };
    public static readonly IrTypeRef Int = new() { Name = "int", Kind = IrTypeRefKind.Primitive };
    public static readonly IrTypeRef Long = new() { Name = "long", Kind = IrTypeRefKind.Primitive };
    public static readonly IrTypeRef Double = new() { Name = "double", Kind = IrTypeRefKind.Primitive };
    public static readonly IrTypeRef Bool = new() { Name = "bool", Kind = IrTypeRefKind.Primitive };
    public static readonly IrTypeRef Object = new() { Name = "object", Kind = IrTypeRefKind.Primitive };
    public static readonly IrTypeRef Dynamic = new() { Name = "dynamic", Kind = IrTypeRefKind.Dynamic };

    public static IrTypeRef Nullable(IrTypeRef inner) =>
        inner with { IsNullable = true };

    public static IrTypeRef Array(IrTypeRef elementType) =>
        new() { Name = elementType.Name + "[]", IsArray = true, ArrayElementType = elementType, Kind = IrTypeRefKind.Array };

    public static IrTypeRef Generic(string name, params IrTypeRef[] typeArgs) =>
        new() { Name = name, TypeArguments = typeArgs.ToList(), Kind = IrTypeRefKind.Named };

    public static IrTypeRef Task(IrTypeRef? resultType = null) =>
        resultType is null
            ? new() { Name = "Task", Namespace = "System.Threading.Tasks", Kind = IrTypeRefKind.Named }
            : Generic("Task", resultType) with { Namespace = "System.Threading.Tasks" };

    public static IrTypeRef Dictionary(IrTypeRef key, IrTypeRef value) =>
        Generic("Dictionary", key, value) with { Namespace = "System.Collections.Generic" };

    public static IrTypeRef HashSet(IrTypeRef element) =>
        Generic("HashSet", element) with { Namespace = "System.Collections.Generic" };

    public static IrTypeRef List(IrTypeRef element) =>
        Generic("List", element) with { Namespace = "System.Collections.Generic" };
}

public enum IrTypeRefKind
{
    Named,
    Primitive,
    Void,
    Dynamic,
    Array,
    Tuple,
}
