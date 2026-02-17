namespace Metal.NET;

file class MTLTensorDescriptorSelector
{
    public static readonly Selector SetCpuCacheMode_ = Selector.Register("setCpuCacheMode:");
    public static readonly Selector SetDataType_ = Selector.Register("setDataType:");
    public static readonly Selector SetDimensions_ = Selector.Register("setDimensions:");
    public static readonly Selector SetHazardTrackingMode_ = Selector.Register("setHazardTrackingMode:");
    public static readonly Selector SetResourceOptions_ = Selector.Register("setResourceOptions:");
    public static readonly Selector SetStorageMode_ = Selector.Register("setStorageMode:");
    public static readonly Selector SetStrides_ = Selector.Register("setStrides:");
    public static readonly Selector SetUsage_ = Selector.Register("setUsage:");
}

public class MTLTensorDescriptor : IDisposable
{
    public MTLTensorDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLTensorDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLTensorDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLTensorDescriptor(nint value)
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

    public void SetCpuCacheMode(MTLCPUCacheMode cpuCacheMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTensorDescriptorSelector.SetCpuCacheMode_, (nint)(uint)cpuCacheMode);
    }

    public void SetDataType(MTLTensorDataType dataType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTensorDescriptorSelector.SetDataType_, (nint)(uint)dataType);
    }

    public void SetDimensions(MTLTensorExtents dimensions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTensorDescriptorSelector.SetDimensions_, dimensions.NativePtr);
    }

    public void SetHazardTrackingMode(MTLHazardTrackingMode hazardTrackingMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTensorDescriptorSelector.SetHazardTrackingMode_, (nint)(uint)hazardTrackingMode);
    }

    public void SetResourceOptions(nuint resourceOptions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTensorDescriptorSelector.SetResourceOptions_, (nint)resourceOptions);
    }

    public void SetStorageMode(MTLStorageMode storageMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTensorDescriptorSelector.SetStorageMode_, (nint)(uint)storageMode);
    }

    public void SetStrides(MTLTensorExtents strides)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTensorDescriptorSelector.SetStrides_, strides.NativePtr);
    }

    public void SetUsage(nuint usage)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTensorDescriptorSelector.SetUsage_, (nint)usage);
    }

}
