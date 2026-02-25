namespace Metal.NET;

public class MTLHeapDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLHeapDescriptor>
{
    public static MTLHeapDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static MTLHeapDescriptor Null => new(0, false);

    public MTLHeapDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLHeapDescriptorBindings.Class), true)
    {
    }

    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapDescriptorBindings.CpuCacheMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorBindings.SetCpuCacheMode, (nuint)value);
    }

    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapDescriptorBindings.HazardTrackingMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorBindings.SetHazardTrackingMode, (nuint)value);
    }

    public MTLSparsePageSize MaxCompatiblePlacementSparsePageSize
    {
        get => (MTLSparsePageSize)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapDescriptorBindings.MaxCompatiblePlacementSparsePageSize);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorBindings.SetMaxCompatiblePlacementSparsePageSize, (nint)value);
    }

    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapDescriptorBindings.ResourceOptions);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorBindings.SetResourceOptions, (nuint)value);
    }

    public nuint Size
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapDescriptorBindings.Size);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorBindings.SetSize, value);
    }

    public MTLSparsePageSize SparsePageSize
    {
        get => (MTLSparsePageSize)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapDescriptorBindings.SparsePageSize);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorBindings.SetSparsePageSize, (nint)value);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapDescriptorBindings.StorageMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorBindings.SetStorageMode, (nuint)value);
    }

    public MTLHeapType Type
    {
        get => (MTLHeapType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapDescriptorBindings.Type);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorBindings.SetType, (nint)value);
    }
}

file static class MTLHeapDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLHeapDescriptor");

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
