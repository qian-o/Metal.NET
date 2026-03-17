namespace Metal.NET;

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

    public nuint Size
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLHeapDescriptorBindings.Size);
        set => ObjectiveC.MsgSend(NativePtr, MTLHeapDescriptorBindings.SetSize, value);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveC.MsgSendULong(NativePtr, MTLHeapDescriptorBindings.StorageMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLHeapDescriptorBindings.SetStorageMode, (nuint)value);
    }

    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveC.MsgSendULong(NativePtr, MTLHeapDescriptorBindings.CpuCacheMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLHeapDescriptorBindings.SetCpuCacheMode, (nuint)value);
    }

    public MTLSparsePageSize SparsePageSize
    {
        get => (MTLSparsePageSize)ObjectiveC.MsgSendLong(NativePtr, MTLHeapDescriptorBindings.SparsePageSize);
        set => ObjectiveC.MsgSend(NativePtr, MTLHeapDescriptorBindings.SetSparsePageSize, (nint)value);
    }

    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveC.MsgSendULong(NativePtr, MTLHeapDescriptorBindings.HazardTrackingMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLHeapDescriptorBindings.SetHazardTrackingMode, (nuint)value);
    }

    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveC.MsgSendULong(NativePtr, MTLHeapDescriptorBindings.ResourceOptions);
        set => ObjectiveC.MsgSend(NativePtr, MTLHeapDescriptorBindings.SetResourceOptions, (nuint)value);
    }

    public MTLHeapType Type
    {
        get => (MTLHeapType)ObjectiveC.MsgSendLong(NativePtr, MTLHeapDescriptorBindings.Type);
        set => ObjectiveC.MsgSend(NativePtr, MTLHeapDescriptorBindings.SetType, (nint)value);
    }

    public MTLSparsePageSize MaxCompatiblePlacementSparsePageSize
    {
        get => (MTLSparsePageSize)ObjectiveC.MsgSendLong(NativePtr, MTLHeapDescriptorBindings.MaxCompatiblePlacementSparsePageSize);
        set => ObjectiveC.MsgSend(NativePtr, MTLHeapDescriptorBindings.SetMaxCompatiblePlacementSparsePageSize, (nint)value);
    }
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
