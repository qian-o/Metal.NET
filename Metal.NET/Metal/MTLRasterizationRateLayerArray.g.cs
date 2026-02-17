namespace Metal.NET;

file class MTLRasterizationRateLayerArraySelector
{
    public static readonly Selector Object_ = Selector.Register("object:");
    public static readonly Selector SetObject_layerIndex_ = Selector.Register("setObject:layerIndex:");
}

public class MTLRasterizationRateLayerArray : IDisposable
{
    public MTLRasterizationRateLayerArray(nint nativePtr)
    {
        NativePtr = nativePtr;
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

    public MTLRasterizationRateLayerDescriptor Object(nuint layerIndex)
    {
        var result = new MTLRasterizationRateLayerDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRasterizationRateLayerArraySelector.Object_, (nint)layerIndex));

        return result;
    }

    public void SetObject(MTLRasterizationRateLayerDescriptor layer, nuint layerIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRasterizationRateLayerArraySelector.SetObject_layerIndex_, layer.NativePtr, (nint)layerIndex);
    }

}
