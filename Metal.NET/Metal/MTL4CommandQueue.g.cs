namespace Metal.NET;

file class MTL4CommandQueueSelector
{
    public static readonly Selector AddResidencySet_ = Selector.Register("addResidencySet:");
    public static readonly Selector RemoveResidencySet_ = Selector.Register("removeResidencySet:");
    public static readonly Selector SignalDrawable_ = Selector.Register("signalDrawable:");
    public static readonly Selector SignalEvent_value_ = Selector.Register("signalEvent:value:");
    public static readonly Selector Wait_value_ = Selector.Register("wait:value:");
    public static readonly Selector Wait_ = Selector.Register("wait:");
}

public class MTL4CommandQueue : IDisposable
{
    public MTL4CommandQueue(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTL4CommandQueue()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4CommandQueue value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4CommandQueue(nint value)
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandQueueSelector.AddResidencySet_, residencySet.NativePtr);
    }

    public void RemoveResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandQueueSelector.RemoveResidencySet_, residencySet.NativePtr);
    }

    public void SignalDrawable(MTLDrawable drawable)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandQueueSelector.SignalDrawable_, drawable.NativePtr);
    }

    public void SignalEvent(MTLEvent @event, nuint value)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandQueueSelector.SignalEvent_value_, @event.NativePtr, (nint)value);
    }

    public void Wait(MTLEvent @event, nuint value)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandQueueSelector.Wait_value_, @event.NativePtr, (nint)value);
    }

    public void Wait(MTLDrawable drawable)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandQueueSelector.Wait_, drawable.NativePtr);
    }

}
