namespace Metal.NET;

public class MTLAccelerationStructurePassSampleBufferAttachmentDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLAccelerationStructurePassSampleBufferAttachmentDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructurePassSampleBufferAttachmentDescriptorSelector.Class))
    {
    }

    public nuint EndOfEncoderSampleIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorSelector.EndOfEncoderSampleIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorSelector.SetEndOfEncoderSampleIndex, value);
    }

    public MTLCounterSampleBuffer? SampleBuffer
    {
        get => GetNullableObject<MTLCounterSampleBuffer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorSelector.SampleBuffer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorSelector.SetSampleBuffer, value?.NativePtr ?? 0);
    }

    public nuint StartOfEncoderSampleIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorSelector.StartOfEncoderSampleIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorSelector.SetStartOfEncoderSampleIndex, value);
    }
}

file static class MTLAccelerationStructurePassSampleBufferAttachmentDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructurePassSampleBufferAttachmentDescriptor");

    public static readonly Selector EndOfEncoderSampleIndex = Selector.Register("endOfEncoderSampleIndex");

    public static readonly Selector SampleBuffer = Selector.Register("sampleBuffer");

    public static readonly Selector SetEndOfEncoderSampleIndex = Selector.Register("setEndOfEncoderSampleIndex:");

    public static readonly Selector SetSampleBuffer = Selector.Register("setSampleBuffer:");

    public static readonly Selector SetStartOfEncoderSampleIndex = Selector.Register("setStartOfEncoderSampleIndex:");

    public static readonly Selector StartOfEncoderSampleIndex = Selector.Register("startOfEncoderSampleIndex");
}
