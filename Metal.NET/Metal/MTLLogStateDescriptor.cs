namespace Metal.NET;

public class MTLLogStateDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLLogStateDescriptor");

    public MTLLogStateDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLLogStateDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLLogStateDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nint BufferSize
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLogStateDescriptorSelector.BufferSize);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLLogStateDescriptorSelector.SetBufferSize, value);
    }

    public MTLLogLevel Level
    {
        get => (MTLLogLevel)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLLogStateDescriptorSelector.Level);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLLogStateDescriptorSelector.SetLevel, (ulong)value);
    }

    public static implicit operator nint(MTLLogStateDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLLogStateDescriptor(nint value)
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

file class MTLLogStateDescriptorSelector
{
    public static readonly Selector BufferSize = Selector.Register("bufferSize");

    public static readonly Selector SetBufferSize = Selector.Register("setBufferSize:");

    public static readonly Selector Level = Selector.Register("level");

    public static readonly Selector SetLevel = Selector.Register("setLevel:");
}
