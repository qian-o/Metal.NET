namespace Metal.NET;

public class MTLRasterizationRateMapDescriptor : IDisposable
{
    public MTLRasterizationRateMapDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLRasterizationRateMapDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLRasterizationRateMapDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRasterizationRateMapDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLRasterizationRateMapDescriptor");

    public static MTLRasterizationRateMapDescriptor New()
    {
        var ptr = ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.MsgSendPtr(ptr, Selector.Register("init"));

        return new MTLRasterizationRateMapDescriptor(ptr);
    }

    public MTLRasterizationRateLayerDescriptor Layer(uint layerIndex)
    {
        MTLRasterizationRateLayerDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateMapDescriptorSelector.Layer, (nint)layerIndex));

        return result;
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateMapDescriptorSelector.SetLabel, label.NativePtr);
    }

    public void SetLayer(MTLRasterizationRateLayerDescriptor layer, uint layerIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateMapDescriptorSelector.SetLayerLayerIndex, layer.NativePtr, (nint)layerIndex);
    }

    public void SetScreenSize(MTLSize screenSize)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateMapDescriptorSelector.SetScreenSize, screenSize);
    }

}

file class MTLRasterizationRateMapDescriptorSelector
{
    public static readonly Selector Layer = Selector.Register("layer:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetLayerLayerIndex = Selector.Register("setLayer:layerIndex:");

    public static readonly Selector SetScreenSize = Selector.Register("setScreenSize:");
}
