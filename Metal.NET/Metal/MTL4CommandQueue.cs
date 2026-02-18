namespace Metal.NET;

public class MTL4CommandQueue(nint nativePtr) : NativeObject(nativePtr)
{

    public MTLDevice? Device
    {
        get => GetNullableObject<MTLDevice>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandQueueSelector.Device));
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandQueueSelector.Label));
    }

    public void AddResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueSelector.AddResidencySet, residencySet.NativePtr);
    }

    public void CopyBufferMappingsFromBuffer(MTLBuffer sourceBuffer, MTLBuffer destinationBuffer, MTL4CopySparseBufferMappingOperation operations, nuint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueSelector.CopyBufferMappingsFromBuffer, sourceBuffer.NativePtr, destinationBuffer.NativePtr, operations, count);
    }

    public void CopyTextureMappingsFromTexture(MTLTexture sourceTexture, MTLTexture destinationTexture, MTL4CopySparseTextureMappingOperation operations, nuint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueSelector.CopyTextureMappingsFromTexture, sourceTexture.NativePtr, destinationTexture.NativePtr, operations, count);
    }

    public void RemoveResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueSelector.RemoveResidencySet, residencySet.NativePtr);
    }

    public void SignalDrawable(MTLDrawable drawable)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueSelector.SignalDrawable, drawable.NativePtr);
    }

    public void SignalEvent(MTLEvent @event, nuint value)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueSelector.SignalEvent, @event.NativePtr, value);
    }

    public void UpdateBufferMappings(MTLBuffer buffer, MTLHeap heap, MTL4UpdateSparseBufferMappingOperation operations, nuint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueSelector.UpdateBufferMappings, buffer.NativePtr, heap.NativePtr, operations, count);
    }

    public void UpdateTextureMappings(MTLTexture texture, MTLHeap heap, MTL4UpdateSparseTextureMappingOperation operations, nuint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueSelector.UpdateTextureMappings, texture.NativePtr, heap.NativePtr, operations, count);
    }

    public void Wait(MTLEvent @event, nuint value)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueSelector.Wait, @event.NativePtr, value);
    }

    public void Wait(MTLDrawable drawable)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueSelector.Wait, drawable.NativePtr);
    }
}

file static class MTL4CommandQueueSelector
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
