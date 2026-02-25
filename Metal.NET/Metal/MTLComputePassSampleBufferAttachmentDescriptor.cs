namespace Metal.NET;

public class MTLComputePassSampleBufferAttachmentDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLComputePassSampleBufferAttachmentDescriptor>
{
    public static MTLComputePassSampleBufferAttachmentDescriptor Create(nint nativePtr) => new(nativePtr, true);

    public static MTLComputePassSampleBufferAttachmentDescriptor CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public MTLComputePassSampleBufferAttachmentDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLComputePassSampleBufferAttachmentDescriptorBindings.Class), true)
    {
    }

    public nuint EndOfEncoderSampleIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorBindings.EndOfEncoderSampleIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorBindings.SetEndOfEncoderSampleIndex, value);
    }

    public MTLCounterSampleBuffer SampleBuffer
    {
        get => GetProperty(ref field, MTLComputePassSampleBufferAttachmentDescriptorBindings.SampleBuffer);
        set => SetProperty(ref field, MTLComputePassSampleBufferAttachmentDescriptorBindings.SetSampleBuffer, value);
    }

    public nuint StartOfEncoderSampleIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorBindings.StartOfEncoderSampleIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorBindings.SetStartOfEncoderSampleIndex, value);
    }
}

file static class MTLComputePassSampleBufferAttachmentDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLComputePassSampleBufferAttachmentDescriptor");

    public static readonly Selector EndOfEncoderSampleIndex = "endOfEncoderSampleIndex";

    public static readonly Selector SampleBuffer = "sampleBuffer";

    public static readonly Selector SetEndOfEncoderSampleIndex = "setEndOfEncoderSampleIndex:";

    public static readonly Selector SetSampleBuffer = "setSampleBuffer:";

    public static readonly Selector SetStartOfEncoderSampleIndex = "setStartOfEncoderSampleIndex:";

    public static readonly Selector StartOfEncoderSampleIndex = "startOfEncoderSampleIndex";
}
