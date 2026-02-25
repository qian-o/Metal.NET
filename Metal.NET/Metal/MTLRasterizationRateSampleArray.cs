namespace Metal.NET;

public class MTLRasterizationRateSampleArray(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLRasterizationRateSampleArray>
{
    public static MTLRasterizationRateSampleArray Null { get; } = new(0, false);

    public static MTLRasterizationRateSampleArray Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLRasterizationRateSampleArray() : this(ObjectiveCRuntime.AllocInit(MTLRasterizationRateSampleArrayBindings.Class), true)
    {
    }
}

file static class MTLRasterizationRateSampleArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRasterizationRateSampleArray");
}
