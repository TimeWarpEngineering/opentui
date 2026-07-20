namespace TsToCs.Core.Generation;

using TsToCs.Core.Analysis;
using TsToCs.Core.IR;
using TsToCs.Core.Parsing.TsAstModel;

public class IrGenerator
{
    private readonly AnalysisResult _analysis;
    private readonly TypeMapper _typeMapper;
    private readonly Dictionary<string, string> _namespaceMap;

    public IrGenerator(AnalysisResult analysis, Dictionary<string, string> namespaceMap)
    {
        _analysis = analysis;
        _typeMapper = new TypeMapper(analysis);
        _namespaceMap = namespaceMap;
    }

    public List<IrModule> Generate(IReadOnlyList<TsSourceFile> sourceFiles)
    {
        var modules = new List<IrModule>();

        foreach (var file in sourceFiles)
        {
            var module = GenerateModule(file);
            if (module.Types.Count > 0)
                modules.Add(module);
        }

        return modules;
    }

    private IrModule GenerateModule(TsSourceFile file)
    {
        var ns = NameMapper.FilePathToNamespace(file.FilePath, _namespaceMap);
        var fileName = Path.GetFileNameWithoutExtension(file.FilePath);

        var module = new IrModule
        {
            Namespace = ns,
            FileName = NameMapper.ToPascalCase(fileName) + ".cs",
            SourceFile = file.FilePath,
        };

        foreach (var decl in file.Declarations)
        {
            var irType = GenerateDeclaration(decl, file.FilePath);
            if (irType is not null)
                module.Types.Add(irType);
        }

        return module;
    }

    private IrTypeDeclaration? GenerateDeclaration(TsDeclaration decl, string filePath)
    {
        return decl switch
        {
            TsClassDeclaration classDecl => GenerateClass(classDecl, filePath),
            TsInterfaceDeclaration ifaceDecl => GenerateInterface(ifaceDecl, filePath),
            TsTypeAliasDeclaration typeAlias => GenerateTypeAlias(typeAlias, filePath),
            TsEnumDeclaration enumDecl => GenerateEnum(enumDecl, filePath),
            TsFunctionDeclaration funcDecl => GenerateStaticMethodClass(funcDecl, filePath),
            TsVariableDeclaration varDecl => GenerateConstantClass(varDecl, filePath),
            _ => null,
        };
    }

    private IrClass GenerateClass(TsClassDeclaration decl, string filePath)
    {
        var members = new List<IrMember>();

        foreach (var member in decl.Members)
        {
            var irMember = GenerateClassMember(member);
            if (irMember is not null)
                members.Add(irMember);
        }

        var baseClass = decl.Extends is not null
            ? MapHeritageClause(decl.Extends)
            : null;

        // If extends EventEmitter, use our runtime EventEmitter
        if (baseClass is not null && _analysis.EventEmitterClasses.Contains(decl.Name))
        {
            baseClass = new IrTypeRef { Name = "EventEmitter", Kind = IrTypeRefKind.Named };
        }

        var interfaces = decl.Implements?
            .Select(MapHeritageClause)
            .ToList() ?? new();

        return new IrClass
        {
            Name = NameMapper.ToPascalCase(decl.Name),
            OriginalName = decl.Name,
            SourceFile = filePath,
            IsAbstract = decl.IsAbstract,
            Accessibility = decl.Exported ? IrAccessibility.Public : IrAccessibility.Internal,
            GenericParameters = MapTypeParameters(decl.TypeParameters),
            BaseClass = baseClass,
            Interfaces = interfaces,
            Members = members,
        };
    }

