namespace Metal.NET;

public class MTLBinaryArchiveDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLBinaryArchiveDescriptor");

    public MTLBinaryArchiveDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLBinaryArchiveDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLBinaryArchiveDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public NSURL Url
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBinaryArchiveDescriptorSelector.Url));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLBinaryArchiveDescriptorSelector.SetUrl, value.NativePtr);
    }

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
}

file class MTLBinaryArchiveDescriptorSelector
{
    public static readonly Selector Url = Selector.Register("url");

    public static readonly Selector SetUrl = Selector.Register("setUrl:");
}
