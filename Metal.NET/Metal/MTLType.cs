namespace Metal.NET;

public class MTLType(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLType>
{
    public static MTLType Create(nint nativePtr) => new(nativePtr, true);

    public static MTLType CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public MTLType() : this(ObjectiveCRuntime.AllocInit(MTLTypeBindings.Class), true)
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
