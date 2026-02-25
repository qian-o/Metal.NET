namespace Metal.NET;

public class MTL4PipelineOptions(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTL4PipelineOptions>
{
    public static MTL4PipelineOptions Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTL4PipelineOptions Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTL4PipelineOptions() : this(ObjectiveCRuntime.AllocInit(MTL4PipelineOptionsBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTL4ShaderReflection ShaderReflection
    {
        get => (MTL4ShaderReflection)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4PipelineOptionsBindings.ShaderReflection);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineOptionsBindings.SetShaderReflection, (nuint)value);
    }

    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4PipelineOptionsBindings.ShaderValidation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineOptionsBindings.SetShaderValidation, (nint)value);
    }
}

file static class MTL4PipelineOptionsBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4PipelineOptions");

    public static readonly Selector SetShaderReflection = "setShaderReflection:";

    public static readonly Selector SetShaderValidation = "setShaderValidation:";

    public static readonly Selector ShaderReflection = "shaderReflection";

    public static readonly Selector ShaderValidation = "shaderValidation";
}
