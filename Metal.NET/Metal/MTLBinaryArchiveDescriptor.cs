namespace Metal.NET;

public class MTLBinaryArchiveDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLBinaryArchiveDescriptor>
{
    public static MTLBinaryArchiveDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLBinaryArchiveDescriptor Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLBinaryArchiveDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLBinaryArchiveDescriptorBindings.Class), NativeObjectOwnership.Managed)
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
