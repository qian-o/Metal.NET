namespace Metal.NET;

public class MTLTensorAuxiliaryPlane(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLTensorAuxiliaryPlane>
{
    #region INativeObject
    public static new MTLTensorAuxiliaryPlane Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLTensorAuxiliaryPlane New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLTensorDataType DataType
    {
        get => (MTLTensorDataType)ObjectiveC.MsgSendLong(NativePtr, MTLTensorAuxiliaryPlaneBindings.DataType);
    }

    public MTLTensorExtents BlockFactors
    {
        get => GetProperty(ref field, MTLTensorAuxiliaryPlaneBindings.BlockFactors);
    }

    public MTLBuffer Buffer
    {
        get => GetProperty(ref field, MTLTensorAuxiliaryPlaneBindings.Buffer);
    }

    public nuint BufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTensorAuxiliaryPlaneBindings.BufferOffset);
    }

    public MTLTensorPlaneType PlaneType
    {
        get => (MTLTensorPlaneType)ObjectiveC.MsgSendLong(NativePtr, MTLTensorAuxiliaryPlaneBindings.PlaneType);
    }
}

file static class MTLTensorAuxiliaryPlaneBindings
{
    public static readonly Selector BlockFactors = "blockFactors";

    public static readonly Selector Buffer = "buffer";

    public static readonly Selector BufferOffset = "bufferOffset";

    public static readonly Selector DataType = "dataType";

    public static readonly Selector PlaneType = "planeType";
}
