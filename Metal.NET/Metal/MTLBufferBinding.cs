namespace Metal.NET;

public class MTLBufferBinding : IDisposable
{
    public MTLBufferBinding(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLBufferBinding()
    {
        Release();
    }

    public nint NativePtr { get; }

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
        get => (MTLDataType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLBufferBindingSelector.BufferDataType));
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

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
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
