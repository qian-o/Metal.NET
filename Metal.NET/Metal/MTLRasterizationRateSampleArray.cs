namespace Metal.NET;

public class MTLRasterizationRateSampleArray(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<MTLRasterizationRateSampleArray>
{
    public static MTLRasterizationRateSampleArray Create(nint nativePtr) => new(nativePtr);

    public static MTLRasterizationRateSampleArray CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public MTLRasterizationRateSampleArray() : this(ObjectiveCRuntime.AllocInit(MTLRasterizationRateSampleArrayBindings.Class))
    {
    }
}

file static class MTLRasterizationRateSampleArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRasterizationRateSampleArray");
}
