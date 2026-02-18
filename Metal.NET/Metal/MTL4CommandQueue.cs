namespace Metal.NET;

public class MTL4CommandQueue : IDisposable
{
    public MTL4CommandQueue(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTL4CommandQueue()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLDevice Device
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandQueueSelector.Device));
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandQueueSelector.Label));
    }

    public static implicit operator nint(MTL4CommandQueue value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4CommandQueue(nint value)
    {
        return new(value);
    }

    public void AddResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueSelector.AddResidencySet, residencySet.NativePtr);
    }

    public void CopyBufferMappingsFromBuffer(MTLBuffer sourceBuffer, MTLBuffer destinationBuffer, MTL4CopySparseBufferMappingOperation operations, nuint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueSelector.CopyBufferMappingsFromBufferToBufferOperationsCount, sourceBuffer.NativePtr, destinationBuffer.NativePtr, operations, count);
    }

    public void CopyTextureMappingsFromTexture(MTLTexture sourceTexture, MTLTexture destinationTexture, MTL4CopySparseTextureMappingOperation operations, nuint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueSelector.CopyTextureMappingsFromTextureToTextureOperationsCount, sourceTexture.NativePtr, destinationTexture.NativePtr, operations, count);
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
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueSelector.SignalEventValue, @event.NativePtr, value);
    }

    public void UpdateBufferMappings(MTLBuffer buffer, MTLHeap heap, MTL4UpdateSparseBufferMappingOperation operations, nuint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueSelector.UpdateBufferMappingsHeapOperationsCount, buffer.NativePtr, heap.NativePtr, operations, count);
    }

    public void UpdateTextureMappings(MTLTexture texture, MTLHeap heap, MTL4UpdateSparseTextureMappingOperation operations, nuint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueSelector.UpdateTextureMappingsHeapOperationsCount, texture.NativePtr, heap.NativePtr, operations, count);
    }

    public void Wait(MTLEvent @event, nuint value)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueSelector.WaitForEventValue, @event.NativePtr, value);
    }

    public void Wait(MTLDrawable drawable)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueSelector.WaitForDrawable, drawable.NativePtr);
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

file class MTL4CommandQueueSelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector AddResidencySet = Selector.Register("addResidencySet:");

    public static readonly Selector CopyBufferMappingsFromBufferToBufferOperationsCount = Selector.Register("copyBufferMappingsFromBuffer:toBuffer:operations:count:");

    public static readonly Selector CopyTextureMappingsFromTextureToTextureOperationsCount = Selector.Register("copyTextureMappingsFromTexture:toTexture:operations:count:");

    public static readonly Selector RemoveResidencySet = Selector.Register("removeResidencySet:");

    public static readonly Selector SignalDrawable = Selector.Register("signalDrawable:");

    public static readonly Selector SignalEventValue = Selector.Register("signalEvent:value:");

    public static readonly Selector UpdateBufferMappingsHeapOperationsCount = Selector.Register("updateBufferMappings:heap:operations:count:");

    public static readonly Selector UpdateTextureMappingsHeapOperationsCount = Selector.Register("updateTextureMappings:heap:operations:count:");

    public static readonly Selector WaitForEventValue = Selector.Register("waitForEvent:value:");

    public static readonly Selector WaitForDrawable = Selector.Register("waitForDrawable:");
}
