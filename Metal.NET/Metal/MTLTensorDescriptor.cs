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
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorSelector.SetCpuCacheMode, (nint)(uint)cpuCacheMode);
    }

    public void SetDataType(MTLTensorDataType dataType)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorSelector.SetDataType, (nint)(uint)dataType);
    }

    public void SetDimensions(MTLTensorExtents dimensions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorSelector.SetDimensions, dimensions.NativePtr);
    }

    public void SetHazardTrackingMode(MTLHazardTrackingMode hazardTrackingMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorSelector.SetHazardTrackingMode, (nint)(uint)hazardTrackingMode);
    }

    public void SetResourceOptions(uint resourceOptions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorSelector.SetResourceOptions, (nint)resourceOptions);
    }

    public void SetStorageMode(MTLStorageMode storageMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorSelector.SetStorageMode, (nint)(uint)storageMode);
    }

    public void SetStrides(MTLTensorExtents strides)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorSelector.SetStrides, strides.NativePtr);
    }

    public void SetUsage(uint usage)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorSelector.SetUsage, (nint)usage);
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
