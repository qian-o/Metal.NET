using System.Text;

namespace Metal.NET.Generator;

/// <summary>
/// Emits C# source files from parsed metal-ast.json definitions.
/// Generates enum types, NativeObject-based classes with properties/methods, and P/Invoke free functions.
/// Also auto-generates Common/ObjectiveC.cs with all required MsgSend overloads.
/// </summary>
partial class CSharpEmitter
{
    #region Method Emission

    /// <summary>
    /// Emits a single method into <paramref name="sb"/>, handling parameter marshalling
    /// (arrays, blocks, out-params, enums) and selecting the correct <c>MsgSend</c> variant.
    /// </summary>
    void EmitMethod(StringBuilder sb, MethodInfo method, string csClassName, SortedDictionary<string, string> selectors, HashSet<string> hasZeroParamVersion, Dictionary<MethodInfo, string> simplifiedNames)
    {
        string csMethodName;
        string selectorObjC;
        string methodName = method.Name;

        if (method.Selector != null)
        {
            selectorObjC = method.Selector;

            string selectorBaseName = selectorObjC.Contains(':')
                ? selectorObjC[..selectorObjC.IndexOf(':')]
                : selectorObjC;

            // Use pre-computed simplified name (with conflict detection) for any selector method
            int colonCount = selectorObjC.Count(c => c == ':');
            if (simplifiedNames.TryGetValue(method, out string? simplified))
            {
                csMethodName = simplified;
            }
            else if (colonCount > 1)
            {
                csMethodName = BuildMethodNameFromSelector(selectorObjC);
            }
            else if (hasZeroParamVersion.Contains(methodName) && method.Parameters.Count > 0)
            {
                csMethodName = TypeMapper.ToPascalCase(selectorBaseName);
            }
            else
            {
                csMethodName = TypeMapper.ToPascalCase(methodName);
            }
        }
        else
        {
            csMethodName = TypeMapper.ToPascalCase(methodName);
            int colonCount = method.Parameters.Count;
            selectorObjC = method.Name + (colonCount > 0 ? new string(':', colonCount) : "");
        }

        bool isStaticClassMethod = method.IsStatic && method.UsesClassTarget;
        string target = isStaticClassMethod ? $"{csClassName}Bindings.Class" : "NativePtr";

        string selectorKey = hasZeroParamVersion.Contains(method.Name) && method.Parameters.Count > 0
            ? BuildMethodNameFromSelector(selectorObjC)
            : TypeMapper.ToPascalCase(method.Name);
        if (selectors.TryGetValue(selectorKey, out string? existingSelector) && existingSelector != selectorObjC)
        {
            selectorKey = BuildMethodNameFromSelector(selectorObjC);
        }
        selectors.TryAdd(selectorKey, selectorObjC);

        string selectorRef = $"{csClassName}Bindings.{selectorKey}";

        string returnType = TypeMapper.MapType(method.ReturnType);

        string? returnArrayElemType = null;
        if (returnType == "NSArray")
        {
            returnArrayElemType = TryResolveNSArrayElementType(csClassName, csMethodName);
        }
        bool returnsArray = returnArrayElemType != null;

        bool nullable = !returnsArray && typeMapper.IsNativeObjectType(returnType);
        bool isEnum = typeMapper.IsEnumType(returnType);
        bool isStruct = TypeMapper.StructTypes.Contains(returnType);
        bool isBool = returnType == "bool";
        bool isVoid = returnType == "void";

        bool hasOutError = method.Parameters.Any(p => p.Type.Contains("Error**"));

        List<string> csParams = [];
        List<string> callArgs = [target, selectorRef];
        List<string> callArgTypes = [];
        List<string> arraySetupLines = [];
        List<string> fixedStatements = [];
        List<string> nsArrayReleaseVars = [];
        List<(string CsType, string CsParamName, string PtrVarName)> autoreleasedOutParams = [];
        bool needsUnsafeContext = false;

        for (int pi = 0; pi < method.Parameters.Count; pi++)
        {
            ParamDef param = method.Parameters[pi];
            if (param.Type == "ARRAY_PARAM")
            {
                continue;
            }

            if (param.Type.StartsWith("OBJ_ARRAY:"))
            {
                needsUnsafeContext = true;
                string elemType = param.Type["OBJ_ARRAY:".Length..];
                string elemCsType = TypeMapper.MapType(elemType + "*");
                string csParamName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));

                csParams.Add($"{elemCsType}[] {csParamName}");

                bool nextIsCount = pi + 1 < method.Parameters.Count &&
                    method.Parameters[pi + 1].Type is "NS::UInteger" &&
                    method.Parameters[pi + 1].Name is "count";

                string ptrVar = $"p{TypeMapper.ToPascalCase(param.Name)}";
                arraySetupLines.Add($"        nint* {ptrVar} = stackalloc nint[{csParamName}.Length];");
                arraySetupLines.Add($"        for (int i = 0; i < {csParamName}.Length; i++)");
                arraySetupLines.Add("        {");
                arraySetupLines.Add($"            {ptrVar}[i] = {csParamName}[i].NativePtr;");
                arraySetupLines.Add("        }");

                callArgs.Add($"(nint){ptrVar}");
                callArgTypes.Add("nint");

                if (nextIsCount)
                {
                    callArgs.Add($"(nuint){csParamName}.Length");
                    callArgTypes.Add("nuint");
                    pi++;
                }
                continue;
            }

