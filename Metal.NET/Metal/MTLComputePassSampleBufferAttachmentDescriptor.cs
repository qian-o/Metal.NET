namespace Metal.NET;

public class MTLComputePassSampleBufferAttachmentDescriptor : IDisposable
{
    public MTLComputePassSampleBufferAttachmentDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLComputePassSampleBufferAttachmentDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLComputePassSampleBufferAttachmentDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLComputePassSampleBufferAttachmentDescriptor(nint value)
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
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorSelector.SetEndOfEncoderSampleIndex, (nint)endOfEncoderSampleIndex);
    }

    public void SetSampleBuffer(MTLCounterSampleBuffer sampleBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorSelector.SetSampleBuffer, sampleBuffer.NativePtr);
    }

    public void SetStartOfEncoderSampleIndex(uint startOfEncoderSampleIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorSelector.SetStartOfEncoderSampleIndex, (nint)startOfEncoderSampleIndex);
    }

}

file class MTLComputePassSampleBufferAttachmentDescriptorSelector
{
    public static readonly Selector SetEndOfEncoderSampleIndex = Selector.Register("setEndOfEncoderSampleIndex:");

    public static readonly Selector SetSampleBuffer = Selector.Register("setSampleBuffer:");

    public static readonly Selector SetStartOfEncoderSampleIndex = Selector.Register("setStartOfEncoderSampleIndex:");
}
