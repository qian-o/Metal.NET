namespace Metal.NET;

public class MTLObjectPayloadBinding(nint nativePtr, NativeObjectOwnership ownership) : MTLBinding(nativePtr, ownership), INativeObject<MTLObjectPayloadBinding>
{
    public static new MTLObjectPayloadBinding Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLObjectPayloadBinding Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

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
