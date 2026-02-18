namespace Metal.NET;

public class MTLHeap(nint nativePtr) : MTLAllocation(nativePtr)
{

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
        get => GetNullableObject<MTLDevice>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.Device));
    }

    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapSelector.HazardTrackingMode);
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapSelector.ResourceOptions);
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
        return GetNullableObject<MTLAccelerationStructure>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.NewAccelerationStructure, size));
    }

    public MTLAccelerationStructure? NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor)
    {
        return GetNullableObject<MTLAccelerationStructure>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.NewAccelerationStructure, descriptor.NativePtr));
    }

    public MTLAccelerationStructure? NewAccelerationStructure(nuint size, nuint offset)
    {
        return GetNullableObject<MTLAccelerationStructure>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.NewAccelerationStructure, size, offset));
    }

    public MTLAccelerationStructure? NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor, nuint offset)
    {
        return GetNullableObject<MTLAccelerationStructure>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.NewAccelerationStructure, descriptor.NativePtr, offset));
    }

    public MTLBuffer? NewBuffer(nuint length, MTLResourceOptions options)
    {
        return GetNullableObject<MTLBuffer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.NewBuffer, length, (nuint)options));
    }

    public MTLBuffer? NewBuffer(nuint length, MTLResourceOptions options, nuint offset)
    {
        return GetNullableObject<MTLBuffer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.NewBuffer, length, (nuint)options, offset));
    }

    public MTLTexture? NewTexture(MTLTextureDescriptor descriptor)
    {
        return GetNullableObject<MTLTexture>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.NewTexture, descriptor.NativePtr));
    }

    public MTLTexture? NewTexture(MTLTextureDescriptor descriptor, nuint offset)
    {
        return GetNullableObject<MTLTexture>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.NewTexture, descriptor.NativePtr, offset));
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

    public static readonly Selector MaxAvailableSize = Selector.Register("maxAvailableSizeWithAlignment:");

    public static readonly Selector NewAccelerationStructure = Selector.Register("newAccelerationStructureWithSize:");

    public static readonly Selector NewBuffer = Selector.Register("newBufferWithLength:options:");

    public static readonly Selector NewTexture = Selector.Register("newTextureWithDescriptor:");

    public static readonly Selector ResourceOptions = Selector.Register("resourceOptions");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetPurgeableState = Selector.Register("setPurgeableState:");

    public static readonly Selector Size = Selector.Register("size");

    public static readonly Selector StorageMode = Selector.Register("storageMode");

    public static readonly Selector Type = Selector.Register("type");

    public static readonly Selector UsedSize = Selector.Register("usedSize");
}
