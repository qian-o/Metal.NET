namespace Metal.NET;

public partial class MTLAccelerationStructurePassDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructurePassDescriptor");

    public MTLAccelerationStructurePassDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray? SampleBufferAttachments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructurePassDescriptorSelector.SampleBufferAttachments);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public static MTLAccelerationStructurePassDescriptor? AccelerationStructurePassDescriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(Class, MTLAccelerationStructurePassDescriptorSelector.AccelerationStructurePassDescriptor);
        return ptr is not 0 ? new(ptr) : null;
    }
}

file static class MTLAccelerationStructurePassDescriptorSelector
{
    public static readonly Selector AccelerationStructurePassDescriptor = Selector.Register("accelerationStructurePassDescriptor");

    public static readonly Selector SampleBufferAttachments = Selector.Register("sampleBufferAttachments");
}
