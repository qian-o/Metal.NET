namespace Metal.NET;

public readonly struct MTLBufferBinding(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public nuint BufferAlignment
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLBufferBindingBindings.BufferAlignment);
    }

    public nuint BufferDataSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLBufferBindingBindings.BufferDataSize);
    }

    public MTLDataType BufferDataType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLBufferBindingBindings.BufferDataType);
    }

    public MTLPointerType? BufferPointerType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferBindingBindings.BufferPointerType);
            return ptr is not 0 ? new MTLPointerType(ptr) : default;
        }
    }

    public MTLStructType? BufferStructType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferBindingBindings.BufferStructType);
            return ptr is not 0 ? new MTLStructType(ptr) : default;
        }
    }
}

file static class MTLBufferBindingBindings
{
    public static readonly Selector BufferAlignment = Selector.Register("bufferAlignment");

    public static readonly Selector BufferDataSize = Selector.Register("bufferDataSize");

    public static readonly Selector BufferDataType = Selector.Register("bufferDataType");

    public static readonly Selector BufferPointerType = Selector.Register("bufferPointerType");

    public static readonly Selector BufferStructType = Selector.Register("bufferStructType");
}
