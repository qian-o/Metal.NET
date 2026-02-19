namespace Metal.NET;

public class MTLIOCommandQueue(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLIOCommandBuffer? CommandBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandQueueBindings.CommandBuffer);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLIOCommandBuffer(ptr);
            }

            return field;
        }
    }

    public MTLIOCommandBuffer? CommandBufferWithUnretainedReferences
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandQueueBindings.CommandBufferWithUnretainedReferences);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLIOCommandBuffer(ptr);
            }

            return field;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandQueueBindings.Label);

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
            ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandQueueBindings.SetLabel, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public void EnqueueBarrier()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandQueueBindings.EnqueueBarrier);
    }
}

file static class MTLIOCommandQueueBindings
{
    public static readonly Selector CommandBuffer = Selector.Register("commandBuffer");

    public static readonly Selector CommandBufferWithUnretainedReferences = Selector.Register("commandBufferWithUnretainedReferences");

    public static readonly Selector EnqueueBarrier = Selector.Register("enqueueBarrier");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
