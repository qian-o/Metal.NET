namespace Metal.NET;

public partial class MTL4PipelineOptions(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4PipelineOptions>
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

    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveC.MsgSendLong(NativePtr, MTL4PipelineOptionsBindings.ShaderValidation);
        set => ObjectiveC.MsgSend(NativePtr, MTL4PipelineOptionsBindings.SetShaderValidation, (nint)value);
    }

    public MTL4ShaderReflection ShaderReflection
    {
        get => (MTL4ShaderReflection)ObjectiveC.MsgSendULong(NativePtr, MTL4PipelineOptionsBindings.ShaderReflection);
        set => ObjectiveC.MsgSend(NativePtr, MTL4PipelineOptionsBindings.SetShaderReflection, (nuint)value);
    }
}

file static class MTL4PipelineOptionsBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4PipelineOptions");

    public static readonly Selector SetShaderReflection = "setShaderReflection:";

    public static readonly Selector SetShaderValidation = "setShaderValidation:";

    public static readonly Selector ShaderReflection = "shaderReflection";

    public static readonly Selector ShaderValidation = "shaderValidation";
}
