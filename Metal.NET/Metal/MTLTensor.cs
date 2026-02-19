namespace Metal.NET;

public class MTLTensor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLBuffer? Buffer
    {
        get => GetProperty<MTLBuffer>(ref field, MTLTensorBindings.Buffer);
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
        get => GetProperty<MTLTensorExtents>(ref field, MTLTensorBindings.Dimensions);
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLTensorBindings.GpuResourceID);
    }

    public MTLTensorExtents? Strides
    {
        get => GetProperty<MTLTensorExtents>(ref field, MTLTensorBindings.Strides);
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
