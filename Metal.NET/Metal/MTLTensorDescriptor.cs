namespace Metal.NET;

public readonly struct MTLTensorDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLTensorDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLTensorDescriptorBindings.Class))
    {
    }

    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorDescriptorBindings.CpuCacheMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetCpuCacheMode, (nuint)value);
    }

    public MTLTensorDataType DataType
    {
        get => (MTLTensorDataType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorDescriptorBindings.DataType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetDataType, (nint)value);
    }

    public MTLTensorExtents? Dimensions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorDescriptorBindings.Dimensions);
            return ptr is not 0 ? new MTLTensorExtents(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetDimensions, value?.NativePtr ?? 0);
    }

    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorDescriptorBindings.HazardTrackingMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetHazardTrackingMode, (nuint)value);
    }

    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorDescriptorBindings.ResourceOptions);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetResourceOptions, (nuint)value);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorDescriptorBindings.StorageMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetStorageMode, (nuint)value);
    }

    public MTLTensorExtents? Strides
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorDescriptorBindings.Strides);
            return ptr is not 0 ? new MTLTensorExtents(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetStrides, value?.NativePtr ?? 0);
    }

    public MTLTensorUsage Usage
    {
        get => (MTLTensorUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorDescriptorBindings.Usage);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetUsage, (nuint)value);
    }
}

file static class MTLTensorDescriptorBindings
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
