namespace Metal.NET;

public partial class MTLRasterizationRateSampleArray(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLRasterizationRateSampleArray>
{
    #region INativeObject
    public static new MTLRasterizationRateSampleArray Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLRasterizationRateSampleArray New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSNumber this[nuint index]
    {
        get
        {
            nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRasterizationRateSampleArrayBindings.Object, index);

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
    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
