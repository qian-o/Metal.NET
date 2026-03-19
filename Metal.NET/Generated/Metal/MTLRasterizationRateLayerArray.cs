namespace Metal.NET;

public partial class MTLRasterizationRateLayerArray(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLRasterizationRateLayerArray>
{
    #region INativeObject
    public static new MTLRasterizationRateLayerArray Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLRasterizationRateLayerArray New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLRasterizationRateLayerDescriptor this[nuint layerIndex]
    {
        get
        {
            nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRasterizationRateLayerArrayBindings.Object, layerIndex);

            return new(nativePtr, NativeObjectOwnership.Borrowed);
        }
        set
        {
            ObjectiveC.MsgSend(NativePtr, MTLRasterizationRateLayerArrayBindings.SetObject, value.NativePtr, layerIndex);
        }
    }
}

file static class MTLRasterizationRateLayerArrayBindings
{
    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
