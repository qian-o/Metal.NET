namespace Metal.NET.Generator;

partial class CSharpEmitter
{
    #region Free Function Emission

    /// <summary>
    /// Builds the shared parameter lists for a free function (P/Invoke params, wrapper params, call args).
    /// </summary>
    (string PInvokeReturnType, string PInvokeParams, string WrapperParams, string CallArgs, string CsReturnType, string? ArrayElemType)
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

        foreach (ParamDef p in func.Parameters)
        {
            string csType = TypeMapper.MapType(p.Type);
            string csName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(p.Name));

            if (typeMapper.IsNativeObjectType(csType))
            {
                pinvokeParams.Add($"nint {csName}");
                wrapperParams.Add($"{csType} {csName}");
                callArgs.Add($"{csName}.NativePtr");
            }
            else
            {
                pinvokeParams.Add($"{csType} {csName}");
                wrapperParams.Add($"{csType} {csName}");
                callArgs.Add(csName);
            }
        }

        string pinvokeReturnType = (nullable || returnsArray) ? "nint" : csReturnType;

        return (pinvokeReturnType, string.Join(", ", pinvokeParams), string.Join(", ", wrapperParams),
            string.Join(", ", callArgs), csReturnType, returnArrayElemType);
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

        if (returnsArray)
        {
            sb.AppendLine($"    public static {csFullReturnType} {func.Name}({sig.WrapperParams})");
            sb.AppendLine("    {");
            sb.AppendLine($"        return new({func.CEntryPoint}({sig.CallArgs}), NativeObjectOwnership.Owned);");
            sb.AppendLine("    }");
        }
        else if (nullable)
        {
            sb.AppendLine($"    public static {csFullReturnType} {func.Name}({sig.WrapperParams})");
            sb.AppendLine("    {");
            sb.AppendLine($"        nint nativePtr = {func.CEntryPoint}({sig.CallArgs});");
            sb.AppendLine();
            sb.AppendLine("        return new(nativePtr, NativeObjectOwnership.Owned);");
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
