namespace Metal.NET;

public class MTLBufferBinding(nint nativePtr, NativeObjectOwnership ownership) : MTLBinding(nativePtr, ownership), INativeObject<MTLBufferBinding>
{
    #region INativeObject
    public static new MTLBufferBinding Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLBufferBinding New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

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
        get => GetProperty(ref field, MTLBufferBindingBindings.BufferStructType);
    }

    public MTLPointerType BufferPointerType
    {
        get => GetProperty(ref field, MTLBufferBindingBindings.BufferPointerType);
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
