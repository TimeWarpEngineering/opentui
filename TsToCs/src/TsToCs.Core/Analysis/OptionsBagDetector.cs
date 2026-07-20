namespace TsToCs.Core.Analysis;

using TsToCs.Core.Parsing.TsAstModel;

public class OptionsBagDetector
{
    public void Analyze(IReadOnlyList<TsSourceFile> sourceFiles, AnalysisResult result)
    {
        var interfaceNames = new HashSet<string>();
        var usedAsParams = new HashSet<string>();

        foreach (var file in sourceFiles)
            foreach (var decl in file.Declarations)
                if (decl is TsInterfaceDeclaration iface)
                    interfaceNames.Add(iface.Name);

        foreach (var file in sourceFiles)
        {
            foreach (var decl in file.Declarations)
            {
                if (decl is TsClassDeclaration classDecl)
                {
                    foreach (var member in classDecl.Members)
                    {
                        var parameters = member switch
                        {
                            TsConstructorMember ctor => ctor.Parameters,
                            TsMethodMember method => method.Parameters,
                            _ => null,
                        };
                        if (parameters is null) continue;

                        foreach (var param in parameters)
                            if (param.Type?.Name is not null && interfaceNames.Contains(param.Type.Name))
                                usedAsParams.Add(param.Type.Name);
                    }
                }
            }
        }

        foreach (var file in sourceFiles)
        {
            foreach (var decl in file.Declarations)
            {
                if (decl is TsInterfaceDeclaration iface && usedAsParams.Contains(iface.Name))
                {
                    if (iface.Properties.Count == 0) continue;
                    int optionalCount = iface.Properties.Count(p => p.Optional);
                    if (optionalCount >= iface.Properties.Count / 2)
                        result.OptionsBagInterfaces.Add(iface.Name);
                }
            }
        }
    }
}
