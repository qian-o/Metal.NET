namespace Metal.NET;

public class MTLAttributeDescriptor : IDisposable
{
    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLAttributeDescriptor");

    public MTLAttributeDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    public MTLAttributeDescriptor() : this(ObjectiveCRuntime.AllocInit(s_class))
    {
    }

    ~MTLAttributeDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nuint BufferIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAttributeDescriptorSelector.BufferIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAttributeDescriptorSelector.SetBufferIndex, (nuint)value);
    }

    public MTLAttributeFormat Format
    {
        get => (MTLAttributeFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLAttributeDescriptorSelector.Format));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAttributeDescriptorSelector.SetFormat, (uint)value);
    }

    public nuint Offset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAttributeDescriptorSelector.Offset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAttributeDescriptorSelector.SetOffset, (nuint)value);
    }

    public static implicit operator nint(MTLAttributeDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLAttributeDescriptor(nint value)
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

file class MTLAttributeDescriptorSelector
{
    public static readonly Selector BufferIndex = Selector.Register("bufferIndex");

    public static readonly Selector SetBufferIndex = Selector.Register("setBufferIndex:");

    public static readonly Selector Format = Selector.Register("format");

    public static readonly Selector SetFormat = Selector.Register("setFormat:");

    public static readonly Selector Offset = Selector.Register("offset");

    public static readonly Selector SetOffset = Selector.Register("setOffset:");
}
