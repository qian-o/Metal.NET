namespace Metal.NET;

public class MTLObjectPayloadBinding(nint nativePtr) : MTLBinding(nativePtr), INativeObject<MTLObjectPayloadBinding>
{
    public static MTLObjectPayloadBinding Create(nint nativePtr) => new(nativePtr);

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
    public static readonly Selector ObjectPayloadAlignment = "objectPayloadAlignment";

    public static readonly Selector ObjectPayloadDataSize = "objectPayloadDataSize";
}
