using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLRenderPassSampleBufferAttachmentDescriptorArray_Selectors
{
    internal static readonly Selector object_ = Selector.Register("object:");
    internal static readonly Selector setObject_attachmentIndex_ = Selector.Register("setObject:attachmentIndex:");
}

public class MTLRenderPassSampleBufferAttachmentDescriptorArray : IDisposable
{
    public nint NativePtr { get; }

    public MTLRenderPassSampleBufferAttachmentDescriptorArray(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLRenderPassSampleBufferAttachmentDescriptorArray o) => o.NativePtr;
    public static implicit operator MTLRenderPassSampleBufferAttachmentDescriptorArray(nint ptr) => new MTLRenderPassSampleBufferAttachmentDescriptorArray(ptr);

    ~MTLRenderPassSampleBufferAttachmentDescriptorArray() => Release();

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

    public MTLRenderPassSampleBufferAttachmentDescriptor Object(nuint attachmentIndex)
    {
        var __r = new MTLRenderPassSampleBufferAttachmentDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorArray_Selectors.object_, (nint)attachmentIndex));
        return __r;
    }

    public void SetObject(MTLRenderPassSampleBufferAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorArray_Selectors.setObject_attachmentIndex_, attachment.NativePtr, (nint)attachmentIndex);
    }

}
