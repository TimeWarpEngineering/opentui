namespace TsToCs.Core.Generation;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;
using TsToCs.Core.IR;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

public class CSharpEmitter
{
    public Dictionary<string, string> Emit(IReadOnlyList<IrModule> modules)
    {
        var files = new Dictionary<string, string>();
        foreach (var module in modules)
        {
            var code = EmitModule(module);
            files[module.FileName] = code;
        }
        return files;
    }

    private string EmitModule(IrModule module)
    {
        var members = new List<MemberDeclarationSyntax>();

        foreach (var type in module.Types)
        {
            var member = EmitTypeDeclaration(type);
            if (member is not null)
                members.Add(member);
        }

        var ns = FileScopedNamespaceDeclaration(ParseName(module.Namespace))
            .WithMembers(List(members));

        var usings = new List<UsingDirectiveSyntax>
        {
            UsingDirective(ParseName("System")),
            UsingDirective(ParseName("System.Collections.Generic")),
        };

        foreach (var u in module.Usings)
        {
            var usingDir = UsingDirective(ParseName(u.Namespace));
            if (u.IsStatic)
                usingDir = usingDir.WithStaticKeyword(Token(SyntaxKind.StaticKeyword));
            usings.Add(usingDir);
        }

        var compilationUnit = CompilationUnit()
            .WithUsings(List(usings))
            .WithMembers(SingletonList<MemberDeclarationSyntax>(ns))
            .NormalizeWhitespace();

        return compilationUnit.ToFullString();
    }

    private MemberDeclarationSyntax? EmitTypeDeclaration(IrTypeDeclaration type)
    {
        return type switch
        {
            IrClass c => EmitClass(c),
            IrInterface i => EmitInterface(i),
            IrEnum e => EmitEnum(e),
            IrStruct s => EmitStruct(s),
            IrDelegate d => EmitDelegate(d),
            _ => null,
        };
    }

    private ClassDeclarationSyntax EmitClass(IrClass c)
    {
        var classDecl = ClassDeclaration(c.Name)
            .WithModifiers(BuildModifiers(c.Accessibility, c.IsAbstract, c.IsStatic, c.IsSealed));

        // Type parameters
        if (c.GenericParameters.Count > 0)
            classDecl = classDecl.WithTypeParameterList(EmitTypeParameterList(c.GenericParameters));

        // Base types
        var baseTypes = new List<BaseTypeSyntax>();
        if (c.BaseClass is not null)
            baseTypes.Add(SimpleBaseType(EmitTypeRef(c.BaseClass)));
        foreach (var iface in c.Interfaces)
            baseTypes.Add(SimpleBaseType(EmitTypeRef(iface)));
        if (baseTypes.Count > 0)
            classDecl = classDecl.WithBaseList(BaseList(SeparatedList(baseTypes)));

        // Constraints
        var constraints = EmitTypeParameterConstraints(c.GenericParameters);
        if (constraints.Count > 0)
            classDecl = classDecl.WithConstraintClauses(List(constraints));

        // Members
        var members = new List<MemberDeclarationSyntax>();
        foreach (var member in c.Members)
        {
            var m = EmitMember(member);
            if (m is not null) members.Add(m);
        }
        classDecl = classDecl.WithMembers(List(members));

        return classDecl;
    }

    private InterfaceDeclarationSyntax EmitInterface(IrInterface i)
    {
        var ifaceDecl = InterfaceDeclaration(i.Name)
            .WithModifiers(BuildModifiers(i.Accessibility));

        if (i.GenericParameters.Count > 0)
            ifaceDecl = ifaceDecl.WithTypeParameterList(EmitTypeParameterList(i.GenericParameters));

        var baseTypes = i.BaseInterfaces.Select(b => (BaseTypeSyntax)SimpleBaseType(EmitTypeRef(b))).ToList();
        if (baseTypes.Count > 0)
            ifaceDecl = ifaceDecl.WithBaseList(BaseList(SeparatedList(baseTypes)));

        var constraints = EmitTypeParameterConstraints(i.GenericParameters);
        if (constraints.Count > 0)
            ifaceDecl = ifaceDecl.WithConstraintClauses(List(constraints));

        var members = new List<MemberDeclarationSyntax>();
        foreach (var member in i.Members)
        {
            var m = EmitMember(member);
            if (m is not null) members.Add(m);
        }
        ifaceDecl = ifaceDecl.WithMembers(List(members));

        return ifaceDecl;
    }

