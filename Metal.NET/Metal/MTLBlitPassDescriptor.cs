namespace Metal.NET;

public class MTLBlitPassDescriptor : IDisposable
{
    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLBlitPassDescriptor");

    public MTLBlitPassDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    public MTLBlitPassDescriptor() : this(ObjectiveCRuntime.AllocInit(s_class))
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
        MTLBlitPassDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(s_class, MTLBlitPassDescriptorSelector.BlitPassDescriptor));

        return result;
    }

}

file class MTLBlitPassDescriptorSelector
{
    public static readonly Selector SampleBufferAttachments = Selector.Register("sampleBufferAttachments");

    public static readonly Selector BlitPassDescriptor = Selector.Register("blitPassDescriptor");
}
