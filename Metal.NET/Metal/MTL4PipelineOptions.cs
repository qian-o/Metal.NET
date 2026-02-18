namespace Metal.NET;

public partial class MTL4PipelineOptions : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4PipelineOptions");

    public MTL4PipelineOptions(nint nativePtr) : base(nativePtr)
    {
    }

    public MTL4ShaderReflection ShaderReflection
    {
        get => (MTL4ShaderReflection)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4PipelineOptionsSelector.ShaderReflection);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineOptionsSelector.SetShaderReflection, (nuint)value);
    }

    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4PipelineOptionsSelector.ShaderValidation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineOptionsSelector.SetShaderValidation, (nint)value);
    }
}

file static class MTL4PipelineOptionsSelector
{
    public static readonly Selector SetShaderReflection = Selector.Register("setShaderReflection:");

    public static readonly Selector SetShaderValidation = Selector.Register("setShaderValidation:");

    public static readonly Selector ShaderReflection = Selector.Register("shaderReflection");

    public static readonly Selector ShaderValidation = Selector.Register("shaderValidation");
}
