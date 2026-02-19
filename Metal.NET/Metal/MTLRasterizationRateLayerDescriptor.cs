namespace Metal.NET;

public readonly struct MTLRasterizationRateLayerDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLRasterizationRateLayerDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLRasterizationRateLayerDescriptorBindings.Class))
    {
    }

    public MTLRasterizationRateSampleArray? Horizontal
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateLayerDescriptorBindings.Horizontal);
            return ptr is not 0 ? new MTLRasterizationRateSampleArray(ptr) : default;
        }
    }

    public float HorizontalSampleStorage
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLRasterizationRateLayerDescriptorBindings.HorizontalSampleStorage);
    }

    public MTLSize MaxSampleCount
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLRasterizationRateLayerDescriptorBindings.MaxSampleCount);
    }

    public MTLSize SampleCount
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLRasterizationRateLayerDescriptorBindings.SampleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateLayerDescriptorBindings.SetSampleCount, value);
    }

    public MTLRasterizationRateSampleArray? Vertical
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateLayerDescriptorBindings.Vertical);
            return ptr is not 0 ? new MTLRasterizationRateSampleArray(ptr) : default;
        }
    }

    public float VerticalSampleStorage
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLRasterizationRateLayerDescriptorBindings.VerticalSampleStorage);
    }
}

file static class MTLRasterizationRateLayerDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRasterizationRateLayerDescriptor");

    public static readonly Selector Horizontal = Selector.Register("horizontal");

    public static readonly Selector HorizontalSampleStorage = Selector.Register("horizontalSampleStorage");

    public static readonly Selector MaxSampleCount = Selector.Register("maxSampleCount");

    public static readonly Selector SampleCount = Selector.Register("sampleCount");

    public static readonly Selector SetSampleCount = Selector.Register("setSampleCount:");

    public static readonly Selector Vertical = Selector.Register("vertical");

    public static readonly Selector VerticalSampleStorage = Selector.Register("verticalSampleStorage");
}
