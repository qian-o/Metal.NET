namespace Metal.NET;

public class MTL4CommandQueue(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandQueueBindings.Device);

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
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandQueueBindings.Label);

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
    }

    public void AddResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueBindings.AddResidencySet, residencySet.NativePtr);
    }

    public void CopyBufferMappingsFromBuffer(MTLBuffer sourceBuffer, MTLBuffer destinationBuffer, MTL4CopySparseBufferMappingOperation operations, nuint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueBindings.CopyBufferMappingsFromBuffer, sourceBuffer.NativePtr, destinationBuffer.NativePtr, operations, count);
    }

    public void CopyTextureMappingsFromTexture(MTLTexture sourceTexture, MTLTexture destinationTexture, MTL4CopySparseTextureMappingOperation operations, nuint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueBindings.CopyTextureMappingsFromTexture, sourceTexture.NativePtr, destinationTexture.NativePtr, operations, count);
    }

    public void RemoveResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueBindings.RemoveResidencySet, residencySet.NativePtr);
    }

    public void SignalDrawable(MTLDrawable drawable)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueBindings.SignalDrawable, drawable.NativePtr);
    }

    public void SignalEvent(MTLEvent @event, nuint value)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueBindings.SignalEvent, @event.NativePtr, value);
    }

    public void UpdateBufferMappings(MTLBuffer buffer, MTLHeap heap, MTL4UpdateSparseBufferMappingOperation operations, nuint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueBindings.UpdateBufferMappings, buffer.NativePtr, heap.NativePtr, operations, count);
    }

    public void UpdateTextureMappings(MTLTexture texture, MTLHeap heap, MTL4UpdateSparseTextureMappingOperation operations, nuint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueBindings.UpdateTextureMappings, texture.NativePtr, heap.NativePtr, operations, count);
    }

    public void Wait(MTLEvent @event, nuint value)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueBindings.Wait, @event.NativePtr, value);
    }

    public void Wait(MTLDrawable drawable)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueBindings.Wait, drawable.NativePtr);
    }
}

file static class MTL4CommandQueueBindings
{
    public static readonly Selector AddResidencySet = Selector.Register("addResidencySet:");

    public static readonly Selector CopyBufferMappingsFromBuffer = Selector.Register("copyBufferMappingsFromBuffer:toBuffer:operations:count:");

    public static readonly Selector CopyTextureMappingsFromTexture = Selector.Register("copyTextureMappingsFromTexture:toTexture:operations:count:");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector RemoveResidencySet = Selector.Register("removeResidencySet:");

    public static readonly Selector SignalDrawable = Selector.Register("signalDrawable:");

    public static readonly Selector SignalEvent = Selector.Register("signalEvent:value:");

    public static readonly Selector UpdateBufferMappings = Selector.Register("updateBufferMappings:heap:operations:count:");

    public static readonly Selector UpdateTextureMappings = Selector.Register("updateTextureMappings:heap:operations:count:");

    public static readonly Selector Wait = Selector.Register("waitForEvent:value:");
}
