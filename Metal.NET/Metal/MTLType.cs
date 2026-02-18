namespace Metal.NET;

public partial class MTLType : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLType");

    public MTLType(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLDataType DataType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTypeSelector.DataType);
    }
}

file static class MTLTypeSelector
{
    public static readonly Selector DataType = Selector.Register("dataType");
}
