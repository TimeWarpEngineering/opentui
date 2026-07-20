namespace TsToCs.Core.Analysis;

using TsToCs.Core.Parsing.TsAstModel;

public class InheritanceAnalyzer
{
    public void Analyze(IReadOnlyList<TsSourceFile> sourceFiles, AnalysisResult result)
    {
        foreach (var file in sourceFiles)
        {
            foreach (var decl in file.Declarations)
            {
                if (decl is TsClassDeclaration classDecl)
                {
                    var node = new ClassHierarchyNode
                    {
                        Name = classDecl.Name,
                        BaseClass = classDecl.Extends?.Name,
                        Interfaces = classDecl.Implements?.Select(i => i.Name).ToList() ?? new(),
                        IsAbstract = classDecl.IsAbstract,
                    };
                    result.ClassHierarchy[classDecl.Name] = node;
                }
            }
        }

        foreach (var (name, node) in result.ClassHierarchy)
        {
            if (node.BaseClass is not null && result.ClassHierarchy.TryGetValue(node.BaseClass, out var parent))
            {
                parent.DerivedClasses.Add(name);
            }
        }
    }
}
