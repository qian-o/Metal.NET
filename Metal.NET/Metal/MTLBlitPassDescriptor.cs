namespace Metal.NET;

public readonly struct MTLBlitPassDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLBlitPassDescriptor value) => new(value.NativePtr);

    public MTLBlitPassDescriptor() : this(ObjectiveC.AllocInit(MTLBlitPassDescriptorBindings.Class))
    {
    }

    public MTLBlitPassDescriptor Retain()
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

    public MTLBlitPassSampleBufferAttachmentDescriptorArray SampleBufferAttachments
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLBlitPassDescriptorBindings.SampleBufferAttachments));
    }

    public static MTLBlitPassDescriptor BlitPassDescriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLBlitPassDescriptorBindings.Class, MTLBlitPassDescriptorBindings.BlitPassDescriptor);

        return new(nativePtr);
    }
}

file static class MTLBlitPassDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLBlitPassDescriptor");

    public static readonly Selector BlitPassDescriptor = "blitPassDescriptor";

    public static readonly Selector SampleBufferAttachments = "sampleBufferAttachments";
}
