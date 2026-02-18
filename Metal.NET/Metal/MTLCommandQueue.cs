namespace Metal.NET;

public partial class MTLCommandQueue : NativeObject
{
    public MTLCommandQueue(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLCommandBuffer? CommandBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueSelector.CommandBuffer);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLCommandBuffer? CommandBufferWithUnretainedReferences
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueSelector.CommandBufferWithUnretainedReferences);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueSelector.Device);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandQueueSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public void AddResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandQueueSelector.AddResidencySet, residencySet.NativePtr);
    }

    public MTLCommandBuffer? CommandBufferWithDescriptor(MTLCommandBufferDescriptor descriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueSelector.CommandBuffer, descriptor.NativePtr);
        return ptr is not 0 ? new(ptr) : null;
    }

    public void InsertDebugCaptureBoundary()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandQueueSelector.InsertDebugCaptureBoundary);
    }

    public void RemoveResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandQueueSelector.RemoveResidencySet, residencySet.NativePtr);
    }
}

file static class MTLCommandQueueSelector
{
    public static readonly Selector AddResidencySet = Selector.Register("addResidencySet:");

    public static readonly Selector CommandBuffer = Selector.Register("commandBuffer");

    public static readonly Selector CommandBufferWithUnretainedReferences = Selector.Register("commandBufferWithUnretainedReferences");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector InsertDebugCaptureBoundary = Selector.Register("insertDebugCaptureBoundary");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector RemoveResidencySet = Selector.Register("removeResidencySet:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
