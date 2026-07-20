import { Project, ClassDeclaration, InterfaceDeclaration, TypeAliasDeclaration, EnumDeclaration, FunctionDeclaration, VariableStatement, Node, SyntaxKind, Scope, SourceFile, ParameterDeclaration, TypeParameterDeclaration } from "ts-morph"
import { serializeType, type SerializedType, type SerializedParameter, type SerializedTypeParameter } from "./type-serializer"

function parseArgs(): string {
  const args = typeof Bun !== "undefined" ? Bun.argv : process.argv
  const idx = args.indexOf("--project")
  if (idx === -1 || idx + 1 >= args.length) {
    console.error("Usage: bun run index.ts --project <path-to-tsconfig.json>")
    process.exit(1)
  }
  return args[idx + 1]
}

function getVisibility(scope: Scope | undefined): string {
  switch (scope) {
    case Scope.Private: return "private"
    case Scope.Protected: return "protected"
    case Scope.Public: return "public"
    default: return "public"
  }
}

function serializeParameters(params: ParameterDeclaration[]): SerializedParameter[] {
  return params.map(p => {
    try {
      return {
        name: p.getName(),
        type: p.getType() ? serializeType(p.getType()) : undefined,
        optional: p.isOptional(),
        isRest: p.isRestParameter(),
        defaultValue: p.getInitializer()?.getText(),
      }
    } catch {
      return {
        name: p.getName(),
        type: undefined,
        optional: false,
        isRest: false,
      }
    }
  })
}

function serializeTypeParameters(typeParams: TypeParameterDeclaration[]): SerializedTypeParameter[] {
  return typeParams.map(tp => {
    try {
      const constraint = tp.getConstraint()
      const def = tp.getDefault()
      return {
        name: tp.getName(),
        constraint: constraint ? serializeType(constraint.getType()) : undefined,
        default: def ? serializeType(def.getType()) : undefined,
      }
    } catch {
      return { name: tp.getName() }
    }
  })
}

function serializeHeritageClause(expr: Node): { name: string; typeArguments?: SerializedType[] } | null {
  try {
    const text = expr.getText()
    const name = text.replace(/<.*>$/, "").trim()
    const type = expr.getType()
    const typeArgs = type.getTypeArguments()
    return {
      name,
      typeArguments: typeArgs.length > 0
        ? typeArgs.map(t => serializeType(t))
        : undefined,
    }
  } catch {
    return { name: expr.getText() }
  }
}

