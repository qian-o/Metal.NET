namespace Metal.NET;

public class MTLCounterSampleBufferDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLCounterSampleBufferDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLCounterSampleBufferDescriptorBindings.Class))
    {
    }

    public MTLCounterSet? CounterSet
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCounterSampleBufferDescriptorBindings.CounterSet);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLCounterSet(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLCounterSampleBufferDescriptorBindings.SetCounterSet, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCounterSampleBufferDescriptorBindings.Label);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSString(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLCounterSampleBufferDescriptorBindings.SetLabel, value?.NativePtr ?? 0);
            field = value;
        }
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
