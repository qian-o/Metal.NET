namespace Metal.NET;

public class MTLResourceStatePassSampleBufferAttachmentDescriptor : IDisposable
{
    public MTLResourceStatePassSampleBufferAttachmentDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLResourceStatePassSampleBufferAttachmentDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLResourceStatePassSampleBufferAttachmentDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLResourceStatePassSampleBufferAttachmentDescriptor(nint value)
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
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptorSelector.SetEndOfEncoderSampleIndex, (nint)endOfEncoderSampleIndex);
    }

    public void SetSampleBuffer(MTLCounterSampleBuffer sampleBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptorSelector.SetSampleBuffer, sampleBuffer.NativePtr);
    }

    public void SetStartOfEncoderSampleIndex(uint startOfEncoderSampleIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptorSelector.SetStartOfEncoderSampleIndex, (nint)startOfEncoderSampleIndex);
    }

}

file class MTLResourceStatePassSampleBufferAttachmentDescriptorSelector
{
    public static readonly Selector SetEndOfEncoderSampleIndex = Selector.Register("setEndOfEncoderSampleIndex:");

    public static readonly Selector SetSampleBuffer = Selector.Register("setSampleBuffer:");

    public static readonly Selector SetStartOfEncoderSampleIndex = Selector.Register("setStartOfEncoderSampleIndex:");
}
