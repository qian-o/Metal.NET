namespace Metal.NET;

public readonly struct MTLRasterizationRateLayerArray(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLRasterizationRateLayerArray value) => new(value.NativePtr);

    public MTLRasterizationRateLayerArray Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public MTLRasterizationRateLayerDescriptor this[nuint layerIndex]
    {
        get
        {
            nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRasterizationRateLayerArrayBindings.Object, layerIndex);

            return new(nativePtr);
        }
        set
        {
            ObjectiveC.MsgSend(NativePtr, MTLRasterizationRateLayerArrayBindings.SetObject, value.NativePtr, layerIndex);
        }
    }
}

file static class MTLRasterizationRateLayerArrayBindings
{
    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
