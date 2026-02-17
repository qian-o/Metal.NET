namespace Metal.NET;

public class MTLHeapDescriptor : IDisposable
{
    public MTLHeapDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLHeapDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLHeapDescriptor");

    public static MTLHeapDescriptor New()
    {
        var ptr = ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.MsgSendPtr(ptr, Selector.Register("init"));

        return new MTLHeapDescriptor(ptr);
    }

    public void SetCpuCacheMode(MTLCPUCacheMode cpuCacheMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorSelector.SetCpuCacheMode, (nint)(uint)cpuCacheMode);
    }

    public void SetHazardTrackingMode(MTLHazardTrackingMode hazardTrackingMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorSelector.SetHazardTrackingMode, (nint)(uint)hazardTrackingMode);
    }

    public void SetMaxCompatiblePlacementSparsePageSize(MTLSparsePageSize maxCompatiblePlacementSparsePageSize)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorSelector.SetMaxCompatiblePlacementSparsePageSize, (nint)(uint)maxCompatiblePlacementSparsePageSize);
    }

    public void SetResourceOptions(uint resourceOptions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorSelector.SetResourceOptions, (nint)resourceOptions);
    }

    public void SetSize(uint size)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorSelector.SetSize, (nint)size);
    }

    public void SetSparsePageSize(MTLSparsePageSize sparsePageSize)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorSelector.SetSparsePageSize, (nint)(uint)sparsePageSize);
    }

    public void SetStorageMode(MTLStorageMode storageMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorSelector.SetStorageMode, (nint)(uint)storageMode);
    }

    public void SetType(MTLHeapType type)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapDescriptorSelector.SetType, (nint)(uint)type);
    }

}

file class MTLHeapDescriptorSelector
{
    public static readonly Selector SetCpuCacheMode = Selector.Register("setCpuCacheMode:");

    public static readonly Selector SetHazardTrackingMode = Selector.Register("setHazardTrackingMode:");

    public static readonly Selector SetMaxCompatiblePlacementSparsePageSize = Selector.Register("setMaxCompatiblePlacementSparsePageSize:");

    public static readonly Selector SetResourceOptions = Selector.Register("setResourceOptions:");

    public static readonly Selector SetSize = Selector.Register("setSize:");

    public static readonly Selector SetSparsePageSize = Selector.Register("setSparsePageSize:");

    public static readonly Selector SetStorageMode = Selector.Register("setStorageMode:");

    public static readonly Selector SetType = Selector.Register("setType:");
}
