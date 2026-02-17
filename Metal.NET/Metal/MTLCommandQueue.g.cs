namespace Metal.NET;

file class MTLCommandQueueSelector
{
    public static readonly Selector AddResidencySet_ = Selector.Register("addResidencySet:");
    public static readonly Selector InsertDebugCaptureBoundary = Selector.Register("insertDebugCaptureBoundary");
    public static readonly Selector RemoveResidencySet_ = Selector.Register("removeResidencySet:");
    public static readonly Selector SetLabel_ = Selector.Register("setLabel:");
}

public class MTLCommandQueue : IDisposable
{
    public MTLCommandQueue(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLCommandQueue()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLCommandQueue value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLCommandQueue(nint value)
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

    public void AddResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandQueueSelector.AddResidencySet_, residencySet.NativePtr);
    }

    public void InsertDebugCaptureBoundary()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandQueueSelector.InsertDebugCaptureBoundary);
    }

    public void RemoveResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandQueueSelector.RemoveResidencySet_, residencySet.NativePtr);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandQueueSelector.SetLabel_, label.NativePtr);
    }

}
