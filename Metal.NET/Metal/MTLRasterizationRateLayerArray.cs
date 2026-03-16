namespace Metal.NET;

/// <summary>Descriptions for the rasterization rates to apply to the set of layers in a rate map.</summary>
public class MTLRasterizationRateLayerArray(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLRasterizationRateLayerArray>
{
    #region INativeObject
    public static new MTLRasterizationRateLayerArray Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLRasterizationRateLayerArray New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLRasterizationRateLayerArray() : this(ObjectiveC.AllocInit(MTLRasterizationRateLayerArrayBindings.Class), NativeObjectOwnership.Managed)
    {
    }

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
    public static readonly nint Class = ObjectiveC.GetClass("MTLRasterizationRateLayerArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
