namespace Metal.NET;

public class MTLFunctionStitchingAttributeAlwaysInline(nint nativePtr, bool ownsReference) : MTLFunctionStitchingAttribute(nativePtr, ownsReference), INativeObject<MTLFunctionStitchingAttributeAlwaysInline>
{
    public static new MTLFunctionStitchingAttributeAlwaysInline Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
    public static new MTLFunctionStitchingAttributeAlwaysInline Null => Create(0, false);
    public static new MTLFunctionStitchingAttributeAlwaysInline Empty => Null;

    public MTLFunctionStitchingAttributeAlwaysInline() : this(ObjectiveCRuntime.AllocInit(MTLFunctionStitchingAttributeAlwaysInlineBindings.Class), true)
    {
    }
}

file static class MTLFunctionStitchingAttributeAlwaysInlineBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingAttributeAlwaysInline");
}
