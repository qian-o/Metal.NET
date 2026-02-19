namespace Metal.NET;

public readonly struct MTLRasterizationRateSampleArray(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLRasterizationRateSampleArray() : this(ObjectiveCRuntime.AllocInit(MTLRasterizationRateSampleArrayBindings.Class))
    {
    }
}

file static class MTLRasterizationRateSampleArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRasterizationRateSampleArray");
}
