namespace Metal.NET;

public readonly struct MTLCompileOptions(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLCompileOptions() : this(ObjectiveCRuntime.AllocInit(MTLCompileOptionsBindings.Class))
    {
    }

    public bool AllowReferencingUndefinedSymbols
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCompileOptionsBindings.AllowReferencingUndefinedSymbols);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsBindings.SetAllowReferencingUndefinedSymbols, (Bool8)value);
    }

    public MTLCompileSymbolVisibility CompileSymbolVisibility
    {
        get => (MTLCompileSymbolVisibility)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCompileOptionsBindings.CompileSymbolVisibility);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsBindings.SetCompileSymbolVisibility, (nint)value);
    }

    public bool EnableLogging
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCompileOptionsBindings.EnableLogging);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsBindings.SetEnableLogging, (Bool8)value);
    }

    public bool FastMathEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCompileOptionsBindings.FastMathEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsBindings.SetFastMathEnabled, (Bool8)value);
    }

    public NSString? InstallName
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCompileOptionsBindings.InstallName);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsBindings.SetInstallName, value?.NativePtr ?? 0);
    }

    public MTLLanguageVersion LanguageVersion
    {
        get => (MTLLanguageVersion)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLCompileOptionsBindings.LanguageVersion);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsBindings.SetLanguageVersion, (nuint)value);
    }

    public NSArray? Libraries
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCompileOptionsBindings.Libraries);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsBindings.SetLibraries, value?.NativePtr ?? 0);
    }

    public MTLLibraryType LibraryType
    {
        get => (MTLLibraryType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCompileOptionsBindings.LibraryType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsBindings.SetLibraryType, (nint)value);
    }

    public MTLMathFloatingPointFunctions MathFloatingPointFunctions
    {
        get => (MTLMathFloatingPointFunctions)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCompileOptionsBindings.MathFloatingPointFunctions);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsBindings.SetMathFloatingPointFunctions, (nint)value);
    }

    public MTLMathMode MathMode
    {
        get => (MTLMathMode)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCompileOptionsBindings.MathMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsBindings.SetMathMode, (nint)value);
    }

    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLCompileOptionsBindings.MaxTotalThreadsPerThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsBindings.SetMaxTotalThreadsPerThreadgroup, value);
    }

    public MTLLibraryOptimizationLevel OptimizationLevel
    {
        get => (MTLLibraryOptimizationLevel)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCompileOptionsBindings.OptimizationLevel);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsBindings.SetOptimizationLevel, (nint)value);
    }

    public bool PreserveInvariance
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCompileOptionsBindings.PreserveInvariance);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsBindings.SetPreserveInvariance, (Bool8)value);
    }

    public MTLSize RequiredThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLCompileOptionsBindings.RequiredThreadsPerThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsBindings.SetRequiredThreadsPerThreadgroup, value);
    }
}

file static class MTLCompileOptionsBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLCompileOptions");

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
