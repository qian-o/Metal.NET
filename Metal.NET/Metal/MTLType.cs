namespace Metal.NET;

public class MTLType(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLType() : this(ObjectiveCRuntime.AllocInit(MTLTypeBindings.Class))
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
