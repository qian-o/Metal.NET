namespace Metal.NET;

public class MTLFunctionStitchingAttributeAlwaysInline(nint nativePtr, bool ownsReference) : MTLFunctionStitchingAttribute(nativePtr, ownsReference), INativeObject<MTLFunctionStitchingAttributeAlwaysInline>
{
    public static new MTLFunctionStitchingAttributeAlwaysInline Null { get; } = new(0, false);

    public static new MTLFunctionStitchingAttributeAlwaysInline Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLFunctionStitchingAttributeAlwaysInline() : this(ObjectiveCRuntime.AllocInit(MTLFunctionStitchingAttributeAlwaysInlineBindings.Class), true)
    {
        GC.ReRegisterForFinalize(this);
    }
}

file static class MTLFunctionStitchingAttributeAlwaysInlineBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingAttributeAlwaysInline");
}
