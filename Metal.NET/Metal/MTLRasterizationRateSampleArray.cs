namespace Metal.NET;

public class MTLRasterizationRateSampleArray(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLRasterizationRateSampleArray>
{
    public static MTLRasterizationRateSampleArray Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static MTLRasterizationRateSampleArray Null => new(0, false);

    public MTLRasterizationRateSampleArray() : this(ObjectiveCRuntime.AllocInit(MTLRasterizationRateSampleArrayBindings.Class), true)
    {
    }
}

file static class MTLRasterizationRateSampleArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRasterizationRateSampleArray");
}
