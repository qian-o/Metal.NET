using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLHeapDescriptor_Selectors
{
    internal static readonly Selector setCpuCacheMode_ = Selector.Register("setCpuCacheMode:");
    internal static readonly Selector setHazardTrackingMode_ = Selector.Register("setHazardTrackingMode:");
    internal static readonly Selector setMaxCompatiblePlacementSparsePageSize_ = Selector.Register("setMaxCompatiblePlacementSparsePageSize:");
    internal static readonly Selector setResourceOptions_ = Selector.Register("setResourceOptions:");
    internal static readonly Selector setSize_ = Selector.Register("setSize:");
    internal static readonly Selector setSparsePageSize_ = Selector.Register("setSparsePageSize:");
    internal static readonly Selector setStorageMode_ = Selector.Register("setStorageMode:");
    internal static readonly Selector setType_ = Selector.Register("setType:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLHeapDescriptor
{
    public readonly nint NativePtr;

    public MTLHeapDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLHeapDescriptor o) => o.NativePtr;
    public static implicit operator MTLHeapDescriptor(nint ptr) => new MTLHeapDescriptor(ptr);

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLHeapDescriptor");

    public static MTLHeapDescriptor Alloc()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        return new MTLHeapDescriptor(ptr);
    }

    public MTLHeapDescriptor Init()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, Selector.Register("init"));
        return new MTLHeapDescriptor(ptr);
    }

    public static MTLHeapDescriptor New()
    {
        return Alloc().Init();
    }

    public void SetCpuCacheMode(MTLCPUCacheMode cpuCacheMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLHeapDescriptor_Selectors.setCpuCacheMode_, (nint)(uint)cpuCacheMode);
    }

    public void SetHazardTrackingMode(MTLHazardTrackingMode hazardTrackingMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLHeapDescriptor_Selectors.setHazardTrackingMode_, (nint)(uint)hazardTrackingMode);
    }

    public void SetMaxCompatiblePlacementSparsePageSize(MTLSparsePageSize maxCompatiblePlacementSparsePageSize)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLHeapDescriptor_Selectors.setMaxCompatiblePlacementSparsePageSize_, (nint)(uint)maxCompatiblePlacementSparsePageSize);
    }

    public void SetResourceOptions(nuint resourceOptions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLHeapDescriptor_Selectors.setResourceOptions_, (nint)resourceOptions);
    }

    public void SetSize(nuint size)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLHeapDescriptor_Selectors.setSize_, (nint)size);
    }

    public void SetSparsePageSize(MTLSparsePageSize sparsePageSize)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLHeapDescriptor_Selectors.setSparsePageSize_, (nint)(uint)sparsePageSize);
    }

    public void SetStorageMode(MTLStorageMode storageMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLHeapDescriptor_Selectors.setStorageMode_, (nint)(uint)storageMode);
    }

    public void SetType(MTLHeapType type)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLHeapDescriptor_Selectors.setType_, (nint)(uint)type);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
