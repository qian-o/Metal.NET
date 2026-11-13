namespace Metal.NET;

public readonly struct MTLRasterizationRateLayerDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLRasterizationRateLayerDescriptor value) => new(value.NativePtr);

    public MTLRasterizationRateLayerDescriptor() : this(ObjectiveC.AllocInit(MTLRasterizationRateLayerDescriptorBindings.Class))
    {
    }

    public MTLRasterizationRateLayerDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
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
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRasterizationRateLayerDescriptorBindings.Horizontal));
    }

    public MTLRasterizationRateSampleArray Vertical
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRasterizationRateLayerDescriptorBindings.Vertical));
    }

    public static MTLRasterizationRateLayerDescriptor InitWithSampleCount(MTLSize sampleCount)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(MTLRasterizationRateLayerDescriptorBindings.Class), MTLRasterizationRateLayerDescriptorBindings.InitWithSampleCount, sampleCount);

        return new(nativePtr);
    }

    public static MTLRasterizationRateLayerDescriptor InitWithSampleCount(MTLSize sampleCount, float horizontal, float vertical)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(MTLRasterizationRateLayerDescriptorBindings.Class), MTLRasterizationRateLayerDescriptorBindings.InitWithSampleCount_Horizontal_Vertical, sampleCount, horizontal, vertical);

        return new(nativePtr);
    }
}

file static class MTLRasterizationRateLayerDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLRasterizationRateLayerDescriptor");

    public static readonly Selector Horizontal = "horizontal";

    public static readonly Selector HorizontalSampleStorage = "horizontalSampleStorage";

    public static readonly Selector InitWithSampleCount = "initWithSampleCount:";

    public static readonly Selector InitWithSampleCount_Horizontal_Vertical = "initWithSampleCount:horizontal:vertical:";

    public static readonly Selector MaxSampleCount = "maxSampleCount";

    public static readonly Selector SampleCount = "sampleCount";

    public static readonly Selector SetSampleCount = "setSampleCount:";

    public static readonly Selector Vertical = "vertical";

    public static readonly Selector VerticalSampleStorage = "verticalSampleStorage";
}
