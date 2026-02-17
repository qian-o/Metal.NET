namespace Metal.NET;

file class MTL4PipelineDataSetSerializerDescriptorSelector
{
    public static readonly Selector SetConfiguration_ = Selector.Register("setConfiguration:");
}

public class MTL4PipelineDataSetSerializerDescriptor : IDisposable
{
    public MTL4PipelineDataSetSerializerDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTL4PipelineDataSetSerializerDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4PipelineDataSetSerializerDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4PipelineDataSetSerializerDescriptor(nint value)
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

    public void SetConfiguration(nuint configuration)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4PipelineDataSetSerializerDescriptorSelector.SetConfiguration_, (nint)configuration);
    }

}
