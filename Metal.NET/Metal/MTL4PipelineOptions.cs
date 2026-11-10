namespace Metal.NET;

public readonly struct MTL4PipelineOptions(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTL4PipelineOptions value) => new(value.NativePtr);

    public MTL4PipelineOptions() : this(ObjectiveC.AllocInit(MTL4PipelineOptionsBindings.Class))
    {
    }

    public MTL4PipelineOptions Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
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
