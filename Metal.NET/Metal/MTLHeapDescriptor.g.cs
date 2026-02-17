namespace Metal.NET;

file class MTLHeapDescriptorSelector
{
    public static readonly Selector SetCpuCacheMode_ = Selector.Register("setCpuCacheMode:");
    public static readonly Selector SetHazardTrackingMode_ = Selector.Register("setHazardTrackingMode:");
    public static readonly Selector SetMaxCompatiblePlacementSparsePageSize_ = Selector.Register("setMaxCompatiblePlacementSparsePageSize:");
    public static readonly Selector SetResourceOptions_ = Selector.Register("setResourceOptions:");
    public static readonly Selector SetSize_ = Selector.Register("setSize:");
    public static readonly Selector SetSparsePageSize_ = Selector.Register("setSparsePageSize:");
    public static readonly Selector SetStorageMode_ = Selector.Register("setStorageMode:");
    public static readonly Selector SetType_ = Selector.Register("setType:");
}

public class MTLHeapDescriptor : IDisposable
{
    public MTLHeapDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLHeapDescriptor(ptr);
    }

    public void SetCpuCacheMode(MTLCPUCacheMode cpuCacheMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLHeapDescriptorSelector.SetCpuCacheMode_, (nint)(uint)cpuCacheMode);
    }

    public void SetHazardTrackingMode(MTLHazardTrackingMode hazardTrackingMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLHeapDescriptorSelector.SetHazardTrackingMode_, (nint)(uint)hazardTrackingMode);
    }

    public void SetMaxCompatiblePlacementSparsePageSize(MTLSparsePageSize maxCompatiblePlacementSparsePageSize)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLHeapDescriptorSelector.SetMaxCompatiblePlacementSparsePageSize_, (nint)(uint)maxCompatiblePlacementSparsePageSize);
    }

    public void SetResourceOptions(nuint resourceOptions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLHeapDescriptorSelector.SetResourceOptions_, (nint)resourceOptions);
    }

    public void SetSize(nuint size)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLHeapDescriptorSelector.SetSize_, (nint)size);
    }

    public void SetSparsePageSize(MTLSparsePageSize sparsePageSize)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLHeapDescriptorSelector.SetSparsePageSize_, (nint)(uint)sparsePageSize);
    }

    public void SetStorageMode(MTLStorageMode storageMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLHeapDescriptorSelector.SetStorageMode_, (nint)(uint)storageMode);
    }

    public void SetType(MTLHeapType type)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLHeapDescriptorSelector.SetType_, (nint)(uint)type);
    }

}
