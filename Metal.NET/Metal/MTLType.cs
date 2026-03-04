namespace Metal.NET;

public class MTLType(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLType>
{
    public static MTLType Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLType Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLType() : this(ObjectiveC.AllocInit(MTLTypeBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLDataType DataType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLTypeBindings.DataType);
    }
}

file static class MTLTypeBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLType");

    public static readonly Selector DataType = "dataType";
}
