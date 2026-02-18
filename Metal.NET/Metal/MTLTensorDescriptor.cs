namespace Metal.NET;

public class MTLTensorDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLTensorDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLTensorDescriptorSelector.Class))
    {
    }

    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorDescriptorSelector.CpuCacheMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorSelector.SetCpuCacheMode, (nuint)value);
    }

    public MTLTensorDataType DataType
    {
        get => (MTLTensorDataType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorDescriptorSelector.DataType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorSelector.SetDataType, (nint)value);
    }

    public MTLTensorExtents? Dimensions
    {
        get => GetNullableObject<MTLTensorExtents>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorDescriptorSelector.Dimensions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorSelector.SetDimensions, value?.NativePtr ?? 0);
    }

    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorDescriptorSelector.HazardTrackingMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorSelector.SetHazardTrackingMode, (nuint)value);
    }

    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorDescriptorSelector.ResourceOptions);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorSelector.SetResourceOptions, (nuint)value);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorDescriptorSelector.StorageMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorSelector.SetStorageMode, (nuint)value);
    }

    public MTLTensorExtents? Strides
    {
        get => GetNullableObject<MTLTensorExtents>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorDescriptorSelector.Strides));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorSelector.SetStrides, value?.NativePtr ?? 0);
    }

    public MTLTensorUsage Usage
    {
        get => (MTLTensorUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorDescriptorSelector.Usage);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorSelector.SetUsage, (nuint)value);
    }
}

file static class MTLTensorDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLTensorDescriptor");

    public static readonly Selector CpuCacheMode = Selector.Register("cpuCacheMode");

    public static readonly Selector DataType = Selector.Register("dataType");

    public static readonly Selector Dimensions = Selector.Register("dimensions");

    public static readonly Selector HazardTrackingMode = Selector.Register("hazardTrackingMode");

    public static readonly Selector ResourceOptions = Selector.Register("resourceOptions");

    public static readonly Selector SetCpuCacheMode = Selector.Register("setCpuCacheMode:");

    public static readonly Selector SetDataType = Selector.Register("setDataType:");

    public static readonly Selector SetDimensions = Selector.Register("setDimensions:");

    public static readonly Selector SetHazardTrackingMode = Selector.Register("setHazardTrackingMode:");

    public static readonly Selector SetResourceOptions = Selector.Register("setResourceOptions:");

    public static readonly Selector SetStorageMode = Selector.Register("setStorageMode:");

    public static readonly Selector SetStrides = Selector.Register("setStrides:");

    public static readonly Selector SetUsage = Selector.Register("setUsage:");

    public static readonly Selector StorageMode = Selector.Register("storageMode");

    public static readonly Selector Strides = Selector.Register("strides");

    public static readonly Selector Usage = Selector.Register("usage");
}
