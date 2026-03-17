namespace Metal.NET;

/// <summary>
/// A memory pool from which you can suballocate resources.
/// </summary>
public class MTLHeap(nint nativePtr, NativeObjectOwnership ownership) : MTLAllocation(nativePtr, ownership), INativeObject<MTLHeap>
{
    #region INativeObject
    public static new MTLHeap Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLHeap New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Naming and identifying a heap - Properties

    /// <summary>
    /// A string that identifies the heap.
    /// </summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLHeapBindings.Label);
        set => SetProperty(ref field, MTLHeapBindings.SetLabel, value);
    }
    #endregion

    #region Checking a heap’s size information - Properties

    /// <summary>
    /// The total size of the heap, in bytes.
    /// </summary>
    public nuint Size
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLHeapBindings.Size);
    }

    /// <summary>
    /// The size of all resources currently in the heap, in bytes.
    /// </summary>
    public nuint UsedSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLHeapBindings.UsedSize);
    }

    /// <summary>
    /// The size, in bytes, of the current heap allocation.
    /// </summary>
    public nuint CurrentAllocatedSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLHeapBindings.CurrentAllocatedSize);
    }
    #endregion

    #region Checking a heap’s permanent configuration - Properties

    /// <summary>
    /// The device object that created the heap.
    /// </summary>
    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLHeapBindings.Device);
    }

    /// <summary>
    /// The heap’s type.
    /// </summary>
    public MTLHeapType Type
    {
        get => (MTLHeapType)ObjectiveC.MsgSendLong(NativePtr, MTLHeapBindings.Type);
    }

    /// <summary>
    /// The heap’s storage mode.
    /// </summary>
    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveC.MsgSendULong(NativePtr, MTLHeapBindings.StorageMode);
    }

    /// <summary>
    /// The heap’s CPU cache mode.
    /// </summary>
    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveC.MsgSendULong(NativePtr, MTLHeapBindings.CpuCacheMode);
    }

    /// <summary>
    /// The heap’s hazard tracking mode.
    /// </summary>
    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveC.MsgSendULong(NativePtr, MTLHeapBindings.HazardTrackingMode);
    }

    /// <summary>
    /// The options for resources created by the heap.
    /// </summary>
    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveC.MsgSendULong(NativePtr, MTLHeapBindings.ResourceOptions);
    }
    #endregion

    #region Creating buffers from a heap - Methods

    /// <summary>
    /// Creates a buffer on the heap.
    /// </summary>
    public MTLBuffer NewBuffer(nuint length, MTLResourceOptions options)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLHeapBindings.NewBuffer, length, (nuint)options);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a buffer on the heap.
    /// </summary>
    public MTLBuffer NewBuffer(nuint length, MTLResourceOptions options, nuint offset)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLHeapBindings.NewBufferWithLengthoptionsoffset, length, (nuint)options, offset);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Creating textures from a heap - Methods

    /// <summary>
    /// Creates a texture on the heap.
    /// </summary>
    public MTLTexture NewTexture(MTLTextureDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLHeapBindings.NewTexture, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a texture on the heap.
    /// </summary>
    public MTLTexture NewTexture(MTLTextureDescriptor descriptor, nuint offset)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLHeapBindings.NewTextureWithDescriptoroffset, descriptor.NativePtr, offset);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Creating acceleration structure from a heap - Methods

    public MTLAccelerationStructure NewAccelerationStructure(nuint size)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLHeapBindings.NewAccelerationStructure, size);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLAccelerationStructure NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLHeapBindings.NewAccelerationStructureWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLAccelerationStructure NewAccelerationStructure(nuint size, nuint offset)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLHeapBindings.NewAccelerationStructureWithSizeoffset, size, offset);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLAccelerationStructure NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor, nuint offset)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLHeapBindings.NewAccelerationStructureWithDescriptoroffset, descriptor.NativePtr, offset);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Configuring a heap’s purgeable state - Methods

    /// <summary>
    /// Sets the purgeable state of the heap.
    /// </summary>
    public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
    {
        return (MTLPurgeableState)ObjectiveC.MsgSendULong(NativePtr, MTLHeapBindings.SetPurgeableState, (nuint)state);
    }
    #endregion

    #region Checking a heap’s size information - Methods

    /// <summary>
    /// The maximum size of a resource, in bytes, that can be currently allocated from the heap.
    /// </summary>
    public nuint MaxAvailableSize(nuint alignment)
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, MTLHeapBindings.MaxAvailableSize, alignment);
    }
    #endregion
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
