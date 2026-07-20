namespace TsToCs.Core.IR;

public abstract record IrNode
{
    public string? SourceFile { get; init; }
    public string? OriginalName { get; init; }
}

public record IrModule : IrNode
{
    public string Namespace { get; init; } = "";
    public string FileName { get; init; } = "";
    public List<IrTypeDeclaration> Types { get; init; } = new();
    public List<IrUsingDirective> Usings { get; init; } = new();
}

public record IrUsingDirective
{
    public string Namespace { get; init; } = "";
    public string? Alias { get; init; }
    public bool IsStatic { get; init; }
}
