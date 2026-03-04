namespace Metal.NET;

public class MTLVertexAttributeDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLVertexAttributeDescriptor>
{
    public static MTLVertexAttributeDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLVertexAttributeDescriptor Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLVertexAttributeDescriptor() : this(ObjectiveC.AllocInit(MTLVertexAttributeDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public nuint BufferIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLVertexAttributeDescriptorBindings.BufferIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLVertexAttributeDescriptorBindings.SetBufferIndex, value);
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
