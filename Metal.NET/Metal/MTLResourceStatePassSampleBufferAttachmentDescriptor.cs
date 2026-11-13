namespace Metal.NET;

public readonly struct MTLResourceStatePassSampleBufferAttachmentDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLResourceStatePassSampleBufferAttachmentDescriptor value) => new(value.NativePtr);

    public MTLResourceStatePassSampleBufferAttachmentDescriptor() : this(ObjectiveC.AllocInit(MTLResourceStatePassSampleBufferAttachmentDescriptorBindings.Class))
    {
    }

    public MTLResourceStatePassSampleBufferAttachmentDescriptor Retain()
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
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptorBindings.SampleBuffer));
        set => ObjectiveC.MsgSend(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptorBindings.SetSampleBuffer, value.NativePtr);
    }

    public nuint StartOfEncoderSampleIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptorBindings.StartOfEncoderSampleIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptorBindings.SetStartOfEncoderSampleIndex, value);
    }

    public nuint EndOfEncoderSampleIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptorBindings.EndOfEncoderSampleIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptorBindings.SetEndOfEncoderSampleIndex, value);
    }
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
