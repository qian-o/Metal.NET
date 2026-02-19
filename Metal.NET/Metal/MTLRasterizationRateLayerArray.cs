namespace Metal.NET;

public class MTLRasterizationRateLayerArray(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public MTLRasterizationRateLayerArray() : this(ObjectiveCRuntime.AllocInit(MTLRasterizationRateLayerArrayBindings.Class), true)
    {
    }

    public MTLRasterizationRateLayerDescriptor? Object(nuint layerIndex)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateLayerArrayBindings.Object, layerIndex);

        return nativePtr is not 0 ? new(nativePtr, false) : null;
    }

    public void SetObject(MTLRasterizationRateLayerDescriptor layer, nuint layerIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateLayerArrayBindings.SetObject, layer.NativePtr, layerIndex);
    }
}

file static class MTLRasterizationRateLayerArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRasterizationRateLayerArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
