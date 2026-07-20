namespace TsToCs.Core.Parsing.TsAstModel;

using System.Text.Json.Serialization;

public record TsSourceFile
{
    [JsonPropertyName("filePath")]
    public string FilePath { get; init; } = "";

    [JsonPropertyName("declarations")]
    public List<TsDeclaration> Declarations { get; init; } = new();
}

[JsonPolymorphic(TypeDiscriminatorPropertyName = "declarationKind")]
[JsonDerivedType(typeof(TsClassDeclaration), "class")]
[JsonDerivedType(typeof(TsInterfaceDeclaration), "interface")]
[JsonDerivedType(typeof(TsTypeAliasDeclaration), "typeAlias")]
[JsonDerivedType(typeof(TsEnumDeclaration), "enum")]
[JsonDerivedType(typeof(TsFunctionDeclaration), "function")]
[JsonDerivedType(typeof(TsVariableDeclaration), "variable")]
public abstract record TsDeclaration
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = "";

    [JsonPropertyName("exported")]
    public bool Exported { get; init; }

    [JsonPropertyName("documentation")]
    public string? Documentation { get; init; }
}

public record TsClassDeclaration : TsDeclaration
{
    [JsonPropertyName("typeParameters")]
    public List<SerializedTypeParameter>? TypeParameters { get; init; }

    [JsonPropertyName("extends")]
    public TsHeritageClause? Extends { get; init; }

    [JsonPropertyName("implements")]
    public List<TsHeritageClause>? Implements { get; init; }

    [JsonPropertyName("isAbstract")]
    public bool IsAbstract { get; init; }

    [JsonPropertyName("members")]
    public List<TsClassMember> Members { get; init; } = new();
}

public record TsHeritageClause
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = "";

    [JsonPropertyName("typeArguments")]
    public List<SerializedType>? TypeArguments { get; init; }
}

[JsonPolymorphic(TypeDiscriminatorPropertyName = "memberKind")]
[JsonDerivedType(typeof(TsMethodMember), "method")]
[JsonDerivedType(typeof(TsPropertyMember), "property")]
[JsonDerivedType(typeof(TsConstructorMember), "constructor")]
[JsonDerivedType(typeof(TsGetAccessorMember), "getter")]
[JsonDerivedType(typeof(TsSetAccessorMember), "setter")]
public abstract record TsClassMember
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = "";

    [JsonPropertyName("visibility")]
    public string? Visibility { get; init; }

    [JsonPropertyName("isStatic")]
    public bool IsStatic { get; init; }
}

public record TsMethodMember : TsClassMember
{
    [JsonPropertyName("parameters")]
    public List<SerializedParameter> Parameters { get; init; } = new();

    [JsonPropertyName("returnType")]
    public SerializedType? ReturnType { get; init; }

    [JsonPropertyName("typeParameters")]
    public List<SerializedTypeParameter>? TypeParameters { get; init; }

    [JsonPropertyName("isAsync")]
    public bool IsAsync { get; init; }

    [JsonPropertyName("isAbstract")]
    public bool IsAbstract { get; init; }

    [JsonPropertyName("body")]
    public string? Body { get; init; }
}

public record TsPropertyMember : TsClassMember
{
    [JsonPropertyName("type")]
    public SerializedType? Type { get; init; }

    [JsonPropertyName("optional")]
    public bool Optional { get; init; }

    [JsonPropertyName("readonly")]
    public bool IsReadonly { get; init; }

    [JsonPropertyName("initializer")]
    public string? Initializer { get; init; }
}

public record TsConstructorMember : TsClassMember
{
    [JsonPropertyName("parameters")]
    public List<SerializedParameter> Parameters { get; init; } = new();

    [JsonPropertyName("body")]
    public string? Body { get; init; }
}

public record TsGetAccessorMember : TsClassMember
{
    [JsonPropertyName("returnType")]
    public SerializedType? ReturnType { get; init; }

    [JsonPropertyName("body")]
    public string? Body { get; init; }
}

public record TsSetAccessorMember : TsClassMember
{
    [JsonPropertyName("parameterType")]
    public SerializedType? ParameterType { get; init; }

    [JsonPropertyName("body")]
    public string? Body { get; init; }
}

public record TsInterfaceDeclaration : TsDeclaration
{
    [JsonPropertyName("typeParameters")]
    public List<SerializedTypeParameter>? TypeParameters { get; init; }

    [JsonPropertyName("extends")]
    public List<TsHeritageClause>? Extends { get; init; }

    [JsonPropertyName("properties")]
    public List<SerializedProperty> Properties { get; init; } = new();

    [JsonPropertyName("methods")]
    public List<TsMethodSignature>? Methods { get; init; }

    [JsonPropertyName("indexSignatures")]
    public List<TsIndexSignature>? IndexSignatures { get; init; }
}

public record TsMethodSignature
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = "";

    [JsonPropertyName("parameters")]
    public List<SerializedParameter> Parameters { get; init; } = new();

    [JsonPropertyName("returnType")]
    public SerializedType? ReturnType { get; init; }

    [JsonPropertyName("typeParameters")]
    public List<SerializedTypeParameter>? TypeParameters { get; init; }

    [JsonPropertyName("optional")]
    public bool Optional { get; init; }
}

public record TsIndexSignature
{
    [JsonPropertyName("keyName")]
    public string KeyName { get; init; } = "";

    [JsonPropertyName("keyType")]
    public SerializedType? KeyType { get; init; }

    [JsonPropertyName("valueType")]
    public SerializedType? ValueType { get; init; }

    [JsonPropertyName("readonly")]
    public bool IsReadonly { get; init; }
}

public record TsTypeAliasDeclaration : TsDeclaration
{
    [JsonPropertyName("typeParameters")]
    public List<SerializedTypeParameter>? TypeParameters { get; init; }

    [JsonPropertyName("type")]
    public SerializedType? Type { get; init; }
}

public record TsEnumDeclaration : TsDeclaration
{
    [JsonPropertyName("isConst")]
    public bool IsConst { get; init; }

    [JsonPropertyName("members")]
    public List<TsEnumMember> Members { get; init; } = new();
}

public record TsEnumMember
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = "";

    [JsonPropertyName("value")]
    [JsonConverter(typeof(LiteralValueConverter))]
    public object? Value { get; init; }
}

public record TsFunctionDeclaration : TsDeclaration
{
    [JsonPropertyName("parameters")]
    public List<SerializedParameter> Parameters { get; init; } = new();

    [JsonPropertyName("returnType")]
    public SerializedType? ReturnType { get; init; }

    [JsonPropertyName("typeParameters")]
    public List<SerializedTypeParameter>? TypeParameters { get; init; }

    [JsonPropertyName("isAsync")]
    public bool IsAsync { get; init; }

    [JsonPropertyName("body")]
    public string? Body { get; init; }
}

public record TsVariableDeclaration : TsDeclaration
{
    [JsonPropertyName("type")]
    public SerializedType? Type { get; init; }

    [JsonPropertyName("initializer")]
    public string? Initializer { get; init; }

    [JsonPropertyName("isConst")]
    public bool IsConst { get; init; }
}
