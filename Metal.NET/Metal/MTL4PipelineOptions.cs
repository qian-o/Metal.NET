namespace Metal.NET;

/// <summary>Provides options controlling how to compile a pipeline state.</summary>
public class MTL4PipelineOptions(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4PipelineOptions>
{
    #region INativeObject
    public static new MTL4PipelineOptions Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4PipelineOptions New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4PipelineOptions() : this(ObjectiveC.AllocInit(MTL4PipelineOptionsBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties

    /// <summary>Controls whether to include Metal shader reflection in this pipeline.</summary>
    public MTL4ShaderReflection ShaderReflection
    {
        get => (MTL4ShaderReflection)ObjectiveC.MsgSendULong(NativePtr, MTL4PipelineOptionsBindings.ShaderReflection);
        set => ObjectiveC.MsgSend(NativePtr, MTL4PipelineOptionsBindings.SetShaderReflection, (nuint)value);
    }

    /// <summary>Controls whether to enable or disable Metal Shader Validation for the pipeline.</summary>
    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveC.MsgSendLong(NativePtr, MTL4PipelineOptionsBindings.ShaderValidation);
        set => ObjectiveC.MsgSend(NativePtr, MTL4PipelineOptionsBindings.SetShaderValidation, (nint)value);
    }
    #endregion
}

file static class MTL4PipelineOptionsBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4PipelineOptions");

    public static readonly Selector SetShaderReflection = "setShaderReflection:";

    public static readonly Selector SetShaderValidation = "setShaderValidation:";

    public static readonly Selector ShaderReflection = "shaderReflection";

    public static readonly Selector ShaderValidation = "shaderValidation";
}
