namespace Metal.NET;

public readonly struct MTLCounterSampleBufferDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLCounterSampleBufferDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLCounterSampleBufferDescriptorBindings.Class))
    {
    }

    public MTLCounterSet? CounterSet
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCounterSampleBufferDescriptorBindings.CounterSet);
            return ptr is not 0 ? new MTLCounterSet(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCounterSampleBufferDescriptorBindings.SetCounterSet, value?.NativePtr ?? 0);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCounterSampleBufferDescriptorBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCounterSampleBufferDescriptorBindings.SetLabel, value?.NativePtr ?? 0);
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

    public static readonly Selector CounterSet = Selector.Register("counterSet");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SampleCount = Selector.Register("sampleCount");

    public static readonly Selector SetCounterSet = Selector.Register("setCounterSet:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetSampleCount = Selector.Register("setSampleCount:");

    public static readonly Selector SetStorageMode = Selector.Register("setStorageMode:");

    public static readonly Selector StorageMode = Selector.Register("storageMode");
}
