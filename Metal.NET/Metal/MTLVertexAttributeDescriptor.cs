namespace Metal.NET;

public partial class MTLVertexAttributeDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLVertexAttributeDescriptor");

    public MTLVertexAttributeDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public nuint BufferIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLVertexAttributeDescriptorSelector.BufferIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexAttributeDescriptorSelector.SetBufferIndex, value);
    }

    public MTLVertexFormat Format
    {
        get => (MTLVertexFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLVertexAttributeDescriptorSelector.Format);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexAttributeDescriptorSelector.SetFormat, (nuint)value);
    }

    public nuint Offset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLVertexAttributeDescriptorSelector.Offset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexAttributeDescriptorSelector.SetOffset, value);
    }
}

file static class MTLVertexAttributeDescriptorSelector
{
    public static readonly Selector BufferIndex = Selector.Register("bufferIndex");

    public static readonly Selector Format = Selector.Register("format");

    public static readonly Selector Offset = Selector.Register("offset");

    public static readonly Selector SetBufferIndex = Selector.Register("setBufferIndex:");

    public static readonly Selector SetFormat = Selector.Register("setFormat:");

    public static readonly Selector SetOffset = Selector.Register("setOffset:");
}
