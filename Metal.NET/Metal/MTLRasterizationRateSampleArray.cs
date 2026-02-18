namespace Metal.NET;

public class MTLRasterizationRateSampleArray(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLRasterizationRateSampleArray() : this(ObjectiveCRuntime.AllocInit(MTLRasterizationRateSampleArraySelector.Class))
    {
    }
}

file static class MTLRasterizationRateSampleArraySelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRasterizationRateSampleArray");
}
