using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4RenderPipelineColorAttachmentDescriptorArray_Selectors
{
    internal static readonly Selector object_ = Selector.Register("object:");
    internal static readonly Selector reset = Selector.Register("reset");
    internal static readonly Selector setObject_attachmentIndex_ = Selector.Register("setObject:attachmentIndex:");
}

public class MTL4RenderPipelineColorAttachmentDescriptorArray : IDisposable
{
    public nint NativePtr { get; }

    public MTL4RenderPipelineColorAttachmentDescriptorArray(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4RenderPipelineColorAttachmentDescriptorArray o) => o.NativePtr;
    public static implicit operator MTL4RenderPipelineColorAttachmentDescriptorArray(nint ptr) => new MTL4RenderPipelineColorAttachmentDescriptorArray(ptr);

    ~MTL4RenderPipelineColorAttachmentDescriptorArray() => Release();

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

    public MTL4RenderPipelineColorAttachmentDescriptor Object(nuint attachmentIndex)
    {
        var __r = new MTL4RenderPipelineColorAttachmentDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorArray_Selectors.object_, (nint)attachmentIndex));
        return __r;
    }

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorArray_Selectors.reset);
    }

    public void SetObject(MTL4RenderPipelineColorAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorArray_Selectors.setObject_attachmentIndex_, attachment.NativePtr, (nint)attachmentIndex);
    }

}
