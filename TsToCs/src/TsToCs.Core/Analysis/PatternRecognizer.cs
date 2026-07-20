namespace TsToCs.Core.Analysis;

using TsToCs.Core.Parsing.TsAstModel;

public class PatternRecognizer
{
    private readonly InheritanceAnalyzer _inheritanceAnalyzer = new();
    private readonly UnionTypeClassifier _unionTypeClassifier = new();
    private readonly EventEmitterDetector _eventEmitterDetector = new();
    private readonly OptionsBagDetector _optionsBagDetector = new();

    public AnalysisResult Analyze(IReadOnlyList<TsSourceFile> sourceFiles)
    {
        var result = new AnalysisResult();

        _inheritanceAnalyzer.Analyze(sourceFiles, result);
        _eventEmitterDetector.Analyze(sourceFiles, result);
        _unionTypeClassifier.AnalyzeAll(sourceFiles, result);
        _optionsBagDetector.Analyze(sourceFiles, result);

        return result;
    }
}
