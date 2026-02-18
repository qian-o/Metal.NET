namespace Metal.NET;

public class MTLComputePassDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLComputePassDescriptor");

    public MTLComputePassDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLComputePassDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLComputePassDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLDispatchType DispatchType
    {
        get => (MTLDispatchType)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLComputePassDescriptorSelector.DispatchType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePassDescriptorSelector.SetDispatchType, (ulong)value);
    }

    public MTLComputePassSampleBufferAttachmentDescriptorArray SampleBufferAttachments
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePassDescriptorSelector.SampleBufferAttachments));
    }

    public static implicit operator nint(MTLComputePassDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLComputePassDescriptor(nint value)
    {
        return new(value);
    }

    public static MTLComputePassDescriptor ComputePassDescriptor()
    {
        MTLComputePassDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(Class, MTLComputePassDescriptorSelector.ComputePassDescriptor));

        return result;
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTLComputePassDescriptorSelector
{
    public static readonly Selector DispatchType = Selector.Register("dispatchType");

    public static readonly Selector SetDispatchType = Selector.Register("setDispatchType:");

    public static readonly Selector SampleBufferAttachments = Selector.Register("sampleBufferAttachments");

    public static readonly Selector ComputePassDescriptor = Selector.Register("computePassDescriptor");
}
