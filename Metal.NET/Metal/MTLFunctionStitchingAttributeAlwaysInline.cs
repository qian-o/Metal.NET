namespace Metal.NET;

public class MTLFunctionStitchingAttributeAlwaysInline(nint nativePtr, NativeObjectOwnership ownership) : MTLFunctionStitchingAttribute(nativePtr, ownership), INativeObject<MTLFunctionStitchingAttributeAlwaysInline>
{
    public static new MTLFunctionStitchingAttributeAlwaysInline Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFunctionStitchingAttributeAlwaysInline Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLFunctionStitchingAttributeAlwaysInline() : this(ObjectiveCRuntime.AllocInit(MTLFunctionStitchingAttributeAlwaysInlineBindings.Class), NativeObjectOwnership.Managed)
    {
    }
}

file static class MTLFunctionStitchingAttributeAlwaysInlineBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingAttributeAlwaysInline");
}
