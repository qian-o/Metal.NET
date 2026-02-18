namespace Metal.NET;

public partial class MTL4RenderPipelineColorAttachmentDescriptorArray : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4RenderPipelineColorAttachmentDescriptorArray");

    public MTL4RenderPipelineColorAttachmentDescriptorArray(nint nativePtr) : base(nativePtr)
    {
    }

    public MTL4RenderPipelineColorAttachmentDescriptor? @object(nuint attachmentIndex)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorArraySelector.Object, attachmentIndex);
        return ptr is not 0 ? new(ptr) : null;
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorArraySelector.Reset);
    }

    public void SetObject(MTL4RenderPipelineColorAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorArraySelector.SetObject, attachment.NativePtr, attachmentIndex);
    }
}

file static class MTL4RenderPipelineColorAttachmentDescriptorArraySelector
{
    public static readonly Selector Object = Selector.Register("object:");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetObject = Selector.Register("setObject::");
}
