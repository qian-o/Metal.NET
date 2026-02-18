namespace Metal.NET;

public partial class MTLCompileOptions : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLCompileOptions");

    public MTLCompileOptions(nint nativePtr) : base(nativePtr)
    {
    }

    public bool AllowReferencingUndefinedSymbols
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCompileOptionsSelector.AllowReferencingUndefinedSymbols);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetAllowReferencingUndefinedSymbols, (Bool8)value);
    }

    public MTLCompileSymbolVisibility CompileSymbolVisibility
    {
        get => (MTLCompileSymbolVisibility)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCompileOptionsSelector.CompileSymbolVisibility);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetCompileSymbolVisibility, (nint)value);
    }

    public bool EnableLogging
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCompileOptionsSelector.EnableLogging);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetEnableLogging, (Bool8)value);
    }

    public bool FastMathEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCompileOptionsSelector.FastMathEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetFastMathEnabled, (Bool8)value);
    }

    public NSString? InstallName
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCompileOptionsSelector.InstallName);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetInstallName, value?.NativePtr ?? 0);
    }

    public MTLLanguageVersion LanguageVersion
    {
        get => (MTLLanguageVersion)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLCompileOptionsSelector.LanguageVersion);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetLanguageVersion, (nuint)value);
    }

    public NSArray? Libraries
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCompileOptionsSelector.Libraries);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetLibraries, value?.NativePtr ?? 0);
    }

    public MTLLibraryType LibraryType
    {
        get => (MTLLibraryType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCompileOptionsSelector.LibraryType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetLibraryType, (nint)value);
    }

    public MTLMathFloatingPointFunctions MathFloatingPointFunctions
    {
        get => (MTLMathFloatingPointFunctions)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCompileOptionsSelector.MathFloatingPointFunctions);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetMathFloatingPointFunctions, (nint)value);
    }

    public MTLMathMode MathMode
    {
        get => (MTLMathMode)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCompileOptionsSelector.MathMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetMathMode, (nint)value);
    }

    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLCompileOptionsSelector.MaxTotalThreadsPerThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetMaxTotalThreadsPerThreadgroup, value);
    }

    public MTLLibraryOptimizationLevel OptimizationLevel
    {
        get => (MTLLibraryOptimizationLevel)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCompileOptionsSelector.OptimizationLevel);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetOptimizationLevel, (nint)value);
    }

    public bool PreserveInvariance
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCompileOptionsSelector.PreserveInvariance);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetPreserveInvariance, (Bool8)value);
    }

    public MTLSize RequiredThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLCompileOptionsSelector.RequiredThreadsPerThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetRequiredThreadsPerThreadgroup, value);
    }
}

file static class MTLCompileOptionsSelector
{
    public static readonly Selector AllowReferencingUndefinedSymbols = Selector.Register("allowReferencingUndefinedSymbols");

    public static readonly Selector CompileSymbolVisibility = Selector.Register("compileSymbolVisibility");

    public static readonly Selector EnableLogging = Selector.Register("enableLogging");

    public static readonly Selector FastMathEnabled = Selector.Register("fastMathEnabled");

    public static readonly Selector InstallName = Selector.Register("installName");

    public static readonly Selector LanguageVersion = Selector.Register("languageVersion");

    public static readonly Selector Libraries = Selector.Register("libraries");

    public static readonly Selector LibraryType = Selector.Register("libraryType");

    public static readonly Selector MathFloatingPointFunctions = Selector.Register("mathFloatingPointFunctions");

    public static readonly Selector MathMode = Selector.Register("mathMode");

    public static readonly Selector MaxTotalThreadsPerThreadgroup = Selector.Register("maxTotalThreadsPerThreadgroup");

    public static readonly Selector OptimizationLevel = Selector.Register("optimizationLevel");

    public static readonly Selector PreserveInvariance = Selector.Register("preserveInvariance");

    public static readonly Selector RequiredThreadsPerThreadgroup = Selector.Register("requiredThreadsPerThreadgroup");

    public static readonly Selector SetAllowReferencingUndefinedSymbols = Selector.Register("setAllowReferencingUndefinedSymbols:");

    public static readonly Selector SetCompileSymbolVisibility = Selector.Register("setCompileSymbolVisibility:");

    public static readonly Selector SetEnableLogging = Selector.Register("setEnableLogging:");

    public static readonly Selector SetFastMathEnabled = Selector.Register("setFastMathEnabled:");

    public static readonly Selector SetInstallName = Selector.Register("setInstallName:");

    public static readonly Selector SetLanguageVersion = Selector.Register("setLanguageVersion:");

    public static readonly Selector SetLibraries = Selector.Register("setLibraries:");

    public static readonly Selector SetLibraryType = Selector.Register("setLibraryType:");

    public static readonly Selector SetMathFloatingPointFunctions = Selector.Register("setMathFloatingPointFunctions:");

    public static readonly Selector SetMathMode = Selector.Register("setMathMode:");

    public static readonly Selector SetMaxTotalThreadsPerThreadgroup = Selector.Register("setMaxTotalThreadsPerThreadgroup:");

    public static readonly Selector SetOptimizationLevel = Selector.Register("setOptimizationLevel:");

    public static readonly Selector SetPreserveInvariance = Selector.Register("setPreserveInvariance:");

    public static readonly Selector SetRequiredThreadsPerThreadgroup = Selector.Register("setRequiredThreadsPerThreadgroup:");
}
