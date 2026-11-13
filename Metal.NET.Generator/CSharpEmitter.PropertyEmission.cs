namespace Metal.NET.Generator;

partial class CSharpEmitter
{
    #region Property Emission

    /// <summary>
    /// Emits a single property (getter + optional setter) into <paramref name="sb"/>.
    /// Returns <see langword="false"/> if the property was already emitted or cannot be resolved.
    /// </summary>
    bool EmitProperty(StringBuilder sb, PropertyDef prop, string csClassName, List<string> ancestors, SortedDictionary<string, string> selectors, HashSet<string> emittedProperties)
    {
        MethodInfo getter = prop.Getter;
        string csPropName = TypeMapper.ToPascalCase(getter.Name);

        if (!emittedProperties.Add(csPropName))
        {
            return false;
        }

        string csType = TypeMapper.MapType(getter.ReturnType);

        string? nsArrayElemType = null;
        if (csType == "NSArray")
        {
            nsArrayElemType = TryResolveNSArrayElementType(csClassName, csPropName, ancestors);
            if (nsArrayElemType == null) return false;
        }

        bool isNSArray = nsArrayElemType != null;
        bool nullable = !isNSArray && typeMapper.IsNativeObjectType(csType);
        bool isEnum = typeMapper.IsEnumType(csType);
        bool isStruct = TypeMapper.StructTypes.Contains(csType);
        bool isBool = csType == "bool";

        string selectorObjC = getter.Selector ?? getter.Name;
        string selectorName = BuildMethodNameFromSelector(selectorObjC);
        selectors.TryAdd(selectorName, selectorObjC);

        const string Target = "NativePtr";

        string selectorRef = $"{csClassName}Bindings.{selectorName}";
        string typeStr = csType;

        string? setSelName = null;
        if (prop.Setter != null)
        {
            string setSelObjC = prop.Setter.Selector ?? "set" + csPropName + ":";
            setSelName = BuildMethodNameFromSelector(setSelObjC);
            selectors.TryAdd(setSelName, setSelObjC);
        }

        if (getter.DeprecationMessage != null)
        {
            EmitDeprecation(sb, getter.DeprecationMessage);
        }

        if (isNSArray)
        {
            RecordMsgSend("MsgSendNInt");
            sb.AppendLine($"    public NSArray<{nsArrayElemType}> {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => new(ObjectiveC.MsgSendNInt({Target}, {selectorRef}));");
            if (prop.Setter != null)
            {
                RecordMsgSend("MsgSend", "nint");
                sb.AppendLine($"        set => ObjectiveC.MsgSend({Target}, {csClassName}Bindings.{setSelName}, value.NativePtr);");
            }
            sb.AppendLine("    }");
        }
        else if (nullable)
        {
            RecordMsgSend("MsgSendNInt");
            sb.AppendLine($"    public {typeStr} {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => new(ObjectiveC.MsgSendNInt({Target}, {selectorRef}));");
            if (prop.Setter != null)
            {
                RecordMsgSend("MsgSend", "nint");
                sb.AppendLine($"        set => ObjectiveC.MsgSend({Target}, {csClassName}Bindings.{setSelName}, value.NativePtr);");
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
            string narrowCast = TypeMapper.NeedsNarrowCast(csType) ? $"({csType})" : "";
            sb.AppendLine($"    public {typeStr} {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => {narrowCast}ObjectiveC.{msgSend}({Target}, {selectorRef});");
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
