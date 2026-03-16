namespace Metal.NET;

/// <summary>Compilation settings for a Metal shader library.</summary>
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

    #region Configuring the compiler options - Properties

    /// <summary>A Boolean value that enables shader logging.</summary>
    public Bool8 EnableLogging
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLCompileOptionsBindings.EnableLogging);
        set => ObjectiveC.MsgSend(NativePtr, MTLCompileOptionsBindings.SetEnableLogging, value);
    }

    /// <summary>An indication of whether the compiler can perform optimizations for floating-point arithmetic that may violate the IEEE 754 standard.</summary>
    public MTLMathMode MathMode
    {
        get => (MTLMathMode)ObjectiveC.MsgSendLong(NativePtr, MTLCompileOptionsBindings.MathMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLCompileOptionsBindings.SetMathMode, (nint)value);
    }

    /// <summary>The FP32 math functions Metal uses.</summary>
    public MTLMathFloatingPointFunctions MathFloatingPointFunctions
    {
        get => (MTLMathFloatingPointFunctions)ObjectiveC.MsgSendLong(NativePtr, MTLCompileOptionsBindings.MathFloatingPointFunctions);
        set => ObjectiveC.MsgSend(NativePtr, MTLCompileOptionsBindings.SetMathFloatingPointFunctions, (nint)value);
    }

    /// <summary>A Boolean value that indicates whether the compiler compiles vertex shaders conservatively to generate consistent position calculations.</summary>
    public Bool8 PreserveInvariance
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLCompileOptionsBindings.PreserveInvariance);
        set => ObjectiveC.MsgSend(NativePtr, MTLCompileOptionsBindings.SetPreserveInvariance, value);
    }

    /// <summary>The language version for interpreting the library source code.</summary>
    public MTLLanguageVersion LanguageVersion
    {
        get => (MTLLanguageVersion)ObjectiveC.MsgSendULong(NativePtr, MTLCompileOptionsBindings.LanguageVersion);
        set => ObjectiveC.MsgSend(NativePtr, MTLCompileOptionsBindings.SetLanguageVersion, (nuint)value);
    }

    /// <summary>A list of preprocessor macros to apply when compiling the library source.</summary>
    public NSDictionary PreprocessorMacros
    {
        get => GetProperty(ref field, MTLCompileOptionsBindings.PreprocessorMacros);
        set => SetProperty(ref field, MTLCompileOptionsBindings.SetPreprocessorMacros, value);
    }

    /// <summary>An option that tells the compiler what to prioritize when it compiles Metal shader code.</summary>
    public MTLLibraryOptimizationLevel OptimizationLevel
    {
        get => (MTLLibraryOptimizationLevel)ObjectiveC.MsgSendLong(NativePtr, MTLCompileOptionsBindings.OptimizationLevel);
        set => ObjectiveC.MsgSend(NativePtr, MTLCompileOptionsBindings.SetOptimizationLevel, (nint)value);
    }

    /// <summary>An array of dynamic libraries the Metal compiler links against.</summary>
    public MTLDynamicLibrary[] Libraries
    {
        get => GetArrayProperty<MTLDynamicLibrary>(MTLCompileOptionsBindings.Libraries);
        set => SetArrayProperty(MTLCompileOptionsBindings.SetLibraries, value);
    }

    /// <summary>A Boolean value that indicates whether the compiler can perform optimizations for floating-point arithmetic that may violate the IEEE 754 standard.</summary>
    [Obsolete("Use mathMode instead.")]
    public Bool8 FastMathEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLCompileOptionsBindings.FastMathEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLCompileOptionsBindings.SetFastMathEnabled, value);
    }
    #endregion

    #region Configuring the library output options - Properties

    /// <summary>The kind of library to create.</summary>
    public MTLLibraryType LibraryType
    {
        get => (MTLLibraryType)ObjectiveC.MsgSendLong(NativePtr, MTLCompileOptionsBindings.LibraryType);
        set => ObjectiveC.MsgSend(NativePtr, MTLCompileOptionsBindings.SetLibraryType, (nint)value);
    }

    /// <summary>For a dynamic library, the name to use when installing the library.</summary>
    public NSString InstallName
    {
        get => GetProperty(ref field, MTLCompileOptionsBindings.InstallName);
        set => SetProperty(ref field, MTLCompileOptionsBindings.SetInstallName, value);
    }
    #endregion

    #region Instance Properties - Properties

    public Bool8 AllowReferencingUndefinedSymbols
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLCompileOptionsBindings.AllowReferencingUndefinedSymbols);
        set => ObjectiveC.MsgSend(NativePtr, MTLCompileOptionsBindings.SetAllowReferencingUndefinedSymbols, value);
    }

    public MTLCompileSymbolVisibility CompileSymbolVisibility
    {
        get => (MTLCompileSymbolVisibility)ObjectiveC.MsgSendLong(NativePtr, MTLCompileOptionsBindings.CompileSymbolVisibility);
        set => ObjectiveC.MsgSend(NativePtr, MTLCompileOptionsBindings.SetCompileSymbolVisibility, (nint)value);
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
    #endregion
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

    public static readonly Selector Libraries = "libraries";

    public static readonly Selector LibraryType = "libraryType";

    public static readonly Selector MathFloatingPointFunctions = "mathFloatingPointFunctions";

    public static readonly Selector MathMode = "mathMode";

    public static readonly Selector MaxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";

    public static readonly Selector OptimizationLevel = "optimizationLevel";

    public static readonly Selector PreprocessorMacros = "preprocessorMacros";

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

    public static readonly Selector SetPreprocessorMacros = "setPreprocessorMacros:";

    public static readonly Selector SetPreserveInvariance = "setPreserveInvariance:";

    public static readonly Selector SetRequiredThreadsPerThreadgroup = "setRequiredThreadsPerThreadgroup:";
}
