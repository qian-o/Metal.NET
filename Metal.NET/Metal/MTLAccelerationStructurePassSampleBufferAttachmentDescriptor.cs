namespace Metal.NET;

public readonly struct MTLAccelerationStructurePassSampleBufferAttachmentDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLAccelerationStructurePassSampleBufferAttachmentDescriptor value) => new(value.NativePtr);

    public MTLAccelerationStructurePassSampleBufferAttachmentDescriptor() : this(ObjectiveC.AllocInit(MTLAccelerationStructurePassSampleBufferAttachmentDescriptorBindings.Class))
    {
    }

    public MTLAccelerationStructurePassSampleBufferAttachmentDescriptor Retain()
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
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorBindings.SampleBuffer));
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorBindings.SetSampleBuffer, value.NativePtr);
    }

    public nuint StartOfEncoderSampleIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorBindings.StartOfEncoderSampleIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorBindings.SetStartOfEncoderSampleIndex, value);
    }

    public nuint EndOfEncoderSampleIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorBindings.EndOfEncoderSampleIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorBindings.SetEndOfEncoderSampleIndex, value);
    }
}

file static class MTLAccelerationStructurePassSampleBufferAttachmentDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLAccelerationStructurePassSampleBufferAttachmentDescriptor");

    public static readonly Selector EndOfEncoderSampleIndex = "endOfEncoderSampleIndex";

    public static readonly Selector SampleBuffer = "sampleBuffer";

    public static readonly Selector SetEndOfEncoderSampleIndex = "setEndOfEncoderSampleIndex:";

    public static readonly Selector SetSampleBuffer = "setSampleBuffer:";

    public static readonly Selector SetStartOfEncoderSampleIndex = "setStartOfEncoderSampleIndex:";

    public static readonly Selector StartOfEncoderSampleIndex = "startOfEncoderSampleIndex";
}
