namespace TsToCs.Plugins.OpenTui;

using TsToCs.Core.IR;
using TsToCs.Core.Parsing.TsAstModel;
using TsToCs.Core.Pipeline;
using TsToCs.Core.Plugins;

public class OpenTuiPlugin : IConversionPlugin
{
    public string Name => "OpenTui";

    public void Configure(ConversionConfig config)
    {
        config.NamespaceMap["packages/core/src"] = "OpenTui.Core";
        config.NamespaceMap["packages/core/src/lib"] = "OpenTui.Core.Lib";
        config.NamespaceMap["packages/core/src/renderables"] = "OpenTui.Core.Renderables";
        config.NamespaceMap["packages/core/src/animation"] = "OpenTui.Core.Animation";
        config.NamespaceMap["packages/solid/src"] = "OpenTui.Solid";
        config.NamespaceMap["packages/react/src"] = "OpenTui.React";

        config.TypeOverrides["yoga-layout"] = "Yoga.NET";
    }

    public IrTypeRef? MapType(SerializedType tsType)
    {
        if (tsType.Name is "YogaNode" or "Node")
            return new IrTypeRef { Name = "YogaNode", Namespace = "Yoga", Kind = IrTypeRefKind.Named };

        return null;
    }

    public IrTypeDeclaration? TransformDeclaration(TsDeclaration tsDecl, string filePath)
    {
        return null;
    }
}
