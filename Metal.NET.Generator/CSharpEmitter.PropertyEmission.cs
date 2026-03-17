using System.Text;

namespace Metal.NET.Generator;

/// <summary>
/// Emits C# source files from parsed metal-ast.json definitions.
/// Generates enum types, NativeObject-based classes with properties/methods, and P/Invoke free functions.
/// Also auto-generates Common/ObjectiveC.cs with all required MsgSend overloads.
/// </summary>
partial class CSharpEmitter
{
    #region Property Emission

    /// <summary>
    /// Emits a single property (getter + optional setter) into <paramref name="sb"/>.
    /// Returns <see langword="false"/> if the property is inherited and should be skipped.
    /// </summary>
    bool EmitProperty(StringBuilder sb, PropertyDef prop, string csClassName, SortedDictionary<string, string> selectors, HashSet<string> inheritedProperties)
    {
        MethodInfo getter = prop.Getter;
        string csPropName = TypeMapper.ToPascalCase(getter.Name);

        if (inheritedProperties.Contains(csPropName))
        {
            return false;
        }

        string csType = TypeMapper.MapType(getter.ReturnType);

        string? nsArrayElemType = null;
        if (csType == "NSArray")
        {
            nsArrayElemType = TryResolveNSArrayElementType(csClassName, csPropName);
        }

        bool isNSArray = nsArrayElemType != null;
        bool nullable = !isNSArray && typeMapper.IsNativeObjectType(csType);
        bool isEnum = typeMapper.IsEnumType(csType);
        bool isStruct = TypeMapper.StructTypes.Contains(csType);
        bool isBool = csType == "bool";

        string selectorName = csPropName;
        string selectorObjC = getter.Selector ?? getter.Name;
        selectors.TryAdd(selectorName, selectorObjC);

        const string Target = "NativePtr";

        string selectorRef = $"{csClassName}Bindings.{selectorName}";
        string typeStr = csType;

        string? setSelName = null;
        if (prop.Setter != null)
        {
            setSelName = TypeMapper.ToPascalCase(prop.Setter.Name);
            string setSelObjC = prop.Setter.Selector ?? "set" + csPropName + ":";
            selectors.TryAdd(setSelName, setSelObjC);
        }

        if (getter.DeprecationMessage != null)
        {
            sb.AppendLine("    /// <summary>");
            sb.AppendLine($"    /// Deprecated: {getter.DeprecationMessage}");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine($"    [Obsolete(\"{getter.DeprecationMessage}\")]");
        }

        if (isNSArray)
        {
            sb.AppendLine($"    public {nsArrayElemType}[] {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => GetArrayProperty<{nsArrayElemType}>({selectorRef});");
            if (prop.Setter != null)
            {
                sb.AppendLine($"        set => SetArrayProperty({csClassName}Bindings.{setSelName}, value);");
            }
            sb.AppendLine("    }");
        }
        else if (nullable)
        {
            sb.AppendLine($"    public {typeStr} {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => GetProperty(ref field, {selectorRef});");
            if (prop.Setter != null)
            {
                sb.AppendLine($"        set => SetProperty(ref field, {csClassName}Bindings.{setSelName}, value);");
            }
            sb.AppendLine("    }");
        }
        else if (isEnum)
        {
            string msgSend = typeMapper.GetMsgSendForEnumGet(csType);
            string enumGetGroup = msgSend.Replace("ObjectiveC.", "");
            RecordMsgSend(enumGetGroup);
            sb.AppendLine($"    public {typeStr} {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => ({csType}){msgSend}({Target}, {selectorRef});");
            if (prop.Setter != null)
            {
                string setCast = typeMapper.GetEnumSetCast(csType);
                string enumSetType = setCast.TrimStart('(').TrimEnd(')');
                RecordMsgSend("MsgSend", enumSetType);
                sb.AppendLine($"        set => ObjectiveC.MsgSend(NativePtr, {csClassName}Bindings.{setSelName}, {setCast}value);");
            }
            sb.AppendLine("    }");
        }
        else if (isBool)
        {
            RecordMsgSend("MsgSendBool");
            sb.AppendLine($"    public Bool8 {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => ObjectiveC.MsgSendBool({Target}, {selectorRef});");
            if (prop.Setter != null)
            {
                RecordMsgSend("MsgSend", "Bool8");
                sb.AppendLine($"        set => ObjectiveC.MsgSend(NativePtr, {csClassName}Bindings.{setSelName}, value);");
            }
            sb.AppendLine("    }");
        }
        else if (isStruct)
        {
            string msgSend = TypeMapper.GetMsgSendForStruct(csType);
            RecordMsgSend(msgSend);
            sb.AppendLine($"    public {typeStr} {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => ObjectiveC.{msgSend}({Target}, {selectorRef});");
            if (prop.Setter != null)
            {
                RecordMsgSend("MsgSend", csType);
                sb.AppendLine($"        set => ObjectiveC.MsgSend(NativePtr, {csClassName}Bindings.{setSelName}, value);");
            }
            sb.AppendLine("    }");
        }
        else
        {
            string msgSend = TypeMapper.GetMsgSendMethod(csType);
            RecordMsgSend(msgSend);
            sb.AppendLine($"    public {typeStr} {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => ObjectiveC.{msgSend}({Target}, {selectorRef});");
            if (prop.Setter != null)
            {
                RecordMsgSend("MsgSend", csType);
                sb.AppendLine($"        set => ObjectiveC.MsgSend(NativePtr, {csClassName}Bindings.{setSelName}, value);");
            }
            sb.AppendLine("    }");
        }

        return true;
    }

    #endregion
}
