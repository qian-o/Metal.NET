namespace Metal.NET;

public class MTLFunctionStitchingAttributeAlwaysInline(nint nativePtr) : MTLFunctionStitchingAttribute(nativePtr)
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingAttributeAlwaysInline");

    public MTLFunctionStitchingAttributeAlwaysInline() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    public static implicit operator nint(MTLFunctionStitchingAttributeAlwaysInline value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFunctionStitchingAttributeAlwaysInline(nint value)
    {
        return new(value);
    }
}

file class MTLFunctionStitchingAttributeAlwaysInlineSelector
{
}
