namespace Metal.NET;

public readonly struct MTLComputePassDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLComputePassDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLComputePassDescriptorBindings.Class))
    {
    }

    public MTLDispatchType DispatchType
    {
        get => (MTLDispatchType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePassDescriptorBindings.DispatchType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePassDescriptorBindings.SetDispatchType, (nuint)value);
    }

    public MTLComputePassSampleBufferAttachmentDescriptorArray? SampleBufferAttachments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePassDescriptorBindings.SampleBufferAttachments);
            return ptr is not 0 ? new MTLComputePassSampleBufferAttachmentDescriptorArray(ptr) : default;
        }
    }

    public static MTLComputePassDescriptor? ComputePassDescriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLComputePassDescriptorBindings.Class, MTLComputePassDescriptorBindings.ComputePassDescriptor);
        return ptr is not 0 ? new MTLComputePassDescriptor(ptr) : default;
    }
}

file static class MTLComputePassDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLComputePassDescriptor");

    public static readonly Selector ComputePassDescriptor = Selector.Register("computePassDescriptor");

    public static readonly Selector DispatchType = Selector.Register("dispatchType");

    public static readonly Selector SampleBufferAttachments = Selector.Register("sampleBufferAttachments");

    public static readonly Selector SetDispatchType = Selector.Register("setDispatchType:");
}
