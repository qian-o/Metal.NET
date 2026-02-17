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

    public MTLBinaryArchiveDescriptor() : this(ObjectiveCRuntime.MsgSendPtr(ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc")), Selector.Register("init")))
    {
    }

    public NSURL Url
    {
        get => new NSURL(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBinaryArchiveDescriptorSelector.Url));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLBinaryArchiveDescriptorSelector.SetUrl, value.NativePtr);
    }

}

file class MTLBinaryArchiveDescriptorSelector
{
    public static readonly Selector Url = Selector.Register("url");

    public static readonly Selector SetUrl = Selector.Register("setUrl:");
}
