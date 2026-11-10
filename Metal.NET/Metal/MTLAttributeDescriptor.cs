namespace Metal.NET;

public readonly struct MTLAttributeDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLAttributeDescriptor value) => new(value.NativePtr);

    public MTLAttributeDescriptor() : this(ObjectiveC.AllocInit(MTLAttributeDescriptorBindings.Class))
    {
    }

    public MTLAttributeDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLAttributeFormat Format
    {
        get => (MTLAttributeFormat)ObjectiveC.MsgSendULong(NativePtr, MTLAttributeDescriptorBindings.Format);
        set => ObjectiveC.MsgSend(NativePtr, MTLAttributeDescriptorBindings.SetFormat, (nuint)value);
    }

    public nuint Offset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAttributeDescriptorBindings.Offset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAttributeDescriptorBindings.SetOffset, value);
    }

    public nuint BufferIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAttributeDescriptorBindings.BufferIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLAttributeDescriptorBindings.SetBufferIndex, value);
    }
}

file static class MTLAttributeDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLAttributeDescriptor");

    public static readonly Selector BufferIndex = "bufferIndex";

    public static readonly Selector Format = "format";

    public static readonly Selector Offset = "offset";

    public static readonly Selector SetBufferIndex = "setBufferIndex:";

    public static readonly Selector SetFormat = "setFormat:";

    public static readonly Selector SetOffset = "setOffset:";
}
