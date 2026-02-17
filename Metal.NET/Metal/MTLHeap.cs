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

    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLHeapSelector.CpuCacheMode));
    }

    public nuint CurrentAllocatedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapSelector.CurrentAllocatedSize);
    }

    public MTLDevice Device
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.Device));
    }

    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLHeapSelector.HazardTrackingMode));
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapSelector.SetLabel, value.NativePtr);
    }

    public nuint ResourceOptions
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapSelector.ResourceOptions);
    }

    public nuint Size
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapSelector.Size);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLHeapSelector.StorageMode));
    }

    public MTLHeapType Type
    {
        get => (MTLHeapType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLHeapSelector.Type));
    }

    public nuint UsedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapSelector.UsedSize);
    }

    public nuint MaxAvailableSize(nuint alignment)
    {
        nuint result = ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapSelector.MaxAvailableSize, alignment);

        return result;
    }

    public MTLAccelerationStructure NewAccelerationStructure(nuint size)
    {
        MTLAccelerationStructure result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.NewAccelerationStructure, size));

        return result;
    }

    public MTLAccelerationStructure NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor)
    {
        MTLAccelerationStructure result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.NewAccelerationStructure, descriptor.NativePtr));

        return result;
    }

    public MTLAccelerationStructure NewAccelerationStructure(nuint size, nuint offset)
    {
        MTLAccelerationStructure result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.NewAccelerationStructureOffset, size, offset));

        return result;
    }

    public MTLAccelerationStructure NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor, nuint offset)
    {
        MTLAccelerationStructure result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.NewAccelerationStructureOffset, descriptor.NativePtr, offset));

        return result;
    }

    public MTLBuffer NewBuffer(nuint length, nuint options)
    {
        MTLBuffer result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.NewBufferOptions, length, options));

        return result;
    }

    public MTLBuffer NewBuffer(nuint length, nuint options, nuint offset)
    {
        MTLBuffer result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.NewBufferOptionsOffset, length, options, offset));

        return result;
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor)
    {
        MTLTexture result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.NewTexture, descriptor.NativePtr));

        return result;
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor, nuint offset)
    {
        MTLTexture result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.NewTextureOffset, descriptor.NativePtr, offset));

        return result;
    }

    public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
    {
        MTLPurgeableState result = (MTLPurgeableState)ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLHeapSelector.SetPurgeableState, (uint)state);

        return result;
    }

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
}

file class MTLHeapSelector
{
    public static readonly Selector CpuCacheMode = Selector.Register("cpuCacheMode");

    public static readonly Selector CurrentAllocatedSize = Selector.Register("currentAllocatedSize");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector HazardTrackingMode = Selector.Register("hazardTrackingMode");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector ResourceOptions = Selector.Register("resourceOptions");

    public static readonly Selector Size = Selector.Register("size");

    public static readonly Selector StorageMode = Selector.Register("storageMode");

    public static readonly Selector Type = Selector.Register("type");

    public static readonly Selector UsedSize = Selector.Register("usedSize");

    public static readonly Selector MaxAvailableSize = Selector.Register("maxAvailableSize:");

    public static readonly Selector NewAccelerationStructure = Selector.Register("newAccelerationStructure:");

    public static readonly Selector NewAccelerationStructureOffset = Selector.Register("newAccelerationStructure:offset:");

    public static readonly Selector NewBufferOptions = Selector.Register("newBuffer:options:");

    public static readonly Selector NewBufferOptionsOffset = Selector.Register("newBuffer:options:offset:");

    public static readonly Selector NewTexture = Selector.Register("newTexture:");

    public static readonly Selector NewTextureOffset = Selector.Register("newTexture:offset:");

    public static readonly Selector SetPurgeableState = Selector.Register("setPurgeableState:");
}
