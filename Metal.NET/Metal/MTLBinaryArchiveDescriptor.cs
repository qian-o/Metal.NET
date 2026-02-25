namespace Metal.NET;

public class MTLBinaryArchiveDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLBinaryArchiveDescriptor>
{
    public static MTLBinaryArchiveDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static MTLBinaryArchiveDescriptor Null => new(0, false);

    public MTLBinaryArchiveDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLBinaryArchiveDescriptorBindings.Class), true)
    {
    }

    public NSURL Url
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
