namespace Metal.NET;

public partial class MTLRasterizationRateSampleArray : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRasterizationRateSampleArray");

    public MTLRasterizationRateSampleArray(nint nativePtr) : base(nativePtr)
    {
    }
}

file static class MTLRasterizationRateSampleArraySelector
{
}
