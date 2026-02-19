namespace Metal.NET;

public class MTLCommandQueue(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLCommandBuffer? CommandBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueBindings.CommandBuffer);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLCommandBuffer(ptr);
            }

            return field;
        }
    }

    public MTLCommandBuffer? CommandBufferWithUnretainedReferences
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueBindings.CommandBufferWithUnretainedReferences);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLCommandBuffer(ptr);
            }

            return field;
        }
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueBindings.Device);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLDevice(ptr);
            }

            return field;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueBindings.Label);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSString(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandQueueBindings.SetLabel, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public void AddResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandQueueBindings.AddResidencySet, residencySet.NativePtr);
    }

    public MTLCommandBuffer? CommandBufferWithDescriptor(MTLCommandBufferDescriptor descriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueBindings.CommandBuffer, descriptor.NativePtr);
        return ptr is not 0 ? new MTLCommandBuffer(ptr) : null;
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
