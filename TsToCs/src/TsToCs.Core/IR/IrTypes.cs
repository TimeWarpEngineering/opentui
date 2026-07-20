namespace TsToCs.Core.IR;

public abstract record IrTypeDeclaration : IrNode
{
    public string Name { get; init; } = "";
    public IrAccessibility Accessibility { get; init; } = IrAccessibility.Public;
    public List<IrGenericParam> GenericParameters { get; init; } = new();
}

public record IrClass : IrTypeDeclaration
{
    public bool IsAbstract { get; init; }
    public bool IsSealed { get; init; }
    public bool IsStatic { get; init; }
    public bool IsPartial { get; init; }
    public IrTypeRef? BaseClass { get; init; }
    public List<IrTypeRef> Interfaces { get; init; } = new();
    public List<IrMember> Members { get; init; } = new();
}

public record IrInterface : IrTypeDeclaration
{
    public List<IrTypeRef> BaseInterfaces { get; init; } = new();
    public List<IrMember> Members { get; init; } = new();
}

public record IrEnum : IrTypeDeclaration
{
    public bool IsStringBacked { get; init; }
    public List<IrEnumMember> Members { get; init; } = new();
}

public record IrEnumMember
{
    public string Name { get; init; } = "";
    public object? Value { get; init; }
}

public record IrStruct : IrTypeDeclaration
{
    public bool IsReadonly { get; init; }
    public List<IrMember> Members { get; init; } = new();
}

public record IrDelegate : IrTypeDeclaration
{
    public List<IrParameter> Parameters { get; init; } = new();
    public IrTypeRef ReturnType { get; init; } = IrTypeRef.Void;
}

public enum IrAccessibility
{
    Public,
    Internal,
    Protected,
    Private,
    ProtectedInternal,
    PrivateProtected,
}
