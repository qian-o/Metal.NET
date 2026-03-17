namespace Metal.NET;

/// <summary>
/// An attribute to specify that Metal needs to inline all of the function calls when generating the stitched function.
/// </summary>
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
