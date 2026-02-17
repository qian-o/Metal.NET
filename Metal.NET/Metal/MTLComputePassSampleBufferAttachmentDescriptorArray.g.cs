using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLComputePassSampleBufferAttachmentDescriptorArray_Selectors
{
    internal static readonly Selector object_ = Selector.Register("object:");
    internal static readonly Selector setObject_attachmentIndex_ = Selector.Register("setObject:attachmentIndex:");
}

public class MTLComputePassSampleBufferAttachmentDescriptorArray : IDisposable
{
    public nint NativePtr { get; }

    public MTLComputePassSampleBufferAttachmentDescriptorArray(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLComputePassSampleBufferAttachmentDescriptorArray o) => o.NativePtr;
    public static implicit operator MTLComputePassSampleBufferAttachmentDescriptorArray(nint ptr) => new MTLComputePassSampleBufferAttachmentDescriptorArray(ptr);

    ~MTLComputePassSampleBufferAttachmentDescriptorArray() => Release();

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

    public MTLComputePassSampleBufferAttachmentDescriptor Object(nuint attachmentIndex)
    {
        var __r = new MTLComputePassSampleBufferAttachmentDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorArray_Selectors.object_, (nint)attachmentIndex));
        return __r;
    }

    public void SetObject(MTLComputePassSampleBufferAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorArray_Selectors.setObject_attachmentIndex_, attachment.NativePtr, (nint)attachmentIndex);
    }

}
