namespace Metal.NET;

/// <summary>
/// A configuration that instructs the GPU where to store counter data from the beginning and end of a blit pass.
/// </summary>
public class MTLBlitPassSampleBufferAttachmentDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLBlitPassSampleBufferAttachmentDescriptor>
{
    #region INativeObject
    public static new MTLBlitPassSampleBufferAttachmentDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLBlitPassSampleBufferAttachmentDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLBlitPassSampleBufferAttachmentDescriptor() : this(ObjectiveC.AllocInit(MTLBlitPassSampleBufferAttachmentDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Configuring the sample buffer attachment - Properties

    /// <summary>
    /// A specialized memory buffer that the GPU uses to store its counter data during the blit pass.
    /// </summary>
    public MTLCounterSampleBuffer SampleBuffer
    {
        get => GetProperty(ref field, MTLBlitPassSampleBufferAttachmentDescriptorBindings.SampleBuffer);
        set => SetProperty(ref field, MTLBlitPassSampleBufferAttachmentDescriptorBindings.SetSampleBuffer, value);
    }

    /// <summary>
    /// An index within a counter sample buffer that tells the GPU where to store counter data from the start of a blit pass.
    /// </summary>
    public nuint StartOfEncoderSampleIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorBindings.StartOfEncoderSampleIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorBindings.SetStartOfEncoderSampleIndex, value);
    }

    /// <summary>
    /// An index within a counter sample buffer that tells the GPU where to store counter data from the end of a blit pass.
    /// </summary>
    public nuint EndOfEncoderSampleIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorBindings.EndOfEncoderSampleIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorBindings.SetEndOfEncoderSampleIndex, value);
    }
    #endregion
}

file static class MTLBlitPassSampleBufferAttachmentDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLBlitPassSampleBufferAttachmentDescriptor");

    public static readonly Selector EndOfEncoderSampleIndex = "endOfEncoderSampleIndex";

    public static readonly Selector SampleBuffer = "sampleBuffer";

    public static readonly Selector SetEndOfEncoderSampleIndex = "setEndOfEncoderSampleIndex:";

    public static readonly Selector SetSampleBuffer = "setSampleBuffer:";

    public static readonly Selector SetStartOfEncoderSampleIndex = "setStartOfEncoderSampleIndex:";

    public static readonly Selector StartOfEncoderSampleIndex = "startOfEncoderSampleIndex";
}
