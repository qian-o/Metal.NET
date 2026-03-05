namespace Metal.NET;

public class MTLFunctionStitchingAttributeAlwaysInline(nint nativePtr, NativeObjectOwnership ownership) : MTLFunctionStitchingAttribute(nativePtr, ownership), INativeObject<MTLFunctionStitchingAttributeAlwaysInline>
{
    #region INativeObject
    public static new MTLFunctionStitchingAttributeAlwaysInline Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFunctionStitchingAttributeAlwaysInline New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLFunctionStitchingAttributeAlwaysInline() : this(ObjectiveC.AllocInit(MTLFunctionStitchingAttributeAlwaysInlineBindings.Class), NativeObjectOwnership.Managed)
    {
    }
}

file static class MTLFunctionStitchingAttributeAlwaysInlineBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLFunctionStitchingAttributeAlwaysInline");
}
