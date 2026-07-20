namespace TsToCs.Core.IR;

public abstract record IrStatement;

public record IrBlock
{
    public List<IrStatement> Statements { get; init; } = new();
}

public record IrExpressionStatement : IrStatement
{
    public IrExpression Expression { get; init; } = null!;
}

public record IrReturnStatement : IrStatement
{
    public IrExpression? Value { get; init; }
}

public record IrVariableDeclaration : IrStatement
{
    public string Name { get; init; } = "";
    public IrTypeRef? Type { get; init; }
    public IrExpression? Initializer { get; init; }
    public bool IsVar { get; init; } = true;
}

public record IrAssignment : IrStatement
{
    public IrExpression Target { get; init; } = null!;
    public IrExpression Value { get; init; } = null!;
    public string Operator { get; init; } = "=";
}

public record IrIfStatement : IrStatement
{
    public IrExpression Condition { get; init; } = null!;
    public IrBlock ThenBlock { get; init; } = new();
    public IrBlock? ElseBlock { get; init; }
}

public record IrForStatement : IrStatement
{
    public IrStatement? Initializer { get; init; }
    public IrExpression? Condition { get; init; }
    public IrExpression? Incrementor { get; init; }
    public IrBlock Body { get; init; } = new();
}

public record IrForEachStatement : IrStatement
{
    public string VariableName { get; init; } = "";
    public IrTypeRef? VariableType { get; init; }
    public IrExpression Collection { get; init; } = null!;
    public IrBlock Body { get; init; } = new();
}

public record IrWhileStatement : IrStatement
{
    public IrExpression Condition { get; init; } = null!;
    public IrBlock Body { get; init; } = new();
}

public record IrSwitchStatement : IrStatement
{
    public IrExpression Expression { get; init; } = null!;
    public List<IrSwitchCase> Cases { get; init; } = new();
    public IrBlock? DefaultBlock { get; init; }
}

public record IrSwitchCase
{
    public IrExpression Value { get; init; } = null!;
    public IrBlock Body { get; init; } = new();
}

public record IrTryCatchStatement : IrStatement
{
    public IrBlock TryBlock { get; init; } = new();
    public string? CatchVariable { get; init; }
    public IrTypeRef? CatchType { get; init; }
    public IrBlock? CatchBlock { get; init; }
    public IrBlock? FinallyBlock { get; init; }
}

public record IrThrowStatement : IrStatement
{
    public IrExpression? Expression { get; init; }
}

public record IrBreakStatement : IrStatement;

public record IrContinueStatement : IrStatement;

public record IrUsingStatement : IrStatement
{
    public string VariableName { get; init; } = "";
    public IrExpression Value { get; init; } = null!;
    public IrBlock Body { get; init; } = new();
}

public record IrRawStatement : IrStatement
{
    public string Code { get; init; } = "";
    public string? ConversionNote { get; init; }
}
