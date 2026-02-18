namespace Metal.NET;

public class MTLTensor(nint nativePtr) : MTLResource(nativePtr)
{
    public MTLBuffer Buffer
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorSelector.Buffer));
    }

    public nuint BufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorSelector.BufferOffset);
    }

    public MTLTensorDataType DataType
    {
        get => (MTLTensorDataType)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLTensorSelector.DataType);
    }

    public MTLTensorExtents Dimensions
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorSelector.Dimensions));
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLTensorSelector.GpuResourceID);
    }

    public MTLTensorExtents Strides
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorSelector.Strides));
    }

    public MTLTensorUsage Usage
    {
        get => (MTLTensorUsage)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLTensorSelector.Usage);
    }

    public static implicit operator nint(MTLTensor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLTensor(nint value)
    {
        return new(value);
    }

    public void GetBytes(nint bytes, MTLTensorExtents strides, MTLTensorExtents sliceOrigin, MTLTensorExtents sliceDimensions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorSelector.GetBytesStridesFromSliceOriginSliceDimensions, bytes, strides.NativePtr, sliceOrigin.NativePtr, sliceDimensions.NativePtr);
    }

    public void ReplaceSliceOrigin(MTLTensorExtents sliceOrigin, MTLTensorExtents sliceDimensions, nint bytes, MTLTensorExtents strides)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorSelector.ReplaceSliceOriginSliceDimensionsWithBytesStrides, sliceOrigin.NativePtr, sliceDimensions.NativePtr, bytes, strides.NativePtr);
    }
}

file class MTLTensorSelector
{
    public static readonly Selector Buffer = Selector.Register("buffer");

    public static readonly Selector BufferOffset = Selector.Register("bufferOffset");

    public static readonly Selector DataType = Selector.Register("dataType");

    public static readonly Selector Dimensions = Selector.Register("dimensions");

    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector Strides = Selector.Register("strides");

    public static readonly Selector Usage = Selector.Register("usage");

    public static readonly Selector GetBytesStridesFromSliceOriginSliceDimensions = Selector.Register("getBytes:strides:fromSliceOrigin:sliceDimensions:");

    public static readonly Selector ReplaceSliceOriginSliceDimensionsWithBytesStrides = Selector.Register("replaceSliceOrigin:sliceDimensions:withBytes:strides:");
}
