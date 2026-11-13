namespace Metal.NET;

public readonly struct MTLTileRenderPipelineColorAttachmentDescriptorArray(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLTileRenderPipelineColorAttachmentDescriptorArray value) => new(value.NativePtr);

    public MTLTileRenderPipelineColorAttachmentDescriptorArray Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public MTLTileRenderPipelineColorAttachmentDescriptor this[nuint attachmentIndex]
    {
        get
        {
            nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLTileRenderPipelineColorAttachmentDescriptorArrayBindings.Object, attachmentIndex);

            return new(nativePtr);
        }
        set
        {
            ObjectiveC.MsgSend(NativePtr, MTLTileRenderPipelineColorAttachmentDescriptorArrayBindings.SetObject, value.NativePtr, attachmentIndex);
        }
    }
}

file static class MTLTileRenderPipelineColorAttachmentDescriptorArrayBindings
{
    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
