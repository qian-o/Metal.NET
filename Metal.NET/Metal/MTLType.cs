namespace Metal.NET;

public class MTLType(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLType() : this(ObjectiveCRuntime.AllocInit(MTLTypeSelector.Class))
    {
    }

    public MTLDataType DataType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTypeSelector.DataType);
    }
}

file static class MTLTypeSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLType");

    public static readonly Selector DataType = Selector.Register("dataType");
}
