using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLRenderPipelineColorAttachmentDescriptorArray_Selectors
{
    internal static readonly Selector object_ = Selector.Register("object:");
    internal static readonly Selector setObject_attachmentIndex_ = Selector.Register("setObject:attachmentIndex:");
}

public class MTLRenderPipelineColorAttachmentDescriptorArray : IDisposable
{
    public nint NativePtr { get; }

    public MTLRenderPipelineColorAttachmentDescriptorArray(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLRenderPipelineColorAttachmentDescriptorArray o) => o.NativePtr;
    public static implicit operator MTLRenderPipelineColorAttachmentDescriptorArray(nint ptr) => new MTLRenderPipelineColorAttachmentDescriptorArray(ptr);

    ~MTLRenderPipelineColorAttachmentDescriptorArray() => Release();

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

    public MTLRenderPipelineColorAttachmentDescriptor Object(nuint attachmentIndex)
    {
        var __r = new MTLRenderPipelineColorAttachmentDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorArray_Selectors.object_, (nint)attachmentIndex));
        return __r;
    }

    public void SetObject(MTLRenderPipelineColorAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorArray_Selectors.setObject_attachmentIndex_, attachment.NativePtr, (nint)attachmentIndex);
    }

}
