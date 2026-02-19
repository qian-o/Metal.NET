namespace Metal.NET;

public class MTLComputePassSampleBufferAttachmentDescriptorArray(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public MTLComputePassSampleBufferAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLComputePassSampleBufferAttachmentDescriptorArrayBindings.Class), true)
    {
    }

    public MTLComputePassSampleBufferAttachmentDescriptor? Object(nuint attachmentIndex)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorArrayBindings.Object, attachmentIndex);

        return nativePtr is not 0 ? new(nativePtr, false) : null;
    }

    public void SetObject(MTLComputePassSampleBufferAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorArrayBindings.SetObject, attachment.NativePtr, attachmentIndex);
    }
}

file static class MTLComputePassSampleBufferAttachmentDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLComputePassSampleBufferAttachmentDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
