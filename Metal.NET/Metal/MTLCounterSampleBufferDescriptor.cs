namespace Metal.NET;

public readonly struct MTLCounterSampleBufferDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLCounterSampleBufferDescriptor value) => new(value.NativePtr);

    public MTLCounterSampleBufferDescriptor() : this(ObjectiveC.AllocInit(MTLCounterSampleBufferDescriptorBindings.Class))
    {
    }

    public MTLCounterSampleBufferDescriptor Retain()
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

    public MTLCounterSet CounterSet
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLCounterSampleBufferDescriptorBindings.CounterSet));
        set => ObjectiveC.MsgSend(NativePtr, MTLCounterSampleBufferDescriptorBindings.SetCounterSet, value.NativePtr);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLCounterSampleBufferDescriptorBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLCounterSampleBufferDescriptorBindings.SetLabel, value.NativePtr);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveC.MsgSendULong(NativePtr, MTLCounterSampleBufferDescriptorBindings.StorageMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLCounterSampleBufferDescriptorBindings.SetStorageMode, (nuint)value);
    }

    public nuint SampleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLCounterSampleBufferDescriptorBindings.SampleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLCounterSampleBufferDescriptorBindings.SetSampleCount, value);
    }
}

file static class MTLCounterSampleBufferDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLCounterSampleBufferDescriptor");

    public static readonly Selector CounterSet = "counterSet";

    public static readonly Selector Label = "label";

    public static readonly Selector SampleCount = "sampleCount";

    public static readonly Selector SetCounterSet = "setCounterSet:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetSampleCount = "setSampleCount:";

    public static readonly Selector SetStorageMode = "setStorageMode:";

    public static readonly Selector StorageMode = "storageMode";
}
