namespace Metal.NET;

public partial class MTLCounterSampleBufferDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLCounterSampleBufferDescriptor");

    public MTLCounterSampleBufferDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLCounterSet? CounterSet
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCounterSampleBufferDescriptorSelector.CounterSet);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCounterSampleBufferDescriptorSelector.SetCounterSet, value?.NativePtr ?? 0);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCounterSampleBufferDescriptorSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCounterSampleBufferDescriptorSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public nuint SampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLCounterSampleBufferDescriptorSelector.SampleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCounterSampleBufferDescriptorSelector.SetSampleCount, value);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLCounterSampleBufferDescriptorSelector.StorageMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCounterSampleBufferDescriptorSelector.SetStorageMode, (nuint)value);
    }
}

file static class MTLCounterSampleBufferDescriptorSelector
{
    public static readonly Selector CounterSet = Selector.Register("counterSet");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SampleCount = Selector.Register("sampleCount");

    public static readonly Selector SetCounterSet = Selector.Register("setCounterSet:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetSampleCount = Selector.Register("setSampleCount:");

    public static readonly Selector SetStorageMode = Selector.Register("setStorageMode:");

    public static readonly Selector StorageMode = Selector.Register("storageMode");
}
