namespace Metal.NET;

public class MTLFunctionStitchingAttributeAlwaysInline(nint nativePtr, bool ownsReference, bool allowGCRelease = false) : MTLFunctionStitchingAttribute(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLFunctionStitchingAttributeAlwaysInline>
{
    public static new MTLFunctionStitchingAttributeAlwaysInline Null { get; } = new(0, false);

    public static new MTLFunctionStitchingAttributeAlwaysInline Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLFunctionStitchingAttributeAlwaysInline() : this(ObjectiveCRuntime.AllocInit(MTLFunctionStitchingAttributeAlwaysInlineBindings.Class), true, true)
    {
    }
}

file static class MTLFunctionStitchingAttributeAlwaysInlineBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingAttributeAlwaysInline");
}
