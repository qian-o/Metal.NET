namespace Metal.NET;

public class MTLRasterizationRateLayerArray : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRasterizationRateLayerArray");

    public MTLRasterizationRateLayerArray(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLRasterizationRateLayerArray() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLRasterizationRateLayerArray()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLRasterizationRateLayerDescriptor Object(nuint layerIndex)
    {
        MTLRasterizationRateLayerDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateLayerArraySelector.ObjectAtIndexedSubscript, layerIndex));

        return result;
    }

    public void SetObject(MTLRasterizationRateLayerDescriptor layer, nuint layerIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateLayerArraySelector.SetObjectAtIndexedSubscript, layer.NativePtr, layerIndex);
    }

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
}

file class MTLRasterizationRateLayerArraySelector
{
    public static readonly Selector ObjectAtIndexedSubscript = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObjectAtIndexedSubscript = Selector.Register("setObject:atIndexedSubscript:");
}
