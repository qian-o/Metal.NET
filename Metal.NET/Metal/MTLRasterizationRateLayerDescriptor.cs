namespace Metal.NET;

public class MTLRasterizationRateLayerDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRasterizationRateLayerDescriptor");

    public MTLRasterizationRateLayerDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    public MTLRasterizationRateLayerDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLRasterizationRateLayerDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLRasterizationRateSampleArray Horizontal => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateLayerDescriptorSelector.Horizontal));

    public nint HorizontalSampleStorage => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateLayerDescriptorSelector.HorizontalSampleStorage);

    public MTLRasterizationRateSampleArray Vertical => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateLayerDescriptorSelector.Vertical));

    public nint VerticalSampleStorage => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateLayerDescriptorSelector.VerticalSampleStorage);

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

}

file class MTLRasterizationRateLayerDescriptorSelector
{
    public static readonly Selector Horizontal = Selector.Register("horizontal");

    public static readonly Selector HorizontalSampleStorage = Selector.Register("horizontalSampleStorage");

    public static readonly Selector MaxSampleCount = Selector.Register("maxSampleCount");

    public static readonly Selector SampleCount = Selector.Register("sampleCount");

    public static readonly Selector SetSampleCount = Selector.Register("setSampleCount:");

    public static readonly Selector Vertical = Selector.Register("vertical");

    public static readonly Selector VerticalSampleStorage = Selector.Register("verticalSampleStorage");
}
