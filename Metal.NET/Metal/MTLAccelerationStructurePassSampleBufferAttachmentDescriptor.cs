namespace Metal.NET;

public class MTLAccelerationStructurePassSampleBufferAttachmentDescriptor : IDisposable
{
    public MTLAccelerationStructurePassSampleBufferAttachmentDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLAccelerationStructurePassSampleBufferAttachmentDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLAccelerationStructurePassSampleBufferAttachmentDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLAccelerationStructurePassSampleBufferAttachmentDescriptor(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

    public void SetEndOfEncoderSampleIndex(uint endOfEncoderSampleIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorSelector.SetEndOfEncoderSampleIndex, (nint)endOfEncoderSampleIndex);
    }

    public void SetSampleBuffer(MTLCounterSampleBuffer sampleBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorSelector.SetSampleBuffer, sampleBuffer.NativePtr);
    }

    public void SetStartOfEncoderSampleIndex(uint startOfEncoderSampleIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorSelector.SetStartOfEncoderSampleIndex, (nint)startOfEncoderSampleIndex);
    }

}

file class MTLAccelerationStructurePassSampleBufferAttachmentDescriptorSelector
{
    public static readonly Selector SetEndOfEncoderSampleIndex = Selector.Register("setEndOfEncoderSampleIndex:");

    public static readonly Selector SetSampleBuffer = Selector.Register("setSampleBuffer:");

    public static readonly Selector SetStartOfEncoderSampleIndex = Selector.Register("setStartOfEncoderSampleIndex:");
}
