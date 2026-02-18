namespace Metal.NET;

public class MTLFunctionStitchingAttributeAlwaysInline(nint nativePtr) : MTLFunctionStitchingAttribute(nativePtr)
{
    public MTLFunctionStitchingAttributeAlwaysInline() : this(ObjectiveCRuntime.AllocInit(MTLFunctionStitchingAttributeAlwaysInlineSelector.Class))
    {
    }
}

file static class MTLFunctionStitchingAttributeAlwaysInlineSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingAttributeAlwaysInline");
}
