namespace Metal.NET;

file class MTLHeapSelector
{
    public static readonly Selector MaxAvailableSize_ = Selector.Register("maxAvailableSize:");
    public static readonly Selector NewAccelerationStructure_ = Selector.Register("newAccelerationStructure:");
    public static readonly Selector NewAccelerationStructure_offset_ = Selector.Register("newAccelerationStructure:offset:");
    public static readonly Selector NewBuffer_options_ = Selector.Register("newBuffer:options:");
    public static readonly Selector NewBuffer_options_offset_ = Selector.Register("newBuffer:options:offset:");
    public static readonly Selector NewTexture_ = Selector.Register("newTexture:");
    public static readonly Selector NewTexture_offset_ = Selector.Register("newTexture:offset:");
    public static readonly Selector SetLabel_ = Selector.Register("setLabel:");
    public static readonly Selector SetPurgeableState_ = Selector.Register("setPurgeableState:");
}

public class MTLHeap : IDisposable
{
    public MTLHeap(nint nativePtr)
    {
        NativePtr = nativePtr;
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

    public nuint MaxAvailableSize(nuint alignment)
    {
        var result = (nuint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLHeapSelector.MaxAvailableSize_, (nint)alignment);

        return result;
    }

    public MTLAccelerationStructure NewAccelerationStructure(nuint size)
    {
        var result = new MTLAccelerationStructure(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLHeapSelector.NewAccelerationStructure_, (nint)size));

        return result;
    }

    public MTLAccelerationStructure NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor)
    {
        var result = new MTLAccelerationStructure(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLHeapSelector.NewAccelerationStructure_, descriptor.NativePtr));

        return result;
    }

    public MTLAccelerationStructure NewAccelerationStructure(nuint size, nuint offset)
    {
        var result = new MTLAccelerationStructure(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLHeapSelector.NewAccelerationStructure_offset_, (nint)size, (nint)offset));

        return result;
    }

    public MTLAccelerationStructure NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor, nuint offset)
    {
        var result = new MTLAccelerationStructure(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLHeapSelector.NewAccelerationStructure_offset_, descriptor.NativePtr, (nint)offset));

        return result;
    }

    public MTLBuffer NewBuffer(nuint length, nuint options)
    {
        var result = new MTLBuffer(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLHeapSelector.NewBuffer_options_, (nint)length, (nint)options));

        return result;
    }

    public MTLBuffer NewBuffer(nuint length, nuint options, nuint offset)
    {
        var result = new MTLBuffer(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLHeapSelector.NewBuffer_options_offset_, (nint)length, (nint)options, (nint)offset));

        return result;
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor)
    {
        var result = new MTLTexture(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLHeapSelector.NewTexture_, descriptor.NativePtr));

        return result;
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor, nuint offset)
    {
        var result = new MTLTexture(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLHeapSelector.NewTexture_offset_, descriptor.NativePtr, (nint)offset));

        return result;
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLHeapSelector.SetLabel_, label.NativePtr);
    }

    public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
    {
        var result = (MTLPurgeableState)(uint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLHeapSelector.SetPurgeableState_, (nint)(uint)state);

        return result;
    }

}
