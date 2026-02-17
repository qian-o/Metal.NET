namespace Metal.NET;

file class MTLRasterizationRateLayerDescriptorSelector
{
    public static readonly Selector SetSampleCount_ = Selector.Register("setSampleCount:");
}

public class MTLRasterizationRateLayerDescriptor : IDisposable
{
    public MTLRasterizationRateLayerDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLRasterizationRateLayerDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLRasterizationRateLayerDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRasterizationRateLayerDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLRasterizationRateLayerDescriptor");

    public static MTLRasterizationRateLayerDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLRasterizationRateLayerDescriptor(ptr);
    }

    public void SetSampleCount(MTLSize sampleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRasterizationRateLayerDescriptorSelector.SetSampleCount_, sampleCount);
    }

}
