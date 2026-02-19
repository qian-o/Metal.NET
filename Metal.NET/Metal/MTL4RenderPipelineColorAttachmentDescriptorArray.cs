namespace Metal.NET;

public class MTL4RenderPipelineColorAttachmentDescriptorArray(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4RenderPipelineColorAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTL4RenderPipelineColorAttachmentDescriptorArrayBindings.Class))
    {
    }

    public MTL4RenderPipelineColorAttachmentDescriptor? Object(nuint attachmentIndex)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorArrayBindings.Object, attachmentIndex);
        return ptr is not 0 ? new MTL4RenderPipelineColorAttachmentDescriptor(ptr) : null;
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorArrayBindings.Reset);
    }

    public void SetObject(MTL4RenderPipelineColorAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorArrayBindings.SetObject, attachment.NativePtr, attachmentIndex);
    }
}

file static class MTL4RenderPipelineColorAttachmentDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4RenderPipelineColorAttachmentDescriptorArray");

    public static readonly Selector Object = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetObject = Selector.Register("setObject:atIndexedSubscript:");
}
