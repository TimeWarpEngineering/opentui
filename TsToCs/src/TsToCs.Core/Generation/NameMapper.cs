namespace TsToCs.Core.Generation;

using System.Text;
using System.Text.RegularExpressions;

public static partial class NameMapper
{
    public static string ToPascalCase(string name)
    {
        if (string.IsNullOrEmpty(name)) return name;

        // Already PascalCase
        if (char.IsUpper(name[0]) && !name.Contains('_') && !name.Contains('-'))
            return name;

        var sb = new StringBuilder();
        bool capitalizeNext = true;

        foreach (var ch in name)
        {
            if (ch is '_' or '-')
            {
                capitalizeNext = true;
                continue;
            }

            if (capitalizeNext)
            {
                sb.Append(char.ToUpper(ch));
                capitalizeNext = false;
            }
            else
            {
                sb.Append(ch);
            }
        }

        return sb.ToString();
    }

    public static string ToCamelCase(string name)
    {
        var pascal = ToPascalCase(name);
        if (pascal.Length == 0) return pascal;
        return char.ToLower(pascal[0]) + pascal[1..];
    }

    public static string SanitizeIdentifier(string name)
    {
        if (CSharpKeywords.Contains(name))
            return "@" + name;
        return name;
    }

    public static string FilePathToNamespace(string filePath, Dictionary<string, string> moduleMap)
    {
        foreach (var (prefix, ns) in moduleMap)
        {
            if (filePath.StartsWith(prefix))
                return ns;
        }

        var parts = filePath
            .Replace('\\', '/')
            .Split('/')
            .Where(p => p != "src" && p != "index.ts" && !p.EndsWith(".ts"))
            .Select(ToPascalCase);

        return string.Join(".", parts);
    }

    private static readonly HashSet<string> CSharpKeywords = new()
    {
        "abstract", "as", "base", "bool", "break", "byte", "case", "catch",
        "char", "checked", "class", "const", "continue", "decimal", "default",
        "delegate", "do", "double", "else", "enum", "event", "explicit",
        "extern", "false", "finally", "fixed", "float", "for", "foreach",
        "goto", "if", "implicit", "in", "int", "interface", "internal", "is",
        "lock", "long", "namespace", "new", "null", "object", "operator",
        "out", "override", "params", "private", "protected", "public",
        "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof",
        "stackalloc", "static", "string", "struct", "switch", "this", "throw",
        "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe",
        "ushort", "using", "virtual", "void", "volatile", "while", "yield",
    };
}
