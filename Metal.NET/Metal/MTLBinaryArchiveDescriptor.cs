namespace Metal.NET;

public class MTLBinaryArchiveDescriptor(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTLBinaryArchiveDescriptor>
{
    #region INativeObject
    public static MTLBinaryArchiveDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLBinaryArchiveDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLBinaryArchiveDescriptor() : this(ObjectiveC.AllocInit(MTLBinaryArchiveDescriptorBindings.Class), NativeObjectOwnership.Managed)
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
    public static readonly nint Class = ObjectiveC.GetClass("MTLBinaryArchiveDescriptor");

    public static readonly Selector SetUrl = "setUrl:";

    public static readonly Selector Url = "url";
}
