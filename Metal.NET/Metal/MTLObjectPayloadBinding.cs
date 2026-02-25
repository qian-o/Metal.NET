namespace Metal.NET;

public class MTLObjectPayloadBinding(nint nativePtr, bool ownsReference) : MTLBinding(nativePtr, ownsReference), INativeObject<MTLObjectPayloadBinding>
{
    public static new MTLObjectPayloadBinding Create(nint nativePtr) => new(nativePtr, true);

    public static new MTLObjectPayloadBinding CreateBorrowed(nint nativePtr) => new(nativePtr, false);

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
