namespace Metal.NET;

public class MTLBufferBinding(nint nativePtr) : MTLBinding(nativePtr)
{
    public nuint BufferAlignment
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLBufferBindingSelector.BufferAlignment);
    }

    public nuint BufferDataSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLBufferBindingSelector.BufferDataSize);
    }

    public MTLDataType BufferDataType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLBufferBindingSelector.BufferDataType);
    }

    public MTLPointerType BufferPointerType
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferBindingSelector.BufferPointerType));
    }

    public MTLStructType BufferStructType
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferBindingSelector.BufferStructType));
    }

    public static implicit operator nint(MTLBufferBinding value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLBufferBinding(nint value)
    {
        return new(value);
    }
}

file class MTLBufferBindingSelector
{
    public static readonly Selector BufferAlignment = Selector.Register("bufferAlignment");

    public static readonly Selector BufferDataSize = Selector.Register("bufferDataSize");

    public static readonly Selector BufferDataType = Selector.Register("bufferDataType");

    public static readonly Selector BufferPointerType = Selector.Register("bufferPointerType");

    public static readonly Selector BufferStructType = Selector.Register("bufferStructType");
}
