namespace Metal.NET;

public class MTLVertexAttributeDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLVertexAttributeDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLVertexAttributeDescriptorBindings.Class))
    {
    }

    public nuint BufferIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLVertexAttributeDescriptorBindings.BufferIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexAttributeDescriptorBindings.SetBufferIndex, value);
    }

    public MTLVertexFormat Format
    {
        get => (MTLVertexFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLVertexAttributeDescriptorBindings.Format);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexAttributeDescriptorBindings.SetFormat, (nuint)value);
    }

    public nuint Offset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLVertexAttributeDescriptorBindings.Offset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexAttributeDescriptorBindings.SetOffset, value);
    }
}

file static class MTLVertexAttributeDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLVertexAttributeDescriptor");

    public static readonly Selector BufferIndex = Selector.Register("bufferIndex");

    public static readonly Selector Format = Selector.Register("format");

    public static readonly Selector Offset = Selector.Register("offset");

    public static readonly Selector SetBufferIndex = Selector.Register("setBufferIndex:");

    public static readonly Selector SetFormat = Selector.Register("setFormat:");

    public static readonly Selector SetOffset = Selector.Register("setOffset:");
}
