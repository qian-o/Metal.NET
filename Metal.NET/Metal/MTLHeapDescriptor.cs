namespace Metal.NET;

/// <summary>A configuration that customizes the behavior for a Metal memory heap.</summary>
public class MTLHeapDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLHeapDescriptor>
{
    #region INativeObject
    public static new MTLHeapDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLHeapDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLHeapDescriptor() : this(ObjectiveC.AllocInit(MTLHeapDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Configuring a heap - Properties

    /// <summary>The memory placement strategy for any resources you allocate from the heaps you create with this descriptor.</summary>
    public MTLHeapType Type
    {
        get => (MTLHeapType)ObjectiveC.MsgSendLong(NativePtr, MTLHeapDescriptorBindings.Type);
        set => ObjectiveC.MsgSend(NativePtr, MTLHeapDescriptorBindings.SetType, (nint)value);
    }

    /// <summary>The storage mode for the heaps you create with this descriptor.</summary>
    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveC.MsgSendULong(NativePtr, MTLHeapDescriptorBindings.StorageMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLHeapDescriptorBindings.SetStorageMode, (nuint)value);
    }

    /// <summary>The CPU cache behavior for any resources you allocate from the heaps you create with this descriptor.</summary>
    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveC.MsgSendULong(NativePtr, MTLHeapDescriptorBindings.CpuCacheMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLHeapDescriptorBindings.SetCpuCacheMode, (nuint)value);
    }

    /// <summary>The hazard tracking behavior for any resources you allocate from the heaps you create with this descriptor.</summary>
    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveC.MsgSendULong(NativePtr, MTLHeapDescriptorBindings.HazardTrackingMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLHeapDescriptorBindings.SetHazardTrackingMode, (nuint)value);
    }

    /// <summary>The combined behavior for any resources you allocate from the heaps you create with this descriptor.</summary>
    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveC.MsgSendULong(NativePtr, MTLHeapDescriptorBindings.ResourceOptions);
        set => ObjectiveC.MsgSend(NativePtr, MTLHeapDescriptorBindings.SetResourceOptions, (nuint)value);
    }

    /// <summary>The total amount of memory, in bytes, for the heaps you create with this descriptor.</summary>
    public nuint Size
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLHeapDescriptorBindings.Size);
        set => ObjectiveC.MsgSend(NativePtr, MTLHeapDescriptorBindings.SetSize, value);
    }

    /// <summary>The page size for any resources you allocate from the heaps you create with this descriptor.</summary>
    public MTLSparsePageSize SparsePageSize
    {
        get => (MTLSparsePageSize)ObjectiveC.MsgSendLong(NativePtr, MTLHeapDescriptorBindings.SparsePageSize);
        set => ObjectiveC.MsgSend(NativePtr, MTLHeapDescriptorBindings.SetSparsePageSize, (nint)value);
    }
    #endregion

    #region Instance Properties - Properties

    /// <summary>Specifies the largest sparse page size that the Metal heap supports.</summary>
    public MTLSparsePageSize MaxCompatiblePlacementSparsePageSize
    {
        get => (MTLSparsePageSize)ObjectiveC.MsgSendLong(NativePtr, MTLHeapDescriptorBindings.MaxCompatiblePlacementSparsePageSize);
        set => ObjectiveC.MsgSend(NativePtr, MTLHeapDescriptorBindings.SetMaxCompatiblePlacementSparsePageSize, (nint)value);
    }
    #endregion
}

file static class MTLHeapDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLHeapDescriptor");

    public static readonly Selector CpuCacheMode = "cpuCacheMode";

    public static readonly Selector HazardTrackingMode = "hazardTrackingMode";

    public static readonly Selector MaxCompatiblePlacementSparsePageSize = "maxCompatiblePlacementSparsePageSize";

    public static readonly Selector ResourceOptions = "resourceOptions";

    public static readonly Selector SetCpuCacheMode = "setCpuCacheMode:";

    public static readonly Selector SetHazardTrackingMode = "setHazardTrackingMode:";

    public static readonly Selector SetMaxCompatiblePlacementSparsePageSize = "setMaxCompatiblePlacementSparsePageSize:";

    public static readonly Selector SetResourceOptions = "setResourceOptions:";

    public static readonly Selector SetSize = "setSize:";

    public static readonly Selector SetSparsePageSize = "setSparsePageSize:";

    public static readonly Selector SetStorageMode = "setStorageMode:";

    public static readonly Selector SetType = "setType:";

    public static readonly Selector Size = "size";

    public static readonly Selector SparsePageSize = "sparsePageSize";

    public static readonly Selector StorageMode = "storageMode";

    public static readonly Selector Type = "type";
}
