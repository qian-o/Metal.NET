namespace Metal.NET;

public partial class MTLIntersectionFunctionDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTLFunctionDescriptor(nativePtr, ownership), INativeObject<MTLIntersectionFunctionDescriptor>
{
    #region INativeObject
    public static new MTLIntersectionFunctionDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLIntersectionFunctionDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLIntersectionFunctionDescriptor() : this(ObjectiveC.AllocInit(MTLIntersectionFunctionDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }
}

file static class MTLIntersectionFunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLIntersectionFunctionDescriptor");
}
