namespace Metal.NET;

public class MTL4RenderPipelineColorAttachmentDescriptorArray(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTL4RenderPipelineColorAttachmentDescriptorArray>
{
    public static MTL4RenderPipelineColorAttachmentDescriptorArray Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static MTL4RenderPipelineColorAttachmentDescriptorArray Null => new(0, false);

    public MTL4RenderPipelineColorAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTL4RenderPipelineColorAttachmentDescriptorArrayBindings.Class), true)
    {
    }

    public MTL4RenderPipelineColorAttachmentDescriptor this[nuint attachmentIndex]
    {
        get
        {
            nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorArrayBindings.Object, attachmentIndex);

            return new(nativePtr, false);
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorArrayBindings.SetObject, value.NativePtr, attachmentIndex);
        }
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorArrayBindings.Reset);
    }
}

file static class MTL4RenderPipelineColorAttachmentDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4RenderPipelineColorAttachmentDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
