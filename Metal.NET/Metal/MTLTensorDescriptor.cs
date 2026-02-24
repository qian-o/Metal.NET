namespace Metal.NET;

public class MTLTensorDescriptor(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTLTensorDescriptor>
{
    public static MTLTensorDescriptor Create(nint nativePtr) => new(nativePtr);

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

    public MTLTensorExtents Dimensions
    {
        get => GetProperty(ref field, MTLTensorDescriptorBindings.Dimensions);
        set => SetProperty(ref field, MTLTensorDescriptorBindings.SetDimensions, value);
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

    public MTLTensorExtents Strides
    {
        get => GetProperty(ref field, MTLTensorDescriptorBindings.Strides);
        set => SetProperty(ref field, MTLTensorDescriptorBindings.SetStrides, value);
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

    public static readonly Selector CpuCacheMode = "cpuCacheMode";

    public static readonly Selector DataType = "dataType";

    public static readonly Selector Dimensions = "dimensions";

    public static readonly Selector HazardTrackingMode = "hazardTrackingMode";

    public static readonly Selector ResourceOptions = "resourceOptions";

    public static readonly Selector SetCpuCacheMode = "setCpuCacheMode:";

    public static readonly Selector SetDataType = "setDataType:";

    public static readonly Selector SetDimensions = "setDimensions:";

    public static readonly Selector SetHazardTrackingMode = "setHazardTrackingMode:";

    public static readonly Selector SetResourceOptions = "setResourceOptions:";

    public static readonly Selector SetStorageMode = "setStorageMode:";

    public static readonly Selector SetStrides = "setStrides:";

    public static readonly Selector SetUsage = "setUsage:";

    public static readonly Selector StorageMode = "storageMode";

    public static readonly Selector Strides = "strides";

    public static readonly Selector Usage = "usage";
}
