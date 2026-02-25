namespace Metal.NET;

public class MTLObjectPayloadBinding(nint nativePtr, bool ownsReference) : MTLBinding(nativePtr, ownsReference), INativeObject<MTLObjectPayloadBinding>
{
    public static new MTLObjectPayloadBinding Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
    public static new MTLObjectPayloadBinding Null => Create(0, false);
    public static new MTLObjectPayloadBinding Empty => Null;

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
