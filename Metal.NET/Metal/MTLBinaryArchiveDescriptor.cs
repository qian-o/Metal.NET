namespace Metal.NET;

public class MTLBinaryArchiveDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLBinaryArchiveDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLBinaryArchiveDescriptorSelector.Class))
    {
    }

    public NSURL? Url
    {
        get => GetNullableObject<NSURL>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBinaryArchiveDescriptorSelector.Url));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLBinaryArchiveDescriptorSelector.SetUrl, value?.NativePtr ?? 0);
    }
}

file static class MTLBinaryArchiveDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLBinaryArchiveDescriptor");

    public static readonly Selector SetUrl = Selector.Register("setUrl:");

    public static readonly Selector Url = Selector.Register("url");
}
