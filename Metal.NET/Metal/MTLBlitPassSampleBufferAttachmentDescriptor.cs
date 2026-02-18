namespace Metal.NET;

public partial class MTLBlitPassSampleBufferAttachmentDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLBlitPassSampleBufferAttachmentDescriptor");

    public MTLBlitPassSampleBufferAttachmentDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public nuint EndOfEncoderSampleIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorSelector.EndOfEncoderSampleIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorSelector.SetEndOfEncoderSampleIndex, value);
    }

    public MTLCounterSampleBuffer? SampleBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorSelector.SampleBuffer);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorSelector.SetSampleBuffer, value?.NativePtr ?? 0);
    }

    public nuint StartOfEncoderSampleIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorSelector.StartOfEncoderSampleIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorSelector.SetStartOfEncoderSampleIndex, value);
    }
}

file static class MTLBlitPassSampleBufferAttachmentDescriptorSelector
{
    public static readonly Selector EndOfEncoderSampleIndex = Selector.Register("endOfEncoderSampleIndex");

    public static readonly Selector SampleBuffer = Selector.Register("sampleBuffer");

    public static readonly Selector SetEndOfEncoderSampleIndex = Selector.Register("setEndOfEncoderSampleIndex:");

    public static readonly Selector SetSampleBuffer = Selector.Register("setSampleBuffer:");

    public static readonly Selector SetStartOfEncoderSampleIndex = Selector.Register("setStartOfEncoderSampleIndex:");

    public static readonly Selector StartOfEncoderSampleIndex = Selector.Register("startOfEncoderSampleIndex");
}
