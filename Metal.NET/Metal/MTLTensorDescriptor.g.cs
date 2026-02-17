namespace Metal.NET;

public class MTLTensorDescriptor : IDisposable
{
    public MTLTensorDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTensorDescriptorSelector.SetCpuCacheMode, (nint)(uint)cpuCacheMode);
    }

    public void SetDataType(MTLTensorDataType dataType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTensorDescriptorSelector.SetDataType, (nint)(uint)dataType);
    }

    public void SetDimensions(MTLTensorExtents dimensions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTensorDescriptorSelector.SetDimensions, dimensions.NativePtr);
    }

    public void SetHazardTrackingMode(MTLHazardTrackingMode hazardTrackingMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTensorDescriptorSelector.SetHazardTrackingMode, (nint)(uint)hazardTrackingMode);
    }

    public void SetResourceOptions(uint resourceOptions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTensorDescriptorSelector.SetResourceOptions, (nint)resourceOptions);
    }

    public void SetStorageMode(MTLStorageMode storageMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTensorDescriptorSelector.SetStorageMode, (nint)(uint)storageMode);
    }

    public void SetStrides(MTLTensorExtents strides)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTensorDescriptorSelector.SetStrides, strides.NativePtr);
    }

    public void SetUsage(uint usage)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTensorDescriptorSelector.SetUsage, (nint)usage);
    }

}

file class MTLTensorDescriptorSelector
{
    public static readonly Selector SetCpuCacheMode = Selector.Register("setCpuCacheMode:");
    public static readonly Selector SetDataType = Selector.Register("setDataType:");
    public static readonly Selector SetDimensions = Selector.Register("setDimensions:");
    public static readonly Selector SetHazardTrackingMode = Selector.Register("setHazardTrackingMode:");
    public static readonly Selector SetResourceOptions = Selector.Register("setResourceOptions:");
    public static readonly Selector SetStorageMode = Selector.Register("setStorageMode:");
    public static readonly Selector SetStrides = Selector.Register("setStrides:");
    public static readonly Selector SetUsage = Selector.Register("setUsage:");
}