    private IrMember? GenerateClassMember(TsClassMember member)
    {
        return member switch
        {
            TsMethodMember method => new IrMethod
            {
                Name = NameMapper.ToPascalCase(method.Name),
                OriginalName = method.Name,
                Accessibility = MapVisibility(method.Visibility),
                IsStatic = method.IsStatic,
                IsAbstract = method.IsAbstract,
                IsAsync = method.IsAsync,
                Parameters = MapParameters(method.Parameters),
                ReturnType = method.IsAsync
                    ? IrTypeRef.Task(_typeMapper.MapType(method.ReturnType))
                    : _typeMapper.MapType(method.ReturnType),
                GenericParameters = MapTypeParameters(method.TypeParameters),
                Body = method.Body is not null
                    ? new IrBlock { Statements = { new IrRawStatement { Code = method.Body, ConversionNote = "Body requires manual conversion" } } }
                    : null,
            },
            TsPropertyMember prop => new IrProperty
            {
                Name = NameMapper.ToPascalCase(prop.Name),
                OriginalName = prop.Name,
                Accessibility = MapVisibility(prop.Visibility),
                IsStatic = prop.IsStatic,
                Type = prop.Optional
                    ? IrTypeRef.Nullable(_typeMapper.MapType(prop.Type))
                    : _typeMapper.MapType(prop.Type),
                HasGetter = true,
                HasSetter = !prop.IsReadonly,
                Initializer = prop.Initializer is not null
                    ? new IrRawExpression { Code = prop.Initializer, ConversionNote = "Initializer requires conversion" }
                    : null,
            },
            TsConstructorMember ctor => new IrConstructor
            {
                Name = ".ctor",
                Accessibility = MapVisibility(ctor.Visibility),
                Parameters = MapParameters(ctor.Parameters),
                Body = ctor.Body is not null
                    ? new IrBlock { Statements = { new IrRawStatement { Code = ctor.Body, ConversionNote = "Body requires manual conversion" } } }
                    : null,
            },
            TsGetAccessorMember getter => new IrProperty
            {
                Name = NameMapper.ToPascalCase(getter.Name),
                OriginalName = getter.Name,
                Accessibility = MapVisibility(getter.Visibility),
                IsStatic = getter.IsStatic,
                Type = _typeMapper.MapType(getter.ReturnType),
                HasGetter = true,
                HasSetter = false,
            },
            TsSetAccessorMember setter => new IrProperty
            {
                Name = NameMapper.ToPascalCase(setter.Name),
                OriginalName = setter.Name,
                Accessibility = MapVisibility(setter.Visibility),
                IsStatic = setter.IsStatic,
                Type = _typeMapper.MapType(setter.ParameterType),
                HasGetter = false,
                HasSetter = true,
            },
            _ => null,
        };
    }

    private IrTypeDeclaration GenerateInterface(TsInterfaceDeclaration decl, string filePath)
    {
        // Options bag interfaces become classes
        if (_analysis.OptionsBagInterfaces.Contains(decl.Name))
            return GenerateOptionsBagClass(decl, filePath);

        var members = new List<IrMember>();

        foreach (var prop in decl.Properties)
        {
            members.Add(new IrProperty
            {
                Name = NameMapper.ToPascalCase(prop.Name),
                OriginalName = prop.Name,
                Type = prop.Optional
                    ? IrTypeRef.Nullable(_typeMapper.MapType(prop.Type))
                    : _typeMapper.MapType(prop.Type),
                HasGetter = true,
                HasSetter = !prop.IsReadonly,
            });
        }

        if (decl.Methods is not null)
        {
            foreach (var method in decl.Methods)
            {
                members.Add(new IrMethod
                {
                    Name = NameMapper.ToPascalCase(method.Name),
                    OriginalName = method.Name,
                    Parameters = MapParameters(method.Parameters),
                    ReturnType = _typeMapper.MapType(method.ReturnType),
                    GenericParameters = MapTypeParameters(method.TypeParameters),
                });
            }
        }

        return new IrInterface
        {
            Name = "I" + NameMapper.ToPascalCase(decl.Name),
            OriginalName = decl.Name,
            SourceFile = filePath,
            Accessibility = decl.Exported ? IrAccessibility.Public : IrAccessibility.Internal,
            GenericParameters = MapTypeParameters(decl.TypeParameters),
            BaseInterfaces = decl.Extends?.Select(MapHeritageClause).ToList() ?? new(),
            Members = members,
        };
    }

