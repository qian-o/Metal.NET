namespace Metal.NET;

public partial class MTLHeap : NativeObject
{
    public MTLHeap(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapSelector.CpuCacheMode);
    }

    public nuint CurrentAllocatedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapSelector.CurrentAllocatedSize);
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.Device);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapSelector.HazardTrackingMode);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapSelector.SetLabel, value?.NativePtr ?? 0);
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
        get => (MTLStorageMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapSelector.StorageMode);
    }

    public MTLHeapType Type
    {
        get => (MTLHeapType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.Type);
    }

    public nuint UsedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapSelector.UsedSize);
    }

    public nuint MaxAvailableSize(nuint alignment)
    {
        return ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapSelector.MaxAvailableSize, alignment);
    }

    public MTLAccelerationStructure? NewAccelerationStructure(nuint size)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.NewAccelerationStructure, size);
        return ptr is not 0 ? new(ptr) : null;
    }

    public MTLAccelerationStructure? NewAccelerationStructure(nuint size, nuint offset)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.NewAccelerationStructure, size, offset);
        return ptr is not 0 ? new(ptr) : null;
    }

    public MTLBuffer? NewBuffer(nuint length, MTLResourceOptions options)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.NewBuffer, length, (nuint)options);
        return ptr is not 0 ? new(ptr) : null;
    }

    public MTLBuffer? NewBuffer(nuint length, MTLResourceOptions options, nuint offset)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.NewBuffer, length, (nuint)options, offset);
        return ptr is not 0 ? new(ptr) : null;
    }

    public MTLTexture? NewTexture(MTLTextureDescriptor descriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.NewTexture, descriptor.NativePtr);
        return ptr is not 0 ? new(ptr) : null;
    }

    public MTLTexture? NewTexture(MTLTextureDescriptor descriptor, nuint offset)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.NewTexture, descriptor.NativePtr, offset);
        return ptr is not 0 ? new(ptr) : null;
    }

    public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
    {
        return (MTLPurgeableState)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapSelector.SetPurgeableState, (nuint)state);
    }
}

file static class MTLHeapSelector
{
    public static readonly Selector CpuCacheMode = Selector.Register("cpuCacheMode");

    public static readonly Selector CurrentAllocatedSize = Selector.Register("currentAllocatedSize");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector HazardTrackingMode = Selector.Register("hazardTrackingMode");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector MaxAvailableSize = Selector.Register("maxAvailableSize:");

    public static readonly Selector NewAccelerationStructure = Selector.Register("newAccelerationStructure:");

    public static readonly Selector NewBuffer = Selector.Register("newBuffer::");

    public static readonly Selector NewTexture = Selector.Register("newTexture:");

    public static readonly Selector ResourceOptions = Selector.Register("resourceOptions");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetPurgeableState = Selector.Register("setPurgeableState:");

    public static readonly Selector Size = Selector.Register("size");

    public static readonly Selector StorageMode = Selector.Register("storageMode");

    public static readonly Selector Type = Selector.Register("type");

    public static readonly Selector UsedSize = Selector.Register("usedSize");
}
