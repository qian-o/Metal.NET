namespace Metal.NET;

public class MTLRasterizationRateLayerDescriptor(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<MTLRasterizationRateLayerDescriptor>
{
    public static MTLRasterizationRateLayerDescriptor Create(nint nativePtr) => new(nativePtr);

    public static MTLRasterizationRateLayerDescriptor CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public MTLRasterizationRateLayerDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLRasterizationRateLayerDescriptorBindings.Class))
    {
    }

    public MTLRasterizationRateSampleArray Horizontal
    {
        get => GetProperty(ref field, MTLRasterizationRateLayerDescriptorBindings.Horizontal);
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

    public MTLRasterizationRateSampleArray Vertical
    {
        get => GetProperty(ref field, MTLRasterizationRateLayerDescriptorBindings.Vertical);
    }

    public float VerticalSampleStorage
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLRasterizationRateLayerDescriptorBindings.VerticalSampleStorage);
    }
}

file static class MTLRasterizationRateLayerDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRasterizationRateLayerDescriptor");

    public static readonly Selector Horizontal = "horizontal";

    public static readonly Selector HorizontalSampleStorage = "horizontalSampleStorage";

    public static readonly Selector MaxSampleCount = "maxSampleCount";

    public static readonly Selector SampleCount = "sampleCount";

    public static readonly Selector SetSampleCount = "setSampleCount:";

    public static readonly Selector Vertical = "vertical";

    public static readonly Selector VerticalSampleStorage = "verticalSampleStorage";
}
