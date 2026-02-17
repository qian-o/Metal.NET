namespace Metal.NET;

public class MTLRasterizationRateLayerArray : IDisposable
{
    public MTLRasterizationRateLayerArray(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLRasterizationRateLayerArray()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLRasterizationRateLayerArray value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRasterizationRateLayerArray(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

    public MTLRasterizationRateLayerDescriptor Object(uint layerIndex)
    {
        MTLRasterizationRateLayerDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateLayerArraySelector.Object, (nint)layerIndex));

        return result;
    }

    public void SetObject(MTLRasterizationRateLayerDescriptor layer, uint layerIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateLayerArraySelector.SetObjectLayerIndex, layer.NativePtr, (nint)layerIndex);
    }

}

file class MTLRasterizationRateLayerArraySelector
{
    public static readonly Selector Object = Selector.Register("object:");

    public static readonly Selector SetObjectLayerIndex = Selector.Register("setObject:layerIndex:");
}
