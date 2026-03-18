namespace Metal.NET.Generator;

/// <summary>
/// Emits C# source files from parsed metal-ast.json definitions.
/// Generates enum types, NativeObject-based classes with properties/methods, and P/Invoke free functions.
/// Also auto-generates Common/ObjectiveC.cs with all required MsgSend overloads.
/// </summary>
partial class CSharpEmitter
{
    #region ObjectiveC.cs Generation

    /// <summary>
    /// Generates the auto-generated Common/ObjectiveC.cs file containing all required
    /// MsgSend overloads using delegate* unmanaged function pointers, null-guard wrappers,
    /// and Alloc/Init/Release helpers.
    /// Signatures are collected during property/method emission via RecordMsgSend().
    /// </summary>
    void GenerateObjectiveCFile()
    {
        string dir = Path.Combine(outputDir, "Common");
        Directory.CreateDirectory(dir);

        StringBuilder sb = new();
        sb.AppendLine("using System.Runtime.InteropServices;");
        sb.AppendLine();
        sb.AppendLine("namespace Metal.NET;");
        sb.AppendLine();
        sb.AppendLine("internal static unsafe partial class ObjectiveC");
        sb.AppendLine("{");

        sb.AppendLine("    private static readonly nint msgSend;");
        sb.AppendLine();
        sb.AppendLine("    static ObjectiveC()");
        sb.AppendLine("    {");
        sb.AppendLine("        string[] frameworks =");
        sb.AppendLine("        [");
        sb.AppendLine("            \"CoreGraphics\",");
        sb.AppendLine("            \"QuartzCore\",");
        sb.AppendLine("            \"AppKit\",");
        sb.AppendLine("            \"Metal\",");
        sb.AppendLine("            \"MetalFX\",");
        sb.AppendLine("            \"MetalKit\"");
        sb.AppendLine("        ];");
        sb.AppendLine();
        sb.AppendLine("        foreach (string framework in frameworks)");
        sb.AppendLine("        {");
        sb.AppendLine("            NativeLibrary.TryLoad(framework, out _);");
        sb.AppendLine("        }");
        sb.AppendLine();
        sb.AppendLine("        msgSend = NativeLibrary.GetExport(NativeLibrary.Load(\"/usr/lib/libobjc.A.dylib\"), \"objc_msgSend\");");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine("    #region Class and Selector Lookups");
        sb.AppendLine();
        sb.AppendLine("    [LibraryImport(\"/usr/lib/libobjc.A.dylib\", EntryPoint = \"objc_getClass\", StringMarshalling = StringMarshalling.Utf8)]");
        sb.AppendLine("    private static partial nint _GetClass(string name);");
        sb.AppendLine();
        sb.AppendLine("    [LibraryImport(\"/usr/lib/libobjc.A.dylib\", EntryPoint = \"sel_registerName\", StringMarshalling = StringMarshalling.Utf8)]");
        sb.AppendLine("    private static partial Selector _RegisterName(string name);");
        sb.AppendLine();
        sb.AppendLine("    public static nint GetClass(string name)");
        sb.AppendLine("    {");
        sb.AppendLine("        if (string.IsNullOrEmpty(name))");
        sb.AppendLine("        {");
        sb.AppendLine("            return 0;");
        sb.AppendLine("        }");
        sb.AppendLine();
        sb.AppendLine("        return _GetClass(name);");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine("    public static Selector RegisterName(string name)");
        sb.AppendLine("    {");
        sb.AppendLine("        if (string.IsNullOrEmpty(name))");
        sb.AppendLine("        {");
        sb.AppendLine("            return default;");
        sb.AppendLine("        }");
        sb.AppendLine();
        sb.AppendLine("        return _RegisterName(name);");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine("    #endregion");

        var groups = context.MsgSendSignatures.Keys.OrderBy(k => k == "MsgSend" ? "" : k).ToList();

        foreach (string group in groups)
        {
            sb.AppendLine();
            sb.AppendLine($"    #region {group}");

            string returnType = GetReturnTypeForGroup(group);
            bool isVoid = returnType == "void";

            foreach (string sig in context.MsgSendSignatures[group])
            {
                ParsedParam[] parameters = ParseSignature(sig);

                sb.AppendLine();
                sb.AppendLine($"    public static {returnType} {group}(nint receiver, Selector selector{BuildPublicParams(parameters)})");
                sb.AppendLine("    {");

                // Null guard
                sb.AppendLine("        if (receiver is 0)");
                sb.AppendLine("        {");
                var outGuardParams = parameters.Where(p => p.Kind == ParamKind.Out).ToList();
                foreach (var p in outGuardParams)
                {
                    sb.AppendLine($"            {p.Letter} = default;");
                }
                if (outGuardParams.Count > 1)
                {
                    sb.AppendLine();
                }
                sb.AppendLine(isVoid ? "            return;" : "            return default;");
                sb.AppendLine("        }");
                sb.AppendLine();

                // Build and emit call expression
                string delegateType = BuildDelegateUnmanagedType(parameters, returnType);
                string callArgs = BuildCallArgs(parameters);
                string callExpr = $"(({delegateType})msgSend)(receiver, selector{callArgs})";

                EmitCallBody(sb, callExpr, isVoid, parameters);

                sb.AppendLine("    }");
            }

            sb.AppendLine();
            sb.AppendLine("    #endregion");
        }

        sb.AppendLine();
        sb.AppendLine("    public static nint Alloc(nint @class)");
        sb.AppendLine("    {");
        sb.AppendLine("        return MsgSendNInt(@class, \"alloc\");");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine("    public static nint Init(nint receiver)");
        sb.AppendLine("    {");
        sb.AppendLine("        return MsgSendNInt(receiver, \"init\");");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine("    public static nint AllocInit(nint @class)");
        sb.AppendLine("    {");
        sb.AppendLine("        return Init(Alloc(@class));");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine("    public static nint Retain(nint receiver)");
        sb.AppendLine("    {");
        sb.AppendLine("        return MsgSendNInt(receiver, \"retain\");");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine("    public static void Release(nint receiver)");
        sb.AppendLine("    {");
        sb.AppendLine("        MsgSend(receiver, \"release\");");
        sb.AppendLine("    }");
        sb.AppendLine("}");

        File.WriteAllText(Path.Combine(dir, "ObjectiveC.cs"), sb.ToString(), new UTF8Encoding(true));

        int totalOverloads = context.MsgSendSignatures.Values.Sum(s => s.Count);
        Console.WriteLine($"  Generated: Common/ObjectiveC.cs ({totalOverloads} overloads across {context.MsgSendSignatures.Count} groups)");
    }

