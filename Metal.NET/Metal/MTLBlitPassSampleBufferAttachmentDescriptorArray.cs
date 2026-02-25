namespace Metal.NET;

public class MTLBlitPassSampleBufferAttachmentDescriptorArray(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLBlitPassSampleBufferAttachmentDescriptorArray>
{
    public static MTLBlitPassSampleBufferAttachmentDescriptorArray Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static MTLBlitPassSampleBufferAttachmentDescriptorArray Null => new(0, false);

    public MTLBlitPassSampleBufferAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLBlitPassSampleBufferAttachmentDescriptorArrayBindings.Class), true)
    {
    }

    public MTLBlitPassSampleBufferAttachmentDescriptor this[nuint attachmentIndex]
    {
        get
        {
            nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorArrayBindings.Object, attachmentIndex);

            return new(nativePtr, false);
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorArrayBindings.SetObject, value.NativePtr, attachmentIndex);
        }
    }
}

file static class MTLBlitPassSampleBufferAttachmentDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLBlitPassSampleBufferAttachmentDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
