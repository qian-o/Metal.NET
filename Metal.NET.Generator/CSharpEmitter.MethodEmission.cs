namespace Metal.NET.Generator;

partial class CSharpEmitter
{
    #region Method Emission

    /// <summary>
    /// Emits a single method into <paramref name="sb"/>, handling parameter marshalling
    /// (arrays, blocks, out-params, enums) and selecting the correct <c>MsgSend</c> variant.
    /// </summary>
    void EmitMethod(StringBuilder sb, MethodInfo method, string csClassName, SortedDictionary<string, string> selectors, HashSet<string> knownDelegateNames)
    {
        string selectorObjC;
        string csMethodName = TypeMapper.ToPascalCase(method.Name);

        if (method.Selector != null)
        {
            selectorObjC = method.Selector;
        }
        else
        {
            int colonCount = method.Parameters.Count;
            selectorObjC = method.Name + (colonCount > 0 ? new string(':', colonCount) : "");
        }

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
                    method.Parameters[pi + 1] is { Type: "NS::UInteger" or "ARRAY_PARAM", Name: "count" };

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
                    method.Parameters[pi + 1] is { Type: "NS::UInteger" or "ARRAY_PARAM", Name: "count" };

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

            if (IsBlockHandlerType(param.Type, knownDelegateNames))
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
            EmitDeprecation(sb, method.DeprecationMessage);
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
            if (TypeMapper.NeedsNarrowCast(returnType))
            {
                msgSendExpr = $"({returnType})ObjectiveC.{msgSend}({argsStr})";
            }
            else
            {
                msgSendExpr = $"ObjectiveC.{msgSend}({argsStr})";
            }
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
            if (nsArrayReleaseVars.Count > 0)
            {
                sb.AppendLine();
                foreach (string rv in nsArrayReleaseVars)
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
            if (nsArrayReleaseVars.Count > 0)
            {
                sb.AppendLine();
                foreach (string rv in nsArrayReleaseVars)
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
    /// Emits a parameterized constructor from an ObjC <c>init</c> method.
    /// Pattern: <c>public ClassName(params) : this(ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(Bindings.Class), Bindings.InitSelector, args), NativeObjectOwnership.Managed)</c>
    /// </summary>
    void EmitInitStaticMethod(StringBuilder sb, MethodInfo method, string csClassName, SortedDictionary<string, string> selectors)
    {
        string selectorObjC = method.Selector!;
        string selectorKey = BuildMethodNameFromSelector(selectorObjC);
        selectors.TryAdd(selectorKey, selectorObjC);

        string selectorRef = $"{csClassName}Bindings.{selectorKey}";

        List<string> csParams = [];
        List<string> callArgs = [$"ObjectiveC.Alloc({csClassName}Bindings.Class)", selectorRef];
        List<string> callArgTypes = [];
        List<string> arraySetupLines = [];
        List<string> fixedStatements = [];
        List<string> nsArrayReleaseVars = [];
        bool hasOutError = method.Parameters.Any(p => p.Type.Contains("Error**"));
        bool needsUnsafeContext = false;

        for (int pi = 0; pi < method.Parameters.Count; pi++)
        {
            ParamDef param = method.Parameters[pi];
            if (param.Type == "ARRAY_PARAM")
            {
                continue;
            }

            if (param.Type.Contains("Error**"))
            {
                csParams.Add("out NSError error");
                callArgs.Add("out nint errorPtr");
                callArgTypes.Add("out nint");
                continue;
            }

            // NSArray/NSDictionary are static helper classes, pass as raw nint
            if (param.Type.StartsWith("NSDictionary"))
            {
                string csParamName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));
                csParams.Add($"nint {csParamName}");
                callArgs.Add(csParamName);
                callArgTypes.Add("nint");
                continue;
            }

            // NSArray param with known element type → typed array + NSArray.FromArray
            if (param.Type.StartsWith("NSARRAY_PARAM:"))
            {
                string elemModelType = param.Type["NSARRAY_PARAM:".Length..];
                string elemCsType = TypeMapper.MapType(elemModelType);
                string csParamName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));

                csParams.Add($"{elemCsType}[] {csParamName}");

                string ptrVar = $"p{TypeMapper.ToPascalCase(param.Name)}";
                arraySetupLines.Add($"        nint {ptrVar} = NSArray.FromArray({csParamName});");
                nsArrayReleaseVars.Add(ptrVar);

                callArgs.Add(ptrVar);
                callArgTypes.Add("nint");
                continue;
            }

            // NSArray without generic info → raw nint
            if (param.Type.StartsWith("NSArray"))
            {
                string csParamName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));
                csParams.Add($"nint {csParamName}");
                callArgs.Add(csParamName);
                callArgTypes.Add("nint");
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
                    method.Parameters[pi + 1] is { Type: "NS::UInteger" or "ARRAY_PARAM", Name: "count" };

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
                    method.Parameters[pi + 1] is { Type: "NS::UInteger" or "ARRAY_PARAM", Name: "count" };

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

            string csParamType = TypeMapper.MapType(param.Type);
            string paramName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));

            csParams.Add($"{csParamType} {paramName}");

            if (typeMapper.IsNativeObjectType(csParamType))
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
            else
            {
                callArgs.Add(paramName);
                callArgTypes.Add(csParamType == "bool" ? "Bool8" : csParamType);
            }
        }

        string paramStr = string.Join(", ", csParams);
        string argsStr = string.Join(", ", callArgs);
        string csMethodName = TypeMapper.ToPascalCase(selectorKey);
        string unsafeKw = needsUnsafeContext ? "unsafe " : "";

        RecordMsgSend("MsgSendNInt", [.. callArgTypes]);

        if (method.DeprecationMessage != null)
        {
            EmitDeprecation(sb, method.DeprecationMessage);
        }

        sb.AppendLine($"    public static {unsafeKw}{csClassName} {csMethodName}({paramStr})");
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

        if (hasOutError)
        {
            sb.AppendLine($"{indent}nint nativePtr = ObjectiveC.MsgSendNInt({argsStr});");
            sb.AppendLine();
            sb.AppendLine($"{indent}error = new(errorPtr, NativeObjectOwnership.Owned);");
            if (nsArrayReleaseVars.Count > 0)
            {
                sb.AppendLine();
                foreach (string rv in nsArrayReleaseVars)
                    sb.AppendLine($"{indent}ObjectiveC.Release({rv});");
            }
            sb.AppendLine();
            sb.AppendLine($"{indent}return new(nativePtr, NativeObjectOwnership.Managed);");
        }
        else
        {
            sb.AppendLine($"{indent}nint nativePtr = ObjectiveC.MsgSendNInt({argsStr});");
            if (nsArrayReleaseVars.Count > 0)
            {
                sb.AppendLine();
                foreach (string rv in nsArrayReleaseVars)
                    sb.AppendLine($"{indent}ObjectiveC.Release({rv});");
            }
            sb.AppendLine();
            sb.AppendLine($"{indent}return new(nativePtr, NativeObjectOwnership.Managed);");
        }

        for (int fi = fixedStatements.Count - 1; fi >= 0; fi--)
        {
            indent = "        " + new string(' ', fi * 4);
            sb.AppendLine($"{indent}}}");
        }

        sb.AppendLine("    }");
    }

    #endregion
}
