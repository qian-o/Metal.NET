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

    public static MTLCompileOptions New()
    {
        var ptr = ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.MsgSendPtr(ptr, Selector.Register("init"));

        return new MTLCompileOptions(ptr);
    }

    public void SetAllowReferencingUndefinedSymbols(Bool8 allowReferencingUndefinedSymbols)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetAllowReferencingUndefinedSymbols, (nint)allowReferencingUndefinedSymbols.Value);
    }

    public void SetCompileSymbolVisibility(MTLCompileSymbolVisibility compileSymbolVisibility)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetCompileSymbolVisibility, (nint)(uint)compileSymbolVisibility);
    }

    public void SetEnableLogging(Bool8 enableLogging)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetEnableLogging, (nint)enableLogging.Value);
    }

    public void SetFastMathEnabled(Bool8 fastMathEnabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetFastMathEnabled, (nint)fastMathEnabled.Value);
    }

    public void SetInstallName(NSString installName)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetInstallName, installName.NativePtr);
    }

    public void SetLanguageVersion(MTLLanguageVersion languageVersion)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetLanguageVersion, (nint)(uint)languageVersion);
    }

    public void SetLibraries(NSArray libraries)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetLibraries, libraries.NativePtr);
    }

    public void SetLibraryType(MTLLibraryType libraryType)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetLibraryType, (nint)(uint)libraryType);
    }

    public void SetMathFloatingPointFunctions(MTLMathFloatingPointFunctions mathFloatingPointFunctions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetMathFloatingPointFunctions, (nint)(uint)mathFloatingPointFunctions);
    }

    public void SetMathMode(MTLMathMode mathMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetMathMode, (nint)(uint)mathMode);
    }

    public void SetMaxTotalThreadsPerThreadgroup(uint maxTotalThreadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetMaxTotalThreadsPerThreadgroup, (nint)maxTotalThreadsPerThreadgroup);
    }

    public void SetOptimizationLevel(MTLLibraryOptimizationLevel optimizationLevel)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetOptimizationLevel, (nint)(uint)optimizationLevel);
    }

    public void SetPreprocessorMacros(int preprocessorMacros)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetPreprocessorMacros, preprocessorMacros);
    }

    public void SetPreserveInvariance(Bool8 preserveInvariance)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetPreserveInvariance, (nint)preserveInvariance.Value);
    }

    public void SetRequiredThreadsPerThreadgroup(MTLSize requiredThreadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsSelector.SetRequiredThreadsPerThreadgroup, requiredThreadsPerThreadgroup);
    }

}

file class MTLCompileOptionsSelector
{
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

    public static readonly Selector SetPreprocessorMacros = Selector.Register("setPreprocessorMacros:");

    public static readonly Selector SetPreserveInvariance = Selector.Register("setPreserveInvariance:");

    public static readonly Selector SetRequiredThreadsPerThreadgroup = Selector.Register("setRequiredThreadsPerThreadgroup:");
}
