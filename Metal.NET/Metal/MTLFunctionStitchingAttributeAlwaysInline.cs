namespace Metal.NET;

public readonly struct MTLFunctionStitchingAttributeAlwaysInline(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLFunctionStitchingAttributeAlwaysInline() : this(ObjectiveCRuntime.AllocInit(MTLFunctionStitchingAttributeAlwaysInlineBindings.Class))
    {
    }
}

file static class MTLFunctionStitchingAttributeAlwaysInlineBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingAttributeAlwaysInline");
}
