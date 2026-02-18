namespace Metal.NET;

public partial class MTLRasterizationRateLayerDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRasterizationRateLayerDescriptor");

    public MTLRasterizationRateLayerDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLRasterizationRateSampleArray? Horizontal
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateLayerDescriptorSelector.Horizontal);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public nint HorizontalSampleStorage
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateLayerDescriptorSelector.HorizontalSampleStorage);
    }

    public MTLSize MaxSampleCount
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLRasterizationRateLayerDescriptorSelector.MaxSampleCount);
    }

    public MTLSize SampleCount
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLRasterizationRateLayerDescriptorSelector.SampleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateLayerDescriptorSelector.SetSampleCount, value);
    }

    public MTLRasterizationRateSampleArray? Vertical
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateLayerDescriptorSelector.Vertical);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public nint VerticalSampleStorage
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateLayerDescriptorSelector.VerticalSampleStorage);
    }
}

file static class MTLRasterizationRateLayerDescriptorSelector
{
    public static readonly Selector Horizontal = Selector.Register("horizontal");

    public static readonly Selector HorizontalSampleStorage = Selector.Register("horizontalSampleStorage");

    public static readonly Selector MaxSampleCount = Selector.Register("maxSampleCount");

    public static readonly Selector SampleCount = Selector.Register("sampleCount");

    public static readonly Selector SetSampleCount = Selector.Register("setSampleCount:");

    public static readonly Selector Vertical = Selector.Register("vertical");

    public static readonly Selector VerticalSampleStorage = Selector.Register("verticalSampleStorage");
}
