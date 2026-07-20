import { Type, Symbol as TsSymbol, Signature } from "ts-morph"

export interface SerializedType {
  kind: string
  text?: string
  value?: string | number | boolean
  types?: SerializedType[]
  elementType?: SerializedType
  typeArguments?: SerializedType[]
  name?: string
  constraint?: SerializedType
  default?: SerializedType
  properties?: SerializedProperty[]
  signatures?: SerializedSignature[]
  checkType?: SerializedType
  extendsType?: SerializedType
  trueType?: SerializedType
  falseType?: SerializedType
}

export interface SerializedProperty {
  name: string
  type?: SerializedType
  optional: boolean
  readonly: boolean
}

export interface SerializedSignature {
  parameters?: SerializedParameter[]
  returnType?: SerializedType
  typeParameters?: SerializedTypeParameter[]
}

export interface SerializedParameter {
  name: string
  type?: SerializedType
  optional: boolean
  isRest: boolean
  defaultValue?: string
}

export interface SerializedTypeParameter {
  name: string
  constraint?: SerializedType
  default?: SerializedType
}

export function serializeType(type: Type, depth = 0, maxDepth = 5): SerializedType {
  if (depth > maxDepth) {
    return { kind: "unknown", text: tryGetText(type) }
  }

  try {
    const next = depth + 1

    if (type.isString()) return { kind: "string" }
    if (type.isNumber()) return { kind: "number" }
    if (type.isBoolean()) return { kind: "boolean" }
    if (type.isNull()) return { kind: "null" }
    if (type.isUndefined()) return { kind: "undefined" }
    if (type.isAny()) return { kind: "any" }
    if (type.isUnknown()) return { kind: "unknown" }
    if (type.isNever()) return { kind: "never" }

    const text = tryGetText(type)

    if (text === "void") return { kind: "void" }
    if (text === "true") return { kind: "literal", value: true, text }
    if (text === "false") return { kind: "literal", value: false, text }

    if (type.isStringLiteral()) {
      return { kind: "literal", value: type.getLiteralValue() as string, text }
    }
    if (type.isNumberLiteral()) {
      return { kind: "literal", value: type.getLiteralValue() as number, text }
    }
    if (type.isBooleanLiteral()) {
      return { kind: "literal", value: text === "true", text }
    }

    if (type.isUnion()) {
      return {
        kind: "union",
        types: type.getUnionTypes().map(t => serializeType(t, next, maxDepth)),
        text,
      }
    }

    if (type.isIntersection()) {
      return {
        kind: "intersection",
        types: type.getIntersectionTypes().map(t => serializeType(t, next, maxDepth)),
        text,
      }
    }

    if (type.isArray()) {
      try {
        return {
          kind: "array",
          elementType: serializeType(type.getArrayElementTypeOrThrow(), next, maxDepth),
          text,
        }
      } catch {
        return { kind: "array", text }
      }
    }

    if (type.isTuple()) {
      return {
        kind: "tuple",
        types: type.getTupleElements().map(t => serializeType(t, next, maxDepth)),
        text,
      }
    }

    if (type.isEnum()) {
      return { kind: "enum", name: type.getSymbol()?.getName(), text }
    }

    if (type.isEnumLiteral()) {
      return { kind: "enumLiteral", name: type.getSymbol()?.getName(), text }
    }

    if (type.isTypeParameter()) {
      const result: SerializedType = {
        kind: "typeParameter",
        name: type.getSymbol()?.getName() ?? text,
        text,
      }
      try {
        const constraint = type.getConstraint()
        if (constraint) result.constraint = serializeType(constraint, next, maxDepth)
      } catch {}
      try {
        const def = type.getDefault()
        if (def) result.default = serializeType(def, next, maxDepth)
      } catch {}
      return result
    }

    // Check for conditional type
    if ((type as any).isConditional?.()) {
      try {
        return {
          kind: "conditional",
          text,
          checkType: serializeType((type as any).getCheckType(), next, maxDepth),
          extendsType: serializeType((type as any).getExtendsType(), next, maxDepth),
          trueType: serializeType((type as any).getTrueType(), next, maxDepth),
          falseType: serializeType((type as any).getFalseType(), next, maxDepth),
        }
      } catch {
        return { kind: "conditional", text }
      }
    }

    // Template literal type
    if (text.includes("`") || (text.includes("${") && text.includes("}"))) {
      return { kind: "templateLiteral", text }
    }

    if (type.isObject()) {
      const callSignatures = type.getCallSignatures()
      if (callSignatures.length > 0) {
        return {
          kind: "function",
          signatures: callSignatures.map(s => serializeSignature(s, next, maxDepth)),
          text,
        }
      }

      const typeArgs = type.getTypeArguments()
      const symbol = type.getSymbol() ?? type.getAliasSymbol()
      const name = symbol?.getName()

      if (name && name !== "__type") {
        return {
          kind: "typeReference",
          name,
          text,
          typeArguments: typeArgs.length > 0
            ? typeArgs.map(t => serializeType(t, next, maxDepth))
            : undefined,
        }
      }

      // Anonymous object type — serialize properties
      const properties: SerializedProperty[] = []
      for (const prop of type.getProperties()) {
        try {
          const propType = prop.getValueDeclaration()
            ? prop.getTypeAtLocation(prop.getValueDeclaration()!)
            : undefined
          properties.push({
            name: prop.getName(),
            type: propType ? serializeType(propType, next, maxDepth) : undefined,
            optional: prop.isOptional(),
            readonly: prop.getValueDeclaration()?.getCombinedModifierFlags?.()
              ? false
              : false,
          })
        } catch {
          properties.push({
            name: prop.getName(),
            type: undefined,
            optional: false,
            readonly: false,
          })
        }
      }

      return { kind: "object", properties, text }
    }

    // Fallback: try to get as type reference
    const symbol = type.getSymbol() ?? type.getAliasSymbol()
    const aliasTypeArgs = type.getAliasTypeArguments()
    return {
      kind: "typeReference",
      name: symbol?.getName() ?? text,
      text,
      typeArguments: aliasTypeArgs.length > 0
        ? aliasTypeArgs.map(t => serializeType(t, depth + 1, maxDepth))
        : undefined,
    }
  } catch {
    return { kind: "unknown", text: tryGetText(type) }
  }
}

