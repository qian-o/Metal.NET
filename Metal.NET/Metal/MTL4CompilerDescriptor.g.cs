namespace Metal.NET;

file class MTL4CompilerDescriptorSelector
{
    public static readonly Selector SetLabel_ = Selector.Register("setLabel:");
    public static readonly Selector SetPipelineDataSetSerializer_ = Selector.Register("setPipelineDataSetSerializer:");
}

public class MTL4CompilerDescriptor : IDisposable
{
    public MTL4CompilerDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTL4CompilerDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4CompilerDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4CompilerDescriptor(nint value)
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

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CompilerDescriptorSelector.SetLabel_, label.NativePtr);
    }

    public void SetPipelineDataSetSerializer(MTL4PipelineDataSetSerializer pipelineDataSetSerializer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CompilerDescriptorSelector.SetPipelineDataSetSerializer_, pipelineDataSetSerializer.NativePtr);
    }

}
