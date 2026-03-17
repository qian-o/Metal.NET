namespace Metal.NET;

/// <summary>
/// A description of where to store GPU counter information at the start and end of a resource state pass.
/// </summary>
public class MTLResourceStatePassSampleBufferAttachmentDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLResourceStatePassSampleBufferAttachmentDescriptor>
{
    #region INativeObject
    public static new MTLResourceStatePassSampleBufferAttachmentDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLResourceStatePassSampleBufferAttachmentDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLResourceStatePassSampleBufferAttachmentDescriptor() : this(ObjectiveC.AllocInit(MTLResourceStatePassSampleBufferAttachmentDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Configuring the sample buffer attachment - Properties

    /// <summary>
    /// A specialized memory buffer that the GPU uses to store its counter data during the resource state pass.
    /// </summary>
    public MTLCounterSampleBuffer SampleBuffer
    {
        get => GetProperty(ref field, MTLResourceStatePassSampleBufferAttachmentDescriptorBindings.SampleBuffer);
        set => SetProperty(ref field, MTLResourceStatePassSampleBufferAttachmentDescriptorBindings.SetSampleBuffer, value);
    }

    /// <summary>
    /// The index the Metal device object should use to store GPU counters when starting the resource state pass.
    /// </summary>
    public nuint StartOfEncoderSampleIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptorBindings.StartOfEncoderSampleIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptorBindings.SetStartOfEncoderSampleIndex, value);
    }

    /// <summary>
    /// The index the Metal device object should use to store GPU counters when ending the resource state pass.
    /// </summary>
    public nuint EndOfEncoderSampleIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptorBindings.EndOfEncoderSampleIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptorBindings.SetEndOfEncoderSampleIndex, value);
    }
    #endregion
}

file static class MTLResourceStatePassSampleBufferAttachmentDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLResourceStatePassSampleBufferAttachmentDescriptor");

    public static readonly Selector EndOfEncoderSampleIndex = "endOfEncoderSampleIndex";

    public static readonly Selector SampleBuffer = "sampleBuffer";

    public static readonly Selector SetEndOfEncoderSampleIndex = "setEndOfEncoderSampleIndex:";

    public static readonly Selector SetSampleBuffer = "setSampleBuffer:";

    public static readonly Selector SetStartOfEncoderSampleIndex = "setStartOfEncoderSampleIndex:";

    public static readonly Selector StartOfEncoderSampleIndex = "startOfEncoderSampleIndex";
}
