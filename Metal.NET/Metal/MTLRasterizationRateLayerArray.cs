namespace Metal.NET;

public readonly struct MTLRasterizationRateLayerArray(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLRasterizationRateLayerArray() : this(ObjectiveCRuntime.AllocInit(MTLRasterizationRateLayerArrayBindings.Class))
    {
    }

    public MTLRasterizationRateLayerDescriptor? Object(nuint layerIndex)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateLayerArrayBindings.Object, layerIndex);
        return ptr is not 0 ? new MTLRasterizationRateLayerDescriptor(ptr) : default;
    }

    public void SetObject(MTLRasterizationRateLayerDescriptor layer, nuint layerIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateLayerArrayBindings.SetObject, layer.NativePtr, layerIndex);
    }
}

file static class MTLRasterizationRateLayerArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRasterizationRateLayerArray");

    public static readonly Selector Object = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObject = Selector.Register("setObject:atIndexedSubscript:");
}
