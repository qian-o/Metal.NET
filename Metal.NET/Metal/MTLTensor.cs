namespace Metal.NET;

public readonly struct MTLTensor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLBuffer? Buffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorBindings.Buffer);
            return ptr is not 0 ? new MTLBuffer(ptr) : default;
        }
    }

    public nuint BufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorBindings.BufferOffset);
    }

    public MTLTensorDataType DataType
    {
        get => (MTLTensorDataType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorBindings.DataType);
    }

    public MTLTensorExtents? Dimensions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorBindings.Dimensions);
            return ptr is not 0 ? new MTLTensorExtents(ptr) : default;
        }
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLTensorBindings.GpuResourceID);
    }

    public MTLTensorExtents? Strides
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorBindings.Strides);
            return ptr is not 0 ? new MTLTensorExtents(ptr) : default;
        }
    }

    public MTLTensorUsage Usage
    {
        get => (MTLTensorUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorBindings.Usage);
    }

    public void GetBytes(nint bytes, MTLTensorExtents strides, MTLTensorExtents sliceOrigin, MTLTensorExtents sliceDimensions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorBindings.GetBytes, bytes, strides.NativePtr, sliceOrigin.NativePtr, sliceDimensions.NativePtr);
    }

    public void ReplaceSliceOrigin(MTLTensorExtents sliceOrigin, MTLTensorExtents sliceDimensions, nint bytes, MTLTensorExtents strides)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTensorBindings.ReplaceSliceOrigin, sliceOrigin.NativePtr, sliceDimensions.NativePtr, bytes, strides.NativePtr);
    }
}

file static class MTLTensorBindings
{
    public static readonly Selector Buffer = Selector.Register("buffer");

    public static readonly Selector BufferOffset = Selector.Register("bufferOffset");

    public static readonly Selector DataType = Selector.Register("dataType");

    public static readonly Selector Dimensions = Selector.Register("dimensions");

    public static readonly Selector GetBytes = Selector.Register("getBytes:strides:fromSliceOrigin:sliceDimensions:");

    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector ReplaceSliceOrigin = Selector.Register("replaceSliceOrigin:sliceDimensions:withBytes:strides:");

    public static readonly Selector Strides = Selector.Register("strides");

    public static readonly Selector Usage = Selector.Register("usage");
}
