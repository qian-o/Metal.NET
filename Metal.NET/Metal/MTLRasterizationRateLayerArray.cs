namespace Metal.NET;

public class MTLRasterizationRateLayerArray(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLRasterizationRateLayerArray>
{
    public static MTLRasterizationRateLayerArray Null { get; } = new(0, false);

    public static MTLRasterizationRateLayerArray Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLRasterizationRateLayerArray() : this(ObjectiveCRuntime.AllocInit(MTLRasterizationRateLayerArrayBindings.Class), true)
    {
        GC.ReRegisterForFinalize(this);
    }

    public MTLRasterizationRateLayerDescriptor this[nuint layerIndex]
    {
        get
        {
            nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateLayerArrayBindings.Object, layerIndex);

            return new(nativePtr, false);
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateLayerArrayBindings.SetObject, value.NativePtr, layerIndex);
        }
    }
}

file static class MTLRasterizationRateLayerArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRasterizationRateLayerArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
