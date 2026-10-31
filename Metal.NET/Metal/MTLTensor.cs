namespace Metal.NET;

public class MTLTensor(nint nativePtr, NativeObjectOwnership ownership) : MTLResource(nativePtr, ownership), INativeObject<MTLTensor>
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

    public NSArray<MTLTensorAuxiliaryPlane> AuxiliaryPlanes
    {
        get => GetProperty(ref field, MTLTensorBindings.AuxiliaryPlanes);
    }

    public void Replace(MTLTensorExtents sliceOrigin, MTLTensorExtents sliceDimensions, nint bytes, MTLTensorExtents strides)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTensorBindings.ReplaceSliceOrigin_SliceDimensions_WithBytes_Strides, sliceOrigin.NativePtr, sliceDimensions.NativePtr, bytes, strides.NativePtr);
    }

    public void GetBytes(nint bytes, MTLTensorExtents strides, MTLTensorExtents sliceOrigin, MTLTensorExtents sliceDimensions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTensorBindings.GetBytes_Strides_FromSliceOrigin_SliceDimensions, bytes, strides.NativePtr, sliceOrigin.NativePtr, sliceDimensions.NativePtr);
    }

    public void GetBytes(nint bytes, MTLTensorExtents strides, MTLTensorExtents sliceOrigin, MTLTensorExtents sliceDimensions, MTLTensorPlaneType plane)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTensorBindings.GetBytes_Strides_FromSliceOrigin_SliceDimensions_Plane, bytes, strides.NativePtr, sliceOrigin.NativePtr, sliceDimensions.NativePtr, (nint)plane);
    }

    public void Replace(MTLTensorExtents sliceOrigin, MTLTensorExtents sliceDimensions, MTLTensorPlaneType plane, nint bytes, MTLTensorExtents strides)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTensorBindings.ReplaceSliceOrigin_SliceDimensions_Plane_WithBytes_Strides, sliceOrigin.NativePtr, sliceDimensions.NativePtr, (nint)plane, bytes, strides.NativePtr);
    }
}

file static class MTLTensorBindings
{
    public static readonly Selector AuxiliaryPlanes = "auxiliaryPlanes";

    public static readonly Selector Buffer = "buffer";

    public static readonly Selector BufferOffset = "bufferOffset";

    public static readonly Selector DataType = "dataType";

    public static readonly Selector Dimensions = "dimensions";

    public static readonly Selector GetBytes_Strides_FromSliceOrigin_SliceDimensions = "getBytes:strides:fromSliceOrigin:sliceDimensions:";

    public static readonly Selector GetBytes_Strides_FromSliceOrigin_SliceDimensions_Plane = "getBytes:strides:fromSliceOrigin:sliceDimensions:plane:";

    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector ReplaceSliceOrigin_SliceDimensions_Plane_WithBytes_Strides = "replaceSliceOrigin:sliceDimensions:plane:withBytes:strides:";

    public static readonly Selector ReplaceSliceOrigin_SliceDimensions_WithBytes_Strides = "replaceSliceOrigin:sliceDimensions:withBytes:strides:";

    public static readonly Selector Strides = "strides";

    public static readonly Selector Usage = "usage";
}
