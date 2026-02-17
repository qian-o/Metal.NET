namespace Metal.NET;

public class MTLVertexAttributeDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLVertexAttributeDescriptor");

    public MTLVertexAttributeDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    public MTLVertexAttributeDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLVertexAttributeDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nuint BufferIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLVertexAttributeDescriptorSelector.BufferIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexAttributeDescriptorSelector.SetBufferIndex, value);
    }

    public MTLVertexFormat Format
    {
        get => (MTLVertexFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLVertexAttributeDescriptorSelector.Format));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexAttributeDescriptorSelector.SetFormat, (uint)value);
    }

    public nuint Offset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLVertexAttributeDescriptorSelector.Offset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexAttributeDescriptorSelector.SetOffset, value);
    }

    public static implicit operator nint(MTLVertexAttributeDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLVertexAttributeDescriptor(nint value)
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

file class MTLVertexAttributeDescriptorSelector
{
    public static readonly Selector BufferIndex = Selector.Register("bufferIndex");

    public static readonly Selector SetBufferIndex = Selector.Register("setBufferIndex:");

    public static readonly Selector Format = Selector.Register("format");

    public static readonly Selector SetFormat = Selector.Register("setFormat:");

    public static readonly Selector Offset = Selector.Register("offset");

    public static readonly Selector SetOffset = Selector.Register("setOffset:");
}
