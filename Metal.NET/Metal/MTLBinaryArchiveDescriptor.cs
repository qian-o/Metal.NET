namespace Metal.NET;

public class MTLBinaryArchiveDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLBinaryArchiveDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLBinaryArchiveDescriptorBindings.Class))
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
