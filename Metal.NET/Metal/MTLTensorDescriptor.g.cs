using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLTensorDescriptor_Selectors
{
    internal static readonly Selector setCpuCacheMode_ = Selector.Register("setCpuCacheMode:");
    internal static readonly Selector setDataType_ = Selector.Register("setDataType:");
    internal static readonly Selector setDimensions_ = Selector.Register("setDimensions:");
    internal static readonly Selector setHazardTrackingMode_ = Selector.Register("setHazardTrackingMode:");
    internal static readonly Selector setResourceOptions_ = Selector.Register("setResourceOptions:");
    internal static readonly Selector setStorageMode_ = Selector.Register("setStorageMode:");
    internal static readonly Selector setStrides_ = Selector.Register("setStrides:");
    internal static readonly Selector setUsage_ = Selector.Register("setUsage:");
}

public class MTLTensorDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLTensorDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLTensorDescriptor o) => o.NativePtr;
    public static implicit operator MTLTensorDescriptor(nint ptr) => new MTLTensorDescriptor(ptr);

    ~MTLTensorDescriptor() => Release();

    public void Dispose()
    {
        Release();
        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr != 0)
            ObjectiveCRuntime.Release(NativePtr);
    }

    public void SetCpuCacheMode(MTLCPUCacheMode cpuCacheMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTensorDescriptor_Selectors.setCpuCacheMode_, (nint)(uint)cpuCacheMode);
    }

    public void SetDataType(MTLTensorDataType dataType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTensorDescriptor_Selectors.setDataType_, (nint)(uint)dataType);
    }

    public void SetDimensions(MTLTensorExtents dimensions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTensorDescriptor_Selectors.setDimensions_, dimensions.NativePtr);
    }

    public void SetHazardTrackingMode(MTLHazardTrackingMode hazardTrackingMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTensorDescriptor_Selectors.setHazardTrackingMode_, (nint)(uint)hazardTrackingMode);
    }

    public void SetResourceOptions(nuint resourceOptions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTensorDescriptor_Selectors.setResourceOptions_, (nint)resourceOptions);
    }

    public void SetStorageMode(MTLStorageMode storageMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTensorDescriptor_Selectors.setStorageMode_, (nint)(uint)storageMode);
    }

    public void SetStrides(MTLTensorExtents strides)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTensorDescriptor_Selectors.setStrides_, strides.NativePtr);
    }

    public void SetUsage(nuint usage)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTensorDescriptor_Selectors.setUsage_, (nint)usage);
    }

}
