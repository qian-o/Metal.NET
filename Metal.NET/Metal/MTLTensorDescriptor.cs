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

    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLTensorDescriptorSelector.CpuCacheMode));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorSelector.SetCpuCacheMode, (uint)value);
    }

    public MTLTensorDataType DataType
    {
        get => (MTLTensorDataType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLTensorDescriptorSelector.DataType));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorSelector.SetDataType, (uint)value);
    }

    public MTLTensorExtents Dimensions
    {
        get => new MTLTensorExtents(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorDescriptorSelector.Dimensions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorSelector.SetDimensions, value.NativePtr);
    }

    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLTensorDescriptorSelector.HazardTrackingMode));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorSelector.SetHazardTrackingMode, (uint)value);
    }

    public nuint ResourceOptions
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorDescriptorSelector.ResourceOptions);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorSelector.SetResourceOptions, (nuint)value);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLTensorDescriptorSelector.StorageMode));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorSelector.SetStorageMode, (uint)value);
    }

    public MTLTensorExtents Strides
    {
        get => new MTLTensorExtents(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorDescriptorSelector.Strides));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorSelector.SetStrides, value.NativePtr);
    }

    public nuint Usage
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorDescriptorSelector.Usage);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorSelector.SetUsage, (nuint)value);
    }

}

file class MTLTensorDescriptorSelector
{
    public static readonly Selector CpuCacheMode = Selector.Register("cpuCacheMode");

    public static readonly Selector SetCpuCacheMode = Selector.Register("setCpuCacheMode:");

    public static readonly Selector DataType = Selector.Register("dataType");

    public static readonly Selector SetDataType = Selector.Register("setDataType:");

    public static readonly Selector Dimensions = Selector.Register("dimensions");

    public static readonly Selector SetDimensions = Selector.Register("setDimensions:");

    public static readonly Selector HazardTrackingMode = Selector.Register("hazardTrackingMode");

    public static readonly Selector SetHazardTrackingMode = Selector.Register("setHazardTrackingMode:");

    public static readonly Selector ResourceOptions = Selector.Register("resourceOptions");

    public static readonly Selector SetResourceOptions = Selector.Register("setResourceOptions:");

    public static readonly Selector StorageMode = Selector.Register("storageMode");

    public static readonly Selector SetStorageMode = Selector.Register("setStorageMode:");

    public static readonly Selector Strides = Selector.Register("strides");

    public static readonly Selector SetStrides = Selector.Register("setStrides:");

    public static readonly Selector Usage = Selector.Register("usage");

    public static readonly Selector SetUsage = Selector.Register("setUsage:");
}
