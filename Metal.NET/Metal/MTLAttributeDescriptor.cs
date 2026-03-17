namespace Metal.NET;

/// <summary>
/// A descriptor of an argument’s format and where its data is in memory.
/// </summary>
public class MTLAttributeDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLAttributeDescriptor>
{
    #region INativeObject
    public static new MTLAttributeDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLAttributeDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLAttributeDescriptor() : this(ObjectiveC.AllocInit(MTLAttributeDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Defining attribute location - Properties

    /// <summary>
    /// The index in the buffer argument table for the buffer that contains the data for this attribute.
    /// </summary>
    public nuint BufferIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAttributeDescriptorBindings.BufferIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLAttributeDescriptorBindings.SetBufferIndex, value);
    }

    /// <summary>
    /// The offset, in bytes, from the start of the buffer that contains the attribute data to the start of the data itself.
    /// </summary>
    public nuint Offset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAttributeDescriptorBindings.Offset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAttributeDescriptorBindings.SetOffset, value);
    }

    /// <summary>
    /// The format of the attribute’s data.
    /// </summary>
    public MTLAttributeFormat Format
    {
        get => (MTLAttributeFormat)ObjectiveC.MsgSendULong(NativePtr, MTLAttributeDescriptorBindings.Format);
        set => ObjectiveC.MsgSend(NativePtr, MTLAttributeDescriptorBindings.SetFormat, (nuint)value);
    }
    #endregion
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
