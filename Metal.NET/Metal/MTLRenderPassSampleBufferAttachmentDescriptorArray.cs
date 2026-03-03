namespace Metal.NET;

public class MTLRenderPassSampleBufferAttachmentDescriptorArray(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLRenderPassSampleBufferAttachmentDescriptorArray>
{
    public static MTLRenderPassSampleBufferAttachmentDescriptorArray Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLRenderPassSampleBufferAttachmentDescriptorArray Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLRenderPassSampleBufferAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLRenderPassSampleBufferAttachmentDescriptorArrayBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLRenderPassSampleBufferAttachmentDescriptor this[nuint attachmentIndex]
    {
        get
        {
            nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorArrayBindings.Object, attachmentIndex);

            return new(nativePtr, NativeObjectOwnership.Borrowed);
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
