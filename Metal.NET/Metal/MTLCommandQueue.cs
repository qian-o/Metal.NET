namespace Metal.NET;

public class MTLCommandQueue : IDisposable
{
    public MTLCommandQueue(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLCommandQueue()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLCommandBuffer CommandBuffer
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueSelector.CommandBuffer));
    }

    public MTLCommandBuffer CommandBufferWithUnretainedReferences
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueSelector.CommandBufferWithUnretainedReferences));
    }

    public MTLDevice Device
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueSelector.Device));
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandQueueSelector.SetLabel, value.NativePtr);
    }

    public void AddResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandQueueSelector.AddResidencySet, residencySet.NativePtr);
    }

    public void InsertDebugCaptureBoundary()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandQueueSelector.InsertDebugCaptureBoundary);
    }

    public void RemoveResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandQueueSelector.RemoveResidencySet, residencySet.NativePtr);
    }

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
}

file class MTLCommandQueueSelector
{
    public static readonly Selector CommandBuffer = Selector.Register("commandBuffer");

    public static readonly Selector CommandBufferWithUnretainedReferences = Selector.Register("commandBufferWithUnretainedReferences");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector AddResidencySet = Selector.Register("addResidencySet:");

    public static readonly Selector InsertDebugCaptureBoundary = Selector.Register("insertDebugCaptureBoundary");

    public static readonly Selector RemoveResidencySet = Selector.Register("removeResidencySet:");
}
