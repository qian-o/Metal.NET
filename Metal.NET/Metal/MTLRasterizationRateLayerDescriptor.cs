namespace Metal.NET;

public class MTLRasterizationRateLayerDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLRasterizationRateLayerDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLRasterizationRateLayerDescriptorSelector.Class))
    {
    }

    public MTLRasterizationRateSampleArray? Horizontal
    {
        get => GetNullableObject<MTLRasterizationRateSampleArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateLayerDescriptorSelector.Horizontal));
    }

    public float HorizontalSampleStorage
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLRasterizationRateLayerDescriptorSelector.HorizontalSampleStorage);
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
        get => GetNullableObject<MTLRasterizationRateSampleArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateLayerDescriptorSelector.Vertical));
    }

    public float VerticalSampleStorage
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLRasterizationRateLayerDescriptorSelector.VerticalSampleStorage);
    }
}

file static class MTLRasterizationRateLayerDescriptorSelector
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
