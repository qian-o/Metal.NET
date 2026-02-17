namespace Metal.NET;

public class MTLResourceViewPoolDescriptor : IDisposable
{
    public MTLResourceViewPoolDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLResourceViewPoolDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLResourceViewPoolDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLResourceViewPoolDescriptor(nint value)
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
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceViewPoolDescriptorSelector.SetLabel, label.NativePtr);
    }

    public void SetResourceViewCount(uint resourceViewCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceViewPoolDescriptorSelector.SetResourceViewCount, (nint)resourceViewCount);
    }

}

file class MTLResourceViewPoolDescriptorSelector
{
    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetResourceViewCount = Selector.Register("setResourceViewCount:");
}
