using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLResourceStatePassSampleBufferAttachmentDescriptorArray_Selectors
{
    internal static readonly Selector object_ = Selector.Register("object:");
    internal static readonly Selector setObject_attachmentIndex_ = Selector.Register("setObject:attachmentIndex:");
}

public class MTLResourceStatePassSampleBufferAttachmentDescriptorArray : IDisposable
{
    public nint NativePtr { get; }

    public MTLResourceStatePassSampleBufferAttachmentDescriptorArray(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLResourceStatePassSampleBufferAttachmentDescriptorArray o) => o.NativePtr;
    public static implicit operator MTLResourceStatePassSampleBufferAttachmentDescriptorArray(nint ptr) => new MTLResourceStatePassSampleBufferAttachmentDescriptorArray(ptr);

    ~MTLResourceStatePassSampleBufferAttachmentDescriptorArray() => Release();

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

    public MTLResourceStatePassSampleBufferAttachmentDescriptor Object(nuint attachmentIndex)
    {
        var __r = new MTLResourceStatePassSampleBufferAttachmentDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptorArray_Selectors.object_, (nint)attachmentIndex));
        return __r;
    }

    public void SetObject(MTLResourceStatePassSampleBufferAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptorArray_Selectors.setObject_attachmentIndex_, attachment.NativePtr, (nint)attachmentIndex);
    }

}
