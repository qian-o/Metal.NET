namespace Metal.NET;

public class MTLRasterizationRateLayerDescriptor : IDisposable
{
    public MTLRasterizationRateLayerDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        var ptr = ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.MsgSendPtr(ptr, Selector.Register("init"));

        return new MTLRasterizationRateLayerDescriptor(ptr);
    }

    public void SetSampleCount(MTLSize sampleCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateLayerDescriptorSelector.SetSampleCount, sampleCount);
    }

}

file class MTLRasterizationRateLayerDescriptorSelector
{
    public static readonly Selector SetSampleCount = Selector.Register("setSampleCount:");
}
