namespace TsToCs.Core.Plugins;

using TsToCs.Core.IR;
using TsToCs.Core.Parsing.TsAstModel;
using TsToCs.Core.Pipeline;

public interface IConversionPlugin
{
    string Name { get; }
    void Configure(ConversionConfig config);
    IrTypeRef? MapType(SerializedType tsType);
    IrTypeDeclaration? TransformDeclaration(TsDeclaration tsDecl, string filePath);
}
