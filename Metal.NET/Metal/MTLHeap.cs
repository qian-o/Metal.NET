namespace Metal.NET;

public class MTLHeap(nint nativePtr) : MTLAllocation(nativePtr)
{
    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLHeapSelector.CpuCacheMode);
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
        get => (MTLHazardTrackingMode)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLHeapSelector.HazardTrackingMode);
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapSelector.SetLabel, value.NativePtr);
    }

    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLHeapSelector.ResourceOptions);
    }

    public nuint Size
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapSelector.Size);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLHeapSelector.StorageMode);
    }

    public MTLHeapType Type
    {
        get => (MTLHeapType)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLHeapSelector.Type);
    }

    public nuint UsedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapSelector.UsedSize);
    }

    public static implicit operator nint(MTLHeap value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLHeap(nint value)
    {
        return new(value);
    }

    public nuint MaxAvailableSize(nuint alignment)
    {
        nuint result = ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapSelector.MaxAvailableSizeWithAlignment, alignment);

        return result;
    }

    public MTLAccelerationStructure NewAccelerationStructure(nuint size)
    {
        MTLAccelerationStructure result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.NewAccelerationStructureWithSize, size));

        return result;
    }

    public MTLAccelerationStructure NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor)
    {
        MTLAccelerationStructure result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.NewAccelerationStructureWithDescriptor, descriptor.NativePtr));

        return result;
    }

    public MTLAccelerationStructure NewAccelerationStructure(nuint size, nuint offset)
    {
        MTLAccelerationStructure result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.NewAccelerationStructureWithSizeOffset, size, offset));

        return result;
    }

    public MTLAccelerationStructure NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor, nuint offset)
    {
        MTLAccelerationStructure result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.NewAccelerationStructureWithDescriptorOffset, descriptor.NativePtr, offset));

        return result;
    }

    public MTLBuffer NewBuffer(nuint length, MTLResourceOptions options)
    {
        MTLBuffer result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.NewBufferWithLengthOptions, length, (ulong)options));

        return result;
    }

    public MTLBuffer NewBuffer(nuint length, MTLResourceOptions options, nuint offset)
    {
        MTLBuffer result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.NewBufferWithLengthOptionsOffset, length, (ulong)options, offset));

        return result;
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor)
    {
        MTLTexture result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.NewTextureWithDescriptor, descriptor.NativePtr));

        return result;
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor, nuint offset)
    {
        MTLTexture result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapSelector.NewTextureWithDescriptorOffset, descriptor.NativePtr, offset));

        return result;
    }

    public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
    {
        MTLPurgeableState result = (MTLPurgeableState)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLHeapSelector.SetPurgeableState, (ulong)state);

        return result;
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

    public static readonly Selector MaxAvailableSizeWithAlignment = Selector.Register("maxAvailableSizeWithAlignment:");

    public static readonly Selector NewAccelerationStructureWithSize = Selector.Register("newAccelerationStructureWithSize:");

    public static readonly Selector NewAccelerationStructureWithDescriptor = Selector.Register("newAccelerationStructureWithDescriptor:");

    public static readonly Selector NewAccelerationStructureWithSizeOffset = Selector.Register("newAccelerationStructureWithSize:offset:");

    public static readonly Selector NewAccelerationStructureWithDescriptorOffset = Selector.Register("newAccelerationStructureWithDescriptor:offset:");

    public static readonly Selector NewBufferWithLengthOptions = Selector.Register("newBufferWithLength:options:");

    public static readonly Selector NewBufferWithLengthOptionsOffset = Selector.Register("newBufferWithLength:options:offset:");

    public static readonly Selector NewTextureWithDescriptor = Selector.Register("newTextureWithDescriptor:");

    public static readonly Selector NewTextureWithDescriptorOffset = Selector.Register("newTextureWithDescriptor:offset:");

    public static readonly Selector SetPurgeableState = Selector.Register("setPurgeableState:");
}
