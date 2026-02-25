namespace Metal.NET;

public class MTLCompileOptions(nint nativePtr, bool ownsReference, bool allowGCRelease = false) : NativeObject(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLCompileOptions>
{
    public static MTLCompileOptions Null { get; } = new(0, false);

    public static MTLCompileOptions Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLCompileOptions() : this(ObjectiveCRuntime.AllocInit(MTLCompileOptionsBindings.Class), true, true)
    {
    }

    public Bool8 AllowReferencingUndefinedSymbols
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCompileOptionsBindings.AllowReferencingUndefinedSymbols);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsBindings.SetAllowReferencingUndefinedSymbols, value);
    }

    public MTLCompileSymbolVisibility CompileSymbolVisibility
    {
        get => (MTLCompileSymbolVisibility)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCompileOptionsBindings.CompileSymbolVisibility);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsBindings.SetCompileSymbolVisibility, (nint)value);
    }

    public Bool8 EnableLogging
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCompileOptionsBindings.EnableLogging);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsBindings.SetEnableLogging, value);
    }

    public Bool8 FastMathEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCompileOptionsBindings.FastMathEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsBindings.SetFastMathEnabled, value);
    }

    public NSString InstallName
    {
        get => GetProperty(ref field, MTLCompileOptionsBindings.InstallName);
        set => SetProperty(ref field, MTLCompileOptionsBindings.SetInstallName, value);
    }

    public MTLLanguageVersion LanguageVersion
    {
        get => (MTLLanguageVersion)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLCompileOptionsBindings.LanguageVersion);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsBindings.SetLanguageVersion, (nuint)value);
    }

    public MTLDynamicLibrary[] Libraries
    {
        get => GetArrayProperty<MTLDynamicLibrary>(MTLCompileOptionsBindings.Libraries);
        set => SetArrayProperty(MTLCompileOptionsBindings.SetLibraries, value);
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

    public Bool8 PreserveInvariance
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCompileOptionsBindings.PreserveInvariance);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCompileOptionsBindings.SetPreserveInvariance, value);
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

    public static readonly Selector AllowReferencingUndefinedSymbols = "allowReferencingUndefinedSymbols";

    public static readonly Selector CompileSymbolVisibility = "compileSymbolVisibility";

    public static readonly Selector EnableLogging = "enableLogging";

    public static readonly Selector FastMathEnabled = "fastMathEnabled";

    public static readonly Selector InstallName = "installName";

    public static readonly Selector LanguageVersion = "languageVersion";

    public static readonly Selector Libraries = "libraries";

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

    public static readonly Selector SetLibraries = "setLibraries:";

    public static readonly Selector SetLibraryType = "setLibraryType:";

    public static readonly Selector SetMathFloatingPointFunctions = "setMathFloatingPointFunctions:";

    public static readonly Selector SetMathMode = "setMathMode:";

    public static readonly Selector SetMaxTotalThreadsPerThreadgroup = "setMaxTotalThreadsPerThreadgroup:";

    public static readonly Selector SetOptimizationLevel = "setOptimizationLevel:";

    public static readonly Selector SetPreserveInvariance = "setPreserveInvariance:";

    public static readonly Selector SetRequiredThreadsPerThreadgroup = "setRequiredThreadsPerThreadgroup:";
}
