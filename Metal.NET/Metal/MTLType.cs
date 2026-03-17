namespace Metal.NET;

/// <summary>
/// A description of a data type.
/// </summary>
public class MTLType(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLType>
{
    #region INativeObject
    public static new MTLType Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLType New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLType() : this(ObjectiveC.AllocInit(MTLTypeBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Identifying the data type - Properties

    /// <summary>
    /// The data type of the function argument.
    /// </summary>
    public MTLDataType DataType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLTypeBindings.DataType);
    }
    #endregion
}

file static class MTLTypeBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLType");

    public static readonly Selector DataType = "dataType";
}