function serializeSignature(sig: Signature, depth: number, maxDepth: number): SerializedSignature {
  try {
    return {
      parameters: sig.getParameters().map(p => {
        const decl = p.getValueDeclaration()
        return {
          name: p.getName(),
          type: decl ? serializeType(p.getTypeAtLocation(decl), depth, maxDepth) : undefined,
          optional: p.isOptional(),
          isRest: decl?.getText()?.startsWith("...") ?? false,
          defaultValue: undefined,
        }
      }),
      returnType: serializeType(sig.getReturnType(), depth, maxDepth),
      typeParameters: sig.getTypeParameters().map(tp => ({
        name: tp.getSymbol()?.getName() ?? tp.getText(),
        constraint: tp.getConstraint()
          ? serializeType(tp.getConstraint()!, depth, maxDepth)
          : undefined,
        default: tp.getDefault()
          ? serializeType(tp.getDefault()!, depth, maxDepth)
          : undefined,
      })),
    }
  } catch {
    return {}
  }
}

function tryGetText(type: Type): string {
  try {
    return type.getText()
  } catch {
    return "<unknown>"
  }
}

export function serializeSymbol(symbol: TsSymbol): { name: string; exported: boolean } {
  try {
    return {
      name: symbol.getName(),
      exported: symbol.getValueDeclaration()?.getCombinedModifierFlags?.()
        ? true
        : false,
    }
  } catch {
    return { name: symbol.getName(), exported: false }
  }
}
