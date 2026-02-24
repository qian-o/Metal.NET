namespace Metal.NET;

public class MTLRasterizationRateSampleArray(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTLRasterizationRateSampleArray>
{
    public static MTLRasterizationRateSampleArray Create(nint nativePtr) => new(nativePtr);
    public MTLRasterizationRateSampleArray() : this(ObjectiveCRuntime.AllocInit(MTLRasterizationRateSampleArrayBindings.Class))
    {
    }
}

file static class MTLRasterizationRateSampleArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRasterizationRateSampleArray");
}
