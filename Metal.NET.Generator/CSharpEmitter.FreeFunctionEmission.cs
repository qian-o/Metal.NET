namespace Metal.NET.Generator;

/// <summary>
/// Emits C# source files from parsed metal-ast.json definitions.
/// Generates enum types, NativeObject-based classes with properties/methods, and P/Invoke free functions.
/// Also auto-generates Common/ObjectiveC.cs with all required MsgSend overloads.
/// </summary>
partial class CSharpEmitter
{
    #region Free Function Emission

    /// <summary>
    /// Emits a free function as a <c>[LibraryImport]</c> P/Invoke declaration followed
    /// by a public static wrapper that handles <c>NativeObject</c> marshalling.
    /// </summary>
    void EmitFreeFunction(StringBuilder sb, FreeFunctionDef func, string csClassName)
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
        foreach (ParamDef p in func.Parameters)
        {
            string csType = TypeMapper.MapType(p.Type);
            if (typeMapper.IsNativeObjectType(csType))
            {
                pinvokeParams.Add($"nint {TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(p.Name))}");
            }
            else
            {
                pinvokeParams.Add($"{csType} {TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(p.Name))}");
            }
        }

        string pinvokeReturnType = (nullable || returnsArray) ? "nint" : csReturnType;

        sb.AppendLine($"    [LibraryImport(\"{func.LibraryPath}\", EntryPoint = \"{func.CEntryPoint}\")]");
        sb.AppendLine($"    private static partial {pinvokeReturnType} {func.CEntryPoint}({string.Join(", ", pinvokeParams)});");
        sb.AppendLine();

        List<string> wrapperParams = [];
        List<string> callArgs = [];
        foreach (ParamDef p in func.Parameters)
        {
            string csType = TypeMapper.MapType(p.Type);
            string csName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(p.Name));
            if (typeMapper.IsNativeObjectType(csType))
            {
                wrapperParams.Add($"{csType} {csName}");
                callArgs.Add($"{csName}.NativePtr");
            }
            else
            {
                wrapperParams.Add($"{csType} {csName}");
                callArgs.Add(csName);
            }
        }

        string csFullReturnType = returnsArray ? $"{returnArrayElemType}[]" : csReturnType;
        string wrapperParamStr = string.Join(", ", wrapperParams);
        string callArgStr = string.Join(", ", callArgs);

        if (returnsArray)
        {
            sb.AppendLine($"    public static {csFullReturnType} {func.Name}({wrapperParamStr})");
            sb.AppendLine("    {");
            sb.AppendLine($"        nint nativePtr = {func.CEntryPoint}({callArgStr});");
            sb.AppendLine();
            sb.AppendLine($"        {returnArrayElemType}[] result = NSArray.ToArray<{returnArrayElemType}>(nativePtr);");
            sb.AppendLine();
            sb.AppendLine("        ObjectiveC.Release(nativePtr);");
            sb.AppendLine();
            sb.AppendLine("        return result;");
            sb.AppendLine("    }");
        }
        else if (nullable)
        {
            sb.AppendLine($"    public static {csFullReturnType} {func.Name}({wrapperParamStr})");
            sb.AppendLine("    {");
            sb.AppendLine($"        nint nativePtr = {func.CEntryPoint}({callArgStr});");
            sb.AppendLine();
            sb.AppendLine("        return new(nativePtr, NativeObjectOwnership.Owned);");
            sb.AppendLine("    }");
        }
        else if (csReturnType == "void")
        {
            sb.AppendLine($"    public static void {func.Name}({wrapperParamStr}) => {func.CEntryPoint}({callArgStr});");
        }
        else
        {
            sb.AppendLine($"    public static {csReturnType} {func.Name}({wrapperParamStr}) => {func.CEntryPoint}({callArgStr});");
        }
    }

    #endregion
}
