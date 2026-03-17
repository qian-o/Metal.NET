namespace Metal.NET;

/// <summary>
/// A configuration type for creating new tensor instances.
/// </summary>
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

    #region Instance Properties - Properties

    /// <summary>
    /// A value that configures the cache mode of CPU mapping of tensors you create with this descriptor.
    /// </summary>
    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveC.MsgSendULong(NativePtr, MTLTensorDescriptorBindings.CpuCacheMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetCpuCacheMode, (nuint)value);
    }

    /// <summary>
    /// A data format for the tensors you create with this descriptor.
    /// </summary>
    public MTLTensorDataType DataType
    {
        get => (MTLTensorDataType)ObjectiveC.MsgSendLong(NativePtr, MTLTensorDescriptorBindings.DataType);
        set => ObjectiveC.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetDataType, (nint)value);
    }

    /// <summary>
    /// An array of sizes, in elements, one for each dimension of the tensors you create with this descriptor.
    /// </summary>
    public MTLTensorExtents Dimensions
    {
        get => GetProperty(ref field, MTLTensorDescriptorBindings.Dimensions);
        set => SetProperty(ref field, MTLTensorDescriptorBindings.SetDimensions, value);
    }

    /// <summary>
    /// A value that configures the hazard tracking of tensors you create with this descriptor.
    /// </summary>
    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveC.MsgSendULong(NativePtr, MTLTensorDescriptorBindings.HazardTrackingMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetHazardTrackingMode, (nuint)value);
    }

    /// <summary>
    /// A packed set of the storageMode, cpuCacheMode and hazardTrackingMode properties.
    /// </summary>
    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveC.MsgSendULong(NativePtr, MTLTensorDescriptorBindings.ResourceOptions);
        set => ObjectiveC.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetResourceOptions, (nuint)value);
    }

    /// <summary>
    /// A value that configures the memory location and access permissions of tensors you create with this descriptor.
    /// </summary>
    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveC.MsgSendULong(NativePtr, MTLTensorDescriptorBindings.StorageMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetStorageMode, (nuint)value);
    }

    /// <summary>
    /// An array of strides, in elements, one for each dimension in the tensors you create with this descriptor, if applicable.
    /// </summary>
    public MTLTensorExtents Strides
    {
        get => GetProperty(ref field, MTLTensorDescriptorBindings.Strides);
        set => SetProperty(ref field, MTLTensorDescriptorBindings.SetStrides, value);
    }

    /// <summary>
    /// A set of contexts in which you can use tensors you create with this descriptor.
    /// </summary>
    public MTLTensorUsage Usage
    {
        get => (MTLTensorUsage)ObjectiveC.MsgSendULong(NativePtr, MTLTensorDescriptorBindings.Usage);
        set => ObjectiveC.MsgSend(NativePtr, MTLTensorDescriptorBindings.SetUsage, (nuint)value);
    }
    #endregion
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
