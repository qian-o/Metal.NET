namespace Metal.NET;

public class MTLRenderPassSampleBufferAttachmentDescriptorArray(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLRenderPassSampleBufferAttachmentDescriptorArray>
{
    #region INativeObject
    public static new MTLRenderPassSampleBufferAttachmentDescriptorArray Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLRenderPassSampleBufferAttachmentDescriptorArray New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLRenderPassSampleBufferAttachmentDescriptorArray() : this(ObjectiveC.AllocInit(MTLRenderPassSampleBufferAttachmentDescriptorArrayBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLRenderPassSampleBufferAttachmentDescriptor this[nuint attachmentIndex]
    {
        get
        {
            nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorArrayBindings.Object, attachmentIndex);

            return new(nativePtr, NativeObjectOwnership.Borrowed);
        }
        set
        {
            ObjectiveC.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorArrayBindings.SetObject, value.NativePtr, attachmentIndex);
        }
    }
}

file static class MTLRenderPassSampleBufferAttachmentDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLRenderPassSampleBufferAttachmentDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
