namespace Metal.NET;

public class MTLBlitPassDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLBlitPassDescriptor");

    public MTLBlitPassDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    public MTLBlitPassDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLBlitPassDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLBlitPassSampleBufferAttachmentDescriptorArray SampleBufferAttachments => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBlitPassDescriptorSelector.SampleBufferAttachments));

    public static implicit operator nint(MTLBlitPassDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLBlitPassDescriptor(nint value)
    {
        return new(value);
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

    public static MTLBlitPassDescriptor BlitPassDescriptor()
    {
        MTLBlitPassDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(Class, MTLBlitPassDescriptorSelector.BlitPassDescriptor));

        return result;
    }

}

file class MTLBlitPassDescriptorSelector
{
    public static readonly Selector SampleBufferAttachments = Selector.Register("sampleBufferAttachments");

    public static readonly Selector BlitPassDescriptor = Selector.Register("blitPassDescriptor");
}
