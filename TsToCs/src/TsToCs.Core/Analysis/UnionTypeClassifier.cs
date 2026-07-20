namespace TsToCs.Core.Analysis;

using TsToCs.Core.Parsing.TsAstModel;

public class UnionTypeClassifier
{
    public UnionTypeStrategy Classify(SerializedType unionType)
    {
        if (unionType.Kind != "union" || unionType.Types is null || unionType.Types.Count == 0)
            return UnionTypeStrategy.Dynamic;

        var types = unionType.Types;

        if (types.All(t => t.Kind == "literal" && t.Value is string))
            return UnionTypeStrategy.StringEnum;

        if (types.All(t => t.Kind == "literal" && t.Value is long or double or int))
            return UnionTypeStrategy.NumericEnum;

        bool hasNumber = types.Any(t => t.Kind == "number");
        bool hasAutoLiteral = types.Any(t => t.Kind == "literal" && t.Value is string s && s == "auto");
        bool hasPercentTemplate = types.Any(t => t.Kind == "templateLiteral");
        if (hasNumber && (hasAutoLiteral || hasPercentTemplate))
            return UnionTypeStrategy.DimensionValue;

        if (types.Count == 2)
        {
            bool hasString = types.Any(t => t.Kind == "string");
            bool hasNamedType = types.Any(t => t.Kind is "typeReference" or "object");
            if (hasString && hasNamedType)
                return UnionTypeStrategy.ImplicitConversion;
        }

        if (types.All(t => t.Kind == "object" && t.Properties is not null))
        {
            var discriminator = FindDiscriminatorProperty(types);
            if (discriminator is not null)
                return UnionTypeStrategy.DiscriminatedUnion;
        }

        if (types.Count <= 4)
            return UnionTypeStrategy.OneOf;

        return UnionTypeStrategy.Dynamic;
    }

    private string? FindDiscriminatorProperty(List<SerializedType> types)
    {
        if (types.Count == 0 || types[0].Properties is null) return null;

        var candidateProps = types[0].Properties!
            .Where(p => !p.Optional)
            .Select(p => p.Name)
            .ToList();

        foreach (var prop in candidateProps)
        {
            bool allHaveLiteral = types.All(t =>
                t.Properties?.Any(p => p.Name == prop && p.Type?.Kind == "literal") == true);

            if (allHaveLiteral)
            {
                bool allDistinct = types
                    .Select(t => t.Properties?.First(p => p.Name == prop).Type?.Value?.ToString())
                    .Distinct()
                    .Count() == types.Count;

                if (allDistinct) return prop;
            }
        }

        return null;
    }

    public void AnalyzeAll(IReadOnlyList<TsSourceFile> sourceFiles, AnalysisResult result)
    {
        foreach (var file in sourceFiles)
        {
            foreach (var decl in file.Declarations)
            {
                if (decl is TsTypeAliasDeclaration { Type.Kind: "union" } typeAlias)
                {
                    var strategy = Classify(typeAlias.Type!);
                    result.UnionStrategies[typeAlias.Name] = strategy;
                }
            }
        }
    }
}
