namespace Metal.NET;

public class MTLComputePassSampleBufferAttachmentDescriptorArray(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLComputePassSampleBufferAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLComputePassSampleBufferAttachmentDescriptorArraySelector.Class))
    {
    }

    public MTLComputePassSampleBufferAttachmentDescriptor? Object(nuint attachmentIndex)
    {
        return GetNullableObject<MTLComputePassSampleBufferAttachmentDescriptor>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorArraySelector.Object, attachmentIndex));
    }

    public void SetObject(MTLComputePassSampleBufferAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorArraySelector.SetObject, attachment.NativePtr, attachmentIndex);
    }
}

file static class MTLComputePassSampleBufferAttachmentDescriptorArraySelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLComputePassSampleBufferAttachmentDescriptorArray");

    public static readonly Selector Object = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObject = Selector.Register("setObject:atIndexedSubscript:");
}
