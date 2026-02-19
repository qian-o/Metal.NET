namespace Metal.NET;

public class MTLHeapDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLHeapDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLHeapDescriptorBindings.Class))
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
