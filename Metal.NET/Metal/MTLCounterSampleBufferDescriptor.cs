namespace Metal.NET;

/// <summary>A group of properties that configures the counter sample buffers you create with it.</summary>
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

    #region Configuring a descriptor for a counter sample buffer - Properties

    /// <summary>A GPU device’s counter set instance that you want to sample.</summary>
    public MTLCounterSet CounterSet
    {
        get => GetProperty(ref field, MTLCounterSampleBufferDescriptorBindings.CounterSet);
        set => SetProperty(ref field, MTLCounterSampleBufferDescriptorBindings.SetCounterSet, value);
    }

    /// <summary>The name for the counter sample buffer you create with the descriptor.</summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLCounterSampleBufferDescriptorBindings.Label);
        set => SetProperty(ref field, MTLCounterSampleBufferDescriptorBindings.SetLabel, value);
    }

    /// <summary>The number of instances of a counter set’s data that a counter sample buffer can store.</summary>
    public nuint SampleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLCounterSampleBufferDescriptorBindings.SampleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLCounterSampleBufferDescriptorBindings.SetSampleCount, value);
    }

    /// <summary>The memory storage mode for the counter sample buffers you create with the descriptor.</summary>
    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveC.MsgSendULong(NativePtr, MTLCounterSampleBufferDescriptorBindings.StorageMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLCounterSampleBufferDescriptorBindings.SetStorageMode, (nuint)value);
    }
    #endregion
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
