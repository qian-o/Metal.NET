namespace Metal.NET;

public class MTLHeapDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLHeapDescriptor");

    public MTLHeapDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLHeapDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLHeapDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLHeapDescriptorSelector.CpuCacheMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorSelector.SetCpuCacheMode, (ulong)value);
    }

    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLHeapDescriptorSelector.HazardTrackingMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorSelector.SetHazardTrackingMode, (ulong)value);
    }

    public MTLSparsePageSize MaxCompatiblePlacementSparsePageSize
    {
        get => (MTLSparsePageSize)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLHeapDescriptorSelector.MaxCompatiblePlacementSparsePageSize);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorSelector.SetMaxCompatiblePlacementSparsePageSize, (ulong)value);
    }

    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLHeapDescriptorSelector.ResourceOptions);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorSelector.SetResourceOptions, (ulong)value);
    }

    public nuint Size
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapDescriptorSelector.Size);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorSelector.SetSize, value);
    }

    public MTLSparsePageSize SparsePageSize
    {
        get => (MTLSparsePageSize)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLHeapDescriptorSelector.SparsePageSize);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorSelector.SetSparsePageSize, (ulong)value);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLHeapDescriptorSelector.StorageMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorSelector.SetStorageMode, (ulong)value);
    }

    public MTLHeapType Type
    {
        get => (MTLHeapType)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLHeapDescriptorSelector.Type);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorSelector.SetType, (ulong)value);
    }

    public static implicit operator nint(MTLHeapDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLHeapDescriptor(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTLHeapDescriptorSelector
{
    public static readonly Selector CpuCacheMode = Selector.Register("cpuCacheMode");

    public static readonly Selector SetCpuCacheMode = Selector.Register("setCpuCacheMode:");

    public static readonly Selector HazardTrackingMode = Selector.Register("hazardTrackingMode");

    public static readonly Selector SetHazardTrackingMode = Selector.Register("setHazardTrackingMode:");

    public static readonly Selector MaxCompatiblePlacementSparsePageSize = Selector.Register("maxCompatiblePlacementSparsePageSize");

    public static readonly Selector SetMaxCompatiblePlacementSparsePageSize = Selector.Register("setMaxCompatiblePlacementSparsePageSize:");

    public static readonly Selector ResourceOptions = Selector.Register("resourceOptions");

    public static readonly Selector SetResourceOptions = Selector.Register("setResourceOptions:");

    public static readonly Selector Size = Selector.Register("size");

    public static readonly Selector SetSize = Selector.Register("setSize:");

    public static readonly Selector SparsePageSize = Selector.Register("sparsePageSize");

    public static readonly Selector SetSparsePageSize = Selector.Register("setSparsePageSize:");

    public static readonly Selector StorageMode = Selector.Register("storageMode");

    public static readonly Selector SetStorageMode = Selector.Register("setStorageMode:");

    public static readonly Selector Type = Selector.Register("type");

    public static readonly Selector SetType = Selector.Register("setType:");
}
