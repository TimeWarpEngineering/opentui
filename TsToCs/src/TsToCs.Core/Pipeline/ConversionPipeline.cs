namespace TsToCs.Core.Pipeline;

using TsToCs.Core.Analysis;
using TsToCs.Core.Generation;
using TsToCs.Core.IR;
using TsToCs.Core.Parsing.Bridge;
using TsToCs.Core.Parsing.TsAstModel;
using TsToCs.Core.Plugins;

public class ConversionPipeline
{
    private readonly ConversionConfig _config;
    private readonly List<IConversionPlugin> _plugins = new();

    public ConversionPipeline(ConversionConfig config)
    {
        _config = config;
    }

    public void AddPlugin(IConversionPlugin plugin)
    {
        plugin.Configure(_config);
        _plugins.Add(plugin);
    }

    public async Task<ConversionResult> ConvertAsync()
    {
        // Stage 1: Parse
        Console.Error.WriteLine("Stage 1: Parsing TypeScript project...");
        var sourceFiles = await ParseAsync();
        Console.Error.WriteLine($"  Parsed {sourceFiles.Count} source files");

        // Stage 2: Analyze
        Console.Error.WriteLine("Stage 2: Analyzing patterns...");
        var recognizer = new PatternRecognizer();
        var analysis = recognizer.Analyze(sourceFiles);
        Console.Error.WriteLine($"  Found {analysis.ClassHierarchy.Count} classes, {analysis.EventEmitterClasses.Count} event emitters, {analysis.UnionStrategies.Count} union types");

        // Stage 3: Generate IR
        Console.Error.WriteLine("Stage 3: Generating IR...");
        var irGenerator = new IrGenerator(analysis, _config.NamespaceMap);
        var modules = irGenerator.Generate(sourceFiles);
        Console.Error.WriteLine($"  Generated {modules.Count} modules");

        // Stage 4: Emit C#
        Console.Error.WriteLine("Stage 4: Emitting C# code...");
        var emitter = new CSharpEmitter();
        var files = emitter.Emit(modules);
        Console.Error.WriteLine($"  Emitted {files.Count} C# files");

        // Stage 5: Write to disk
        Console.Error.WriteLine("Stage 5: Writing files...");
        foreach (var (fileName, code) in files)
        {
            var outputPath = Path.Combine(_config.OutputDirectory, fileName);
            var dir = Path.GetDirectoryName(outputPath);
            if (dir is not null)
                Directory.CreateDirectory(dir);
            await File.WriteAllTextAsync(outputPath, code);
        }
        Console.Error.WriteLine($"  Wrote {files.Count} files to {_config.OutputDirectory}");

        return new ConversionResult
        {
            FilesGenerated = files.Count,
            Warnings = analysis.Warnings,
            OutputDirectory = _config.OutputDirectory,
        };
    }

    private async Task<List<TsSourceFile>> ParseAsync()
    {
        using var bridge = new BunProcessManager(_config.TsBridgePath);
        var sourceFiles = new List<TsSourceFile>();

        await foreach (var file in bridge.ParseProjectAsync(_config.TsConfigPath))
        {
            sourceFiles.Add(file);
        }

        return sourceFiles;
    }
}

public class ConversionResult
{
    public int FilesGenerated { get; init; }
    public List<ConversionWarning> Warnings { get; init; } = new();
    public string OutputDirectory { get; init; } = "";
}
