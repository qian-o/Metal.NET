namespace Metal.NET;

public class MTLAccelerationStructurePassDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLAccelerationStructurePassDescriptor>
{
    public static MTLAccelerationStructurePassDescriptor Create(nint nativePtr) => new(nativePtr, true);

    public static MTLAccelerationStructurePassDescriptor CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public MTLAccelerationStructurePassDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructurePassDescriptorBindings.Class), true)
    {
    }

    public MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray SampleBufferAttachments
    {
        get => GetProperty(ref field, MTLAccelerationStructurePassDescriptorBindings.SampleBufferAttachments);
    }

    public static MTLAccelerationStructurePassDescriptor AccelerationStructurePassDescriptor()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLAccelerationStructurePassDescriptorBindings.Class, MTLAccelerationStructurePassDescriptorBindings.AccelerationStructurePassDescriptor);

        return new(nativePtr, true);
    }
}

file static class MTLAccelerationStructurePassDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructurePassDescriptor");

    public static readonly Selector AccelerationStructurePassDescriptor = "accelerationStructurePassDescriptor";

    public static readonly Selector SampleBufferAttachments = "sampleBufferAttachments";
}
