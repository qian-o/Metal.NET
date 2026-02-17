namespace Metal.NET;

file class MTL4PipelineDescriptorSelector
{
    public static readonly Selector SetLabel_ = Selector.Register("setLabel:");
    public static readonly Selector SetOptions_ = Selector.Register("setOptions:");
}

public class MTL4PipelineDescriptor : IDisposable
{
    public MTL4PipelineDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTL4PipelineDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4PipelineDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4PipelineDescriptor(nint value)
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4PipelineDescriptorSelector.SetLabel_, label.NativePtr);
    }

    public void SetOptions(MTL4PipelineOptions options)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4PipelineDescriptorSelector.SetOptions_, options.NativePtr);
    }

}
