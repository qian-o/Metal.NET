namespace Metal.NET;

public readonly struct MTLComputePassSampleBufferAttachmentDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLComputePassSampleBufferAttachmentDescriptor value) => new(value.NativePtr);

    public MTLComputePassSampleBufferAttachmentDescriptor() : this(ObjectiveC.AllocInit(MTLComputePassSampleBufferAttachmentDescriptorBindings.Class))
    {
    }

    public MTLComputePassSampleBufferAttachmentDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public MTLCounterSampleBuffer SampleBuffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorBindings.SampleBuffer));
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorBindings.SetSampleBuffer, value.NativePtr);
    }

    public nuint StartOfEncoderSampleIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorBindings.StartOfEncoderSampleIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorBindings.SetStartOfEncoderSampleIndex, value);
    }

    public nuint EndOfEncoderSampleIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorBindings.EndOfEncoderSampleIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorBindings.SetEndOfEncoderSampleIndex, value);
    }
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
