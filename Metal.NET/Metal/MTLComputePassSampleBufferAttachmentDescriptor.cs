namespace Metal.NET;

/// <summary>
/// A configuration that instructs the GPU where to store counter data from the beginning and end of a compute pass.
/// </summary>
public class MTLComputePassSampleBufferAttachmentDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLComputePassSampleBufferAttachmentDescriptor>
{
    #region INativeObject
    public static new MTLComputePassSampleBufferAttachmentDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLComputePassSampleBufferAttachmentDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLComputePassSampleBufferAttachmentDescriptor() : this(ObjectiveC.AllocInit(MTLComputePassSampleBufferAttachmentDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Configuring the sample buffer attachment - Properties

    /// <summary>
    /// A specialized memory buffer that the GPU uses to store its counter data during a compute pass.
    /// </summary>
    public MTLCounterSampleBuffer SampleBuffer
    {
        get => GetProperty(ref field, MTLComputePassSampleBufferAttachmentDescriptorBindings.SampleBuffer);
        set => SetProperty(ref field, MTLComputePassSampleBufferAttachmentDescriptorBindings.SetSampleBuffer, value);
    }

    /// <summary>
    /// An index within a counter sample buffer that tells the GPU where to store counter data from the start of a compute pass.
    /// </summary>
    public nuint StartOfEncoderSampleIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorBindings.StartOfEncoderSampleIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorBindings.SetStartOfEncoderSampleIndex, value);
    }

    /// <summary>
    /// An index within a counter sample buffer that tells the GPU where to store counter data from the end of a compute pass.
    /// </summary>
    public nuint EndOfEncoderSampleIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorBindings.EndOfEncoderSampleIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorBindings.SetEndOfEncoderSampleIndex, value);
    }
    #endregion
}

file static class MTLComputePassSampleBufferAttachmentDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLComputePassSampleBufferAttachmentDescriptor");

    public static readonly Selector EndOfEncoderSampleIndex = "endOfEncoderSampleIndex";

    public static readonly Selector SampleBuffer = "sampleBuffer";

    public static readonly Selector SetEndOfEncoderSampleIndex = "setEndOfEncoderSampleIndex:";

    public static readonly Selector SetSampleBuffer = "setSampleBuffer:";

    public static readonly Selector SetStartOfEncoderSampleIndex = "setStartOfEncoderSampleIndex:";

    public static readonly Selector StartOfEncoderSampleIndex = "startOfEncoderSampleIndex";
}
