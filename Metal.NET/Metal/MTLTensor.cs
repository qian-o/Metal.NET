namespace Metal.NET;

public partial class MTLTensor : NativeObject
{
    public MTLTensor(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLBuffer? Buffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorSelector.Buffer);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public nuint BufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorSelector.BufferOffset);
    }

    public MTLTensorDataType DataType
    {
        get => (MTLTensorDataType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorSelector.DataType);
    }

    public MTLTensorExtents? Dimensions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorSelector.Dimensions);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLTensorSelector.GpuResourceID);
    }

    public MTLTensorExtents? Strides
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorSelector.Strides);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public nuint Usage
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorSelector.Usage);
    }

    public void GetBytes(nint bytes, MTLTensorExtents strides, MTLTensorExtents sliceOrigin, MTLTensorExtents sliceDimensions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorSelector.GetBytes, bytes, strides.NativePtr, sliceOrigin.NativePtr, sliceDimensions.NativePtr);
    }

    public void ReplaceSliceOrigin(MTLTensorExtents sliceOrigin, MTLTensorExtents sliceDimensions, nint bytes, MTLTensorExtents strides)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorSelector.ReplaceSliceOrigin, sliceOrigin.NativePtr, sliceDimensions.NativePtr, bytes, strides.NativePtr);
    }
}

file static class MTLTensorSelector
{
    public static readonly Selector Buffer = Selector.Register("buffer");

    public static readonly Selector BufferOffset = Selector.Register("bufferOffset");

    public static readonly Selector DataType = Selector.Register("dataType");

    public static readonly Selector Dimensions = Selector.Register("dimensions");

    public static readonly Selector GetBytes = Selector.Register("getBytes::::");

    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector ReplaceSliceOrigin = Selector.Register("replaceSliceOrigin::::");

    public static readonly Selector Strides = Selector.Register("strides");

    public static readonly Selector Usage = Selector.Register("usage");
}
