namespace Metal.NET;

public class MTLCounterSampleBufferDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLCounterSampleBufferDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLCounterSampleBufferDescriptorBindings.Class))
    {
    }

    public MTLCounterSet? CounterSet
    {
        get => GetProperty<MTLCounterSet>(ref field, MTLCounterSampleBufferDescriptorBindings.CounterSet);
        set => SetProperty(ref field, MTLCounterSampleBufferDescriptorBindings.SetCounterSet, value);
    }

    public NSString? Label
    {
        get => GetProperty<NSString>(ref field, MTLCounterSampleBufferDescriptorBindings.Label);
        set => SetProperty(ref field, MTLCounterSampleBufferDescriptorBindings.SetLabel, value);
    }

    public nuint SampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLCounterSampleBufferDescriptorBindings.SampleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCounterSampleBufferDescriptorBindings.SetSampleCount, value);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLCounterSampleBufferDescriptorBindings.StorageMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCounterSampleBufferDescriptorBindings.SetStorageMode, (nuint)value);
    }
}

file static class MTLCounterSampleBufferDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLCounterSampleBufferDescriptor");

    public static readonly Selector CounterSet = "counterSet";

    public static readonly Selector Label = "label";

    public static readonly Selector SampleCount = "sampleCount";

    public static readonly Selector SetCounterSet = "setCounterSet:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetSampleCount = "setSampleCount:";

    public static readonly Selector SetStorageMode = "setStorageMode:";

    public static readonly Selector StorageMode = "storageMode";
}
