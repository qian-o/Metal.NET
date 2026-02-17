using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray_Selectors
{
    internal static readonly Selector object_ = Selector.Register("object:");
    internal static readonly Selector setObject_attachmentIndex_ = Selector.Register("setObject:attachmentIndex:");
}

public class MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray : IDisposable
{
    public nint NativePtr { get; }

    public MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray o) => o.NativePtr;
    public static implicit operator MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray(nint ptr) => new MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray(ptr);

    ~MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray() => Release();

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

    public MTLAccelerationStructurePassSampleBufferAttachmentDescriptor Object(nuint attachmentIndex)
    {
        var __r = new MTLAccelerationStructurePassSampleBufferAttachmentDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray_Selectors.object_, (nint)attachmentIndex));
        return __r;
    }

    public void SetObject(MTLAccelerationStructurePassSampleBufferAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray_Selectors.setObject_attachmentIndex_, attachment.NativePtr, (nint)attachmentIndex);
    }

}