    private IrClass GenerateOptionsBagClass(TsInterfaceDeclaration decl, string filePath)
    {
        var members = decl.Properties.Select(prop => (IrMember)new IrProperty
        {
            Name = NameMapper.ToPascalCase(prop.Name),
            OriginalName = prop.Name,
            Type = IrTypeRef.Nullable(_typeMapper.MapType(prop.Type)),
            HasGetter = true,
            HasSetter = true,
        }).ToList();

        return new IrClass
        {
            Name = NameMapper.ToPascalCase(decl.Name),
            OriginalName = decl.Name,
            SourceFile = filePath,
            Accessibility = decl.Exported ? IrAccessibility.Public : IrAccessibility.Internal,
            GenericParameters = MapTypeParameters(decl.TypeParameters),
            Members = members,
        };
    }

    private IrTypeDeclaration? GenerateTypeAlias(TsTypeAliasDeclaration decl, string filePath)
    {
        if (decl.Type is null) return null;

        if (_analysis.UnionStrategies.TryGetValue(decl.Name, out var strategy))
        {
            return strategy switch
            {
                UnionTypeStrategy.StringEnum => GenerateStringEnumClass(decl, filePath),
                UnionTypeStrategy.NumericEnum => GenerateNumericEnum(decl, filePath),
                _ => null,
            };
        }

        return null;
    }

    private IrClass GenerateStringEnumClass(TsTypeAliasDeclaration decl, string filePath)
    {
        var members = new List<IrMember>();
        if (decl.Type?.Types is not null)
        {
            foreach (var t in decl.Type.Types)
            {
                if (t.Value is string strVal)
                {
                    members.Add(new IrField
                    {
                        Name = NameMapper.ToPascalCase(strVal),
                        OriginalName = strVal,
                        Type = IrTypeRef.String,
                        IsStatic = true,
                        IsReadonly = true,
                        Accessibility = IrAccessibility.Public,
                        Initializer = IrLiteral.String(strVal),
                    });
                }
            }
        }

        return new IrClass
        {
            Name = NameMapper.ToPascalCase(decl.Name),
            OriginalName = decl.Name,
            SourceFile = filePath,
            IsStatic = true,
            Accessibility = decl.Exported ? IrAccessibility.Public : IrAccessibility.Internal,
            Members = members,
        };
    }

    private IrEnum GenerateNumericEnum(TsTypeAliasDeclaration decl, string filePath)
    {
        var members = new List<IrEnumMember>();
        if (decl.Type?.Types is not null)
        {
            foreach (var t in decl.Type.Types)
            {
                members.Add(new IrEnumMember
                {
                    Name = NameMapper.ToPascalCase(t.Text ?? t.Value?.ToString() ?? "Unknown"),
                    Value = t.Value,
                });
            }
        }

        return new IrEnum
        {
            Name = NameMapper.ToPascalCase(decl.Name),
            OriginalName = decl.Name,
            SourceFile = filePath,
            Accessibility = decl.Exported ? IrAccessibility.Public : IrAccessibility.Internal,
            Members = members,
        };
    }

    private IrEnum GenerateEnum(TsEnumDeclaration decl, string filePath)
    {
        bool isStringBacked = decl.Members.Any(m => m.Value is string);

        if (isStringBacked)
        {
            // String enums become static classes — wrap in IrEnum with flag
            return new IrEnum
            {
                Name = NameMapper.ToPascalCase(decl.Name),
                OriginalName = decl.Name,
                SourceFile = filePath,
                IsStringBacked = true,
                Accessibility = decl.Exported ? IrAccessibility.Public : IrAccessibility.Internal,
                Members = decl.Members.Select(m => new IrEnumMember
                {
                    Name = NameMapper.ToPascalCase(m.Name),
                    Value = m.Value,
                }).ToList(),
            };
        }

        return new IrEnum
        {
            Name = NameMapper.ToPascalCase(decl.Name),
            OriginalName = decl.Name,
            SourceFile = filePath,
            Accessibility = decl.Exported ? IrAccessibility.Public : IrAccessibility.Internal,
            Members = decl.Members.Select(m => new IrEnumMember
            {
                Name = NameMapper.ToPascalCase(m.Name),
                Value = m.Value,
            }).ToList(),
        };
    }

