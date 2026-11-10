namespace Metal.NET;

public readonly struct MTLBlitPassSampleBufferAttachmentDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLBlitPassSampleBufferAttachmentDescriptor value) => new(value.NativePtr);

    public MTLBlitPassSampleBufferAttachmentDescriptor() : this(ObjectiveC.AllocInit(MTLBlitPassSampleBufferAttachmentDescriptorBindings.Class))
    {
    }

    public MTLBlitPassSampleBufferAttachmentDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLCounterSampleBuffer SampleBuffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorBindings.SampleBuffer));
        set => ObjectiveC.MsgSend(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorBindings.SetSampleBuffer, value.NativePtr);
    }

    public nuint StartOfEncoderSampleIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorBindings.StartOfEncoderSampleIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorBindings.SetStartOfEncoderSampleIndex, value);
    }

    public nuint EndOfEncoderSampleIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorBindings.EndOfEncoderSampleIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorBindings.SetEndOfEncoderSampleIndex, value);
    }
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