function serializeClassDeclaration(decl: ClassDeclaration): any {
  const members: any[] = []

  for (const method of decl.getMethods()) {
    try {
      members.push({
        memberKind: "method",
        name: method.getName(),
        visibility: getVisibility(method.getScope()),
        isStatic: method.isStatic(),
        isAbstract: method.isAbstract(),
        isAsync: method.isAsync(),
        parameters: serializeParameters(method.getParameters()),
        returnType: method.getReturnType() ? serializeType(method.getReturnType()) : undefined,
        typeParameters: serializeTypeParameters(method.getTypeParameters()),
        body: method.getBody()?.getText(),
      })
    } catch (e) {
      console.error(`  Warning: Failed to serialize method ${method.getName()}: ${e}`)
    }
  }

  for (const prop of decl.getProperties()) {
    try {
      members.push({
        memberKind: "property",
        name: prop.getName(),
        visibility: getVisibility(prop.getScope()),
        isStatic: prop.isStatic(),
        type: prop.getType() ? serializeType(prop.getType()) : undefined,
        optional: prop.hasQuestionToken(),
        readonly: prop.isReadonly(),
        initializer: prop.getInitializer()?.getText(),
      })
    } catch (e) {
      console.error(`  Warning: Failed to serialize property ${prop.getName()}: ${e}`)
    }
  }

  for (const ctor of decl.getConstructors()) {
    try {
      members.push({
        memberKind: "constructor",
        name: "constructor",
        visibility: getVisibility(ctor.getScope()),
        isStatic: false,
        parameters: serializeParameters(ctor.getParameters()),
        body: ctor.getBody()?.getText(),
      })
    } catch (e) {
      console.error(`  Warning: Failed to serialize constructor: ${e}`)
    }
  }

  for (const getter of decl.getGetAccessors()) {
    try {
      members.push({
        memberKind: "getter",
        name: getter.getName(),
        visibility: getVisibility(getter.getScope()),
        isStatic: getter.isStatic(),
        returnType: getter.getReturnType() ? serializeType(getter.getReturnType()) : undefined,
        body: getter.getBody()?.getText(),
      })
    } catch (e) {
      console.error(`  Warning: Failed to serialize getter ${getter.getName()}: ${e}`)
    }
  }

  for (const setter of decl.getSetAccessors()) {
    try {
      const params = setter.getParameters()
      members.push({
        memberKind: "setter",
        name: setter.getName(),
        visibility: getVisibility(setter.getScope()),
        isStatic: setter.isStatic(),
        parameterType: params.length > 0 && params[0].getType()
          ? serializeType(params[0].getType())
          : undefined,
        body: setter.getBody()?.getText(),
      })
    } catch (e) {
      console.error(`  Warning: Failed to serialize setter ${setter.getName()}: ${e}`)
    }
  }

  const extendsExpr = decl.getExtends()
  let extendsClause = null
  if (extendsExpr) {
    extendsClause = serializeHeritageClause(extendsExpr)
  }

  const implementsClauses = decl.getImplements().map(i => serializeHeritageClause(i)).filter(Boolean)

  return {
    declarationKind: "class",
    name: decl.getName() ?? "<anonymous>",
    exported: decl.isExported(),
    isAbstract: decl.isAbstract(),
    typeParameters: serializeTypeParameters(decl.getTypeParameters()),
    extends: extendsClause,
    implements: implementsClauses.length > 0 ? implementsClauses : undefined,
    members,
    documentation: decl.getJsDocs().map(d => d.getText()).join("\n") || undefined,
  }
}

function serializeInterfaceDeclaration(decl: InterfaceDeclaration): any {
  const properties = decl.getProperties().map(p => {
    try {
      return {
        name: p.getName(),
        type: p.getType() ? serializeType(p.getType()) : undefined,
        optional: p.hasQuestionToken(),
        readonly: p.isReadonly(),
      }
    } catch {
      return { name: p.getName(), optional: false, readonly: false }
    }
  })

  const methods = decl.getMethods().map(m => {
    try {
      return {
        name: m.getName(),
        parameters: serializeParameters(m.getParameters()),
        returnType: m.getReturnType() ? serializeType(m.getReturnType()) : undefined,
        typeParameters: serializeTypeParameters(m.getTypeParameters()),
        optional: m.hasQuestionToken(),
      }
    } catch {
      return { name: m.getName(), parameters: [], optional: false }
    }
  })

  const indexSignatures = decl.getIndexSignatures().map(idx => {
    try {
      const keyParam = idx.getKeyName()
      return {
        keyName: keyParam,
        keyType: serializeType(idx.getKeyType()),
        valueType: serializeType(idx.getReturnType()),
        readonly: idx.isReadonly(),
      }
    } catch {
      return { keyName: "key", readonly: false }
    }
  })

  const extendsClauses = decl.getExtends().map(e => serializeHeritageClause(e)).filter(Boolean)

  return {
    declarationKind: "interface",
    name: decl.getName(),
    exported: decl.isExported(),
    typeParameters: serializeTypeParameters(decl.getTypeParameters()),
    extends: extendsClauses.length > 0 ? extendsClauses : undefined,
    properties,
    methods: methods.length > 0 ? methods : undefined,
    indexSignatures: indexSignatures.length > 0 ? indexSignatures : undefined,
    documentation: decl.getJsDocs().map(d => d.getText()).join("\n") || undefined,
  }
}

