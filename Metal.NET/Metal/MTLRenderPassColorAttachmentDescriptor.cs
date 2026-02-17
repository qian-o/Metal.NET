namespace Metal.NET;

public class MTLRenderPassColorAttachmentDescriptor : IDisposable
{
    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLRenderPassColorAttachmentDescriptor");

    public MTLRenderPassColorAttachmentDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    public MTLRenderPassColorAttachmentDescriptor() : this(ObjectiveCRuntime.AllocInit(s_class))
    {
    }

    ~MTLRenderPassColorAttachmentDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLRenderPassColorAttachmentDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRenderPassColorAttachmentDescriptor(nint value)
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

}

file class MTLRenderPassColorAttachmentDescriptorSelector
{
    public static readonly Selector ClearColor = Selector.Register("clearColor");

    public static readonly Selector SetClearColor = Selector.Register("setClearColor:");
}
