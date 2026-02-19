namespace Metal.NET;

public readonly struct MTL4PipelineOptions(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTL4PipelineOptions() : this(ObjectiveCRuntime.AllocInit(MTL4PipelineOptionsBindings.Class))
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

    public static readonly Selector SetShaderReflection = Selector.Register("setShaderReflection:");

    public static readonly Selector SetShaderValidation = Selector.Register("setShaderValidation:");

    public static readonly Selector ShaderReflection = Selector.Register("shaderReflection");

    public static readonly Selector ShaderValidation = Selector.Register("shaderValidation");
}
