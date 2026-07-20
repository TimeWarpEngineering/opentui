namespace TsToCs.Core.IR;

public abstract record IrExpression;

public record IrLiteral : IrExpression
{
    public object? Value { get; init; }
    public IrTypeRef Type { get; init; } = IrTypeRef.Object;

    public static IrLiteral String(string value) => new() { Value = value, Type = IrTypeRef.String };
    public static IrLiteral Number(double value) => new() { Value = value, Type = IrTypeRef.Double };
    public static IrLiteral Bool(bool value) => new() { Value = value, Type = IrTypeRef.Bool };
    public static IrLiteral Null() => new() { Value = null, Type = IrTypeRef.Object };
}

public record IrIdentifier : IrExpression
{
    public string Name { get; init; } = "";
}

public record IrMemberAccess : IrExpression
{
    public IrExpression Target { get; init; } = null!;
    public string MemberName { get; init; } = "";
}

public record IrMethodCall : IrExpression
{
    public IrExpression Target { get; init; } = null!;
    public string MethodName { get; init; } = "";
    public List<IrExpression> Arguments { get; init; } = new();
    public List<IrTypeRef> TypeArguments { get; init; } = new();
}

public record IrNewObject : IrExpression
{
    public IrTypeRef Type { get; init; } = IrTypeRef.Object;
    public List<IrExpression> Arguments { get; init; } = new();
    public List<IrPropertyInit>? Initializers { get; init; }
}

public record IrPropertyInit
{
    public string Name { get; init; } = "";
    public IrExpression Value { get; init; } = null!;
}

public record IrBinaryExpression : IrExpression
{
    public IrExpression Left { get; init; } = null!;
    public string Operator { get; init; } = "";
    public IrExpression Right { get; init; } = null!;
}

public record IrUnaryExpression : IrExpression
{
    public string Operator { get; init; } = "";
    public IrExpression Operand { get; init; } = null!;
    public bool IsPrefix { get; init; } = true;
}

public record IrCastExpression : IrExpression
{
    public IrTypeRef TargetType { get; init; } = IrTypeRef.Object;
    public IrExpression Expression { get; init; } = null!;
}

public record IrIsExpression : IrExpression
{
    public IrExpression Expression { get; init; } = null!;
    public IrTypeRef TargetType { get; init; } = IrTypeRef.Object;
    public string? PatternVariable { get; init; }
}

public record IrConditionalExpression : IrExpression
{
    public IrExpression Condition { get; init; } = null!;
    public IrExpression WhenTrue { get; init; } = null!;
    public IrExpression WhenFalse { get; init; } = null!;
}

public record IrLambdaExpression : IrExpression
{
    public List<IrParameter> Parameters { get; init; } = new();
    public IrTypeRef? ReturnType { get; init; }
    public IrNode Body { get; init; } = null!;
    public bool IsAsync { get; init; }
}

public record IrAwaitExpression : IrExpression
{
    public IrExpression Expression { get; init; } = null!;
}

public record IrThisExpression : IrExpression;

public record IrBaseExpression : IrExpression;

public record IrIndexAccess : IrExpression
{
    public IrExpression Target { get; init; } = null!;
    public IrExpression Index { get; init; } = null!;
}

public record IrRawExpression : IrExpression
{
    public string Code { get; init; } = "";
    public string? ConversionNote { get; init; }
}
