namespace Metal.NET;

public class MTLRasterizationRateLayerArray(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLRasterizationRateLayerArray() : this(ObjectiveCRuntime.AllocInit(MTLRasterizationRateLayerArraySelector.Class))
    {
    }

    public MTLRasterizationRateLayerDescriptor? Object(nuint layerIndex)
    {
        return GetNullableObject<MTLRasterizationRateLayerDescriptor>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateLayerArraySelector.Object, layerIndex));
    }

    public void SetObject(MTLRasterizationRateLayerDescriptor layer, nuint layerIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateLayerArraySelector.SetObject, layer.NativePtr, layerIndex);
    }
}

file static class MTLRasterizationRateLayerArraySelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRasterizationRateLayerArray");

    public static readonly Selector Object = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObject = Selector.Register("setObject:atIndexedSubscript:");
}
