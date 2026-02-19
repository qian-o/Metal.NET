namespace Metal.NET;

public class MTLObjectPayloadBinding(nint nativePtr) : NativeObject(nativePtr)
{
    public nuint ObjectPayloadAlignment
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLObjectPayloadBindingBindings.ObjectPayloadAlignment);
    }

    public nuint ObjectPayloadDataSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLObjectPayloadBindingBindings.ObjectPayloadDataSize);
    }
}

file static class MTLObjectPayloadBindingBindings
{
    public static readonly Selector ObjectPayloadAlignment = Selector.Register("objectPayloadAlignment");

    public static readonly Selector ObjectPayloadDataSize = Selector.Register("objectPayloadDataSize");
}
