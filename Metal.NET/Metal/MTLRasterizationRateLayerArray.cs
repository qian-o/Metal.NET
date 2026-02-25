namespace Metal.NET;

public class MTLRasterizationRateLayerArray(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<MTLRasterizationRateLayerArray>
{
    public static MTLRasterizationRateLayerArray Create(nint nativePtr) => new(nativePtr);

    public static MTLRasterizationRateLayerArray CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public MTLRasterizationRateLayerArray() : this(ObjectiveCRuntime.AllocInit(MTLRasterizationRateLayerArrayBindings.Class))
    {
    }

    public MTLRasterizationRateLayerDescriptor Object(nuint layerIndex)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateLayerArrayBindings.Object, layerIndex);

        return new(nativePtr);
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
