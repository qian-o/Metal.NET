namespace Metal.NET;

public class MTLHeap : IDisposable
{
    public MTLHeap(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLHeap()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLHeap value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLHeap(nint value)
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

    public nuint MaxAvailableSize(uint alignment)
    {
        var result = (nuint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLHeapSelector.MaxAvailableSize, (nint)alignment);

        return result;
    }

    public MTLAccelerationStructure NewAccelerationStructure(uint size)
    {
        var result = new MTLAccelerationStructure(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLHeapSelector.NewAccelerationStructure, (nint)size));

        return result;
    }

    public MTLAccelerationStructure NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor)
    {
        var result = new MTLAccelerationStructure(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLHeapSelector.NewAccelerationStructure, descriptor.NativePtr));

        return result;
    }

    public MTLAccelerationStructure NewAccelerationStructure(uint size, uint offset)
    {
        var result = new MTLAccelerationStructure(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLHeapSelector.NewAccelerationStructureOffset, (nint)size, (nint)offset));

        return result;
    }

    public MTLAccelerationStructure NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor, uint offset)
    {
        var result = new MTLAccelerationStructure(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLHeapSelector.NewAccelerationStructureOffset, descriptor.NativePtr, (nint)offset));

        return result;
    }

    public MTLBuffer NewBuffer(uint length, uint options)
    {
        var result = new MTLBuffer(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLHeapSelector.NewBufferOptions, (nint)length, (nint)options));

        return result;
    }

    public MTLBuffer NewBuffer(uint length, uint options, uint offset)
    {
        var result = new MTLBuffer(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLHeapSelector.NewBufferOptionsOffset, (nint)length, (nint)options, (nint)offset));

        return result;
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor)
    {
        var result = new MTLTexture(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLHeapSelector.NewTexture, descriptor.NativePtr));

        return result;
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor, uint offset)
    {
        var result = new MTLTexture(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLHeapSelector.NewTextureOffset, descriptor.NativePtr, (nint)offset));

        return result;
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLHeapSelector.SetLabel, label.NativePtr);
    }

    public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
    {
        var result = (MTLPurgeableState)(uint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLHeapSelector.SetPurgeableState, (nint)(uint)state);

        return result;
    }

}

file class MTLHeapSelector
{
    public static readonly Selector MaxAvailableSize = Selector.Register("maxAvailableSize:");
    public static readonly Selector NewAccelerationStructure = Selector.Register("newAccelerationStructure:");
    public static readonly Selector NewAccelerationStructureOffset = Selector.Register("newAccelerationStructure:offset:");
    public static readonly Selector NewBufferOptions = Selector.Register("newBuffer:options:");
    public static readonly Selector NewBufferOptionsOffset = Selector.Register("newBuffer:options:offset:");
    public static readonly Selector NewTexture = Selector.Register("newTexture:");
    public static readonly Selector NewTextureOffset = Selector.Register("newTexture:offset:");
    public static readonly Selector SetLabel = Selector.Register("setLabel:");
    public static readonly Selector SetPurgeableState = Selector.Register("setPurgeableState:");
}
