using System.CommandLine;
using TsToCs.Core.Pipeline;
using TsToCs.Plugins.OpenTui;

var projectOption = new Option<string>(
    "--project",
    "Path to the TypeScript tsconfig.json file")
{ IsRequired = true };

var outputOption = new Option<string>(
    "--output",
    () => "./output",
    "Output directory for generated C# files");

var bridgeOption = new Option<string>(
    "--bridge",
    () => Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "ts-bridge"),
    "Path to the ts-bridge directory");

var rootCommand = new RootCommand("TsToCs - TypeScript to C# Converter")
{
    projectOption,
    outputOption,
    bridgeOption,
};

rootCommand.SetHandler(async (project, output, bridge) =>
{
    var config = new ConversionConfig
    {
        TsConfigPath = Path.GetFullPath(project),
        OutputDirectory = Path.GetFullPath(output),
        TsBridgePath = Path.GetFullPath(bridge),
    };

    var pipeline = new ConversionPipeline(config);
    pipeline.AddPlugin(new OpenTuiPlugin());

    try
    {
        var result = await pipeline.ConvertAsync();
        Console.WriteLine($"\nConversion complete!");
        Console.WriteLine($"  Files generated: {result.FilesGenerated}");
        Console.WriteLine($"  Output: {result.OutputDirectory}");

        if (result.Warnings.Count > 0)
        {
            Console.WriteLine($"\nWarnings ({result.Warnings.Count}):");
            foreach (var warning in result.Warnings.Take(20))
            {
                Console.WriteLine($"  [{warning.Severity}] {warning.FilePath}: {warning.Message}");
            }
        }
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine($"Error: {ex.Message}");
        Environment.ExitCode = 1;
    }
}, projectOption, outputOption, bridgeOption);

return await rootCommand.InvokeAsync(args);
