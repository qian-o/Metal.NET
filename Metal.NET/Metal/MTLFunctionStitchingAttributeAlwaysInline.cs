namespace Metal.NET;

public class MTLFunctionStitchingAttributeAlwaysInline(nint nativePtr, bool ownsReference = true) : MTLFunctionStitchingAttribute(nativePtr, ownsReference), INativeObject<MTLFunctionStitchingAttributeAlwaysInline>
{
    public static new MTLFunctionStitchingAttributeAlwaysInline Create(nint nativePtr) => new(nativePtr);

    public static new MTLFunctionStitchingAttributeAlwaysInline CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public MTLFunctionStitchingAttributeAlwaysInline() : this(ObjectiveCRuntime.AllocInit(MTLFunctionStitchingAttributeAlwaysInlineBindings.Class))
    {
    }
}

file static class MTLFunctionStitchingAttributeAlwaysInlineBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingAttributeAlwaysInline");
}
