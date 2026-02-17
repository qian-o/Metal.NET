namespace Metal.NET;

public class MTL4CommandAllocatorDescriptor : IDisposable
{
    public MTL4CommandAllocatorDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandAllocatorDescriptorSelector.SetLabel, label.NativePtr);
    }

}

file class MTL4CommandAllocatorDescriptorSelector
{
    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
