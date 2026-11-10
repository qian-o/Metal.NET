namespace Metal.NET.Generator;

partial class CSharpEmitter
{
    #region Free Function Emission

    /// <summary>
    /// Builds the shared parameter lists for a free function (P/Invoke params, wrapper params, call args).
    /// </summary>
    (string PInvokeReturnType, string PInvokeParams, string WrapperParams, string CallArgs, string CsReturnType, string? ArrayElemType, List<(string CsType, string CsName, string PtrVar)> OutParams)
        BuildFreeFunctionSignature(FreeFunctionDef func, string csClassName)
    {
        string csReturnType = TypeMapper.MapType(func.ReturnType);

        string? returnArrayElemType = null;
        if (csReturnType == "NSArray")
        {
            returnArrayElemType = TryResolveNSArrayElementType(csClassName, func.Name);
        }
        bool returnsArray = returnArrayElemType != null;
        bool nullable = !returnsArray && typeMapper.IsNativeObjectType(csReturnType);

        List<string> pinvokeParams = [];
        List<string> wrapperParams = [];
        List<string> callArgs = [];
        List<(string CsType, string CsName, string PtrVar)> outParams = [];

        foreach (ParamDef p in func.Parameters)
        {
            string csName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(p.Name));

            if (p.Type.StartsWith("Autoreleased"))
            {
                string csType = TypeMapper.MapType(p.Type["Autoreleased".Length..]);
                string ptrVar = $"{csName}Ptr";
                pinvokeParams.Add($"out nint {csName}");
                wrapperParams.Add($"out {csType} {csName}");
                callArgs.Add($"out nint {ptrVar}");
                outParams.Add((csType, csName, ptrVar));
                continue;
            }

            string csParamType = TypeMapper.MapType(p.Type);

            if (typeMapper.IsNativeObjectType(csParamType) || context.BlockTypeAliases.Any(b => b.CsDelegateName == csParamType))
            {
                pinvokeParams.Add($"nint {csName}");
                wrapperParams.Add($"{csParamType} {csName}");
                callArgs.Add($"{csName}.NativePtr");
            }
            else
            {
                pinvokeParams.Add($"{csParamType} {csName}");
                wrapperParams.Add($"{csParamType} {csName}");
                callArgs.Add(csName);
            }
        }

        string pinvokeReturnType = (nullable || returnsArray) ? "nint" : csReturnType;

        return (pinvokeReturnType, string.Join(", ", pinvokeParams), string.Join(", ", wrapperParams),
            string.Join(", ", callArgs), csReturnType, returnArrayElemType, outParams);
    }

    /// <summary>
    /// Emits the public static wrapper method for a free function.
    /// </summary>
    void EmitFreeFunctionWrapper(StringBuilder sb, FreeFunctionDef func, string csClassName)
    {
        var sig = BuildFreeFunctionSignature(func, csClassName);
        bool returnsArray = sig.ArrayElemType != null;
        bool nullable = !returnsArray && typeMapper.IsNativeObjectType(sig.CsReturnType);

        string csFullReturnType = returnsArray ? $"NSArray<{sig.ArrayElemType}>" : sig.CsReturnType;

        if (returnsArray || nullable)
        {
            sb.AppendLine($"    public static {csFullReturnType} {func.Name}({sig.WrapperParams})");
            sb.AppendLine("    {");
            sb.AppendLine($"        nint nativePtr = {func.CEntryPoint}({sig.CallArgs});");
            foreach ((_, string csName, string ptrVar) in sig.OutParams)
            {
                sb.AppendLine();
                sb.AppendLine($"        {csName} = new({ptrVar});");
            }
            sb.AppendLine();
            sb.AppendLine("        return new(nativePtr);");
            sb.AppendLine("    }");
        }
        else if (sig.CsReturnType == "void")
        {
            sb.AppendLine($"    public static void {func.Name}({sig.WrapperParams})");
            sb.AppendLine("    {");
            sb.AppendLine($"        {func.CEntryPoint}({sig.CallArgs});");
            sb.AppendLine("    }");
        }
        else
        {
            sb.AppendLine($"    public static {sig.CsReturnType} {func.Name}({sig.WrapperParams})");
            sb.AppendLine("    {");
            sb.AppendLine($"        return {func.CEntryPoint}({sig.CallArgs});");
            sb.AppendLine("    }");
        }
    }

    /// <summary>
    /// Emits the <c>[LibraryImport]</c> P/Invoke declaration for a free function.
    /// </summary>
    void EmitFreeFunctionPInvoke(StringBuilder sb, FreeFunctionDef func, string csClassName)
    {
        var sig = BuildFreeFunctionSignature(func, csClassName);

        sb.AppendLine($"    [LibraryImport(\"{func.LibraryPath}\", EntryPoint = \"{func.CEntryPoint}\")]");
        sb.AppendLine($"    private static partial {sig.PInvokeReturnType} {func.CEntryPoint}({sig.PInvokeParams});");
    }

    #endregion
}
