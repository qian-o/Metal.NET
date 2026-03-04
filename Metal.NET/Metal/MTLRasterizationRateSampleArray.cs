namespace Metal.NET;

public class MTLRasterizationRateSampleArray(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLRasterizationRateSampleArray>
{
    public static MTLRasterizationRateSampleArray Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLRasterizationRateSampleArray Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLRasterizationRateSampleArray() : this(ObjectiveC.AllocInit(MTLRasterizationRateSampleArrayBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public NSNumber this[nuint index]
    {
        get
        {
            nint nativePtr = ObjectiveC.MsgSendPtr(NativePtr, MTLRasterizationRateSampleArrayBindings.Object, index);

            return new(nativePtr, NativeObjectOwnership.Borrowed);
        }
        set
        {
            ObjectiveC.MsgSend(NativePtr, MTLRasterizationRateSampleArrayBindings.SetObject, value.NativePtr, index);
        }
    }
}

file static class MTLRasterizationRateSampleArrayBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLRasterizationRateSampleArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
