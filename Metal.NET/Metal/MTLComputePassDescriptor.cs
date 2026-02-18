namespace Metal.NET;

public partial class MTLComputePassDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLComputePassDescriptor");

    public MTLComputePassDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLDispatchType DispatchType
    {
        get => (MTLDispatchType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePassDescriptorSelector.DispatchType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePassDescriptorSelector.SetDispatchType, (nuint)value);
    }

    public MTLComputePassSampleBufferAttachmentDescriptorArray? SampleBufferAttachments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePassDescriptorSelector.SampleBufferAttachments);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public static MTLComputePassDescriptor? ComputePassDescriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(Class, MTLComputePassDescriptorSelector.ComputePassDescriptor);
        return ptr is not 0 ? new(ptr) : null;
    }
}

file static class MTLComputePassDescriptorSelector
{
    public static readonly Selector ComputePassDescriptor = Selector.Register("computePassDescriptor");

    public static readonly Selector DispatchType = Selector.Register("dispatchType");

    public static readonly Selector SampleBufferAttachments = Selector.Register("sampleBufferAttachments");

    public static readonly Selector SetDispatchType = Selector.Register("setDispatchType:");
}