    /// <summary>Classification of a parameter in a MsgSend signature.</summary>
    enum ParamKind { Regular, Out }

    /// <summary>A parsed parameter from a MsgSend signature string.</summary>
    readonly record struct ParsedParam(char Letter, string Type, ParamKind Kind)
    {
        /// <summary>The base type for out parameters (strips "out " prefix), or the original type.</summary>
        public string BaseType => Kind == ParamKind.Out ? Type[4..] : Type;
    }

    /// <summary>Maps a MsgSend group name to its C# return type.</summary>
    static string GetReturnTypeForGroup(string group) => group switch
    {
        "MsgSend" => "void",
        "MsgSendBool" => "Bool8",
        "MsgSendNInt" => "nint",
        "MsgSendInt" => "int",
        "MsgSendUInt" => "uint",
        "MsgSendLong" => "long",
        "MsgSendULong" => "ulong",
        "MsgSendFloat" => "float",
        "MsgSendDouble" => "double",
        "MsgSendNUInt" => "nuint",
        _ => group.Replace("MsgSend", "")
    };

    /// <summary>
    /// Parses a comma-separated signature string into structured parameter info.
    /// Each parameter is classified as Regular or Out, and assigned a sequential letter.
    /// </summary>
    static ParsedParam[] ParseSignature(string sig)
    {
        if (string.IsNullOrEmpty(sig)) return [];

        string[] types = sig.Split(", ");
        ParsedParam[] result = new ParsedParam[types.Length];
        char letter = 'a';

        for (int i = 0; i < types.Length; i++)
        {
            string type = types[i];
            ParamKind kind = type.StartsWith("out ")
                ? ParamKind.Out
                : ParamKind.Regular;
            result[i] = new ParsedParam(letter, type, kind);
            letter++;
        }

        return result;
    }

    /// <summary>Builds the public parameter list string (e.g., ", nint a, nint b").</summary>
    static string BuildPublicParams(ParsedParam[] parameters)
    {
        if (parameters.Length == 0) return "";

        StringBuilder sb = new();
        foreach (var p in parameters)
        {
            sb.Append($", {p.Type} {p.Letter}");
        }
        return sb.ToString();
    }

    /// <summary>
    /// Builds the delegate* unmanaged type string for a given signature.
    /// E.g., "delegate* unmanaged&lt;nint, Selector, nint, nint, void&gt;"
    /// Out parameters become pointers.
    /// </summary>
    static string BuildDelegateUnmanagedType(ParsedParam[] parameters, string returnType)
    {
        List<string> typeArgs = ["nint", "Selector"];

        foreach (var p in parameters)
        {
            typeArgs.Add(p.Kind switch
            {
                ParamKind.Out => $"{p.BaseType}*",
                _ => p.Type
            });
        }

        typeArgs.Add(returnType);
        return $"delegate* unmanaged<{string.Join(", ", typeArgs)}>";
    }

    /// <summary>
    /// Builds the call argument string for the function pointer call.
    /// Out parameters use pointer variables (e.g., aPtr).
    /// </summary>
    static string BuildCallArgs(ParsedParam[] parameters)
    {
        if (parameters.Length == 0) return "";

        StringBuilder sb = new();
        foreach (var p in parameters)
        {
            sb.Append(p.Kind switch
            {
                ParamKind.Out => $", {p.Letter}Ptr",
                _ => $", {p.Letter}"
            });
        }
        return sb.ToString();
    }

    /// <summary>
    /// Emits the method body after the null guard: fixed blocks, call expression,
    /// and return statement.
    /// </summary>
    static void EmitCallBody(StringBuilder sb, string callExpr, bool isVoid, ParsedParam[] parameters)
    {
        var outParams = parameters.Where(p => p.Kind == ParamKind.Out).ToList();
        bool hasOutParams = outParams.Count > 0;

        // Each fixed block nests inside the previous, increasing indent by 4 spaces
        const string baseIndent = "        ";
        string innerIndent = hasOutParams ? baseIndent + new string(' ', 4 * outParams.Count) : baseIndent;

        // Emit nested fixed blocks
        for (int i = 0; i < outParams.Count; i++)
        {
            string fixedIndent = baseIndent + new string(' ', 4 * i);
            var p = outParams[i];
            sb.AppendLine($"{fixedIndent}fixed ({p.BaseType}* {p.Letter}Ptr = &{p.Letter})");
            sb.AppendLine($"{fixedIndent}{{");
        }

        sb.AppendLine(isVoid ? $"{innerIndent}{callExpr};" : $"{innerIndent}return {callExpr};");

        // Close nested fixed blocks in reverse order
        for (int i = outParams.Count - 1; i >= 0; i--)
        {
            string fixedIndent = baseIndent + new string(' ', 4 * i);
            sb.AppendLine($"{fixedIndent}}}");
        }
    }

    #endregion
}
