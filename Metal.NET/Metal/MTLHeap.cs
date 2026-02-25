namespace Metal.NET;

public class MTLHeap(nint nativePtr, bool ownsReference) : MTLAllocation(nativePtr, ownsReference), INativeObject<MTLHeap>
{
    public static new MTLHeap Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
    public static new MTLHeap Null => Create(0, false);
    public static new MTLHeap Empty => Null;

    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapBindings.CpuCacheMode);
    }

    public nuint CurrentAllocatedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapBindings.CurrentAllocatedSize);
    }

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLHeapBindings.Device);
    }

    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapBindings.HazardTrackingMode);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLHeapBindings.Label);
        set => SetProperty(ref field, MTLHeapBindings.SetLabel, value);
    }

    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapBindings.ResourceOptions);
    }

    public nuint Size
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapBindings.Size);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapBindings.StorageMode);
    }

    public MTLHeapType Type
    {
        get => (MTLHeapType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapBindings.Type);
    }

    public nuint UsedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapBindings.UsedSize);
    }

    public nuint MaxAvailableSize(nuint alignment)
    {
        return ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapBindings.MaxAvailableSize, alignment);
    }

    public MTLAccelerationStructure NewAccelerationStructure(nuint size)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapBindings.NewAccelerationStructure, size);

        return new(nativePtr, true);
    }

    public MTLAccelerationStructure NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapBindings.NewAccelerationStructureWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, true);
    }

    public MTLAccelerationStructure NewAccelerationStructure(nuint size, nuint offset)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapBindings.NewAccelerationStructureWithSizeoffset, size, offset);

        return new(nativePtr, true);
    }

    public MTLAccelerationStructure NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor, nuint offset)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapBindings.NewAccelerationStructureWithDescriptoroffset, descriptor.NativePtr, offset);

        return new(nativePtr, true);
    }

    public MTLBuffer NewBuffer(nuint length, MTLResourceOptions options)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapBindings.NewBuffer, length, (nuint)options);

        return new(nativePtr, true);
    }

    public MTLBuffer NewBuffer(nuint length, MTLResourceOptions options, nuint offset)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapBindings.NewBufferWithLengthoptionsoffset, length, (nuint)options, offset);

        return new(nativePtr, true);
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapBindings.NewTexture, descriptor.NativePtr);

        return new(nativePtr, true);
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor, nuint offset)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapBindings.NewTextureWithDescriptoroffset, descriptor.NativePtr, offset);

        return new(nativePtr, true);
    }

    public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
    {
        return (MTLPurgeableState)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapBindings.SetPurgeableState, (nuint)state);
    }
}

file static class MTLHeapBindings
{
    public static readonly Selector CpuCacheMode = "cpuCacheMode";

    public static readonly Selector CurrentAllocatedSize = "currentAllocatedSize";

    public static readonly Selector Device = "device";

    public static readonly Selector HazardTrackingMode = "hazardTrackingMode";

    public static readonly Selector Label = "label";

    public static readonly Selector MaxAvailableSize = "maxAvailableSizeWithAlignment:";

    public static readonly Selector NewAccelerationStructure = "newAccelerationStructureWithSize:";

    public static readonly Selector NewAccelerationStructureWithDescriptor = "newAccelerationStructureWithDescriptor:";

    public static readonly Selector NewAccelerationStructureWithDescriptoroffset = "newAccelerationStructureWithDescriptor:offset:";

    public static readonly Selector NewAccelerationStructureWithSizeoffset = "newAccelerationStructureWithSize:offset:";

    public static readonly Selector NewBuffer = "newBufferWithLength:options:";

    public static readonly Selector NewBufferWithLengthoptionsoffset = "newBufferWithLength:options:offset:";

    public static readonly Selector NewTexture = "newTextureWithDescriptor:";

    public static readonly Selector NewTextureWithDescriptoroffset = "newTextureWithDescriptor:offset:";

    public static readonly Selector ResourceOptions = "resourceOptions";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetPurgeableState = "setPurgeableState:";

    public static readonly Selector Size = "size";

    public static readonly Selector StorageMode = "storageMode";

    public static readonly Selector Type = "type";

    public static readonly Selector UsedSize = "usedSize";
}
