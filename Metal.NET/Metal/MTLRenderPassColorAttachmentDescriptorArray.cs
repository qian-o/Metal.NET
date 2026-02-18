namespace Metal.NET;

public class MTLRenderPassColorAttachmentDescriptorArray(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLRenderPassColorAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLRenderPassColorAttachmentDescriptorArraySelector.Class))
    {
    }

    public MTLRenderPassColorAttachmentDescriptor? Object(nuint attachmentIndex)
    {
        return GetNullableObject<MTLRenderPassColorAttachmentDescriptor>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassColorAttachmentDescriptorArraySelector.Object, attachmentIndex));
    }

    public void SetObject(MTLRenderPassColorAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassColorAttachmentDescriptorArraySelector.SetObject, attachment.NativePtr, attachmentIndex);
    }
}

file static class MTLRenderPassColorAttachmentDescriptorArraySelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPassColorAttachmentDescriptorArray");

    public static readonly Selector Object = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObject = Selector.Register("setObject:atIndexedSubscript:");
}
