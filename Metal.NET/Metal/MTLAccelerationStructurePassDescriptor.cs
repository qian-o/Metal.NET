namespace Metal.NET;

public class MTLAccelerationStructurePassDescriptor(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<MTLAccelerationStructurePassDescriptor>
{
    public static MTLAccelerationStructurePassDescriptor Create(nint nativePtr) => new(nativePtr);

    public static MTLAccelerationStructurePassDescriptor CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public MTLAccelerationStructurePassDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructurePassDescriptorBindings.Class))
    {
    }

    public MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray SampleBufferAttachments
    {
        get => GetProperty(ref field, MTLAccelerationStructurePassDescriptorBindings.SampleBufferAttachments);
    }

    public static MTLAccelerationStructurePassDescriptor AccelerationStructurePassDescriptor()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLAccelerationStructurePassDescriptorBindings.Class, MTLAccelerationStructurePassDescriptorBindings.AccelerationStructurePassDescriptor);

        return new(nativePtr);
    }
}

file static class MTLAccelerationStructurePassDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructurePassDescriptor");

    public static readonly Selector AccelerationStructurePassDescriptor = "accelerationStructurePassDescriptor";

    public static readonly Selector SampleBufferAttachments = "sampleBufferAttachments";
}
