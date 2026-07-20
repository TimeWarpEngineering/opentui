namespace TsToCs.Core.Analysis;

using TsToCs.Core.Parsing.TsAstModel;

public class EventEmitterDetector
{
    private static readonly HashSet<string> EventEmitterNames = new()
    {
        "EventEmitter", "TypedEventEmitter", "EventTarget",
    };

    public void Analyze(IReadOnlyList<TsSourceFile> sourceFiles, AnalysisResult result)
    {
        foreach (var file in sourceFiles)
        {
            foreach (var decl in file.Declarations)
            {
                if (decl is TsClassDeclaration classDecl)
                {
                    if (IsEventEmitterClass(classDecl, result))
                    {
                        result.EventEmitterClasses.Add(classDecl.Name);
                        ExtractEventMap(classDecl, result);
                    }
                }
            }
        }
    }

    private bool IsEventEmitterClass(TsClassDeclaration classDecl, AnalysisResult result)
    {
        if (classDecl.Extends is null) return false;

        if (EventEmitterNames.Contains(classDecl.Extends.Name))
            return true;

        return result.EventEmitterClasses.Contains(classDecl.Extends.Name);
    }

    private void ExtractEventMap(TsClassDeclaration classDecl, AnalysisResult result)
    {
        if (classDecl.Extends?.TypeArguments is not { Count: > 0 } typeArgs)
            return;

        var eventMapType = typeArgs[0];
        if (eventMapType.Properties is null) return;

        var events = new List<EventInfo>();
        foreach (var prop in eventMapType.Properties)
        {
            var payloadTypes = new List<SerializedType>();
            if (prop.Type?.Kind == "tuple" && prop.Type.Types is not null)
                payloadTypes.AddRange(prop.Type.Types);
            else if (prop.Type is not null)
                payloadTypes.Add(prop.Type);

            events.Add(new EventInfo
            {
                EventName = prop.Name,
                PayloadTypes = payloadTypes,
            });
        }

        result.EventMaps[classDecl.Name] = events;
    }
}
