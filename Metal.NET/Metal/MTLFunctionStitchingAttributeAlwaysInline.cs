namespace Metal.NET;

public class MTLFunctionStitchingAttributeAlwaysInline(nint nativePtr, bool owned) : MTLFunctionStitchingAttribute(nativePtr, owned)
{
    public MTLFunctionStitchingAttributeAlwaysInline() : this(ObjectiveCRuntime.AllocInit(MTLFunctionStitchingAttributeAlwaysInlineBindings.Class), true)
    {
    }
}

file static class MTLFunctionStitchingAttributeAlwaysInlineBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingAttributeAlwaysInline");
}
