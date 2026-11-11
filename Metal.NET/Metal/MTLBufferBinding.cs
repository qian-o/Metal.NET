namespace Metal.NET;

public readonly struct MTLBufferBinding(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLBinding(MTLBufferBinding value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLBufferBinding value) => new(value.NativePtr);

    public MTLBufferBinding Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public nuint BufferAlignment
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLBufferBindingBindings.BufferAlignment);
    }

    public nuint BufferDataSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLBufferBindingBindings.BufferDataSize);
    }

    public MTLDataType BufferDataType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLBufferBindingBindings.BufferDataType);
    }

    public MTLStructType BufferStructType
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLBufferBindingBindings.BufferStructType));
    }

    public MTLPointerType BufferPointerType
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLBufferBindingBindings.BufferPointerType));
    }

    public NSString Name
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLBufferBindingBindings.Name));
    }

    public MTLBindingType Type
    {
        get => (MTLBindingType)ObjectiveC.MsgSendLong(NativePtr, MTLBufferBindingBindings.Type);
    }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveC.MsgSendULong(NativePtr, MTLBufferBindingBindings.Access);
    }

    public nuint Index
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLBufferBindingBindings.Index);
    }

    public Bool8 IsUsed
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLBufferBindingBindings.IsUsed);
    }

    public Bool8 IsArgument
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLBufferBindingBindings.IsArgument);
    }
}

file static class MTLBufferBindingBindings
{
    public static readonly Selector Access = "access";

    public static readonly Selector BufferAlignment = "bufferAlignment";

    public static readonly Selector BufferDataSize = "bufferDataSize";

    public static readonly Selector BufferDataType = "bufferDataType";

    public static readonly Selector BufferPointerType = "bufferPointerType";

    public static readonly Selector BufferStructType = "bufferStructType";

    public static readonly Selector Index = "index";

    public static readonly Selector IsArgument = "isArgument";

    public static readonly Selector IsUsed = "isUsed";

    public static readonly Selector Name = "name";

    public static readonly Selector Type = "type";
}
