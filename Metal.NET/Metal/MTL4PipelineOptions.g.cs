namespace Metal.NET;

file class MTL4PipelineOptionsSelector
{
    public static readonly Selector SetShaderReflection_ = Selector.Register("setShaderReflection:");
    public static readonly Selector SetShaderValidation_ = Selector.Register("setShaderValidation:");
}

public class MTL4PipelineOptions : IDisposable
{
    public MTL4PipelineOptions(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTL4PipelineOptions()
    {
        Release();
    }

    public nint NativePtr { get; }

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

    public void SetShaderReflection(nuint shaderReflection)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4PipelineOptionsSelector.SetShaderReflection_, (nint)shaderReflection);
    }

    public void SetShaderValidation(MTLShaderValidation shaderValidation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4PipelineOptionsSelector.SetShaderValidation_, (nint)(uint)shaderValidation);
    }

}
