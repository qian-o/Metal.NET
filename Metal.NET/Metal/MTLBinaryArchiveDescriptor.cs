namespace Metal.NET;

public readonly struct MTLBinaryArchiveDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLBinaryArchiveDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLBinaryArchiveDescriptorBindings.Class))
    {
    }

    public NSURL? Url
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBinaryArchiveDescriptorBindings.Url);
            return ptr is not 0 ? new NSURL(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLBinaryArchiveDescriptorBindings.SetUrl, value?.NativePtr ?? 0);
    }
}

file static class MTLBinaryArchiveDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLBinaryArchiveDescriptor");

    public static readonly Selector SetUrl = Selector.Register("setUrl:");

    public static readonly Selector Url = Selector.Register("url");
}
