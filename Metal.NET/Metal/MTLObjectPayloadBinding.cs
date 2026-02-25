namespace Metal.NET;

public class MTLObjectPayloadBinding(nint nativePtr, bool ownsReference, bool allowGCRelease) : MTLBinding(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLObjectPayloadBinding>
{
    public static new MTLObjectPayloadBinding Null { get; } = new(0, false, false);

    public static new MTLObjectPayloadBinding Create(nint nativePtr, bool ownsReference, bool allowGCRelease) => new(nativePtr, ownsReference, allowGCRelease);

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
