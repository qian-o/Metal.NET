namespace Metal.NET;

public class MTL4PipelineOptions(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTL4PipelineOptions>
{
    public static MTL4PipelineOptions Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTL4PipelineOptions Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTL4PipelineOptions() : this(ObjectiveC.AllocInit(MTL4PipelineOptionsBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTL4ShaderReflection ShaderReflection
    {
        get => (MTL4ShaderReflection)ObjectiveC.MsgSendULong(NativePtr, MTL4PipelineOptionsBindings.ShaderReflection);
        set => ObjectiveC.MsgSend(NativePtr, MTL4PipelineOptionsBindings.SetShaderReflection, (nuint)value);
    }

    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveC.MsgSendLong(NativePtr, MTL4PipelineOptionsBindings.ShaderValidation);
        set => ObjectiveC.MsgSend(NativePtr, MTL4PipelineOptionsBindings.SetShaderValidation, (nint)value);
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
