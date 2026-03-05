namespace Metal.NET;

public class MTLCounterSampleBufferDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLCounterSampleBufferDescriptor>
{
    #region INativeObject
    public static new MTLCounterSampleBufferDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLCounterSampleBufferDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLCounterSampleBufferDescriptor() : this(ObjectiveC.AllocInit(MTLCounterSampleBufferDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLCounterSet CounterSet
    {
        get => GetProperty(ref field, MTLCounterSampleBufferDescriptorBindings.CounterSet);
        set => SetProperty(ref field, MTLCounterSampleBufferDescriptorBindings.SetCounterSet, value);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLCounterSampleBufferDescriptorBindings.Label);
        set => SetProperty(ref field, MTLCounterSampleBufferDescriptorBindings.SetLabel, value);
    }

    public nuint SampleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLCounterSampleBufferDescriptorBindings.SampleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLCounterSampleBufferDescriptorBindings.SetSampleCount, value);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveC.MsgSendULong(NativePtr, MTLCounterSampleBufferDescriptorBindings.StorageMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLCounterSampleBufferDescriptorBindings.SetStorageMode, (nuint)value);
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
