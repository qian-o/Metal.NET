namespace Metal.NET;

public class MTLTensorAuxiliaryPlaneType(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLTensorAuxiliaryPlaneType>
{
    #region INativeObject
    public static new MTLTensorAuxiliaryPlaneType Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLTensorAuxiliaryPlaneType New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLTensorDataType DataType
    {
        get => (MTLTensorDataType)ObjectiveC.MsgSendLong(NativePtr, MTLTensorAuxiliaryPlaneTypeBindings.DataType);
    }

    public MTLTensorExtents BlockFactors
    {
        get => GetProperty(ref field, MTLTensorAuxiliaryPlaneTypeBindings.BlockFactors);
    }

    public MTLTensorPlaneType PlaneType
    {
        get => (MTLTensorPlaneType)ObjectiveC.MsgSendLong(NativePtr, MTLTensorAuxiliaryPlaneTypeBindings.PlaneType);
    }
}

file static class MTLTensorAuxiliaryPlaneTypeBindings
{
    public static readonly Selector BlockFactors = "blockFactors";

    public static readonly Selector DataType = "dataType";

    public static readonly Selector PlaneType = "planeType";
}
