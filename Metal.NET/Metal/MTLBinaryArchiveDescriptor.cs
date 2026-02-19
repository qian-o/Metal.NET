namespace Metal.NET;

public class MTLBinaryArchiveDescriptor(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public MTLBinaryArchiveDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLBinaryArchiveDescriptorBindings.Class), true)
    {
    }

    public NSURL? Url
    {
        get => GetProperty(ref field, MTLBinaryArchiveDescriptorBindings.Url);
        set => SetProperty(ref field, MTLBinaryArchiveDescriptorBindings.SetUrl, value);
    }
}

file static class MTLBinaryArchiveDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLBinaryArchiveDescriptor");

    public static readonly Selector SetUrl = "setUrl:";

    public static readonly Selector Url = "url";
}
