namespace Metal.NET;

public class MTLRasterizationRateSampleArray(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public MTLRasterizationRateSampleArray() : this(ObjectiveCRuntime.AllocInit(MTLRasterizationRateSampleArrayBindings.Class), true)
    {
    }
}

file static class MTLRasterizationRateSampleArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRasterizationRateSampleArray");
}
