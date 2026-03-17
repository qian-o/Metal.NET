namespace Metal.NET;

/// <summary>
/// A description of where to store GPU counter information at the start and end of a render pass.
/// </summary>
public class MTLRenderPassSampleBufferAttachmentDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLRenderPassSampleBufferAttachmentDescriptor>
{
    #region INativeObject
    public static new MTLRenderPassSampleBufferAttachmentDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLRenderPassSampleBufferAttachmentDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLRenderPassSampleBufferAttachmentDescriptor() : this(ObjectiveC.AllocInit(MTLRenderPassSampleBufferAttachmentDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Configuring the sample buffer attachment - Properties

    /// <summary>
    /// A specialized memory buffer that the GPU uses to store its counter data during the render pass.
    /// </summary>
    public MTLCounterSampleBuffer SampleBuffer
    {
        get => GetProperty(ref field, MTLRenderPassSampleBufferAttachmentDescriptorBindings.SampleBuffer);
        set => SetProperty(ref field, MTLRenderPassSampleBufferAttachmentDescriptorBindings.SetSampleBuffer, value);
    }

    /// <summary>
    /// The index the Metal device object should use to store GPU counters when starting the render pass’s vertex stage.
    /// </summary>
    public nuint StartOfVertexSampleIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorBindings.StartOfVertexSampleIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorBindings.SetStartOfVertexSampleIndex, value);
    }

    /// <summary>
    /// The index the Metal device object should use to store GPU counters when ending the render pass’s vertex stage.
    /// </summary>
    public nuint EndOfVertexSampleIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorBindings.EndOfVertexSampleIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorBindings.SetEndOfVertexSampleIndex, value);
    }

    /// <summary>
    /// The index the Metal device object should use to store GPU counters when starting the render pass’s fragment stage.
    /// </summary>
    public nuint StartOfFragmentSampleIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorBindings.StartOfFragmentSampleIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorBindings.SetStartOfFragmentSampleIndex, value);
    }

    /// <summary>
    /// The index the Metal device object should use to store GPU counters when ending the render pass’s fragment stage.
    /// </summary>
    public nuint EndOfFragmentSampleIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorBindings.EndOfFragmentSampleIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorBindings.SetEndOfFragmentSampleIndex, value);
    }
    #endregion
}

file static class MTLRenderPassSampleBufferAttachmentDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLRenderPassSampleBufferAttachmentDescriptor");

    public static readonly Selector EndOfFragmentSampleIndex = "endOfFragmentSampleIndex";

    public static readonly Selector EndOfVertexSampleIndex = "endOfVertexSampleIndex";

    public static readonly Selector SampleBuffer = "sampleBuffer";

    public static readonly Selector SetEndOfFragmentSampleIndex = "setEndOfFragmentSampleIndex:";

    public static readonly Selector SetEndOfVertexSampleIndex = "setEndOfVertexSampleIndex:";

    public static readonly Selector SetSampleBuffer = "setSampleBuffer:";

    public static readonly Selector SetStartOfFragmentSampleIndex = "setStartOfFragmentSampleIndex:";

    public static readonly Selector SetStartOfVertexSampleIndex = "setStartOfVertexSampleIndex:";

    public static readonly Selector StartOfFragmentSampleIndex = "startOfFragmentSampleIndex";

    public static readonly Selector StartOfVertexSampleIndex = "startOfVertexSampleIndex";
}
