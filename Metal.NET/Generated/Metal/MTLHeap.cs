namespace Metal.NET;

public partial class MTLHeap(nint nativePtr, NativeObjectOwnership ownership) : MTLAllocation(nativePtr, ownership), INativeObject<MTLHeap>
{
    #region INativeObject
    public static new MTLHeap Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLHeap New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSString Label
    {
        get => GetProperty(ref field, MTLHeapBindings.Label);
        set => SetProperty(ref field, MTLHeapBindings.SetLabel, value);
    }

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLHeapBindings.Device);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveC.MsgSendULong(NativePtr, MTLHeapBindings.StorageMode);
    }

    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveC.MsgSendULong(NativePtr, MTLHeapBindings.CpuCacheMode);
    }

    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveC.MsgSendULong(NativePtr, MTLHeapBindings.HazardTrackingMode);
    }

    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveC.MsgSendULong(NativePtr, MTLHeapBindings.ResourceOptions);
    }

    public nuint Size
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLHeapBindings.Size);
    }

    public nuint UsedSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLHeapBindings.UsedSize);
    }

    public nuint CurrentAllocatedSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLHeapBindings.CurrentAllocatedSize);
    }

    public MTLHeapType Type
    {
        get => (MTLHeapType)ObjectiveC.MsgSendLong(NativePtr, MTLHeapBindings.Type);
    }

    public nuint MaxAvailableSize(nuint alignment)
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, MTLHeapBindings.MaxAvailableSizeWithAlignment, alignment);
    }

    public MTLBuffer MakeBuffer(nuint length, MTLResourceOptions options)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLHeapBindings.NewBufferWithLengthOptions, length, (nuint)options);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLTexture MakeTexture(MTLTextureDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLHeapBindings.NewTextureWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
    {
        return (MTLPurgeableState)ObjectiveC.MsgSendULong(NativePtr, MTLHeapBindings.SetPurgeableState, (nuint)state);
    }

    public MTLBuffer MakeBuffer(nuint length, MTLResourceOptions options, nuint offset)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLHeapBindings.NewBufferWithLengthOptionsOffset, length, (nuint)options, offset);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLTexture MakeTexture(MTLTextureDescriptor descriptor, nuint offset)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLHeapBindings.NewTextureWithDescriptorOffset, descriptor.NativePtr, offset);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLAccelerationStructure MakeAccelerationStructure(nuint size)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLHeapBindings.NewAccelerationStructureWithSize, size);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLAccelerationStructure MakeAccelerationStructure(MTLAccelerationStructureDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLHeapBindings.NewAccelerationStructureWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLAccelerationStructure MakeAccelerationStructure(nuint size, nuint offset)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLHeapBindings.NewAccelerationStructureWithSizeOffset, size, offset);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLAccelerationStructure MakeAccelerationStructure(MTLAccelerationStructureDescriptor descriptor, nuint offset)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLHeapBindings.NewAccelerationStructureWithDescriptorOffset, descriptor.NativePtr, offset);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLHeapBindings
{
    public static readonly Selector CpuCacheMode = "cpuCacheMode";

    public static readonly Selector CurrentAllocatedSize = "currentAllocatedSize";

    public static readonly Selector Device = "device";

    public static readonly Selector HazardTrackingMode = "hazardTrackingMode";

    public static readonly Selector Label = "label";

    public static readonly Selector MaxAvailableSizeWithAlignment = "maxAvailableSizeWithAlignment:";

    public static readonly Selector NewAccelerationStructureWithDescriptor = "newAccelerationStructureWithDescriptor:";

    public static readonly Selector NewAccelerationStructureWithDescriptorOffset = "newAccelerationStructureWithDescriptor:offset:";

    public static readonly Selector NewAccelerationStructureWithSize = "newAccelerationStructureWithSize:";

    public static readonly Selector NewAccelerationStructureWithSizeOffset = "newAccelerationStructureWithSize:offset:";

    public static readonly Selector NewBufferWithLengthOptions = "newBufferWithLength:options:";

    public static readonly Selector NewBufferWithLengthOptionsOffset = "newBufferWithLength:options:offset:";

    public static readonly Selector NewTextureWithDescriptor = "newTextureWithDescriptor:";

    public static readonly Selector NewTextureWithDescriptorOffset = "newTextureWithDescriptor:offset:";

    public static readonly Selector ResourceOptions = "resourceOptions";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetPurgeableState = "setPurgeableState:";

    public static readonly Selector Size = "size";

    public static readonly Selector StorageMode = "storageMode";

    public static readonly Selector Type = "type";

    public static readonly Selector UsedSize = "usedSize";
}
