namespace Metal.NET;

public class MTL4CommandQueue : IDisposable
{
    public MTL4CommandQueue(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandQueueSelector.AddResidencySet, residencySet.NativePtr);
    }

    public void RemoveResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandQueueSelector.RemoveResidencySet, residencySet.NativePtr);
    }

    public void SignalDrawable(MTLDrawable drawable)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandQueueSelector.SignalDrawable, drawable.NativePtr);
    }

    public void SignalEvent(MTLEvent @event, uint value)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandQueueSelector.SignalEventValue, @event.NativePtr, (nint)value);
    }

    public void Wait(MTLEvent @event, uint value)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandQueueSelector.WaitValue, @event.NativePtr, (nint)value);
    }

    public void Wait(MTLDrawable drawable)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandQueueSelector.Wait, drawable.NativePtr);
    }

}

file class MTL4CommandQueueSelector
{
    public static readonly Selector AddResidencySet = Selector.Register("addResidencySet:");
    public static readonly Selector RemoveResidencySet = Selector.Register("removeResidencySet:");
    public static readonly Selector SignalDrawable = Selector.Register("signalDrawable:");
    public static readonly Selector SignalEventValue = Selector.Register("signalEvent:value:");
    public static readonly Selector WaitValue = Selector.Register("wait:value:");
    public static readonly Selector Wait = Selector.Register("wait:");
}
