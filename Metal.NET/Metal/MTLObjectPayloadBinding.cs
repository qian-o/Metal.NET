namespace Metal.NET;

public class MTLObjectPayloadBinding(nint nativePtr) : MTLBinding(nativePtr)
{
    public nuint ObjectPayloadAlignment
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLObjectPayloadBindingSelector.ObjectPayloadAlignment);
    }

    public nuint ObjectPayloadDataSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLObjectPayloadBindingSelector.ObjectPayloadDataSize);
    }

    public static implicit operator nint(MTLObjectPayloadBinding value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLObjectPayloadBinding(nint value)
    {
        return new(value);
    }
}

file class MTLObjectPayloadBindingSelector
{
    public static readonly Selector ObjectPayloadAlignment = Selector.Register("objectPayloadAlignment");

    public static readonly Selector ObjectPayloadDataSize = Selector.Register("objectPayloadDataSize");
}
