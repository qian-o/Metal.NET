using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLRenderPassColorAttachmentDescriptorArray_Selectors
{
    internal static readonly Selector object_ = Selector.Register("object:");
    internal static readonly Selector setObject_attachmentIndex_ = Selector.Register("setObject:attachmentIndex:");
}

public class MTLRenderPassColorAttachmentDescriptorArray : IDisposable
{
    public nint NativePtr { get; }

    public MTLRenderPassColorAttachmentDescriptorArray(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLRenderPassColorAttachmentDescriptorArray o) => o.NativePtr;
    public static implicit operator MTLRenderPassColorAttachmentDescriptorArray(nint ptr) => new MTLRenderPassColorAttachmentDescriptorArray(ptr);

    ~MTLRenderPassColorAttachmentDescriptorArray() => Release();

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

    public MTLRenderPassColorAttachmentDescriptor Object(nuint attachmentIndex)
    {
        var __r = new MTLRenderPassColorAttachmentDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRenderPassColorAttachmentDescriptorArray_Selectors.object_, (nint)attachmentIndex));
        return __r;
    }

    public void SetObject(MTLRenderPassColorAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassColorAttachmentDescriptorArray_Selectors.setObject_attachmentIndex_, attachment.NativePtr, (nint)attachmentIndex);
    }

}
