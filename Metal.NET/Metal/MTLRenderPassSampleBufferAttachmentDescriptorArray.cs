namespace Metal.NET;

public class MTLRenderPassSampleBufferAttachmentDescriptorArray(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLRenderPassSampleBufferAttachmentDescriptorArray>
{
    public static MTLRenderPassSampleBufferAttachmentDescriptorArray Null { get; } = new(0, false);

    public static MTLRenderPassSampleBufferAttachmentDescriptorArray Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLRenderPassSampleBufferAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLRenderPassSampleBufferAttachmentDescriptorArrayBindings.Class), true)
    {
        GC.ReRegisterForFinalize(this);
    }

    public MTLRenderPassSampleBufferAttachmentDescriptor this[nuint attachmentIndex]
    {
        get
        {
            nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorArrayBindings.Object, attachmentIndex);

            return new(nativePtr, false);
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorArrayBindings.SetObject, value.NativePtr, attachmentIndex);
        }
    }
}

file static class MTLRenderPassSampleBufferAttachmentDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPassSampleBufferAttachmentDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
