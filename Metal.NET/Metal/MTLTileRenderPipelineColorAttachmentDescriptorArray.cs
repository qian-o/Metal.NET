namespace Metal.NET;

public class MTLTileRenderPipelineColorAttachmentDescriptorArray : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLTileRenderPipelineColorAttachmentDescriptorArray");

    public MTLTileRenderPipelineColorAttachmentDescriptorArray(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLTileRenderPipelineColorAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLTileRenderPipelineColorAttachmentDescriptorArray()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLTileRenderPipelineColorAttachmentDescriptorArray value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLTileRenderPipelineColorAttachmentDescriptorArray(nint value)
    {
        return new(value);
    }

    public MTLTileRenderPipelineColorAttachmentDescriptor Object(nuint attachmentIndex)
    {
        MTLTileRenderPipelineColorAttachmentDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTileRenderPipelineColorAttachmentDescriptorArraySelector.ObjectAtIndexedSubscript, attachmentIndex));

        return result;
    }

    public void SetObject(MTLTileRenderPipelineColorAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineColorAttachmentDescriptorArraySelector.SetObjectAtIndexedSubscript, attachment.NativePtr, attachmentIndex);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTLTileRenderPipelineColorAttachmentDescriptorArraySelector
{
    public static readonly Selector ObjectAtIndexedSubscript = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObjectAtIndexedSubscript = Selector.Register("setObject:atIndexedSubscript:");
}
