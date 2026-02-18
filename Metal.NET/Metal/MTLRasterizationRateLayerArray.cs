namespace Metal.NET;

public partial class MTLRasterizationRateLayerArray : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRasterizationRateLayerArray");

    public MTLRasterizationRateLayerArray(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLRasterizationRateLayerDescriptor? Object(nuint layerIndex)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateLayerArraySelector.Object, layerIndex);
        return ptr is not 0 ? new(ptr) : null;
    }

    public void SetObject(MTLRasterizationRateLayerDescriptor layer, nuint layerIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateLayerArraySelector.SetObject, layer.NativePtr, layerIndex);
    }
}

file static class MTLRasterizationRateLayerArraySelector
{
    public static readonly Selector Object = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObject = Selector.Register("setObject:atIndexedSubscript:");
}
