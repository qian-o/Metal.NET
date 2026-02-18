namespace Metal.NET;

public partial class MTLObjectPayloadBinding : NativeObject
{
    public MTLObjectPayloadBinding(nint nativePtr) : base(nativePtr)
    {
    }

    public nuint ObjectPayloadAlignment
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLObjectPayloadBindingSelector.ObjectPayloadAlignment);
    }

    public nuint ObjectPayloadDataSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLObjectPayloadBindingSelector.ObjectPayloadDataSize);
    }
}

file static class MTLObjectPayloadBindingSelector
{
    public static readonly Selector ObjectPayloadAlignment = Selector.Register("objectPayloadAlignment");

    public static readonly Selector ObjectPayloadDataSize = Selector.Register("objectPayloadDataSize");
}
