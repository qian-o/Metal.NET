namespace Metal.NET;

public class MTL4StaticLinkingDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4StaticLinkingDescriptor>
{
    #region INativeObject
    public static new MTL4StaticLinkingDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4StaticLinkingDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4StaticLinkingDescriptor() : this(ObjectiveC.AllocInit(MTL4StaticLinkingDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }
}

file static class MTL4StaticLinkingDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4StaticLinkingDescriptor");
}
