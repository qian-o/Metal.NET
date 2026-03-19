namespace Metal.NET;

public partial class MTLTensor(nint nativePtr, NativeObjectOwnership ownership) : MTLResource(nativePtr, ownership), INativeObject<MTLTensor>
{
    #region INativeObject
    public static new MTLTensor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLTensor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLTensorBindings.GpuResourceID);
    }

    public MTLBuffer Buffer
    {
        get => GetProperty(ref field, MTLTensorBindings.Buffer);
    }

    public nuint BufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTensorBindings.BufferOffset);
    }

    public MTLTensorExtents Strides
    {
        get => GetProperty(ref field, MTLTensorBindings.Strides);
    }

    public MTLTensorExtents Dimensions
    {
        get => GetProperty(ref field, MTLTensorBindings.Dimensions);
    }

    public MTLTensorDataType DataType
    {
        get => (MTLTensorDataType)ObjectiveC.MsgSendLong(NativePtr, MTLTensorBindings.DataType);
    }

    public MTLTensorUsage Usage
    {
        get => (MTLTensorUsage)ObjectiveC.MsgSendULong(NativePtr, MTLTensorBindings.Usage);
    }

    public void Replace(MTLTensorExtents sliceOrigin, MTLTensorExtents sliceDimensions, nint bytes, MTLTensorExtents strides)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTensorBindings.ReplaceSliceOriginSliceDimensionsWithBytesStrides, sliceOrigin.NativePtr, sliceDimensions.NativePtr, bytes, strides.NativePtr);
    }

    public void GetBytes(nint bytes, MTLTensorExtents strides, MTLTensorExtents sliceOrigin, MTLTensorExtents sliceDimensions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTensorBindings.GetBytesStridesFromSliceOriginSliceDimensions, bytes, strides.NativePtr, sliceOrigin.NativePtr, sliceDimensions.NativePtr);
    }
}

file static class MTLTensorBindings
{
    public static readonly Selector Buffer = "buffer";

    public static readonly Selector BufferOffset = "bufferOffset";

    public static readonly Selector DataType = "dataType";

    public static readonly Selector Dimensions = "dimensions";

    public static readonly Selector GetBytesStridesFromSliceOriginSliceDimensions = "getBytes:strides:fromSliceOrigin:sliceDimensions:";

    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector ReplaceSliceOriginSliceDimensionsWithBytesStrides = "replaceSliceOrigin:sliceDimensions:withBytes:strides:";

    public static readonly Selector Strides = "strides";

    public static readonly Selector Usage = "usage";
}
