namespace Metal.NET;

file class MTLResourceViewPoolDescriptorSelector
{
    public static readonly Selector SetLabel_ = Selector.Register("setLabel:");
    public static readonly Selector SetResourceViewCount_ = Selector.Register("setResourceViewCount:");
}

public class MTLResourceViewPoolDescriptor : IDisposable
{
    public MTLResourceViewPoolDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResourceViewPoolDescriptorSelector.SetLabel_, label.NativePtr);
    }

    public void SetResourceViewCount(nuint resourceViewCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResourceViewPoolDescriptorSelector.SetResourceViewCount_, (nint)resourceViewCount);
    }

}
