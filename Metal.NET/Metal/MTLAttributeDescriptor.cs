namespace Metal.NET;

public partial class MTLAttributeDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAttributeDescriptor");

    public MTLAttributeDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public nuint BufferIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAttributeDescriptorSelector.BufferIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAttributeDescriptorSelector.SetBufferIndex, value);
    }

    public MTLAttributeFormat Format
    {
        get => (MTLAttributeFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAttributeDescriptorSelector.Format);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAttributeDescriptorSelector.SetFormat, (nuint)value);
    }

    public nuint Offset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAttributeDescriptorSelector.Offset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAttributeDescriptorSelector.SetOffset, value);
    }
}

file static class MTLAttributeDescriptorSelector
{
    public static readonly Selector BufferIndex = Selector.Register("bufferIndex");

    public static readonly Selector Format = Selector.Register("format");

    public static readonly Selector Offset = Selector.Register("offset");

    public static readonly Selector SetBufferIndex = Selector.Register("setBufferIndex:");

    public static readonly Selector SetFormat = Selector.Register("setFormat:");

    public static readonly Selector SetOffset = Selector.Register("setOffset:");
}
