namespace Metal.NET;

public class MTLCompileOptions(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLCompileOptions>
{
    #region INativeObject
    public static new MTLCompileOptions Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLCompileOptions New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLCompileOptions() : this(ObjectiveC.AllocInit(MTLCompileOptionsBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    /// <summary>
    /// Deprecated: Use mathMode instead
    /// </summary>
    [Obsolete("Use mathMode instead")]
    public Bool8 FastMathEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLCompileOptionsBindings.FastMathEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLCompileOptionsBindings.SetFastMathEnabled, value);
    }

    public MTLMathMode MathMode
    {
        get => (MTLMathMode)ObjectiveC.MsgSendLong(NativePtr, MTLCompileOptionsBindings.MathMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLCompileOptionsBindings.SetMathMode, (nint)value);
    }

    public MTLMathFloatingPointFunctions MathFloatingPointFunctions
    {
        get => (MTLMathFloatingPointFunctions)ObjectiveC.MsgSendLong(NativePtr, MTLCompileOptionsBindings.MathFloatingPointFunctions);
        set => ObjectiveC.MsgSend(NativePtr, MTLCompileOptionsBindings.SetMathFloatingPointFunctions, (nint)value);
    }

    public MTLLanguageVersion LanguageVersion
    {
        get => (MTLLanguageVersion)ObjectiveC.MsgSendULong(NativePtr, MTLCompileOptionsBindings.LanguageVersion);
        set => ObjectiveC.MsgSend(NativePtr, MTLCompileOptionsBindings.SetLanguageVersion, (nuint)value);
    }

    public MTLLibraryType LibraryType
    {
        get => (MTLLibraryType)ObjectiveC.MsgSendLong(NativePtr, MTLCompileOptionsBindings.LibraryType);
        set => ObjectiveC.MsgSend(NativePtr, MTLCompileOptionsBindings.SetLibraryType, (nint)value);
    }

    public NSString InstallName
    {
        get => GetProperty(ref field, MTLCompileOptionsBindings.InstallName);
        set => SetProperty(ref field, MTLCompileOptionsBindings.SetInstallName, value);
    }

    public Bool8 PreserveInvariance
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLCompileOptionsBindings.PreserveInvariance);
        set => ObjectiveC.MsgSend(NativePtr, MTLCompileOptionsBindings.SetPreserveInvariance, value);
    }

    public MTLLibraryOptimizationLevel OptimizationLevel
    {
        get => (MTLLibraryOptimizationLevel)ObjectiveC.MsgSendLong(NativePtr, MTLCompileOptionsBindings.OptimizationLevel);
        set => ObjectiveC.MsgSend(NativePtr, MTLCompileOptionsBindings.SetOptimizationLevel, (nint)value);
    }

    public MTLCompileSymbolVisibility CompileSymbolVisibility
    {
        get => (MTLCompileSymbolVisibility)ObjectiveC.MsgSendLong(NativePtr, MTLCompileOptionsBindings.CompileSymbolVisibility);
        set => ObjectiveC.MsgSend(NativePtr, MTLCompileOptionsBindings.SetCompileSymbolVisibility, (nint)value);
    }

    public Bool8 AllowReferencingUndefinedSymbols
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLCompileOptionsBindings.AllowReferencingUndefinedSymbols);
        set => ObjectiveC.MsgSend(NativePtr, MTLCompileOptionsBindings.SetAllowReferencingUndefinedSymbols, value);
    }

    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLCompileOptionsBindings.MaxTotalThreadsPerThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTLCompileOptionsBindings.SetMaxTotalThreadsPerThreadgroup, value);
    }

    public MTLSize RequiredThreadsPerThreadgroup
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLCompileOptionsBindings.RequiredThreadsPerThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTLCompileOptionsBindings.SetRequiredThreadsPerThreadgroup, value);
    }

    public Bool8 EnableLogging
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLCompileOptionsBindings.EnableLogging);
        set => ObjectiveC.MsgSend(NativePtr, MTLCompileOptionsBindings.SetEnableLogging, value);
    }
}

file static class MTLCompileOptionsBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLCompileOptions");

    public static readonly Selector AllowReferencingUndefinedSymbols = "allowReferencingUndefinedSymbols";

    public static readonly Selector CompileSymbolVisibility = "compileSymbolVisibility";

    public static readonly Selector EnableLogging = "enableLogging";

    public static readonly Selector FastMathEnabled = "fastMathEnabled";

    public static readonly Selector InstallName = "installName";

    public static readonly Selector LanguageVersion = "languageVersion";

    public static readonly Selector LibraryType = "libraryType";

    public static readonly Selector MathFloatingPointFunctions = "mathFloatingPointFunctions";

    public static readonly Selector MathMode = "mathMode";

    public static readonly Selector MaxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";

    public static readonly Selector OptimizationLevel = "optimizationLevel";

    public static readonly Selector PreserveInvariance = "preserveInvariance";

    public static readonly Selector RequiredThreadsPerThreadgroup = "requiredThreadsPerThreadgroup";

    public static readonly Selector SetAllowReferencingUndefinedSymbols = "setAllowReferencingUndefinedSymbols:";

    public static readonly Selector SetCompileSymbolVisibility = "setCompileSymbolVisibility:";

    public static readonly Selector SetEnableLogging = "setEnableLogging:";

    public static readonly Selector SetFastMathEnabled = "setFastMathEnabled:";

    public static readonly Selector SetInstallName = "setInstallName:";

    public static readonly Selector SetLanguageVersion = "setLanguageVersion:";

    public static readonly Selector SetLibraryType = "setLibraryType:";

    public static readonly Selector SetMathFloatingPointFunctions = "setMathFloatingPointFunctions:";

    public static readonly Selector SetMathMode = "setMathMode:";

    public static readonly Selector SetMaxTotalThreadsPerThreadgroup = "setMaxTotalThreadsPerThreadgroup:";

    public static readonly Selector SetOptimizationLevel = "setOptimizationLevel:";

    public static readonly Selector SetPreserveInvariance = "setPreserveInvariance:";

    public static readonly Selector SetRequiredThreadsPerThreadgroup = "setRequiredThreadsPerThreadgroup:";
}
