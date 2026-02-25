namespace Metal.NET;

public class MTLRenderPassColorAttachmentDescriptorArray(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLRenderPassColorAttachmentDescriptorArray>
{
    public static MTLRenderPassColorAttachmentDescriptorArray Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static MTLRenderPassColorAttachmentDescriptorArray Null => new(0, false);

    public MTLRenderPassColorAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLRenderPassColorAttachmentDescriptorArrayBindings.Class), true)
    {
    }

    public MTLRenderPassColorAttachmentDescriptor this[nuint attachmentIndex]
    {
        get
        {
            nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassColorAttachmentDescriptorArrayBindings.Object, attachmentIndex);

            return new(nativePtr, false);
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassColorAttachmentDescriptorArrayBindings.SetObject, value.NativePtr, attachmentIndex);
        }
    }
}

file static class MTLRenderPassColorAttachmentDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPassColorAttachmentDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
