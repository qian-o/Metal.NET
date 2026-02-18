namespace Metal.NET;

public partial class MTLBufferBinding : NativeObject
{
    public MTLBufferBinding(nint nativePtr) : base(nativePtr)
    {
    }

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
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLBufferBindingSelector.BufferDataType);
    }

    public MTLPointerType? BufferPointerType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferBindingSelector.BufferPointerType);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLStructType? BufferStructType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferBindingSelector.BufferStructType);
            return ptr is not 0 ? new(ptr) : null;
        }
    }
}

file static class MTLBufferBindingSelector
{
    public static readonly Selector BufferAlignment = Selector.Register("bufferAlignment");

    public static readonly Selector BufferDataSize = Selector.Register("bufferDataSize");

    public static readonly Selector BufferDataType = Selector.Register("bufferDataType");

    public static readonly Selector BufferPointerType = Selector.Register("bufferPointerType");

    public static readonly Selector BufferStructType = Selector.Register("bufferStructType");
}
