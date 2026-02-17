namespace Metal.NET;

public class MTL4PipelineOptions : IDisposable
{
    public MTL4PipelineOptions(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTL4PipelineOptions()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTL4ShaderReflection ShaderReflection
    {
        get => (MTL4ShaderReflection)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTL4PipelineOptionsSelector.ShaderReflection));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineOptionsSelector.SetShaderReflection, (uint)value);
    }

    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTL4PipelineOptionsSelector.ShaderValidation));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineOptionsSelector.SetShaderValidation, (uint)value);
    }

    public static implicit operator nint(MTL4PipelineOptions value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4PipelineOptions(nint value)
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
}

file class MTL4PipelineOptionsSelector
{
    public static readonly Selector ShaderReflection = Selector.Register("shaderReflection");

    public static readonly Selector SetShaderReflection = Selector.Register("setShaderReflection:");

    public static readonly Selector ShaderValidation = Selector.Register("shaderValidation");

    public static readonly Selector SetShaderValidation = Selector.Register("setShaderValidation:");
}
