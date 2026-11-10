namespace Metal.NET;

public readonly struct MTLTensorDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLTensorDescriptor value) => new(value.NativePtr);

    public MTLTensorDescriptor() : this(ObjectiveC.AllocInit(MTLTensorDescriptorBindings.Class))
    {
    }

    public MTLTensorDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLTensorExtents Dimensions
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLTensorDescriptorBindings.Dimensions));
        set => ObjectiveC.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetDimensions, value.NativePtr);
    }

    public MTLTensorExtents Strides
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLTensorDescriptorBindings.Strides));
        set => ObjectiveC.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetStrides, value.NativePtr);
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

    public MTLTensorAuxiliaryPlaneDescriptorMap AuxiliaryPlanes
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLTensorDescriptorBindings.AuxiliaryPlanes));
        set => ObjectiveC.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetAuxiliaryPlanes, value.NativePtr);
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
}

file static class MTLTensorDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLTensorDescriptor");

    public static readonly Selector AuxiliaryPlanes = "auxiliaryPlanes";

    public static readonly Selector CpuCacheMode = "cpuCacheMode";

    public static readonly Selector DataType = "dataType";

    public static readonly Selector Dimensions = "dimensions";

    public static readonly Selector HazardTrackingMode = "hazardTrackingMode";

    public static readonly Selector ResourceOptions = "resourceOptions";

    public static readonly Selector SetAuxiliaryPlanes = "setAuxiliaryPlanes:";

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
