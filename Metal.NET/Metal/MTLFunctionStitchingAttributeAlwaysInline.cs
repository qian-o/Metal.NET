namespace Metal.NET;

public class MTLFunctionStitchingAttributeAlwaysInline(nint nativePtr) : MTLFunctionStitchingAttribute(nativePtr), INativeObject<MTLFunctionStitchingAttributeAlwaysInline>
{
    public static MTLFunctionStitchingAttributeAlwaysInline Create(nint nativePtr) => new(nativePtr);
    public MTLFunctionStitchingAttributeAlwaysInline() : this(ObjectiveCRuntime.AllocInit(MTLFunctionStitchingAttributeAlwaysInlineBindings.Class))
    {
    }
}

file static class MTLFunctionStitchingAttributeAlwaysInlineBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingAttributeAlwaysInline");
}
