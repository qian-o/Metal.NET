namespace Metal.NET;

public class MTLAttributeDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLAttributeDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLAttributeDescriptorBindings.Class))
    {
    }

    public nuint BufferIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAttributeDescriptorBindings.BufferIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAttributeDescriptorBindings.SetBufferIndex, value);
    }

    public MTLAttributeFormat Format
    {
        get => (MTLAttributeFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAttributeDescriptorBindings.Format);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAttributeDescriptorBindings.SetFormat, (nuint)value);
    }

    public nuint Offset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAttributeDescriptorBindings.Offset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAttributeDescriptorBindings.SetOffset, value);
    }
}

file static class MTLAttributeDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAttributeDescriptor");

    public static readonly Selector BufferIndex = "bufferIndex";

    public static readonly Selector Format = "format";

    public static readonly Selector Offset = "offset";

    public static readonly Selector SetBufferIndex = "setBufferIndex:";

    public static readonly Selector SetFormat = "setFormat:";

    public static readonly Selector SetOffset = "setOffset:";
}
