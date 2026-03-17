namespace Metal.NET;

/// <summary>
/// A resource representing a multi-dimensional array that you can use with machine learning workloads.
/// </summary>
public class MTLTensor(nint nativePtr, NativeObjectOwnership ownership) : MTLResource(nativePtr, ownership), INativeObject<MTLTensor>
{
    #region INativeObject
    public static new MTLTensor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLTensor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Instance Properties - Properties

    /// <summary>
    /// A buffer instance this tensor shares its storage with or nil if this tensor does not wrap an underlying buffer.
    /// </summary>
    public MTLBuffer Buffer
    {
        get => GetProperty(ref field, MTLTensorBindings.Buffer);
    }

    /// <summary>
    /// An offset, in bytes, into the buffer instance this tensor shares its storage with, or zero if this tensor does not wrap an underlying buffer.
    /// </summary>
    public nuint BufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTensorBindings.BufferOffset);
    }

    /// <summary>
    /// An underlying data format of this tensor.
    /// </summary>
    public MTLTensorDataType DataType
    {
        get => (MTLTensorDataType)ObjectiveC.MsgSendLong(NativePtr, MTLTensorBindings.DataType);
    }

    /// <summary>
    /// An array of sizes, in elements, one for each dimension of this tensor.
    /// </summary>
    public MTLTensorExtents Dimensions
    {
        get => GetProperty(ref field, MTLTensorBindings.Dimensions);
    }

    /// <summary>
    /// A handle that represents the GPU resource, which you can store in an argument buffer.
    /// </summary>
    public MTLResourceID GpuResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLTensorBindings.GpuResourceID);
    }

    /// <summary>
    /// An array of strides, in elements, one for each dimension of this tensor.
    /// </summary>
    public MTLTensorExtents Strides
    {
        get => GetProperty(ref field, MTLTensorBindings.Strides);
    }

    /// <summary>
    /// A set of contexts in which you can use this tensor.
    /// </summary>
    public MTLTensorUsage Usage
    {
        get => (MTLTensorUsage)ObjectiveC.MsgSendULong(NativePtr, MTLTensorBindings.Usage);
    }
    #endregion

    #region Instance Methods - Methods

    /// <summary>
    /// Copies the data corresponding to a slice of this tensor into a pointer you provide.
    /// </summary>
    public void GetBytes(nint bytes, MTLTensorExtents strides, MTLTensorExtents sliceOrigin, MTLTensorExtents sliceDimensions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTensorBindings.GetBytes, bytes, strides.NativePtr, sliceOrigin.NativePtr, sliceDimensions.NativePtr);
    }

    /// <summary>
    /// Replaces the contents of a slice of this tensor with data you provide.
    /// </summary>
    public void ReplaceSliceOrigin(MTLTensorExtents sliceOrigin, MTLTensorExtents sliceDimensions, nint bytes, MTLTensorExtents strides)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTensorBindings.ReplaceSliceOrigin, sliceOrigin.NativePtr, sliceDimensions.NativePtr, bytes, strides.NativePtr);
    }
    #endregion
}

file static class MTLTensorBindings
{
    public static readonly Selector Buffer = "buffer";

    public static readonly Selector BufferOffset = "bufferOffset";

    public static readonly Selector DataType = "dataType";

    public static readonly Selector Dimensions = "dimensions";

    public static readonly Selector GetBytes = "getBytes:strides:fromSliceOrigin:sliceDimensions:";

    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector ReplaceSliceOrigin = "replaceSliceOrigin:sliceDimensions:withBytes:strides:";

    public static readonly Selector Strides = "strides";

    public static readonly Selector Usage = "usage";
}
