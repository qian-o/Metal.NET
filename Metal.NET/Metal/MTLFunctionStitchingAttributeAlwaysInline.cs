namespace Metal.NET;

public class MTLFunctionStitchingAttributeAlwaysInline(nint nativePtr, bool ownsReference) : MTLFunctionStitchingAttribute(nativePtr, ownsReference), INativeObject<MTLFunctionStitchingAttributeAlwaysInline>
{
    public static new MTLFunctionStitchingAttributeAlwaysInline Create(nint nativePtr) => new(nativePtr, true);

    public static new MTLFunctionStitchingAttributeAlwaysInline CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public MTLFunctionStitchingAttributeAlwaysInline() : this(ObjectiveCRuntime.AllocInit(MTLFunctionStitchingAttributeAlwaysInlineBindings.Class), true)
    {
    }
}

file static class MTLFunctionStitchingAttributeAlwaysInlineBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingAttributeAlwaysInline");
}
