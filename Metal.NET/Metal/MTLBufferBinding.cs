namespace Metal.NET;

public class MTLBufferBinding(nint nativePtr, bool ownsReference) : MTLBinding(nativePtr, ownsReference), INativeObject<MTLBufferBinding>
{
    public static new MTLBufferBinding Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

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

    public MTLPointerType BufferPointerType
    {
        get => GetProperty(ref field, MTLBufferBindingBindings.BufferPointerType);
    }

    public MTLStructType BufferStructType
    {
        get => GetProperty(ref field, MTLBufferBindingBindings.BufferStructType);
    }
}

file static class MTLBufferBindingBindings
{
    public static readonly Selector BufferAlignment = "bufferAlignment";

    public static readonly Selector BufferDataSize = "bufferDataSize";

    public static readonly Selector BufferDataType = "bufferDataType";

    public static readonly Selector BufferPointerType = "bufferPointerType";

    public static readonly Selector BufferStructType = "bufferStructType";
}
