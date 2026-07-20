namespace TsToCs.Core.Analysis;

using TsToCs.Core.Parsing.TsAstModel;

public class AnalysisResult
{
    public Dictionary<string, ClassHierarchyNode> ClassHierarchy { get; } = new();
    public Dictionary<string, UnionTypeStrategy> UnionStrategies { get; } = new();
    public HashSet<string> EventEmitterClasses { get; } = new();
    public Dictionary<string, List<EventInfo>> EventMaps { get; } = new();
    public HashSet<string> OptionsBagInterfaces { get; } = new();
    public List<ConversionWarning> Warnings { get; } = new();
}

public class ClassHierarchyNode
{
    public string Name { get; init; } = "";
    public string? BaseClass { get; init; }
    public List<string> Interfaces { get; init; } = new();
    public List<string> DerivedClasses { get; init; } = new();
    public bool IsAbstract { get; init; }
}

public record EventInfo
{
    public string EventName { get; init; } = "";
    public List<SerializedType> PayloadTypes { get; init; } = new();
}

public enum UnionTypeStrategy
{
    StringEnum,
    NumericEnum,
    DimensionValue,
    DiscriminatedUnion,
    ImplicitConversion,
    OneOf,
    Dynamic,
}

public record ConversionWarning
{
    public string FilePath { get; init; } = "";
    public string Message { get; init; } = "";
    public ConversionWarningSeverity Severity { get; init; }
}

public enum ConversionWarningSeverity
{
    Info,
    Warning,
    ManualRequired,
}
