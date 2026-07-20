namespace TsToCs.Core.Parsing.TsAstModel;

using System.Text.Json;
using System.Text.Json.Serialization;

public record SerializedType
{
    [JsonPropertyName("kind")]
    public string Kind { get; init; } = "unknown";

    [JsonPropertyName("text")]
    public string? Text { get; init; }

    [JsonPropertyName("value")]
    [JsonConverter(typeof(LiteralValueConverter))]
    public object? Value { get; init; }

    [JsonPropertyName("types")]
    public List<SerializedType>? Types { get; init; }

    [JsonPropertyName("elementType")]
    public SerializedType? ElementType { get; init; }

    [JsonPropertyName("typeArguments")]
    public List<SerializedType>? TypeArguments { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("constraint")]
    public SerializedType? Constraint { get; init; }

    [JsonPropertyName("default")]
    public SerializedType? Default { get; init; }

    [JsonPropertyName("properties")]
    public List<SerializedProperty>? Properties { get; init; }

    [JsonPropertyName("signatures")]
    public List<SerializedSignature>? Signatures { get; init; }

    [JsonPropertyName("checkType")]
    public SerializedType? CheckType { get; init; }

    [JsonPropertyName("extendsType")]
    public SerializedType? ExtendsType { get; init; }

    [JsonPropertyName("trueType")]
    public SerializedType? TrueType { get; init; }

    [JsonPropertyName("falseType")]
    public SerializedType? FalseType { get; init; }
}

public record SerializedProperty
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = "";

    [JsonPropertyName("type")]
    public SerializedType? Type { get; init; }

    [JsonPropertyName("optional")]
    public bool Optional { get; init; }

    [JsonPropertyName("readonly")]
    public bool IsReadonly { get; init; }
}

public record SerializedSignature
{
    [JsonPropertyName("parameters")]
    public List<SerializedParameter>? Parameters { get; init; }

    [JsonPropertyName("returnType")]
    public SerializedType? ReturnType { get; init; }

    [JsonPropertyName("typeParameters")]
    public List<SerializedTypeParameter>? TypeParameters { get; init; }
}

public record SerializedParameter
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = "";

    [JsonPropertyName("type")]
    public SerializedType? Type { get; init; }

    [JsonPropertyName("optional")]
    public bool Optional { get; init; }

    [JsonPropertyName("isRest")]
    public bool IsRest { get; init; }

    [JsonPropertyName("defaultValue")]
    public string? DefaultValue { get; init; }
}

public record SerializedTypeParameter
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = "";

    [JsonPropertyName("constraint")]
    public SerializedType? Constraint { get; init; }

    [JsonPropertyName("default")]
    public SerializedType? Default { get; init; }
}

public class LiteralValueConverter : JsonConverter<object?>
{
    public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.String => reader.GetString(),
            JsonTokenType.Number => reader.TryGetInt64(out var l) ? l : reader.GetDouble(),
            JsonTokenType.True => true,
            JsonTokenType.False => false,
            JsonTokenType.Null => null,
            _ => null,
        };
    }

    public override void Write(Utf8JsonWriter writer, object? value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}
