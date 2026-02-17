namespace Metal.NET;

file class MTL4CommandAllocatorDescriptorSelector
{
    public static readonly Selector SetLabel_ = Selector.Register("setLabel:");
}

public class MTL4CommandAllocatorDescriptor : IDisposable
{
    public MTL4CommandAllocatorDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTL4CommandAllocatorDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4CommandAllocatorDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4CommandAllocatorDescriptor(nint value)
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandAllocatorDescriptorSelector.SetLabel_, label.NativePtr);
    }

}
