namespace Metal.NET;

public class MTL4RenderPipelineColorAttachmentDescriptorArray(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4RenderPipelineColorAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTL4RenderPipelineColorAttachmentDescriptorArraySelector.Class))
    {
    }

    public MTL4RenderPipelineColorAttachmentDescriptor? Object(nuint attachmentIndex)
    {
        return GetNullableObject<MTL4RenderPipelineColorAttachmentDescriptor>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorArraySelector.Object, attachmentIndex));
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
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4RenderPipelineColorAttachmentDescriptorArray");

    public static readonly Selector Object = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetObject = Selector.Register("setObject:atIndexedSubscript:");
}