    private MemberDeclarationSyntax EmitEnum(IrEnum e)
    {
        if (e.IsStringBacked)
        {
            // String enums become static classes with const string fields
            var members = e.Members.Select(m =>
                (MemberDeclarationSyntax)FieldDeclaration(
                    VariableDeclaration(PredefinedType(Token(SyntaxKind.StringKeyword)))
                        .WithVariables(SingletonSeparatedList(
                            VariableDeclarator(m.Name)
                                .WithInitializer(EqualsValueClause(
                                    LiteralExpression(SyntaxKind.StringLiteralExpression,
                                        Literal(m.Value?.ToString() ?? m.Name)))))))
                    .WithModifiers(TokenList(
                        Token(SyntaxKind.PublicKeyword),
                        Token(SyntaxKind.ConstKeyword))))
                .ToList();

            return ClassDeclaration(e.Name)
                .WithModifiers(TokenList(
                    Token(SyntaxKind.PublicKeyword),
                    Token(SyntaxKind.StaticKeyword)))
                .WithMembers(List(members));
        }

        var enumMembers = e.Members.Select(m =>
        {
            var memberDecl = EnumMemberDeclaration(m.Name);
            if (m.Value is long lv)
                memberDecl = memberDecl.WithEqualsValue(EqualsValueClause(
                    LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal((int)lv))));
            else if (m.Value is int iv)
                memberDecl = memberDecl.WithEqualsValue(EqualsValueClause(
                    LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(iv))));
            return memberDecl;
        }).ToList();

        return EnumDeclaration(e.Name)
            .WithModifiers(BuildModifiers(e.Accessibility))
            .WithMembers(SeparatedList(enumMembers));
    }

    private StructDeclarationSyntax EmitStruct(IrStruct s)
    {
        var structDecl = StructDeclaration(s.Name)
            .WithModifiers(BuildModifiers(s.Accessibility));

        if (s.IsReadonly)
            structDecl = structDecl.WithModifiers(
                structDecl.Modifiers.Add(Token(SyntaxKind.ReadOnlyKeyword)));

        var members = s.Members.Select(EmitMember).Where(m => m is not null).ToList();
        structDecl = structDecl.WithMembers(List(members!));

        return structDecl;
    }

    private DelegateDeclarationSyntax EmitDelegate(IrDelegate d)
    {
        var delegateDecl = DelegateDeclaration(EmitTypeRef(d.ReturnType), d.Name)
            .WithModifiers(BuildModifiers(d.Accessibility))
            .WithParameterList(EmitParameterList(d.Parameters));

        return delegateDecl;
    }

    private MemberDeclarationSyntax? EmitMember(IrMember member)
    {
        return member switch
        {
            IrMethod method => EmitMethod(method),
            IrConstructor ctor => EmitConstructor(ctor),
            IrProperty prop => EmitProperty(prop),
            IrField field => EmitField(field),
            IrEvent evt => EmitEvent(evt),
            _ => null,
        };
    }

    private MethodDeclarationSyntax EmitMethod(IrMethod method)
    {
        var returnType = EmitTypeRef(method.ReturnType);
        var methodDecl = MethodDeclaration(returnType, method.Name)
            .WithModifiers(BuildMethodModifiers(method))
            .WithParameterList(EmitParameterList(method.Parameters));

        if (method.GenericParameters.Count > 0)
            methodDecl = methodDecl.WithTypeParameterList(EmitTypeParameterList(method.GenericParameters));

        var constraints = EmitTypeParameterConstraints(method.GenericParameters);
        if (constraints.Count > 0)
            methodDecl = methodDecl.WithConstraintClauses(List(constraints));

        if (method.IsAbstract || method.Body is null)
        {
            methodDecl = methodDecl.WithSemicolonToken(Token(SyntaxKind.SemicolonToken));
        }
        else
        {
            var body = EmitBlock(method.Body);
            methodDecl = methodDecl.WithBody(body);
        }

        return methodDecl;
    }

    private ConstructorDeclarationSyntax EmitConstructor(IrConstructor ctor)
    {
        // Get the class name from context — use a placeholder
        var ctorDecl = ConstructorDeclaration("_placeholder_")
            .WithModifiers(BuildModifiers(ctor.Accessibility))
            .WithParameterList(EmitParameterList(ctor.Parameters));

        if (ctor.BaseArguments is not null)
        {
            var args = ctor.BaseArguments.Select(EmitExpression).ToArray();
            ctorDecl = ctorDecl.WithInitializer(
                ConstructorInitializer(SyntaxKind.BaseConstructorInitializer,
                    ArgumentList(SeparatedList(args.Select(Argument)))));
        }

        if (ctor.Body is not null)
            ctorDecl = ctorDecl.WithBody(EmitBlock(ctor.Body));
        else
            ctorDecl = ctorDecl.WithBody(Block());

        return ctorDecl;
    }

    private PropertyDeclarationSyntax EmitProperty(IrProperty prop)
    {
        var propDecl = PropertyDeclaration(EmitTypeRef(prop.Type), prop.Name)
            .WithModifiers(BuildModifiers(prop.Accessibility, isStatic: prop.IsStatic));

        var accessors = new List<AccessorDeclarationSyntax>();
        if (prop.HasGetter)
            accessors.Add(AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                .WithSemicolonToken(Token(SyntaxKind.SemicolonToken)));
        if (prop.HasSetter)
            accessors.Add(AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                .WithSemicolonToken(Token(SyntaxKind.SemicolonToken)));

        propDecl = propDecl.WithAccessorList(AccessorList(List(accessors)));

        if (prop.Initializer is not null)
            propDecl = propDecl.WithInitializer(EqualsValueClause(EmitExpression(prop.Initializer)))
                .WithSemicolonToken(Token(SyntaxKind.SemicolonToken));

        return propDecl;
    }

    private FieldDeclarationSyntax EmitField(IrField field)
    {
        var variableDecl = VariableDeclarator(field.Name);
        if (field.Initializer is not null)
            variableDecl = variableDecl.WithInitializer(EqualsValueClause(EmitExpression(field.Initializer)));

        var modifiers = new List<SyntaxToken>();
        modifiers.AddRange(AccessibilityTokens(field.Accessibility));
        if (field.IsStatic) modifiers.Add(Token(SyntaxKind.StaticKeyword));
        if (field.IsReadonly) modifiers.Add(Token(SyntaxKind.ReadOnlyKeyword));

        return FieldDeclaration(
            VariableDeclaration(EmitTypeRef(field.Type))
                .WithVariables(SingletonSeparatedList(variableDecl)))
            .WithModifiers(TokenList(modifiers));
    }

    private EventFieldDeclarationSyntax EmitEvent(IrEvent evt)
    {
        return EventFieldDeclaration(
            VariableDeclaration(EmitTypeRef(evt.DelegateType))
                .WithVariables(SingletonSeparatedList(VariableDeclarator(evt.Name))))
            .WithModifiers(BuildModifiers(evt.Accessibility));
    }

    // --- Type emission ---

    private TypeSyntax EmitTypeRef(IrTypeRef typeRef)
    {
        if (typeRef.Kind == IrTypeRefKind.Void)
            return PredefinedType(Token(SyntaxKind.VoidKeyword));

        if (typeRef.Kind == IrTypeRefKind.Primitive)
        {
            var predefined = typeRef.Name switch
            {
                "string" => PredefinedType(Token(SyntaxKind.StringKeyword)),
                "int" => PredefinedType(Token(SyntaxKind.IntKeyword)),
                "long" => PredefinedType(Token(SyntaxKind.LongKeyword)),
                "double" => PredefinedType(Token(SyntaxKind.DoubleKeyword)),
                "bool" => PredefinedType(Token(SyntaxKind.BoolKeyword)),
                "object" => PredefinedType(Token(SyntaxKind.ObjectKeyword)),
                _ => (TypeSyntax)ParseTypeName(typeRef.Name),
            };

            return typeRef.IsNullable
                ? NullableType(predefined)
                : predefined;
        }

        if (typeRef.Kind == IrTypeRefKind.Dynamic)
            return IdentifierName("dynamic");

        if (typeRef.Kind == IrTypeRefKind.Array && typeRef.ArrayElementType is not null)
        {
            var elementType = EmitTypeRef(typeRef.ArrayElementType);
            TypeSyntax result = ArrayType(elementType)
                .WithRankSpecifiers(SingletonList(ArrayRankSpecifier()));
            return typeRef.IsNullable ? NullableType(result) : result;
        }

        TypeSyntax baseType;
        if (typeRef.TypeArguments.Count > 0)
        {
            baseType = GenericName(typeRef.Name)
                .WithTypeArgumentList(TypeArgumentList(
                    SeparatedList(typeRef.TypeArguments.Select(EmitTypeRef))));
        }
        else
        {
            baseType = IdentifierName(typeRef.Name);
        }

        return typeRef.IsNullable ? NullableType(baseType) : baseType;
    }

    // --- Expression emission ---

    private ExpressionSyntax EmitExpression(IrExpression expr)
    {
        return expr switch
        {
            IrLiteral lit => EmitLiteral(lit),
            IrIdentifier id => IdentifierName(id.Name),
            IrMemberAccess ma => MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
                EmitExpression(ma.Target), IdentifierName(ma.MemberName)),
            IrMethodCall mc => InvocationExpression(
                MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
                    EmitExpression(mc.Target), IdentifierName(mc.MethodName)),
                ArgumentList(SeparatedList(mc.Arguments.Select(a => Argument(EmitExpression(a)))))),
            IrNewObject no => ObjectCreationExpression(EmitTypeRef(no.Type))
                .WithArgumentList(ArgumentList(SeparatedList(no.Arguments.Select(a => Argument(EmitExpression(a)))))),
            IrBinaryExpression bin => BinaryExpression(MapBinaryOperator(bin.Operator),
                EmitExpression(bin.Left), EmitExpression(bin.Right)),
            IrThisExpression => ThisExpression(),
            IrBaseExpression => BaseExpression(),
            IrAwaitExpression aw => AwaitExpression(EmitExpression(aw.Expression)),
            IrRawExpression raw => ParseExpression(raw.Code.Length > 200
                ? "default /* " + (raw.ConversionNote ?? "requires conversion") + " */"
                : raw.Code),
            _ => LiteralExpression(SyntaxKind.DefaultLiteralExpression),
        };
    }

    private ExpressionSyntax EmitLiteral(IrLiteral lit)
    {
        return lit.Value switch
        {
            string s => LiteralExpression(SyntaxKind.StringLiteralExpression, Literal(s)),
            int i => LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(i)),
            long l => LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(l)),
            double d => LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(d)),
            bool b => b ? LiteralExpression(SyntaxKind.TrueLiteralExpression) : LiteralExpression(SyntaxKind.FalseLiteralExpression),
            null => LiteralExpression(SyntaxKind.NullLiteralExpression),
            _ => LiteralExpression(SyntaxKind.DefaultLiteralExpression),
        };
    }

    // --- Block/Statement emission ---

    private BlockSyntax EmitBlock(IrBlock block)
    {
        var statements = block.Statements.Select(EmitStatement).Where(s => s is not null).ToList();
        return Block(statements!);
    }

    private StatementSyntax? EmitStatement(IrStatement stmt)
    {
        return stmt switch
        {
            IrExpressionStatement es => ExpressionStatement(EmitExpression(es.Expression)),
            IrReturnStatement ret => ret.Value is not null
                ? ReturnStatement(EmitExpression(ret.Value))
                : ReturnStatement(),
            IrRawStatement raw => ParseStatement(raw.Code.Length > 500
                ? "throw new NotImplementedException(\"" + (raw.ConversionNote ?? "Requires manual conversion") + "\");"
                : raw.Code + (raw.Code.EndsWith(";") ? "" : ";")),
            IrVariableDeclaration vd => LocalDeclarationStatement(
                VariableDeclaration(vd.IsVar ? IdentifierName("var") : EmitTypeRef(vd.Type ?? IrTypeRef.Dynamic))
                    .WithVariables(SingletonSeparatedList(
                        VariableDeclarator(vd.Name)
                            .WithInitializer(vd.Initializer is not null
                                ? EqualsValueClause(EmitExpression(vd.Initializer))
                                : null)))),
            IrIfStatement ifs => IfStatement(EmitExpression(ifs.Condition), EmitBlock(ifs.ThenBlock),
                ifs.ElseBlock is not null ? ElseClause(EmitBlock(ifs.ElseBlock)) : null),
            IrThrowStatement ts => ts.Expression is not null
                ? ThrowStatement(EmitExpression(ts.Expression))
                : ThrowStatement(),
            IrBreakStatement => BreakStatement(),
            IrContinueStatement => ContinueStatement(),
            _ => null,
        };
    }

    // --- Helpers ---

    private static SyntaxKind MapBinaryOperator(string op) => op switch
    {
        "+" => SyntaxKind.AddExpression,
        "-" => SyntaxKind.SubtractExpression,
        "*" => SyntaxKind.MultiplyExpression,
        "/" => SyntaxKind.DivideExpression,
        "%" => SyntaxKind.ModuloExpression,
        "==" or "===" => SyntaxKind.EqualsExpression,
        "!=" or "!==" => SyntaxKind.NotEqualsExpression,
        "<" => SyntaxKind.LessThanExpression,
        ">" => SyntaxKind.GreaterThanExpression,
        "<=" => SyntaxKind.LessThanOrEqualExpression,
        ">=" => SyntaxKind.GreaterThanOrEqualExpression,
        "&&" => SyntaxKind.LogicalAndExpression,
        "||" => SyntaxKind.LogicalOrExpression,
        "&" => SyntaxKind.BitwiseAndExpression,
        "|" => SyntaxKind.BitwiseOrExpression,
        "^" => SyntaxKind.ExclusiveOrExpression,
        "??" => SyntaxKind.CoalesceExpression,
        _ => SyntaxKind.AddExpression,
    };

    private TypeParameterListSyntax EmitTypeParameterList(List<IrGenericParam> typeParams)
    {
        return TypeParameterList(SeparatedList(
            typeParams.Select(tp => TypeParameter(tp.Name))));
    }

    private List<TypeParameterConstraintClauseSyntax> EmitTypeParameterConstraints(List<IrGenericParam> typeParams)
    {
        var clauses = new List<TypeParameterConstraintClauseSyntax>();
        foreach (var tp in typeParams)
        {
            if (tp.Constraints.Count > 0)
            {
                var constraints = tp.Constraints
                    .Select(c => (TypeParameterConstraintSyntax)TypeConstraint(EmitTypeRef(c)))
                    .ToList();

                clauses.Add(TypeParameterConstraintClause(tp.Name)
                    .WithConstraints(SeparatedList(constraints)));
            }
        }
        return clauses;
    }

    private ParameterListSyntax EmitParameterList(List<IrParameter> parameters)
    {
        return ParameterList(SeparatedList(
            parameters.Select(p =>
            {
                var param = Parameter(Identifier(p.Name))
                    .WithType(EmitTypeRef(p.Type));
                if (p.IsParams)
                    param = param.WithModifiers(TokenList(Token(SyntaxKind.ParamsKeyword)));
                if (p.DefaultValue is not null)
                    param = param.WithDefault(EqualsValueClause(EmitExpression(p.DefaultValue)));
                else if (p.IsOptional && !p.IsParams)
                    param = param.WithDefault(EqualsValueClause(
                        LiteralExpression(SyntaxKind.DefaultLiteralExpression)));
                return param;
            })));
    }

    private static SyntaxTokenList BuildModifiers(IrAccessibility accessibility,
        bool isAbstract = false, bool isStatic = false, bool isSealed = false)
    {
        var tokens = new List<SyntaxToken>();
        tokens.AddRange(AccessibilityTokens(accessibility));
        if (isAbstract) tokens.Add(Token(SyntaxKind.AbstractKeyword));
        if (isStatic) tokens.Add(Token(SyntaxKind.StaticKeyword));
        if (isSealed) tokens.Add(Token(SyntaxKind.SealedKeyword));
        return TokenList(tokens);
    }

    private static SyntaxTokenList BuildMethodModifiers(IrMethod method)
    {
        var tokens = new List<SyntaxToken>();
        tokens.AddRange(AccessibilityTokens(method.Accessibility));
        if (method.IsStatic) tokens.Add(Token(SyntaxKind.StaticKeyword));
        if (method.IsAbstract) tokens.Add(Token(SyntaxKind.AbstractKeyword));
        if (method.IsVirtual) tokens.Add(Token(SyntaxKind.VirtualKeyword));
        if (method.IsOverride) tokens.Add(Token(SyntaxKind.OverrideKeyword));
        if (method.IsAsync) tokens.Add(Token(SyntaxKind.AsyncKeyword));
        return TokenList(tokens);
    }

    private static IEnumerable<SyntaxToken> AccessibilityTokens(IrAccessibility accessibility)
    {
        return accessibility switch
        {
            IrAccessibility.Public => new[] { Token(SyntaxKind.PublicKeyword) },
            IrAccessibility.Private => new[] { Token(SyntaxKind.PrivateKeyword) },
            IrAccessibility.Protected => new[] { Token(SyntaxKind.ProtectedKeyword) },
            IrAccessibility.Internal => new[] { Token(SyntaxKind.InternalKeyword) },
            IrAccessibility.ProtectedInternal => new[] { Token(SyntaxKind.ProtectedKeyword), Token(SyntaxKind.InternalKeyword) },
            IrAccessibility.PrivateProtected => new[] { Token(SyntaxKind.PrivateKeyword), Token(SyntaxKind.ProtectedKeyword) },
            _ => new[] { Token(SyntaxKind.PublicKeyword) },
        };
    }
}
