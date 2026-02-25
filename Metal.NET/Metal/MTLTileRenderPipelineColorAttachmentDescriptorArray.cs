namespace Metal.NET;

public class MTLTileRenderPipelineColorAttachmentDescriptorArray(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLTileRenderPipelineColorAttachmentDescriptorArray>
{
    public static MTLTileRenderPipelineColorAttachmentDescriptorArray Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static MTLTileRenderPipelineColorAttachmentDescriptorArray Null => new(0, false);

    public MTLTileRenderPipelineColorAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLTileRenderPipelineColorAttachmentDescriptorArrayBindings.Class), true)
    {
    }

    public MTLTileRenderPipelineColorAttachmentDescriptor this[nuint attachmentIndex]
    {
        get
        {
            nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTileRenderPipelineColorAttachmentDescriptorArrayBindings.Object, attachmentIndex);

            return new(nativePtr, false);
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineColorAttachmentDescriptorArrayBindings.SetObject, value.NativePtr, attachmentIndex);
        }
    }
}

file static class MTLTileRenderPipelineColorAttachmentDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLTileRenderPipelineColorAttachmentDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
