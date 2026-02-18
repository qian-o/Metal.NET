namespace Metal.NET;

public class MTLComputePassSampleBufferAttachmentDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLComputePassSampleBufferAttachmentDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLComputePassSampleBufferAttachmentDescriptorSelector.Class))
    {
    }

    public nuint EndOfEncoderSampleIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorSelector.EndOfEncoderSampleIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorSelector.SetEndOfEncoderSampleIndex, value);
    }

    public MTLCounterSampleBuffer? SampleBuffer
    {
        get => GetNullableObject<MTLCounterSampleBuffer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorSelector.SampleBuffer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorSelector.SetSampleBuffer, value?.NativePtr ?? 0);
    }

    public nuint StartOfEncoderSampleIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorSelector.StartOfEncoderSampleIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorSelector.SetStartOfEncoderSampleIndex, value);
    }
}

file static class MTLComputePassSampleBufferAttachmentDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLComputePassSampleBufferAttachmentDescriptor");

    public static readonly Selector EndOfEncoderSampleIndex = Selector.Register("endOfEncoderSampleIndex");

    public static readonly Selector SampleBuffer = Selector.Register("sampleBuffer");

    public static readonly Selector SetEndOfEncoderSampleIndex = Selector.Register("setEndOfEncoderSampleIndex:");

    public static readonly Selector SetSampleBuffer = Selector.Register("setSampleBuffer:");

    public static readonly Selector SetStartOfEncoderSampleIndex = Selector.Register("setStartOfEncoderSampleIndex:");

    public static readonly Selector StartOfEncoderSampleIndex = Selector.Register("startOfEncoderSampleIndex");
}
