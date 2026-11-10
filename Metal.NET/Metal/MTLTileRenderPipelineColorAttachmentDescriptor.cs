namespace Metal.NET;

public readonly struct MTLTileRenderPipelineColorAttachmentDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLTileRenderPipelineColorAttachmentDescriptor value) => new(value.NativePtr);

    public MTLTileRenderPipelineColorAttachmentDescriptor() : this(ObjectiveC.AllocInit(MTLTileRenderPipelineColorAttachmentDescriptorBindings.Class))
    {
    }

    public MTLTileRenderPipelineColorAttachmentDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLTileRenderPipelineColorAttachmentDescriptorBindings.PixelFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLTileRenderPipelineColorAttachmentDescriptorBindings.SetPixelFormat, (nuint)value);
    }
}

file static class MTLTileRenderPipelineColorAttachmentDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLTileRenderPipelineColorAttachmentDescriptor");

    public static readonly Selector PixelFormat = "pixelFormat";

    public static readonly Selector SetPixelFormat = "setPixelFormat:";
}
