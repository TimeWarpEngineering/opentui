namespace TsToCs.Core.Pipeline;

public class ConversionConfig
{
    public string TsConfigPath { get; set; } = "";
    public string TsBridgePath { get; set; } = "";
    public string OutputDirectory { get; set; } = "./output";
    public Dictionary<string, string> NamespaceMap { get; set; } = new();
    public Dictionary<string, string> TypeOverrides { get; set; } = new();
    public List<string> ExcludePatterns { get; set; } = new();
    public string TargetFramework { get; set; } = "net9.0";
}
