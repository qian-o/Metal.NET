namespace Metal.NET;

public class MTLAccelerationStructurePassDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLAccelerationStructurePassDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructurePassDescriptorSelector.Class))
    {
    }

    public MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray? SampleBufferAttachments
    {
        get => GetNullableObject<MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructurePassDescriptorSelector.SampleBufferAttachments));
    }

    public static MTLAccelerationStructurePassDescriptor? AccelerationStructurePassDescriptor()
    {
        return GetNullableObject<MTLAccelerationStructurePassDescriptor>(ObjectiveCRuntime.MsgSendPtr(MTLAccelerationStructurePassDescriptorSelector.Class, MTLAccelerationStructurePassDescriptorSelector.AccelerationStructurePassDescriptor));
    }
}

file static class MTLAccelerationStructurePassDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructurePassDescriptor");

    public static readonly Selector AccelerationStructurePassDescriptor = Selector.Register("accelerationStructurePassDescriptor");

    public static readonly Selector SampleBufferAttachments = Selector.Register("sampleBufferAttachments");
}
