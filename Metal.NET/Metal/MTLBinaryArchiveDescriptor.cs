namespace Metal.NET;

/// <summary>A description of a binary shader archive that you want to create.</summary>
public class MTLBinaryArchiveDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLBinaryArchiveDescriptor>
{
    #region INativeObject
    public static new MTLBinaryArchiveDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLBinaryArchiveDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLBinaryArchiveDescriptor() : this(ObjectiveC.AllocInit(MTLBinaryArchiveDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Choosing an archive file - Properties

    /// <summary>A URL to a Metal binary archive file.</summary>
    public NSURL Url
    {
        get => GetProperty(ref field, MTLBinaryArchiveDescriptorBindings.Url);
        set => SetProperty(ref field, MTLBinaryArchiveDescriptorBindings.SetUrl, value);
    }
    #endregion
}

file static class MTLBinaryArchiveDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLBinaryArchiveDescriptor");

    public static readonly Selector SetUrl = "setUrl:";

    public static readonly Selector Url = "url";
}
