namespace Metal.NET;

public readonly struct MTLObjectPayloadBinding(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator MTLBinding(MTLObjectPayloadBinding value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLObjectPayloadBinding value) => new(value.NativePtr);

    public MTLObjectPayloadBinding Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public nuint ObjectPayloadAlignment
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLObjectPayloadBindingBindings.ObjectPayloadAlignment);
    }

    public nuint ObjectPayloadDataSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLObjectPayloadBindingBindings.ObjectPayloadDataSize);
    }

    public NSString Name
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLObjectPayloadBindingBindings.Name));
    }

    public MTLBindingType Type
    {
        get => (MTLBindingType)ObjectiveC.MsgSendLong(NativePtr, MTLObjectPayloadBindingBindings.Type);
    }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveC.MsgSendULong(NativePtr, MTLObjectPayloadBindingBindings.Access);
    }

    public nuint Index
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLObjectPayloadBindingBindings.Index);
    }

    public Bool8 IsUsed
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLObjectPayloadBindingBindings.IsUsed);
    }

    public Bool8 IsArgument
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLObjectPayloadBindingBindings.IsArgument);
    }
}

file static class MTLObjectPayloadBindingBindings
{
    public static readonly Selector Access = "access";

    public static readonly Selector Index = "index";

    public static readonly Selector IsArgument = "isArgument";

    public static readonly Selector IsUsed = "isUsed";

    public static readonly Selector Name = "name";

    public static readonly Selector ObjectPayloadAlignment = "objectPayloadAlignment";

    public static readonly Selector ObjectPayloadDataSize = "objectPayloadDataSize";

    public static readonly Selector Type = "type";
}
