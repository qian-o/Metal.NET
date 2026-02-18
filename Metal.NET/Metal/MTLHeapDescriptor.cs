namespace Metal.NET;

public class MTLHeapDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLHeapDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLHeapDescriptorSelector.Class))
    {
    }

    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapDescriptorSelector.CpuCacheMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorSelector.SetCpuCacheMode, (nuint)value);
    }

    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapDescriptorSelector.HazardTrackingMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorSelector.SetHazardTrackingMode, (nuint)value);
    }

    public MTLSparsePageSize MaxCompatiblePlacementSparsePageSize
    {
        get => (MTLSparsePageSize)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapDescriptorSelector.MaxCompatiblePlacementSparsePageSize);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorSelector.SetMaxCompatiblePlacementSparsePageSize, (nint)value);
    }

    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapDescriptorSelector.ResourceOptions);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorSelector.SetResourceOptions, (nuint)value);
    }

    public nuint Size
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapDescriptorSelector.Size);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorSelector.SetSize, value);
    }

    public MTLSparsePageSize SparsePageSize
    {
        get => (MTLSparsePageSize)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapDescriptorSelector.SparsePageSize);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorSelector.SetSparsePageSize, (nint)value);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapDescriptorSelector.StorageMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorSelector.SetStorageMode, (nuint)value);
    }

    public MTLHeapType Type
    {
        get => (MTLHeapType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapDescriptorSelector.Type);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorSelector.SetType, (nint)value);
    }
}

file static class MTLHeapDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLHeapDescriptor");

    public static readonly Selector CpuCacheMode = Selector.Register("cpuCacheMode");

    public static readonly Selector HazardTrackingMode = Selector.Register("hazardTrackingMode");

    public static readonly Selector MaxCompatiblePlacementSparsePageSize = Selector.Register("maxCompatiblePlacementSparsePageSize");

    public static readonly Selector ResourceOptions = Selector.Register("resourceOptions");

    public static readonly Selector SetCpuCacheMode = Selector.Register("setCpuCacheMode:");

    public static readonly Selector SetHazardTrackingMode = Selector.Register("setHazardTrackingMode:");

    public static readonly Selector SetMaxCompatiblePlacementSparsePageSize = Selector.Register("setMaxCompatiblePlacementSparsePageSize:");

    public static readonly Selector SetResourceOptions = Selector.Register("setResourceOptions:");

    public static readonly Selector SetSize = Selector.Register("setSize:");

    public static readonly Selector SetSparsePageSize = Selector.Register("setSparsePageSize:");

    public static readonly Selector SetStorageMode = Selector.Register("setStorageMode:");

    public static readonly Selector SetType = Selector.Register("setType:");

    public static readonly Selector Size = Selector.Register("size");

    public static readonly Selector SparsePageSize = Selector.Register("sparsePageSize");

    public static readonly Selector StorageMode = Selector.Register("storageMode");

    public static readonly Selector Type = Selector.Register("type");
}
