namespace Metal.NET;

file class MTLRasterizationRateMapDescriptorSelector
{
    public static readonly Selector Layer_ = Selector.Register("layer:");
    public static readonly Selector SetLabel_ = Selector.Register("setLabel:");
    public static readonly Selector SetLayer_layerIndex_ = Selector.Register("setLayer:layerIndex:");
    public static readonly Selector SetScreenSize_ = Selector.Register("setScreenSize:");
}

public class MTLRasterizationRateMapDescriptor : IDisposable
{
    public MTLRasterizationRateMapDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLRasterizationRateMapDescriptor(ptr);
    }

    public MTLRasterizationRateLayerDescriptor Layer(nuint layerIndex)
    {
        var result = new MTLRasterizationRateLayerDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRasterizationRateMapDescriptorSelector.Layer_, (nint)layerIndex));

        return result;
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRasterizationRateMapDescriptorSelector.SetLabel_, label.NativePtr);
    }

    public void SetLayer(MTLRasterizationRateLayerDescriptor layer, nuint layerIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRasterizationRateMapDescriptorSelector.SetLayer_layerIndex_, layer.NativePtr, (nint)layerIndex);
    }

    public void SetScreenSize(MTLSize screenSize)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRasterizationRateMapDescriptorSelector.SetScreenSize_, screenSize);
    }

}
