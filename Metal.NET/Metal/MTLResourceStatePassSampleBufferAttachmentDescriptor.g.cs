using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLResourceStatePassSampleBufferAttachmentDescriptor_Selectors
{
    internal static readonly Selector setEndOfEncoderSampleIndex_ = Selector.Register("setEndOfEncoderSampleIndex:");
    internal static readonly Selector setSampleBuffer_ = Selector.Register("setSampleBuffer:");
    internal static readonly Selector setStartOfEncoderSampleIndex_ = Selector.Register("setStartOfEncoderSampleIndex:");
}

public class MTLResourceStatePassSampleBufferAttachmentDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLResourceStatePassSampleBufferAttachmentDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLResourceStatePassSampleBufferAttachmentDescriptor o) => o.NativePtr;
    public static implicit operator MTLResourceStatePassSampleBufferAttachmentDescriptor(nint ptr) => new MTLResourceStatePassSampleBufferAttachmentDescriptor(ptr);

    ~MTLResourceStatePassSampleBufferAttachmentDescriptor() => Release();

    public void Dispose()
    {
        Release();
        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr != 0)
            ObjectiveCRuntime.Release(NativePtr);
    }

    public void SetEndOfEncoderSampleIndex(nuint endOfEncoderSampleIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptor_Selectors.setEndOfEncoderSampleIndex_, (nint)endOfEncoderSampleIndex);
    }

    public void SetSampleBuffer(MTLCounterSampleBuffer sampleBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptor_Selectors.setSampleBuffer_, sampleBuffer.NativePtr);
    }

    public void SetStartOfEncoderSampleIndex(nuint startOfEncoderSampleIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptor_Selectors.setStartOfEncoderSampleIndex_, (nint)startOfEncoderSampleIndex);
    }

}
