namespace Metal.NET;

public class MTLAccelerationStructurePassSampleBufferAttachmentDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLAccelerationStructurePassSampleBufferAttachmentDescriptor>
{
    public static MTLAccelerationStructurePassSampleBufferAttachmentDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static MTLAccelerationStructurePassSampleBufferAttachmentDescriptor Null => new(0, false);

    public MTLAccelerationStructurePassSampleBufferAttachmentDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructurePassSampleBufferAttachmentDescriptorBindings.Class), true)
    {
    }

    public nuint EndOfEncoderSampleIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorBindings.EndOfEncoderSampleIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorBindings.SetEndOfEncoderSampleIndex, value);
    }

    public MTLCounterSampleBuffer SampleBuffer
    {
        get => GetProperty(ref field, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorBindings.SampleBuffer);
        set => SetProperty(ref field, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorBindings.SetSampleBuffer, value);
    }

    public nuint StartOfEncoderSampleIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorBindings.StartOfEncoderSampleIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorBindings.SetStartOfEncoderSampleIndex, value);
    }
}

file static class MTLAccelerationStructurePassSampleBufferAttachmentDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructurePassSampleBufferAttachmentDescriptor");

    public static readonly Selector EndOfEncoderSampleIndex = "endOfEncoderSampleIndex";

    public static readonly Selector SampleBuffer = "sampleBuffer";

    public static readonly Selector SetEndOfEncoderSampleIndex = "setEndOfEncoderSampleIndex:";

    public static readonly Selector SetSampleBuffer = "setSampleBuffer:";

    public static readonly Selector SetStartOfEncoderSampleIndex = "setStartOfEncoderSampleIndex:";

    public static readonly Selector StartOfEncoderSampleIndex = "startOfEncoderSampleIndex";
}
