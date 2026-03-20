namespace Metal.NET.Generator;

partial class CSharpEmitter
{
    #region Method Emission

    /// <summary>Accumulated state from parameter marshalling, shared between method and init emission.</summary>
    sealed class MarshalledCall
    {
        public List<string> CsParams { get; } = [];
        public List<string> CallArgs { get; } = [];
        public List<string> CallArgTypes { get; } = [];
        public List<string> ArraySetupLines { get; } = [];
        public List<string> FixedStatements { get; } = [];
        public List<string> NsArrayReleaseVars { get; } = [];
        public List<(string CsType, string CsParamName, string PtrVarName)> AutoreleasedOutParams { get; } = [];
        public bool NeedsUnsafeContext { get; set; }
        public bool HasOutError { get; set; }
    }

    /// <summary>
    /// Marshals all parameters for a method into C# parameter declarations, call arguments,
    /// array setup lines, fixed statements, and out-param tracking.
    /// <para><paramref name="isInit"/> controls init-specific behaviour (NSDictionary/NSArray as raw nint).</para>
    /// </summary>
    MarshalledCall MarshalParameters(
        MethodInfo method, string csClassName, string csMethodName,
        HashSet<string>? knownDelegateNames, bool isInit)
    {
        MarshalledCall mc = new();
        mc.HasOutError = method.Parameters.Any(p => p.Type.Contains("Error**"));

        for (int pi = 0; pi < method.Parameters.Count; pi++)
        {
            ParamDef param = method.Parameters[pi];
            if (param.Type == ParamDef.ArrayParam)
            {
                continue;
            }

            if (param.Type.Contains("Error**"))
            {
                mc.CsParams.Add("out NSError error");
                mc.CallArgs.Add("out nint errorPtr");
                mc.CallArgTypes.Add("out nint");
                continue;
            }

            // Init-only: NSDictionary / bare NSArray → raw nint (no wrapper class available)
            if (isInit)
            {
                if (param.Type.StartsWith("NSDictionary"))
                {
                    string csParamName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));
                    mc.CsParams.Add($"nint {csParamName}");
                    mc.CallArgs.Add(csParamName);
                    mc.CallArgTypes.Add("nint");
                    continue;
                }

                if (param.Type.StartsWith("NSArray") && !param.Type.StartsWith(ParamDef.NsArrayParam))
                {
                    string csParamName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));
                    mc.CsParams.Add($"nint {csParamName}");
                    mc.CallArgs.Add(csParamName);
                    mc.CallArgTypes.Add("nint");
                    continue;
                }
            }

            if (param.Type.StartsWith(ParamDef.ObjArray))
            {
                mc.NeedsUnsafeContext = true;
                string elemType = param.Type[ParamDef.ObjArray.Length..];
                string elemCsType = TypeMapper.MapType(elemType + "*");
                string csParamName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));

                mc.CsParams.Add($"{elemCsType}[] {csParamName}");

                bool nextIsCount = pi + 1 < method.Parameters.Count &&
                    method.Parameters[pi + 1] is { Type: "NS::UInteger" or ParamDef.ArrayParam, Name: "count" };

                string ptrVar = $"p{TypeMapper.ToPascalCase(param.Name)}";
                if (mc.ArraySetupLines.Count > 0) mc.ArraySetupLines.Add("");
                mc.ArraySetupLines.Add($"        nint* {ptrVar} = stackalloc nint[{csParamName}.Length];");
                mc.ArraySetupLines.Add($"        for (int i = 0; i < {csParamName}.Length; i++)");
                mc.ArraySetupLines.Add("        {");
                mc.ArraySetupLines.Add($"            {ptrVar}[i] = {csParamName}[i].NativePtr;");
                mc.ArraySetupLines.Add("        }");

                mc.CallArgs.Add($"(nint){ptrVar}");
                mc.CallArgTypes.Add("nint");

                if (nextIsCount)
                {
                    mc.CallArgs.Add($"(nuint){csParamName}.Length");
                    mc.CallArgTypes.Add("nuint");
                    pi++;
                }
                continue;
            }

            if (param.Type.StartsWith(ParamDef.PrimArray))
            {
                mc.NeedsUnsafeContext = true;
                string elemType = param.Type[ParamDef.PrimArray.Length..];
                string csParamName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));

                mc.CsParams.Add($"{elemType}[] {csParamName}");

                string ptrVar = $"p{TypeMapper.ToPascalCase(param.Name)}";
                if (mc.ArraySetupLines.Count > 0) mc.ArraySetupLines.Add("");
                mc.ArraySetupLines.Add($"        {elemType}* {ptrVar} = stackalloc {elemType}[{csParamName}.Length];");
                mc.ArraySetupLines.Add($"        for (int i = 0; i < {csParamName}.Length; i++)");
                mc.ArraySetupLines.Add("        {");
                mc.ArraySetupLines.Add($"            {ptrVar}[i] = {csParamName}[i];");
                mc.ArraySetupLines.Add("        }");

                mc.CallArgs.Add($"(nint){ptrVar}");
                mc.CallArgTypes.Add("nint");
                continue;
            }

            if (param.Type.StartsWith(ParamDef.StructArray))
            {
                mc.NeedsUnsafeContext = true;
                string elemType = param.Type[ParamDef.StructArray.Length..];
                string elemCsType = TypeMapper.MapType(elemType);
                string csParamName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));

                mc.CsParams.Add($"{elemCsType}[] {csParamName}");

                bool nextIsCount = pi + 1 < method.Parameters.Count &&
                    method.Parameters[pi + 1] is { Type: "NS::UInteger" or ParamDef.ArrayParam, Name: "count" };

                string ptrVar = $"p{TypeMapper.ToPascalCase(param.Name)}";
                mc.FixedStatements.Add($"fixed ({elemCsType}* {ptrVar} = {csParamName})");

                mc.CallArgs.Add($"(nint){ptrVar}");
                mc.CallArgTypes.Add("nint");

                if (nextIsCount)
                {
                    mc.CallArgs.Add($"(nuint){csParamName}.Length");
                    mc.CallArgTypes.Add("nuint");
                    pi++;
                }
                continue;
            }

            if (param.Type.StartsWith(ParamDef.InlineBlock))
            {
                string delegateName = param.Type[ParamDef.InlineBlock.Length..];
                string csParamName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));
                mc.CsParams.Add($"{delegateName} {csParamName}");
                mc.CallArgs.Add($"{csParamName}.NativePtr");
                mc.CallArgTypes.Add("nint");
                continue;
            }

            if (param.Type.StartsWith(ParamDef.NsArrayParam))
            {
                string elemModelType = param.Type[ParamDef.NsArrayParam.Length..];
                string elemCsType = TypeMapper.MapType(elemModelType);
                string csParamName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));

                mc.CsParams.Add($"{elemCsType}[] {csParamName}");

                string ptrVar = $"p{TypeMapper.ToPascalCase(param.Name)}";
                mc.ArraySetupLines.Add($"        nint {ptrVar} = NSArray.FromArray({csParamName});");
                mc.NsArrayReleaseVars.Add(ptrVar);

                mc.CallArgs.Add(ptrVar);
                mc.CallArgTypes.Add("nint");
                continue;
            }

            if (param.Type.StartsWith(ParamDef.NsSetParam))
            {
                string elemModelType = param.Type[ParamDef.NsSetParam.Length..];
                string elemCsType = TypeMapper.MapType(elemModelType);
                string csParamName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));

                mc.CsParams.Add($"{elemCsType}[] {csParamName}");

                string ptrVar = $"p{TypeMapper.ToPascalCase(param.Name)}";
                mc.ArraySetupLines.Add($"        nint {ptrVar} = NSSet.FromArray({csParamName});");
                mc.NsArrayReleaseVars.Add(ptrVar);

                mc.CallArgs.Add(ptrVar);
                mc.CallArgTypes.Add("nint");
                continue;
            }

            if (knownDelegateNames != null && IsBlockHandlerType(param.Type, knownDelegateNames))
            {
                string csType = TypeMapper.MapType(param.Type);
                string csParamName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));
                mc.CsParams.Add($"{csType} {csParamName}");
                mc.CallArgs.Add($"{csParamName}.NativePtr");
                mc.CallArgTypes.Add("nint");
                continue;
            }

            string csParamType = TypeMapper.MapType(param.Type);
            string paramName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));

            // Method-only: Autoreleased* → out parameter
            if (!isInit && param.Type.Contains("Autoreleased"))
            {
                string resolvedType = param.Type.Replace("Autoreleased", "");
                string csType = TypeMapper.MapType(resolvedType);
                string ptrVarName = $"{paramName}Ptr";
                mc.CsParams.Add($"out {csType} {paramName}");
                mc.CallArgs.Add($"out nint {ptrVarName}");
                mc.CallArgTypes.Add("out nint");
                mc.AutoreleasedOutParams.Add((csType, paramName, ptrVarName));
                continue;
            }

            // Method-only: Timestamp* out param
            if (!isInit && param.Type.Contains("Timestamp*") && !param.Type.Contains("TimestampGranularity"))
            {
                mc.CsParams.Add($"out ulong {paramName}");
                mc.CallArgs.Add($"out {paramName}");
                mc.CallArgTypes.Add("out ulong");
                continue;
            }

            mc.CsParams.Add($"{csParamType} {paramName}");

            if (csParamType == "NSArray")
            {
                string? paramArrayElemType = TryResolveNSArrayElementType(csClassName, csMethodName);
                if (paramArrayElemType != null)
                {
                    mc.CsParams[^1] = $"{paramArrayElemType}[] {paramName}";
                    string ptrVar = $"p{TypeMapper.ToPascalCase(param.Name)}";
                    mc.ArraySetupLines.Add($"        nint {ptrVar} = NSArray.FromArray({paramName});");
                    mc.CallArgs.Add(ptrVar);
                    mc.NsArrayReleaseVars.Add(ptrVar);
                }
                else
                {
                    mc.CallArgs.Add($"{paramName}");
                }
                mc.CallArgTypes.Add("nint");
            }
            else if (typeMapper.IsNativeObjectType(csParamType))
            {
                mc.CallArgs.Add($"{paramName}.NativePtr");
                mc.CallArgTypes.Add("nint");
            }
            else if (typeMapper.IsEnumType(csParamType))
            {
                mc.CallArgs.Add($"{typeMapper.GetEnumSetCast(csParamType)}{paramName}");
                string castType = typeMapper.GetEnumSetCast(csParamType).TrimStart('(').TrimEnd(')');
                mc.CallArgTypes.Add(castType);
            }
            else
            {
                mc.CallArgs.Add(paramName);
                mc.CallArgTypes.Add(csParamType == "bool" ? "Bool8" : csParamType);
            }
        }

        return mc;
    }

    /// <summary>Emits array setup lines, opens fixed blocks, and returns the current indent string.</summary>
    static string EmitBodyPrologue(StringBuilder sb, MarshalledCall mc)
    {
        foreach (string line in mc.ArraySetupLines)
        {
            sb.AppendLine(line);
        }

        if (mc.ArraySetupLines.Count > 0)
        {
            sb.AppendLine();
        }

        string indent = "        ";
        foreach (string fixedStmt in mc.FixedStatements)
        {
            sb.AppendLine($"{indent}{fixedStmt}");
            sb.AppendLine($"{indent}{{");
            indent += "    ";
        }

        return indent;
    }

    /// <summary>Emits out-param assignments (autoreleased + NSError) and NSArray release calls.</summary>
    static void EmitOutParamCleanup(StringBuilder sb, string indent, MarshalledCall mc)
    {
        foreach ((_, string csParamName, string ptrVar) in mc.AutoreleasedOutParams)
        {
            sb.AppendLine();
            sb.AppendLine($"{indent}{csParamName} = new({ptrVar}, NativeObjectOwnership.Owned);");
        }
        if (mc.HasOutError)
        {
            sb.AppendLine();
            sb.AppendLine($"{indent}error = new(errorPtr, NativeObjectOwnership.Owned);");
        }
        if (mc.NsArrayReleaseVars.Count > 0)
        {
            sb.AppendLine();
            foreach (string rv in mc.NsArrayReleaseVars)
                sb.AppendLine($"{indent}ObjectiveC.Release({rv});");
        }
    }

    /// <summary>Closes fixed blocks opened in <see cref="EmitBodyPrologue"/>.</summary>
    static void EmitBodyEpilogue(StringBuilder sb, MarshalledCall mc)
    {
        for (int fi = mc.FixedStatements.Count - 1; fi >= 0; fi--)
        {
            string indent = "        " + new string(' ', fi * 4);
            sb.AppendLine($"{indent}}}");
        }
    }

    /// <summary>
    /// Emits a single instance or class method: parameter marshalling, MsgSend dispatch, return handling.
    /// </summary>
    void EmitMethod(StringBuilder sb, MethodInfo method, string csClassName, SortedDictionary<string, string> selectors, HashSet<string> knownDelegateNames)
    {
        string csMethodName = TypeMapper.ToPascalCase(method.Name);

        string selectorObjC = method.Selector
            ?? method.Name + (method.Parameters.Count > 0 ? new string(':', method.Parameters.Count) : "");

        bool isStaticClassMethod = method.IsStatic && method.UsesClassTarget;
        string target = isStaticClassMethod ? $"{csClassName}Bindings.Class" : "NativePtr";

        string selectorKey = BuildMethodNameFromSelector(selectorObjC);
        selectors.TryAdd(selectorKey, selectorObjC);
        string selectorRef = $"{csClassName}Bindings.{selectorKey}";

        string returnType = TypeMapper.MapType(method.ReturnType);

        string? returnArrayElemType = null;
        if (returnType == "NSArray")
        {
            returnArrayElemType = TryResolveNSArrayElementType(csClassName, csMethodName);
            if (returnArrayElemType == null) return;
        }
        bool returnsArray = returnArrayElemType != null;

        bool nullable = !returnsArray && typeMapper.IsNativeObjectType(returnType);
        bool isEnum = typeMapper.IsEnumType(returnType);
        bool isStruct = TypeMapper.StructTypes.Contains(returnType);
        bool isBool = returnType == "bool";
        bool isVoid = returnType == "void";

        // --- Parameter marshalling ---
        MarshalledCall mc = MarshalParameters(method, csClassName, csMethodName, knownDelegateNames, isInit: false);
        mc.CallArgs.InsertRange(0, [target, selectorRef]);

        string paramStr = string.Join(", ", mc.CsParams);
        string argsStr = string.Join(", ", mc.CallArgs);
        string staticKw = isStaticClassMethod ? "static " : "";
        string unsafeKw = mc.NeedsUnsafeContext ? "unsafe " : "";
        string csReturnType = returnsArray ? $"{returnArrayElemType}[]" : (isVoid ? "void" : returnType);

        if (method.DeprecationMessage != null)
        {
            EmitDeprecation(sb, method.DeprecationMessage);
        }

        sb.AppendLine($"    public {staticKw}{unsafeKw}{csReturnType} {csMethodName}({paramStr})");
        sb.AppendLine("    {");

        string indent = EmitBodyPrologue(sb, mc);

        // --- MsgSend dispatch ---
        string[] argTypesArray = [.. mc.CallArgTypes];
        string msgSendExpr;
        if (isVoid)
        {
            RecordMsgSend("MsgSend", argTypesArray);
            msgSendExpr = $"ObjectiveC.MsgSend({argsStr})";
        }
        else if (returnsArray || nullable)
        {
            RecordMsgSend("MsgSendNInt", argTypesArray);
            msgSendExpr = $"ObjectiveC.MsgSendNInt({argsStr})";
        }
        else if (isEnum)
        {
            string msgSend = typeMapper.GetMsgSendForEnumGet(returnType);
            string enumGroup = msgSend.Replace("ObjectiveC.", "");
            RecordMsgSend(enumGroup, argTypesArray);
            msgSendExpr = $"({returnType}){msgSend}({argsStr})";
        }
        else if (isBool)
        {
            RecordMsgSend("MsgSendBool", argTypesArray);
            msgSendExpr = $"ObjectiveC.MsgSendBool({argsStr})";
        }
        else if (isStruct)
        {
            string msgSend = TypeMapper.GetMsgSendForStruct(returnType);
            RecordMsgSend(msgSend, argTypesArray);
            msgSendExpr = $"ObjectiveC.{msgSend}({argsStr})";
        }
        else
        {
            string msgSend = TypeMapper.GetMsgSendMethod(returnType);
            RecordMsgSend(msgSend, argTypesArray);
            msgSendExpr = TypeMapper.NeedsNarrowCast(returnType)
                ? $"({returnType})ObjectiveC.{msgSend}({argsStr})"
                : $"ObjectiveC.{msgSend}({argsStr})";
        }

        // --- Return handling ---
        if (isVoid)
        {
            sb.AppendLine($"{indent}{msgSendExpr};");
            EmitOutParamCleanup(sb, indent, mc);
        }
        else if (returnsArray || nullable)
        {
            sb.AppendLine($"{indent}nint nativePtr = {msgSendExpr};");
            EmitOutParamCleanup(sb, indent, mc);
            sb.AppendLine();
            sb.AppendLine(returnsArray
                ? $"{indent}return NSArray.ToArray<{returnArrayElemType}>(nativePtr);"
                : $"{indent}return new(nativePtr, NativeObjectOwnership.Owned);");
        }
        else if (mc.HasOutError || mc.AutoreleasedOutParams.Count > 0)
        {
            sb.AppendLine($"{indent}{csReturnType} result = {msgSendExpr};");
            EmitOutParamCleanup(sb, indent, mc);
            sb.AppendLine();
            sb.AppendLine($"{indent}return result;");
        }
        else
        {
            sb.AppendLine($"{indent}return {msgSendExpr};");
        }

        EmitBodyEpilogue(sb, mc);
        sb.AppendLine("    }");
    }

    /// <summary>
    /// Builds a unique C# identifier from an ObjC selector by PascalCasing each
    /// colon-separated segment and joining them with underscores.
    /// </summary>
    static string BuildMethodNameFromSelector(string selector)
    {
        ReadOnlySpan<char> remaining = selector.AsSpan();
        StringBuilder sb = new();
        bool first = true;

        while (!remaining.IsEmpty)
        {
            int colon = remaining.IndexOf(':');
            ReadOnlySpan<char> part = colon < 0 ? remaining : remaining[..colon];

            if (!first)
            {
                sb.Append('_');
            }

            if (!part.IsEmpty)
            {
                sb.Append(char.ToUpper(part[0]));
                if (part.Length > 1)
                {
                    sb.Append(part[1..]);
                }
            }

            first = false;
            remaining = colon < 0 ? [] : remaining[(colon + 1)..];
        }

        return sb.ToString();
    }

    /// <summary>
    /// Emits a static factory method from an ObjC <c>init</c> method.
    /// Always returns <c>new(nativePtr, NativeObjectOwnership.Managed)</c>.
    /// </summary>
    void EmitInitStaticMethod(StringBuilder sb, MethodInfo method, string csClassName, SortedDictionary<string, string> selectors)
    {
        string selectorObjC = method.Selector!;
        string selectorKey = BuildMethodNameFromSelector(selectorObjC);
        selectors.TryAdd(selectorKey, selectorObjC);
        string selectorRef = $"{csClassName}Bindings.{selectorKey}";

        string csMethodName = TypeMapper.ToPascalCase(method.Name);

        // --- Parameter marshalling ---
        MarshalledCall mc = MarshalParameters(method, csClassName, csMethodName, knownDelegateNames: null, isInit: true);
        mc.CallArgs.InsertRange(0, [$"ObjectiveC.Alloc({csClassName}Bindings.Class)", selectorRef]);

        string paramStr = string.Join(", ", mc.CsParams);
        string argsStr = string.Join(", ", mc.CallArgs);
        string unsafeKw = mc.NeedsUnsafeContext ? "unsafe " : "";

        RecordMsgSend("MsgSendNInt", [.. mc.CallArgTypes]);

        if (method.DeprecationMessage != null)
        {
            EmitDeprecation(sb, method.DeprecationMessage);
        }

        sb.AppendLine($"    public static {unsafeKw}{csClassName} {csMethodName}({paramStr})");
        sb.AppendLine("    {");

        string indent = EmitBodyPrologue(sb, mc);

        sb.AppendLine($"{indent}nint nativePtr = ObjectiveC.MsgSendNInt({argsStr});");
        EmitOutParamCleanup(sb, indent, mc);
        sb.AppendLine();
        sb.AppendLine($"{indent}return new(nativePtr, NativeObjectOwnership.Managed);");

        EmitBodyEpilogue(sb, mc);
        sb.AppendLine("    }");
    }

    #endregion
}