function serializeTypeAlias(decl: TypeAliasDeclaration): any {
  try {
    return {
      declarationKind: "typeAlias",
      name: decl.getName(),
      exported: decl.isExported(),
      typeParameters: serializeTypeParameters(decl.getTypeParameters()),
      type: serializeType(decl.getType()),
      documentation: decl.getJsDocs().map(d => d.getText()).join("\n") || undefined,
    }
  } catch {
    return {
      declarationKind: "typeAlias",
      name: decl.getName(),
      exported: decl.isExported(),
    }
  }
}

function serializeEnum(decl: EnumDeclaration): any {
  return {
    declarationKind: "enum",
    name: decl.getName(),
    exported: decl.isExported(),
    isConst: decl.isConstEnum(),
    members: decl.getMembers().map(m => ({
      name: m.getName(),
      value: m.getValue(),
    })),
    documentation: decl.getJsDocs().map(d => d.getText()).join("\n") || undefined,
  }
}

function serializeFunction(decl: FunctionDeclaration): any {
  const name = decl.getName()
  if (!name) return null

  try {
    return {
      declarationKind: "function",
      name,
      exported: decl.isExported(),
      parameters: serializeParameters(decl.getParameters()),
      returnType: decl.getReturnType() ? serializeType(decl.getReturnType()) : undefined,
      typeParameters: serializeTypeParameters(decl.getTypeParameters()),
      isAsync: decl.isAsync(),
      body: decl.getBody()?.getText(),
      documentation: decl.getJsDocs().map(d => d.getText()).join("\n") || undefined,
    }
  } catch {
    return {
      declarationKind: "function",
      name,
      exported: decl.isExported(),
    }
  }
}

function serializeVariableStatement(stmt: VariableStatement): any[] {
  return stmt.getDeclarations().map(d => {
    try {
      return {
        declarationKind: "variable",
        name: d.getName(),
        exported: stmt.isExported(),
        type: d.getType() ? serializeType(d.getType()) : undefined,
        initializer: d.getInitializer()?.getText(),
        isConst: stmt.getDeclarationKind() === 2, // VariableDeclarationKind.Const
      }
    } catch {
      return {
        declarationKind: "variable",
        name: d.getName(),
        exported: stmt.isExported(),
      }
    }
  })
}

function processSourceFile(sourceFile: SourceFile): void {
  const filePath = sourceFile.getFilePath()

  // Skip node_modules and declaration files
  if (filePath.includes("node_modules") || filePath.endsWith(".d.ts")) return

  const declarations: any[] = []

  for (const statement of sourceFile.getStatements()) {
    try {
      if (Node.isClassDeclaration(statement)) {
        declarations.push(serializeClassDeclaration(statement))
      } else if (Node.isInterfaceDeclaration(statement)) {
        declarations.push(serializeInterfaceDeclaration(statement))
      } else if (Node.isTypeAliasDeclaration(statement)) {
        declarations.push(serializeTypeAlias(statement))
      } else if (Node.isEnumDeclaration(statement)) {
        declarations.push(serializeEnum(statement))
      } else if (Node.isFunctionDeclaration(statement)) {
        const serialized = serializeFunction(statement)
        if (serialized) declarations.push(serialized)
      } else if (Node.isVariableStatement(statement)) {
        declarations.push(...serializeVariableStatement(statement))
      }
    } catch (e) {
      console.error(`Warning: Failed to process statement in ${filePath}: ${e}`)
    }
  }

  if (declarations.length > 0) {
    console.log(JSON.stringify({ filePath, declarations }))
  }
}

// Main
const projectPath = parseArgs()
console.error(`Loading project from ${projectPath}...`)

try {
  const project = new Project({ tsConfigFilePath: projectPath })
  const sourceFiles = project.getSourceFiles()
  console.error(`Found ${sourceFiles.length} source files`)

  for (const sourceFile of sourceFiles) {
    try {
      processSourceFile(sourceFile)
    } catch (e) {
      console.error(`Error processing ${sourceFile.getFilePath()}: ${e}`)
    }
  }

  console.error("Done.")
} catch (e) {
  console.error(`Fatal error loading project: ${e}`)
  process.exit(1)
}
