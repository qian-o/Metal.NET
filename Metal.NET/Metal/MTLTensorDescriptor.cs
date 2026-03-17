namespace Metal.NET;

public class MTLTensorDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLTensorDescriptor>
{
    #region INativeObject
    public static new MTLTensorDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLTensorDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLTensorDescriptor() : this(ObjectiveC.AllocInit(MTLTensorDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLTensorExtents Dimensions
    {
        get => GetProperty(ref field, MTLTensorDescriptorBindings.Dimensions);
        set => SetProperty(ref field, MTLTensorDescriptorBindings.SetDimensions, value);
    }

    public MTLTensorExtents Strides
    {
        get => GetProperty(ref field, MTLTensorDescriptorBindings.Strides);
        set => SetProperty(ref field, MTLTensorDescriptorBindings.SetStrides, value);
    }

    public MTLTensorDataType DataType
    {
        get => (MTLTensorDataType)ObjectiveC.MsgSendLong(NativePtr, MTLTensorDescriptorBindings.DataType);
        set => ObjectiveC.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetDataType, (nint)value);
    }

    public MTLTensorUsage Usage
    {
        get => (MTLTensorUsage)ObjectiveC.MsgSendULong(NativePtr, MTLTensorDescriptorBindings.Usage);
        set => ObjectiveC.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetUsage, (nuint)value);
    }

    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveC.MsgSendULong(NativePtr, MTLTensorDescriptorBindings.ResourceOptions);
        set => ObjectiveC.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetResourceOptions, (nuint)value);
    }

    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveC.MsgSendULong(NativePtr, MTLTensorDescriptorBindings.CpuCacheMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetCpuCacheMode, (nuint)value);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveC.MsgSendULong(NativePtr, MTLTensorDescriptorBindings.StorageMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetStorageMode, (nuint)value);
    }

    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveC.MsgSendULong(NativePtr, MTLTensorDescriptorBindings.HazardTrackingMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetHazardTrackingMode, (nuint)value);
    }

    public MTLTensorExtents Dimensions
    {
        get => GetProperty(ref field, MTLTensorDescriptorBindings.Dimensions);
        set => SetProperty(ref field, MTLTensorDescriptorBindings.SetDimensions, value);
    }

    public MTLTensorExtents Strides
    {
        get => GetProperty(ref field, MTLTensorDescriptorBindings.Strides);
        set => SetProperty(ref field, MTLTensorDescriptorBindings.SetStrides, value);
    }

    public MTLTensorDataType DataType
    {
        get => (MTLTensorDataType)ObjectiveC.MsgSendLong(NativePtr, MTLTensorDescriptorBindings.DataType);
        set => ObjectiveC.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetDataType, (nint)value);
    }

    public MTLTensorUsage Usage
    {
        get => (MTLTensorUsage)ObjectiveC.MsgSendULong(NativePtr, MTLTensorDescriptorBindings.Usage);
        set => ObjectiveC.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetUsage, (nuint)value);
    }

    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveC.MsgSendULong(NativePtr, MTLTensorDescriptorBindings.ResourceOptions);
        set => ObjectiveC.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetResourceOptions, (nuint)value);
    }

    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveC.MsgSendULong(NativePtr, MTLTensorDescriptorBindings.CpuCacheMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetCpuCacheMode, (nuint)value);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveC.MsgSendULong(NativePtr, MTLTensorDescriptorBindings.StorageMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetStorageMode, (nuint)value);
    }

    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveC.MsgSendULong(NativePtr, MTLTensorDescriptorBindings.HazardTrackingMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetHazardTrackingMode, (nuint)value);
    }

    public void SetDimensions(MTLTensorExtents dimensions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetDimensions, dimensions.NativePtr);
    }

    public void SetStrides(MTLTensorExtents strides)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetStrides, strides.NativePtr);
    }

    public void SetDataType(MTLTensorDataType dataType)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetDataType, (nint)dataType);
    }

    public void SetUsage(MTLTensorUsage usage)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetUsage, (nuint)usage);
    }

    public void SetResourceOptions(MTLResourceOptions resourceOptions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetResourceOptions, (nuint)resourceOptions);
    }

    public void SetCpuCacheMode(MTLCPUCacheMode cpuCacheMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetCpuCacheMode, (nuint)cpuCacheMode);
    }

    public void SetStorageMode(MTLStorageMode storageMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetStorageMode, (nuint)storageMode);
    }

    public void SetHazardTrackingMode(MTLHazardTrackingMode hazardTrackingMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetHazardTrackingMode, (nuint)hazardTrackingMode);
    }
}

file static class MTLTensorDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLTensorDescriptor");

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
