namespace Metal.NET;

public partial class MTLType(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLType>
{
    #region INativeObject
    public static new MTLType Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLType New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLDataType DataType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLTypeBindings.DataType);
    }
}

file static class MTLTypeBindings
{
    public static readonly Selector DataType = "dataType";
}
