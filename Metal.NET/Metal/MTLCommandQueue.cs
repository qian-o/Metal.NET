namespace Metal.NET;

public readonly struct MTLCommandQueue(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLCommandBuffer? CommandBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueBindings.CommandBuffer);
            return ptr is not 0 ? new MTLCommandBuffer(ptr) : default;
        }
    }

    public MTLCommandBuffer? CommandBufferWithUnretainedReferences
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueBindings.CommandBufferWithUnretainedReferences);
            return ptr is not 0 ? new MTLCommandBuffer(ptr) : default;
        }
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueBindings.Device);
            return ptr is not 0 ? new MTLDevice(ptr) : default;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandQueueBindings.SetLabel, value?.NativePtr ?? 0);
    }

    public void AddResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandQueueBindings.AddResidencySet, residencySet.NativePtr);
    }

    public MTLCommandBuffer? CommandBufferWithDescriptor(MTLCommandBufferDescriptor descriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueBindings.CommandBuffer, descriptor.NativePtr);
        return ptr is not 0 ? new MTLCommandBuffer(ptr) : default;
    }

    public void InsertDebugCaptureBoundary()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandQueueBindings.InsertDebugCaptureBoundary);
    }

    public void RemoveResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandQueueBindings.RemoveResidencySet, residencySet.NativePtr);
    }
}

file static class MTLCommandQueueBindings
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
