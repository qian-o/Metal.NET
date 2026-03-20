namespace Metal.NET;

public class MTLComputePassSampleBufferAttachmentDescriptorArray(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLComputePassSampleBufferAttachmentDescriptorArray>
{
    #region INativeObject
    public static new MTLComputePassSampleBufferAttachmentDescriptorArray Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLComputePassSampleBufferAttachmentDescriptorArray New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLComputePassSampleBufferAttachmentDescriptor this[nuint attachmentIndex]
    {
        get
        {
            nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorArrayBindings.Object, attachmentIndex);

            return new(nativePtr, NativeObjectOwnership.Borrowed);
        }
        set
        {
            ObjectiveC.MsgSend(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorArrayBindings.SetObject, value.NativePtr, attachmentIndex);
        }
    }
}

file static class MTLComputePassSampleBufferAttachmentDescriptorArrayBindings
{
    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
