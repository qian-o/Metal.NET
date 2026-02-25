namespace Metal.NET;

public class MTLRasterizationRateSampleArray(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLRasterizationRateSampleArray>
{
    public static MTLRasterizationRateSampleArray Create(nint nativePtr) => new(nativePtr, true);

    public static MTLRasterizationRateSampleArray CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public MTLRasterizationRateSampleArray() : this(ObjectiveCRuntime.AllocInit(MTLRasterizationRateSampleArrayBindings.Class), true)
    {
    }
}

file static class MTLRasterizationRateSampleArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRasterizationRateSampleArray");
}
