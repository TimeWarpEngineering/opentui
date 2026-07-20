namespace TsToCs.Core.Parsing.Bridge;

using System.Diagnostics;
using TsToCs.Core.Parsing.TsAstModel;

public class BunProcessManager : IDisposable
{
    private readonly string _tsBridgePath;
    private Process? _process;

    public BunProcessManager(string tsBridgePath)
    {
        _tsBridgePath = tsBridgePath;
    }

    public async IAsyncEnumerable<TsSourceFile> ParseProjectAsync(string tsconfigPath)
    {
        var indexPath = Path.Combine(_tsBridgePath, "index.ts");

        var startInfo = new ProcessStartInfo
        {
            FileName = "bun",
            Arguments = $"run \"{indexPath}\" --project \"{tsconfigPath}\"",
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true,
        };

        _process = Process.Start(startInfo)
            ?? throw new InvalidOperationException("Failed to start bun process");

        var stderrTask = _process.StandardError.ReadToEndAsync();

        await foreach (var sourceFile in AstDeserializer.DeserializeStreamAsync(_process.StandardOutput.BaseStream))
        {
            yield return sourceFile;
        }

        await _process.WaitForExitAsync();

        if (_process.ExitCode != 0)
        {
            var stderr = await stderrTask;
            throw new InvalidOperationException(
                $"ts-bridge exited with code {_process.ExitCode}: {stderr}");
        }
    }

    public void Dispose()
    {
        if (_process is { HasExited: false })
        {
            _process.Kill();
        }
        _process?.Dispose();
    }
}
