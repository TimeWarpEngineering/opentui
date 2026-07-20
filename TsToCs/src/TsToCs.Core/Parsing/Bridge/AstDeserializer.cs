namespace TsToCs.Core.Parsing.Bridge;

using System.Text.Json;
using TsToCs.Core.Parsing.TsAstModel;

public static class AstDeserializer
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = true,
        AllowTrailingCommas = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
    };

    public static TsSourceFile DeserializeSourceFile(string json)
    {
        return JsonSerializer.Deserialize<TsSourceFile>(json, Options)
            ?? throw new JsonException("Failed to deserialize source file");
    }

    public static async IAsyncEnumerable<TsSourceFile> DeserializeStreamAsync(Stream stream)
    {
        using var reader = new StreamReader(stream);
        while (await reader.ReadLineAsync() is { } line)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            TsSourceFile? sourceFile;
            try
            {
                sourceFile = JsonSerializer.Deserialize<TsSourceFile>(line, Options);
            }
            catch (JsonException ex)
            {
                Console.Error.WriteLine($"Warning: Failed to deserialize line: {ex.Message}");
                continue;
            }

            if (sourceFile is not null)
                yield return sourceFile;
        }
    }
}
