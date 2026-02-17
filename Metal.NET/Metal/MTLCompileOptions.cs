namespace Metal.NET;

public class MTLCompileOptions : IDisposable
{
    public MTLCompileOptions(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLCompileOptions()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLCompileOptions value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLCompileOptions(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLCompileOptions");

    public MTLCompileOptions() : this(ObjectiveCRuntime.MsgSendPtr(ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc")), Selector.Register("init")))
    {
    }

    public Bool8 AllowReferencingUndefinedSymbols
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCompileOptionsSelector.AllowReferencingUndefinedSymbols);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetAllowReferencingUndefinedSymbols, value);
    }

    public MTLCompileSymbolVisibility CompileSymbolVisibility
    {
        get => (MTLCompileSymbolVisibility)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLCompileOptionsSelector.CompileSymbolVisibility));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetCompileSymbolVisibility, (uint)value);
    }

    public Bool8 EnableLogging
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCompileOptionsSelector.EnableLogging);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetEnableLogging, value);
    }

    public Bool8 FastMathEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCompileOptionsSelector.FastMathEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetFastMathEnabled, value);
    }

    public NSString InstallName
    {
        get => new NSString(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCompileOptionsSelector.InstallName));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetInstallName, value.NativePtr);
    }

    public MTLLanguageVersion LanguageVersion
    {
        get => (MTLLanguageVersion)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLCompileOptionsSelector.LanguageVersion));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetLanguageVersion, (uint)value);
    }

    public NSArray Libraries
    {
        get => new NSArray(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCompileOptionsSelector.Libraries));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetLibraries, value.NativePtr);
    }

    public MTLLibraryType LibraryType
    {
        get => (MTLLibraryType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLCompileOptionsSelector.LibraryType));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetLibraryType, (uint)value);
    }

    public MTLMathFloatingPointFunctions MathFloatingPointFunctions
    {
        get => (MTLMathFloatingPointFunctions)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLCompileOptionsSelector.MathFloatingPointFunctions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetMathFloatingPointFunctions, (uint)value);
    }

    public MTLMathMode MathMode
    {
        get => (MTLMathMode)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLCompileOptionsSelector.MathMode));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetMathMode, (uint)value);
    }

    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLCompileOptionsSelector.MaxTotalThreadsPerThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetMaxTotalThreadsPerThreadgroup, (nuint)value);
    }

    public MTLLibraryOptimizationLevel OptimizationLevel
    {
        get => (MTLLibraryOptimizationLevel)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLCompileOptionsSelector.OptimizationLevel));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetOptimizationLevel, (uint)value);
    }

    public nint PreprocessorMacros
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCompileOptionsSelector.PreprocessorMacros);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetPreprocessorMacros, value);
    }

    public Bool8 PreserveInvariance
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCompileOptionsSelector.PreserveInvariance);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetPreserveInvariance, value);
    }

}

file class MTLCompileOptionsSelector
{
    public static readonly Selector AllowReferencingUndefinedSymbols = Selector.Register("allowReferencingUndefinedSymbols");

    public static readonly Selector SetAllowReferencingUndefinedSymbols = Selector.Register("setAllowReferencingUndefinedSymbols:");

    public static readonly Selector CompileSymbolVisibility = Selector.Register("compileSymbolVisibility");

    public static readonly Selector SetCompileSymbolVisibility = Selector.Register("setCompileSymbolVisibility:");

    public static readonly Selector EnableLogging = Selector.Register("enableLogging");

    public static readonly Selector SetEnableLogging = Selector.Register("setEnableLogging:");

    public static readonly Selector FastMathEnabled = Selector.Register("fastMathEnabled");

    public static readonly Selector SetFastMathEnabled = Selector.Register("setFastMathEnabled:");

    public static readonly Selector InstallName = Selector.Register("installName");

    public static readonly Selector SetInstallName = Selector.Register("setInstallName:");

    public static readonly Selector LanguageVersion = Selector.Register("languageVersion");

    public static readonly Selector SetLanguageVersion = Selector.Register("setLanguageVersion:");

    public static readonly Selector Libraries = Selector.Register("libraries");

    public static readonly Selector SetLibraries = Selector.Register("setLibraries:");

    public static readonly Selector LibraryType = Selector.Register("libraryType");

    public static readonly Selector SetLibraryType = Selector.Register("setLibraryType:");

    public static readonly Selector MathFloatingPointFunctions = Selector.Register("mathFloatingPointFunctions");

    public static readonly Selector SetMathFloatingPointFunctions = Selector.Register("setMathFloatingPointFunctions:");

    public static readonly Selector MathMode = Selector.Register("mathMode");

    public static readonly Selector SetMathMode = Selector.Register("setMathMode:");

    public static readonly Selector MaxTotalThreadsPerThreadgroup = Selector.Register("maxTotalThreadsPerThreadgroup");

    public static readonly Selector SetMaxTotalThreadsPerThreadgroup = Selector.Register("setMaxTotalThreadsPerThreadgroup:");

    public static readonly Selector OptimizationLevel = Selector.Register("optimizationLevel");

    public static readonly Selector SetOptimizationLevel = Selector.Register("setOptimizationLevel:");

    public static readonly Selector PreprocessorMacros = Selector.Register("preprocessorMacros");

    public static readonly Selector SetPreprocessorMacros = Selector.Register("setPreprocessorMacros:");

    public static readonly Selector PreserveInvariance = Selector.Register("preserveInvariance");

    public static readonly Selector SetPreserveInvariance = Selector.Register("setPreserveInvariance:");

    public static readonly Selector RequiredThreadsPerThreadgroup = Selector.Register("requiredThreadsPerThreadgroup");

    public static readonly Selector SetRequiredThreadsPerThreadgroup = Selector.Register("setRequiredThreadsPerThreadgroup:");
}
