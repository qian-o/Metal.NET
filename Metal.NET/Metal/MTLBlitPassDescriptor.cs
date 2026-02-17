namespace Metal.NET;

public class MTLBlitPassDescriptor : IDisposable
{
    public MTLBlitPassDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLBlitPassDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLBlitPassDescriptor");

    public MTLBlitPassDescriptor() : this(ObjectiveCRuntime.MsgSendPtr(ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc")), Selector.Register("init")))
    {
    }

    public MTLBlitPassSampleBufferAttachmentDescriptorArray SampleBufferAttachments
    {
        get => new MTLBlitPassSampleBufferAttachmentDescriptorArray(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBlitPassDescriptorSelector.SampleBufferAttachments));
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
