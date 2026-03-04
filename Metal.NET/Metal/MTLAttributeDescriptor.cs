namespace Metal.NET;

public class MTLAttributeDescriptor(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTLAttributeDescriptor>
{
    #region INativeObject
    public static MTLAttributeDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLAttributeDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLAttributeDescriptor() : this(ObjectiveC.AllocInit(MTLAttributeDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public nuint BufferIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAttributeDescriptorBindings.BufferIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLAttributeDescriptorBindings.SetBufferIndex, value);
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
