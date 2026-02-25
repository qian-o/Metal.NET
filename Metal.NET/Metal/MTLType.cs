namespace Metal.NET;

public class MTLType(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLType>
{
    public static MTLType Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLType Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLType() : this(ObjectiveCRuntime.AllocInit(MTLTypeBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLDataType DataType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTypeBindings.DataType);
    }
}

file static class MTLTypeBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLType");

    public static readonly Selector DataType = "dataType";
}
