namespace Metal.NET;

public class MTLRasterizationRateSampleArray(nint nativePtr, bool retain) : NativeObject(nativePtr, retain)
{
    public MTLRasterizationRateSampleArray() : this(ObjectiveCRuntime.AllocInit(MTLRasterizationRateSampleArrayBindings.Class), false)
    {
    }
}

file static class MTLRasterizationRateSampleArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRasterizationRateSampleArray");
}
