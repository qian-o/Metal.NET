namespace Metal.NET.Generator;

partial class CSharpEmitter
{
    #region Delegate Generation

    /// <summary>
    /// Generates Metal/MTLDelegates.cs containing sealed handler classes that inherit
    /// NativeBlock. Each class wraps a managed Action callback and bridges it to native
    /// code via an [UnmanagedCallersOnly] trampoline.
    /// </summary>
    void GenerateDelegateFile()
    {
        string dir = Path.Combine(outputDir, "Metal");
        Directory.CreateDirectory(dir);

        StringBuilder sb = new();
        sb.AppendLine("using System.Runtime.CompilerServices;");
        sb.AppendLine("using System.Runtime.InteropServices;");
        sb.AppendLine();
        sb.AppendLine("namespace Metal.NET;");

        foreach (BlockTypeAlias alias in context.BlockTypeAliases.OrderBy(a => a.CsDelegateName))
        {
            // Skip the first parameter (block pointer) – it's always nint block
            List<BlockParam> callbackParams = [.. alias.Parameters.Skip(1)];

            // Build the strong-typed Action<> argument types and trampoline body
            List<string> actionTypeArgs = [];
            List<string> trampolineArgs = [];
            List<string> callbackArgs = [];

            foreach (BlockParam p in callbackParams)
            {
                string strongType = ResolveStrongType(p);
                actionTypeArgs.Add(strongType);

                // Trampoline receives the low-level type
                trampolineArgs.Add($"{p.CsType} {p.Name}");

                // If the strong type is a NativeObject, wrap it; otherwise pass through
                if (strongType != p.CsType)
                {
                    callbackArgs.Add($"new {strongType}({p.Name}, NativeObjectOwnership.Borrowed)");
                }
                else
                {
                    callbackArgs.Add(p.Name);
                }
            }

            string actionType = actionTypeArgs.Count > 0
                ? $"Action<{string.Join(", ", actionTypeArgs)}>"
                : "Action";

            // Build the delegate* unmanaged type for the constructor: <nint, param types..., void>
            List<string> fPtrTypeArgs = ["nint"]; // block pointer
            foreach (BlockParam p in callbackParams)
            {
                fPtrTypeArgs.Add(p.CsType);
            }
            fPtrTypeArgs.Add("void");
            string fPtrType = $"delegate* unmanaged[Cdecl]<{string.Join(", ", fPtrTypeArgs)}>";

            // Trampoline parameter list (includes nint block as first)
            string trampolineParamStr = callbackParams.Count > 0
                ? $"nint block, {string.Join(", ", trampolineArgs)}"
                : "nint block";

            sb.AppendLine();
            sb.AppendLine($"public sealed unsafe class {alias.CsDelegateName}({actionType} callback) : NativeBlock((nint)({fPtrType})&Trampoline, callback)");
            sb.AppendLine("{");
            sb.AppendLine("    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]");
            sb.AppendLine($"    private static void Trampoline({trampolineParamStr})");
            sb.AppendLine("    {");
            sb.AppendLine($"        {actionType} callback = GetContext<{actionType}>(block);");
            sb.AppendLine();
            sb.AppendLine($"        callback({string.Join(", ", callbackArgs)});");
            sb.AppendLine("    }");
            sb.AppendLine("}");
        }

        File.WriteAllText(Path.Combine(dir, "MTLDelegates.cs"), sb.ToString(), Utf8Bom);
        Console.WriteLine($"  Generated: Metal/MTLDelegates.cs ({context.BlockTypeAliases.Count} handler classes)");
    }

    /// <summary>
    /// Resolves the strong C# type for a block parameter.
    /// Pointer types that map to known NativeObject classes get their class name;
    /// value types (ulong, long, nuint, nint from void*) pass through unchanged.
    /// </summary>
    static string ResolveStrongType(BlockParam param)
    {
        // Value types pass through directly
        if (!param.ObjCType.TrimEnd().EndsWith('*'))
        {
            return param.CsType;
        }

        // void* stays as nint (e.g., MTLDeallocator's pointer param)
        string stripped = param.ObjCType.TrimEnd().TrimEnd('*').Trim();
        if (stripped is "void" or "")
        {
            return "nint";
        }

        // Pointers to value types stay as nint (e.g., BOOL * stop flag)
        if (stripped is "BOOL" or "bool" or "int" or "float" or "double"
            or "char" or "short" or "long" or "unsigned" or "unichar"
            or "uint8_t" or "uint16_t" or "uint32_t" or "uint64_t"
            or "int8_t" or "int16_t" or "int32_t" or "int64_t"
            or "size_t" or "NSUInteger" or "NSInteger"
            || stripped.StartsWith("const "))
        {
            return "nint";
        }

        // Use TypeMapper to resolve the strong type (ObjC object pointers)
        return TypeMapper.MapType(param.ObjCType);
    }

    #endregion
}
