namespace Metal.NET;

public class MTL4RenderPipelineColorAttachmentDescriptorArray(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4RenderPipelineColorAttachmentDescriptorArray>
{
    #region INativeObject
    public static new MTL4RenderPipelineColorAttachmentDescriptorArray Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4RenderPipelineColorAttachmentDescriptorArray New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4RenderPipelineColorAttachmentDescriptor this[nuint attachmentIndex]
    {
        get
        {
            nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorArrayBindings.Object, attachmentIndex);

            return new(nativePtr, NativeObjectOwnership.Borrowed);
        }
        set
        {
            ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorArrayBindings.SetObject, value.NativePtr, attachmentIndex);
        }
    }

    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorArrayBindings.Reset);
    }
}

file static class MTL4RenderPipelineColorAttachmentDescriptorArrayBindings
{
    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
