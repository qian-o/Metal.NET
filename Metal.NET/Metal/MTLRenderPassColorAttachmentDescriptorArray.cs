namespace Metal.NET;

public class MTLRenderPassColorAttachmentDescriptorArray(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLRenderPassColorAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLRenderPassColorAttachmentDescriptorArrayBindings.Class))
    {
    }

    public MTLRenderPassColorAttachmentDescriptor? Object(nuint attachmentIndex)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassColorAttachmentDescriptorArrayBindings.Object, attachmentIndex);

        return nativePtr is not 0 ? new(nativePtr) : null;
    }

    public void SetObject(MTLRenderPassColorAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassColorAttachmentDescriptorArrayBindings.SetObject, attachment.NativePtr, attachmentIndex);
    }
}

file static class MTLRenderPassColorAttachmentDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPassColorAttachmentDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