            if (param.Type.StartsWith("PRIM_ARRAY:"))
            {
                needsUnsafeContext = true;
                string elemType = param.Type["PRIM_ARRAY:".Length..];
                string csParamName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));

                csParams.Add($"{elemType}[] {csParamName}");

                string ptrVar = $"p{TypeMapper.ToPascalCase(param.Name)}";
                arraySetupLines.Add($"        {elemType}* {ptrVar} = stackalloc {elemType}[{csParamName}.Length];");
                arraySetupLines.Add($"        for (int i = 0; i < {csParamName}.Length; i++)");
                arraySetupLines.Add("        {");
                arraySetupLines.Add($"            {ptrVar}[i] = {csParamName}[i];");
                arraySetupLines.Add("        }");

                callArgs.Add($"(nint){ptrVar}");
                callArgTypes.Add("nint");
                continue;
            }

            if (param.Type.StartsWith("STRUCT_ARRAY:"))
            {
                needsUnsafeContext = true;
                string elemType = param.Type["STRUCT_ARRAY:".Length..];
                string elemCsType = TypeMapper.MapType(elemType);
                string csParamName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));

                csParams.Add($"{elemCsType}[] {csParamName}");

                bool nextIsCount = pi + 1 < method.Parameters.Count &&
                    method.Parameters[pi + 1].Type is "NS::UInteger" &&
                    method.Parameters[pi + 1].Name is "count";

                string ptrVar = $"p{TypeMapper.ToPascalCase(param.Name)}";
                fixedStatements.Add($"fixed ({elemCsType}* {ptrVar} = {csParamName})");

                callArgs.Add($"(nint){ptrVar}");
                callArgTypes.Add("nint");

                if (nextIsCount)
                {
                    callArgs.Add($"(nuint){csParamName}.Length");
                    callArgTypes.Add("nuint");
                    pi++;
                }
                continue;
            }

            if (param.Type.StartsWith("INLINE_BLOCK:"))
            {
                string delegateName = param.Type["INLINE_BLOCK:".Length..];
                string csParamName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));
                csParams.Add($"{delegateName} {csParamName}");
                callArgs.Add($"{csParamName}.NativePtr");
                callArgTypes.Add("nint");
                continue;
            }

            if (IsBlockHandlerType(param.Type))
            {
                string csType = TypeMapper.MapType(param.Type);
                string csParamName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));
                csParams.Add($"{csType} {csParamName}");
                callArgs.Add($"{csParamName}.NativePtr");
                callArgTypes.Add("nint");
                continue;
            }

            string csParamType = TypeMapper.MapType(param.Type);
            string paramName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));

            // Autoreleased* types → out parameters (strip "Autoreleased" prefix to resolve underlying type)
            if (param.Type.Contains("Autoreleased"))
            {
                string resolvedType = param.Type.Replace("Autoreleased", "");
                string csType = TypeMapper.MapType(resolvedType);
                string ptrVarName = $"{paramName}Ptr";
                csParams.Add($"out {csType} {paramName}");
                callArgs.Add($"out nint {ptrVarName}");
                callArgTypes.Add("out nint");
                autoreleasedOutParams.Add((csType, paramName, ptrVarName));
                continue;
            }

            if (param.Type.Contains("Error**"))
            {
                csParams.Add("out NSError error");
                callArgs.Add("out nint errorPtr");
                callArgTypes.Add("out nint");
                continue;
            }

            if (param.Type.Contains("Timestamp*") && !param.Type.Contains("TimestampGranularity"))
            {
                csParams.Add($"out ulong {paramName}");
                callArgs.Add($"out {paramName}");
                callArgTypes.Add("out ulong");
                continue;
            }

            csParams.Add($"{csParamType} {paramName}");

            if (csParamType == "NSArray")
            {
                string? paramArrayElemType = TryResolveNSArrayElementType(csClassName, csMethodName);
                if (paramArrayElemType != null)
                {
                    csParams[^1] = $"{paramArrayElemType}[] {paramName}";
                    string ptrVar = $"p{TypeMapper.ToPascalCase(param.Name)}";
                    arraySetupLines.Add($"        nint {ptrVar} = NSArray.FromArray({paramName});");
                    callArgs.Add(ptrVar);
                    nsArrayReleaseVars.Add(ptrVar);
                }
                else
                {
                    callArgs.Add($"{paramName}");
                }
                callArgTypes.Add("nint");
            }
            else if (typeMapper.IsNativeObjectType(csParamType))
            {
                callArgs.Add($"{paramName}.NativePtr");
                callArgTypes.Add("nint");
            }
            else if (typeMapper.IsEnumType(csParamType))
            {
                callArgs.Add($"{typeMapper.GetEnumSetCast(csParamType)}{paramName}");
                string castType = typeMapper.GetEnumSetCast(csParamType).TrimStart('(').TrimEnd(')');
                callArgTypes.Add(castType);
            }
            // For P/Invoke signature tracking: map bool → Bool8 since bool is not
            // blittable in LibraryImport; all other types pass through unchanged.
            else
            {
                callArgs.Add(paramName);
                callArgTypes.Add(csParamType == "bool" ? "Bool8" : csParamType);
            }
        }

        string paramStr = string.Join(", ", csParams);
        string argsStr = string.Join(", ", callArgs);
        string staticKw = isStaticClassMethod ? "static " : "";
        string unsafeKw = needsUnsafeContext ? "unsafe " : "";
        string csReturnType = returnsArray ? $"{returnArrayElemType}[]" : (isVoid ? "void" : returnType);

        if (method.DeprecationMessage != null)
        {
            sb.AppendLine("    /// <summary>");
            sb.AppendLine($"    /// Deprecated: {method.DeprecationMessage}");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine($"    [Obsolete(\"{method.DeprecationMessage}\")]");
        }

        sb.AppendLine($"    public {staticKw}{unsafeKw}{csReturnType} {csMethodName}({paramStr})");
        sb.AppendLine("    {");

        foreach (string line in arraySetupLines)
        {
            sb.AppendLine(line);
        }

        if (arraySetupLines.Count > 0)
        {
            sb.AppendLine();
        }

        string indent = "        ";
        foreach (string fixedStmt in fixedStatements)
        {
            sb.AppendLine($"{indent}{fixedStmt}");
            sb.AppendLine($"{indent}{{");
            indent += "    ";
        }

        string[] argTypesArray = [.. callArgTypes];
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
            msgSendExpr = $"ObjectiveC.{msgSend}({argsStr})";
        }

        if (isVoid)
        {
            sb.AppendLine($"{indent}{msgSendExpr};");
            foreach ((string csType, string csParamName, string ptrVar) in autoreleasedOutParams)
            {
                sb.AppendLine();
                sb.AppendLine($"{indent}{csParamName} = new({ptrVar}, NativeObjectOwnership.Owned);");
            }
            if (hasOutError)
            {
                sb.AppendLine();
                sb.AppendLine($"{indent}error = new(errorPtr, NativeObjectOwnership.Owned);");
            }
            foreach (string rv in nsArrayReleaseVars)
            {
                sb.AppendLine();
                sb.AppendLine($"{indent}ObjectiveC.Release({rv});");
            }
        }
        else if (returnsArray || nullable)
        {
            sb.AppendLine($"{indent}nint nativePtr = {msgSendExpr};");
            foreach ((string csType, string csParamName, string ptrVar) in autoreleasedOutParams)
            {
                sb.AppendLine();
                sb.AppendLine($"{indent}{csParamName} = new({ptrVar}, NativeObjectOwnership.Owned);");
            }
            if (hasOutError)
            {
                sb.AppendLine();
                sb.AppendLine($"{indent}error = new(errorPtr, NativeObjectOwnership.Owned);");
            }
            foreach (string rv in nsArrayReleaseVars)
            {
                sb.AppendLine();
                sb.AppendLine($"{indent}ObjectiveC.Release({rv});");
            }
            sb.AppendLine();
            sb.AppendLine(returnsArray
                ? $"{indent}return NSArray.ToArray<{returnArrayElemType}>(nativePtr);"
                : $"{indent}return new(nativePtr, NativeObjectOwnership.Owned);");
        }
        else if (hasOutError || autoreleasedOutParams.Count > 0)
        {
            sb.AppendLine($"{indent}{csReturnType} result = {msgSendExpr};");
            foreach ((string csType, string csParamName, string ptrVar) in autoreleasedOutParams)
            {
                sb.AppendLine();
                sb.AppendLine($"{indent}{csParamName} = new({ptrVar}, NativeObjectOwnership.Owned);");
            }
            if (hasOutError)
            {
                sb.AppendLine();
                sb.AppendLine($"{indent}error = new(errorPtr, NativeObjectOwnership.Owned);");
            }
            sb.AppendLine();
            sb.AppendLine($"{indent}return result;");
        }
        else
        {
            sb.AppendLine($"{indent}return {msgSendExpr};");
        }

        for (int fi = fixedStatements.Count - 1; fi >= 0; fi--)
        {
            indent = "        " + new string(' ', fi * 4);
            sb.AppendLine($"{indent}}}");
        }

        sb.AppendLine("    }");
    }

    /// <summary>
    /// Builds a C# method name from a multi-part ObjC selector.
    /// E.g., "presentDrawable:atTime:" → "PresentDrawableAtTime"
    /// E.g., "newBufferWithLength:options:" → "NewBufferWithLengthOptions"
    /// </summary>
    static string BuildMethodNameFromSelector(string selector)
    {
        ReadOnlySpan<char> remaining = selector.AsSpan();
        StringBuilder sb = new();

        while (!remaining.IsEmpty)
        {
            int colon = remaining.IndexOf(':');
            ReadOnlySpan<char> part = colon < 0 ? remaining : remaining[..colon];

            if (!part.IsEmpty)
            {
                sb.Append(char.ToUpper(part[0]));
                if (part.Length > 1)
                {
                    sb.Append(part[1..]);
                }
            }

            remaining = colon < 0 ? [] : remaining[(colon + 1)..];
        }

        return sb.ToString();
    }

    /// <summary>
    /// Simplifies a method name by using just the first selector part and stripping
    /// any "With..." suffix. E.g., "newBufferWithLength" → "NewBuffer",
    /// "signalEvent" → "SignalEvent", "newTensorWithDescriptor" → "NewTensor".
    /// </summary>
    static string SimplifyMethodName(string selectorFirstPart)
    {
        string pascal = TypeMapper.ToPascalCase(selectorFirstPart);

        int idx = 0;
        while (idx < pascal.Length)
        {
            idx = pascal.IndexOf("With", idx, StringComparison.Ordinal);
            if (idx <= 0)
            {
                break;
            }

            if (idx + 4 < pascal.Length && char.IsUpper(pascal[idx + 4]))
            {
                return pascal[..idx];
            }

            idx += 4;
        }

        return pascal;
    }

    /// <summary>
    /// Computes a parameter type signature key for method overload conflict detection.
    /// Handles array merging (OBJ_ARRAY + count → single array param) and error out params.
    /// </summary>
    static string ComputeParamTypesKey(MethodInfo method)
    {
        List<string> types = [];
        for (int i = 0; i < method.Parameters.Count; i++)
        {
            ParamDef p = method.Parameters[i];

            if (p.Type is "ARRAY_PARAM")
            {
                continue;
            }

            if (p.Type.StartsWith("OBJ_ARRAY:") || p.Type.StartsWith("STRUCT_ARRAY:"))
            {
                types.Add(TypeMapper.MapType(ExtractArrayElementType(p.Type) + "*") + "[]");
                i += SkipCountParam(method, i);
                continue;
            }

            if (p.Type.StartsWith("PRIM_ARRAY:"))
            {
                types.Add(ExtractArrayElementType(p.Type) + "[]");
                continue;
            }

            if (p.Type.Contains("Error**"))
            {
                types.Add("out:NSError");
                continue;
            }

            types.Add(TypeMapper.MapType(p.Type));
        }
        return string.Join(',', types);

        static string ExtractArrayElementType(string type) => type[(type.IndexOf(':') + 1)..];

        static int SkipCountParam(MethodInfo method, int currentIndex) =>
            currentIndex + 1 < method.Parameters.Count &&
            method.Parameters[currentIndex + 1].Type is "NS::UInteger" &&
            method.Parameters[currentIndex + 1].Name is "count" ? 1 : 0;
    }

    /// <summary>
    /// Pre-computes simplified C# method names for multi-part selector methods.
    /// Detects parameter type signature conflicts and falls back to full selector names
    /// when simplification would create ambiguous overloads (e.g., two methods with the same
    /// simplified name and identical parameter types like presentDrawable:atTime: and
    /// presentDrawable:afterMinimumDuration:).
    /// </summary>
    static Dictionary<MethodInfo, string> ComputeSimplifiedMethodNames(List<MethodInfo> methods, List<PropertyDef> properties)
    {
        Dictionary<MethodInfo, string> result = [];

        HashSet<string> propertyNames = [.. properties.Select(p => TypeMapper.ToPascalCase(p.Getter.Name))];

        List<(MethodInfo Method, string Simplified, string Full, string ParamKey)> entries = [];
        foreach (MethodInfo m in methods)
        {
            if (m.Selector?.Contains(':') != true)
            {
                continue;
            }

            string firstPart = m.Selector[..m.Selector.IndexOf(':')];
            entries.Add((m, SimplifyMethodName(firstPart), BuildMethodNameFromSelector(m.Selector), ComputeParamTypesKey(m)));
        }

        foreach (var group in entries.GroupBy(e => (e.Simplified, e.ParamKey)))
        {
            List<(MethodInfo Method, string Simplified, string Full, string ParamKey)> items = [.. group];

            bool hasConflict = items.Count > 1 || propertyNames.Contains(items[0].Simplified);
            foreach (var (method, simplified, full, _) in items)
            {
                result[method] = hasConflict ? full : simplified;
            }
        }

        return result;
    }

    #endregion
}
