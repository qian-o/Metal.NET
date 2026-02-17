namespace Metal.NET;

public class MTLComputePassDescriptor : IDisposable
{
    public MTLComputePassDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLComputePassDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLComputePassDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLComputePassDescriptor(nint value)
    {
        return new(value);
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLComputePassDescriptor");

    public MTLComputePassDescriptor() : this(ObjectiveCRuntime.MsgSendPtr(ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc")), Selector.Register("init")))
    {
    }

    public MTLDispatchType DispatchType
    {
        get => (MTLDispatchType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLComputePassDescriptorSelector.DispatchType));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePassDescriptorSelector.SetDispatchType, (uint)value);
    }

    public MTLComputePassSampleBufferAttachmentDescriptorArray SampleBufferAttachments
    {
        get => new MTLComputePassSampleBufferAttachmentDescriptorArray(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePassDescriptorSelector.SampleBufferAttachments));
    }

    public static MTLComputePassDescriptor ComputePassDescriptor()
    {
        MTLComputePassDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(s_class, MTLComputePassDescriptorSelector.ComputePassDescriptor));

        return result;
    }

}

file class MTLComputePassDescriptorSelector
{
    public static readonly Selector DispatchType = Selector.Register("dispatchType");

    public static readonly Selector SetDispatchType = Selector.Register("setDispatchType:");

    public static readonly Selector SampleBufferAttachments = Selector.Register("sampleBufferAttachments");

    public static readonly Selector ComputePassDescriptor = Selector.Register("computePassDescriptor");
}
