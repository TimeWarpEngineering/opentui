namespace TsToCs.Core.IR;

public abstract record IrMember : IrNode
{
    public string Name { get; init; } = "";
    public IrAccessibility Accessibility { get; init; } = IrAccessibility.Public;
    public bool IsStatic { get; init; }
}

public record IrMethod : IrMember
{
    public List<IrParameter> Parameters { get; init; } = new();
    public IrTypeRef ReturnType { get; init; } = IrTypeRef.Void;
    public List<IrGenericParam> GenericParameters { get; init; } = new();
    public bool IsAsync { get; init; }
    public bool IsAbstract { get; init; }
    public bool IsVirtual { get; init; }
    public bool IsOverride { get; init; }
    public IrBlock? Body { get; init; }
}

public record IrConstructor : IrMember
{
    public List<IrParameter> Parameters { get; init; } = new();
    public IrBlock? Body { get; init; }
    public List<IrExpression>? BaseArguments { get; init; }
}

public record IrProperty : IrMember
{
    public IrTypeRef Type { get; init; } = IrTypeRef.Object;
    public bool HasGetter { get; init; } = true;
    public bool HasSetter { get; init; } = true;
    public IrExpression? Initializer { get; init; }
    public bool IsRequired { get; init; }
}

public record IrField : IrMember
{
    public IrTypeRef Type { get; init; } = IrTypeRef.Object;
    public bool IsReadonly { get; init; }
    public IrExpression? Initializer { get; init; }
}

public record IrEvent : IrMember
{
    public IrTypeRef DelegateType { get; init; } = IrTypeRef.Object;
    public string EventName { get; init; } = "";
}

public record IrParameter
{
    public string Name { get; init; } = "";
    public IrTypeRef Type { get; init; } = IrTypeRef.Object;
    public bool IsOptional { get; init; }
    public bool IsParams { get; init; }
    public IrExpression? DefaultValue { get; init; }
}

public record IrGenericParam
{
    public string Name { get; init; } = "";
    public List<IrTypeRef> Constraints { get; init; } = new();
    public IrTypeRef? DefaultType { get; init; }
}
