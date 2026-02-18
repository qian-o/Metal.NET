namespace Metal.NET;

public partial class MTLBinaryArchiveDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLBinaryArchiveDescriptor");

    public MTLBinaryArchiveDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public NSURL? Url
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBinaryArchiveDescriptorSelector.Url);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLBinaryArchiveDescriptorSelector.SetUrl, value?.NativePtr ?? 0);
    }
}

file static class MTLBinaryArchiveDescriptorSelector
{
    public static readonly Selector SetUrl = Selector.Register("setUrl:");

    public static readonly Selector Url = Selector.Register("url");
}
