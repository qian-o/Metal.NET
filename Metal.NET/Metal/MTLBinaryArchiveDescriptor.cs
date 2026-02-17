namespace Metal.NET;

public class MTLBinaryArchiveDescriptor : IDisposable
{
    public MTLBinaryArchiveDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLBinaryArchiveDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLBinaryArchiveDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLBinaryArchiveDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLBinaryArchiveDescriptor");

    public static MTLBinaryArchiveDescriptor New()
    {
        var ptr = ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.MsgSendPtr(ptr, Selector.Register("init"));

        return new MTLBinaryArchiveDescriptor(ptr);
    }

    public void SetUrl(NSURL url)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBinaryArchiveDescriptorSelector.SetUrl, url.NativePtr);
    }

}

file class MTLBinaryArchiveDescriptorSelector
{
    public static readonly Selector SetUrl = Selector.Register("setUrl:");
}
