namespace Metal.NET;

public class MTL4RenderPipelineColorAttachmentDescriptorArray(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTL4RenderPipelineColorAttachmentDescriptorArray>
{
    public static MTL4RenderPipelineColorAttachmentDescriptorArray Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTL4RenderPipelineColorAttachmentDescriptorArray Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTL4RenderPipelineColorAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTL4RenderPipelineColorAttachmentDescriptorArrayBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTL4RenderPipelineColorAttachmentDescriptor this[nuint attachmentIndex]
    {
        get
        {
            nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorArrayBindings.Object, attachmentIndex);

            return new(nativePtr, NativeObjectOwnership.Borrowed);
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
