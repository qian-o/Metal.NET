namespace Metal.NET;

/// <summary>
/// An object that determines how to store attribute data in memory and map it to the arguments of a vertex function.
/// </summary>
public class MTLVertexAttributeDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLVertexAttributeDescriptor>
{
    #region INativeObject
    public static new MTLVertexAttributeDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLVertexAttributeDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLVertexAttributeDescriptor() : this(ObjectiveC.AllocInit(MTLVertexAttributeDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Organizing the vertex attribute - Properties

    /// <summary>
    /// The format of the vertex attribute.
    /// </summary>
    public MTLVertexFormat Format
    {
        get => (MTLVertexFormat)ObjectiveC.MsgSendULong(NativePtr, MTLVertexAttributeDescriptorBindings.Format);
        set => ObjectiveC.MsgSend(NativePtr, MTLVertexAttributeDescriptorBindings.SetFormat, (nuint)value);
    }

    /// <summary>
    /// The location of an attribute in vertex data, determined by the byte offset from the start of the vertex data.
    /// </summary>
    public nuint Offset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLVertexAttributeDescriptorBindings.Offset);
        set => ObjectiveC.MsgSend(NativePtr, MTLVertexAttributeDescriptorBindings.SetOffset, value);
    }

    /// <summary>
    /// The index in the argument table for the associated vertex buffer.
    /// </summary>
    public nuint BufferIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLVertexAttributeDescriptorBindings.BufferIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLVertexAttributeDescriptorBindings.SetBufferIndex, value);
    }
    #endregion
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
