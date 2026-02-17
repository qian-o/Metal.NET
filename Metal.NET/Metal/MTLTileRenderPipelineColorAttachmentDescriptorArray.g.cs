using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLTileRenderPipelineColorAttachmentDescriptorArray_Selectors
{
    internal static readonly Selector object_ = Selector.Register("object:");
    internal static readonly Selector setObject_attachmentIndex_ = Selector.Register("setObject:attachmentIndex:");
}

public class MTLTileRenderPipelineColorAttachmentDescriptorArray : IDisposable
{
    public nint NativePtr { get; }

    public MTLTileRenderPipelineColorAttachmentDescriptorArray(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLTileRenderPipelineColorAttachmentDescriptorArray o) => o.NativePtr;
    public static implicit operator MTLTileRenderPipelineColorAttachmentDescriptorArray(nint ptr) => new MTLTileRenderPipelineColorAttachmentDescriptorArray(ptr);

    ~MTLTileRenderPipelineColorAttachmentDescriptorArray() => Release();

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

    public MTLTileRenderPipelineColorAttachmentDescriptor Object(nuint attachmentIndex)
    {
        var __r = new MTLTileRenderPipelineColorAttachmentDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLTileRenderPipelineColorAttachmentDescriptorArray_Selectors.object_, (nint)attachmentIndex));
        return __r;
    }

    public void SetObject(MTLTileRenderPipelineColorAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTileRenderPipelineColorAttachmentDescriptorArray_Selectors.setObject_attachmentIndex_, attachment.NativePtr, (nint)attachmentIndex);
    }

}
