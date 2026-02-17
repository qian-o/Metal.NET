using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLBlitPassSampleBufferAttachmentDescriptorArray_Selectors
{
    internal static readonly Selector object_ = Selector.Register("object:");
    internal static readonly Selector setObject_attachmentIndex_ = Selector.Register("setObject:attachmentIndex:");
}

public class MTLBlitPassSampleBufferAttachmentDescriptorArray : IDisposable
{
    public nint NativePtr { get; }

    public MTLBlitPassSampleBufferAttachmentDescriptorArray(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLBlitPassSampleBufferAttachmentDescriptorArray o) => o.NativePtr;
    public static implicit operator MTLBlitPassSampleBufferAttachmentDescriptorArray(nint ptr) => new MTLBlitPassSampleBufferAttachmentDescriptorArray(ptr);

    ~MTLBlitPassSampleBufferAttachmentDescriptorArray() => Release();

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

    public MTLBlitPassSampleBufferAttachmentDescriptor Object(nuint attachmentIndex)
    {
        var __r = new MTLBlitPassSampleBufferAttachmentDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorArray_Selectors.object_, (nint)attachmentIndex));
        return __r;
    }

    public void SetObject(MTLBlitPassSampleBufferAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorArray_Selectors.setObject_attachmentIndex_, attachment.NativePtr, (nint)attachmentIndex);
    }

}
