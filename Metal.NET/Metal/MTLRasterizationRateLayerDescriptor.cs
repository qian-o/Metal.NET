namespace Metal.NET;

public class MTLRasterizationRateLayerDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLRasterizationRateLayerDescriptor>
{
    #region INativeObject
    public static new MTLRasterizationRateLayerDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLRasterizationRateLayerDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLRasterizationRateLayerDescriptor() : this(ObjectiveC.AllocInit(MTLRasterizationRateLayerDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLSize SampleCount
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLRasterizationRateLayerDescriptorBindings.SampleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLRasterizationRateLayerDescriptorBindings.SetSampleCount, value);
    }

    public MTLSize MaxSampleCount
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLRasterizationRateLayerDescriptorBindings.MaxSampleCount);
    }

    public float HorizontalSampleStorage
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLRasterizationRateLayerDescriptorBindings.HorizontalSampleStorage);
    }

    public float VerticalSampleStorage
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLRasterizationRateLayerDescriptorBindings.VerticalSampleStorage);
    }

    public MTLRasterizationRateSampleArray Horizontal
    {
        get => GetProperty(ref field, MTLRasterizationRateLayerDescriptorBindings.Horizontal);
    }

    public MTLRasterizationRateSampleArray Vertical
    {
        get => GetProperty(ref field, MTLRasterizationRateLayerDescriptorBindings.Vertical);
    }

    public nint InitWithSampleCount(MTLSize sampleCount)
    {
        return ObjectiveC.MsgSendNInt(NativePtr, MTLRasterizationRateLayerDescriptorBindings.InitWithSampleCount, sampleCount);
    }

    public nint InitWithSampleCountHorizontalVertical(MTLSize sampleCount, float horizontal, float vertical)
    {
        return ObjectiveC.MsgSendNInt(NativePtr, MTLRasterizationRateLayerDescriptorBindings.InitWithSampleCounthorizontalvertical, sampleCount, horizontal, vertical);
    }
}

file static class MTLRasterizationRateLayerDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLRasterizationRateLayerDescriptor");

    public static readonly Selector Horizontal = "horizontal";

    public static readonly Selector HorizontalSampleStorage = "horizontalSampleStorage";

    public static readonly Selector InitWithSampleCount = "initWithSampleCount:";

    public static readonly Selector InitWithSampleCounthorizontalvertical = "initWithSampleCount:horizontal:vertical:";

    public static readonly Selector MaxSampleCount = "maxSampleCount";

    public static readonly Selector SampleCount = "sampleCount";

    public static readonly Selector SetSampleCount = "setSampleCount:";

    public static readonly Selector Vertical = "vertical";

    public static readonly Selector VerticalSampleStorage = "verticalSampleStorage";
}
