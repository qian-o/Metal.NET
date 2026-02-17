namespace Metal.NET;

file class MTLCompileOptionsSelector
{
    public static readonly Selector SetAllowReferencingUndefinedSymbols_ = Selector.Register("setAllowReferencingUndefinedSymbols:");
    public static readonly Selector SetCompileSymbolVisibility_ = Selector.Register("setCompileSymbolVisibility:");
    public static readonly Selector SetEnableLogging_ = Selector.Register("setEnableLogging:");
    public static readonly Selector SetFastMathEnabled_ = Selector.Register("setFastMathEnabled:");
    public static readonly Selector SetInstallName_ = Selector.Register("setInstallName:");
    public static readonly Selector SetLanguageVersion_ = Selector.Register("setLanguageVersion:");
    public static readonly Selector SetLibraries_ = Selector.Register("setLibraries:");
    public static readonly Selector SetLibraryType_ = Selector.Register("setLibraryType:");
    public static readonly Selector SetMathFloatingPointFunctions_ = Selector.Register("setMathFloatingPointFunctions:");
    public static readonly Selector SetMathMode_ = Selector.Register("setMathMode:");
    public static readonly Selector SetMaxTotalThreadsPerThreadgroup_ = Selector.Register("setMaxTotalThreadsPerThreadgroup:");
    public static readonly Selector SetOptimizationLevel_ = Selector.Register("setOptimizationLevel:");
    public static readonly Selector SetPreprocessorMacros_ = Selector.Register("setPreprocessorMacros:");
    public static readonly Selector SetPreserveInvariance_ = Selector.Register("setPreserveInvariance:");
    public static readonly Selector SetRequiredThreadsPerThreadgroup_ = Selector.Register("setRequiredThreadsPerThreadgroup:");
}

public class MTLCompileOptions : IDisposable
{
    public MTLCompileOptions(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLCompileOptions(ptr);
    }

    public void SetAllowReferencingUndefinedSymbols(Bool8 allowReferencingUndefinedSymbols)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCompileOptionsSelector.SetAllowReferencingUndefinedSymbols_, (nint)allowReferencingUndefinedSymbols.Value);
    }

    public void SetCompileSymbolVisibility(MTLCompileSymbolVisibility compileSymbolVisibility)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCompileOptionsSelector.SetCompileSymbolVisibility_, (nint)(uint)compileSymbolVisibility);
    }

    public void SetEnableLogging(Bool8 enableLogging)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCompileOptionsSelector.SetEnableLogging_, (nint)enableLogging.Value);
    }

    public void SetFastMathEnabled(Bool8 fastMathEnabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCompileOptionsSelector.SetFastMathEnabled_, (nint)fastMathEnabled.Value);
    }

    public void SetInstallName(NSString installName)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCompileOptionsSelector.SetInstallName_, installName.NativePtr);
    }

    public void SetLanguageVersion(MTLLanguageVersion languageVersion)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCompileOptionsSelector.SetLanguageVersion_, (nint)(uint)languageVersion);
    }

    public void SetLibraries(NSArray libraries)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCompileOptionsSelector.SetLibraries_, libraries.NativePtr);
    }

    public void SetLibraryType(MTLLibraryType libraryType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCompileOptionsSelector.SetLibraryType_, (nint)(uint)libraryType);
    }

    public void SetMathFloatingPointFunctions(MTLMathFloatingPointFunctions mathFloatingPointFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCompileOptionsSelector.SetMathFloatingPointFunctions_, (nint)(uint)mathFloatingPointFunctions);
    }

    public void SetMathMode(MTLMathMode mathMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCompileOptionsSelector.SetMathMode_, (nint)(uint)mathMode);
    }

    public void SetMaxTotalThreadsPerThreadgroup(nuint maxTotalThreadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCompileOptionsSelector.SetMaxTotalThreadsPerThreadgroup_, (nint)maxTotalThreadsPerThreadgroup);
    }

    public void SetOptimizationLevel(MTLLibraryOptimizationLevel optimizationLevel)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCompileOptionsSelector.SetOptimizationLevel_, (nint)(uint)optimizationLevel);
    }

    public void SetPreprocessorMacros(nint preprocessorMacros)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCompileOptionsSelector.SetPreprocessorMacros_, preprocessorMacros);
    }

    public void SetPreserveInvariance(Bool8 preserveInvariance)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCompileOptionsSelector.SetPreserveInvariance_, (nint)preserveInvariance.Value);
    }

    public void SetRequiredThreadsPerThreadgroup(MTLSize requiredThreadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCompileOptionsSelector.SetRequiredThreadsPerThreadgroup_, requiredThreadsPerThreadgroup);
    }

}
