namespace Metal.NET;

public readonly struct MTLVertexAttributeDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLVertexAttributeDescriptor value) => new(value.NativePtr);

    public MTLVertexAttributeDescriptor() : this(ObjectiveC.AllocInit(MTLVertexAttributeDescriptorBindings.Class))
    {
    }

    public MTLVertexAttributeDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLVertexFormat Format
    {
        get => (MTLVertexFormat)ObjectiveC.MsgSendULong(NativePtr, MTLVertexAttributeDescriptorBindings.Format);
        set => ObjectiveC.MsgSend(NativePtr, MTLVertexAttributeDescriptorBindings.SetFormat, (nuint)value);
    }

    public nuint Offset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLVertexAttributeDescriptorBindings.Offset);
        set => ObjectiveC.MsgSend(NativePtr, MTLVertexAttributeDescriptorBindings.SetOffset, value);
    }

    public nuint BufferIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLVertexAttributeDescriptorBindings.BufferIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLVertexAttributeDescriptorBindings.SetBufferIndex, value);
    }
}

file static class MTLVertexAttributeDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLVertexAttributeDescriptor");

    public static readonly Selector BufferIndex = "bufferIndex";

    public static readonly Selector Format = "format";

    public static readonly Selector Offset = "offset";

    public static readonly Selector SetBufferIndex = "setBufferIndex:";

    public static readonly Selector SetFormat = "setFormat:";

    public static readonly Selector SetOffset = "setOffset:";
}
