namespace Metal.NET;

public class MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray>
{
    #region INativeObject
    public static new MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLAccelerationStructurePassSampleBufferAttachmentDescriptor this[nuint attachmentIndex]
    {
        get
        {
            nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArrayBindings.Object, attachmentIndex);

            return new(nativePtr, NativeObjectOwnership.Borrowed);
        }
        set
        {
            ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArrayBindings.SetObject, value.NativePtr, attachmentIndex);
        }
    }
}

file static class MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArrayBindings
{
    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