    private IrClass GenerateStaticMethodClass(TsFunctionDeclaration decl, string filePath)
    {
        return new IrClass
        {
            Name = NameMapper.ToPascalCase(decl.Name) + "Helper",
            OriginalName = decl.Name,
            SourceFile = filePath,
            IsStatic = true,
            Accessibility = decl.Exported ? IrAccessibility.Public : IrAccessibility.Internal,
            Members =
            {
                new IrMethod
                {
                    Name = NameMapper.ToPascalCase(decl.Name),
                    OriginalName = decl.Name,
                    IsStatic = true,
                    IsAsync = decl.IsAsync,
                    Parameters = MapParameters(decl.Parameters),
                    ReturnType = decl.IsAsync
                        ? IrTypeRef.Task(_typeMapper.MapType(decl.ReturnType))
                        : _typeMapper.MapType(decl.ReturnType),
                    GenericParameters = MapTypeParameters(decl.TypeParameters),
                    Body = decl.Body is not null
                        ? new IrBlock { Statements = { new IrRawStatement { Code = decl.Body } } }
                        : null,
                },
            },
        };
    }

    private IrClass? GenerateConstantClass(TsVariableDeclaration decl, string filePath)
    {
        if (!decl.IsConst || !decl.Exported) return null;

        return new IrClass
        {
            Name = NameMapper.ToPascalCase(decl.Name) + "Constants",
            OriginalName = decl.Name,
            SourceFile = filePath,
            IsStatic = true,
            Accessibility = IrAccessibility.Public,
            Members =
            {
                new IrField
                {
                    Name = NameMapper.ToPascalCase(decl.Name),
                    OriginalName = decl.Name,
                    IsStatic = true,
                    IsReadonly = true,
                    Type = _typeMapper.MapType(decl.Type),
                    Initializer = decl.Initializer is not null
                        ? new IrRawExpression { Code = decl.Initializer }
                        : null,
                },
            },
        };
    }

    private IrTypeRef MapHeritageClause(TsHeritageClause clause)
    {
        var typeArgs = clause.TypeArguments?.Select(t => _typeMapper.MapType(t)).ToList() ?? new();
        return new IrTypeRef
        {
            Name = NameMapper.ToPascalCase(clause.Name),
            Kind = IrTypeRefKind.Named,
            TypeArguments = typeArgs,
        };
    }

    private List<IrParameter> MapParameters(List<SerializedParameter>? parameters)
    {
        if (parameters is null) return new();

        return parameters.Select(p => new IrParameter
        {
            Name = NameMapper.SanitizeIdentifier(NameMapper.ToCamelCase(p.Name)),
            Type = p.IsRest
                ? IrTypeRef.Array(_typeMapper.MapType(p.Type))
                : (p.Optional ? IrTypeRef.Nullable(_typeMapper.MapType(p.Type)) : _typeMapper.MapType(p.Type)),
            IsOptional = p.Optional,
            IsParams = p.IsRest,
            DefaultValue = p.DefaultValue is not null
                ? new IrRawExpression { Code = p.DefaultValue }
                : null,
        }).ToList();
    }

    private List<IrGenericParam> MapTypeParameters(List<SerializedTypeParameter>? typeParams)
    {
        if (typeParams is null) return new();

        return typeParams.Select(tp => new IrGenericParam
        {
            Name = tp.Name,
            Constraints = tp.Constraint is not null
                ? new List<IrTypeRef> { _typeMapper.MapType(tp.Constraint) }
                : new(),
            DefaultType = tp.Default is not null ? _typeMapper.MapType(tp.Default) : null,
        }).ToList();
    }

    private static IrAccessibility MapVisibility(string? visibility) => visibility switch
    {
        "private" => IrAccessibility.Private,
        "protected" => IrAccessibility.Protected,
        "public" => IrAccessibility.Public,
        _ => IrAccessibility.Public,
    };
}
