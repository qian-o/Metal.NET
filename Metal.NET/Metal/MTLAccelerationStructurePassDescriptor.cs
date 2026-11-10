namespace Metal.NET;

public readonly struct MTLAccelerationStructurePassDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLAccelerationStructurePassDescriptor value) => new(value.NativePtr);

    public MTLAccelerationStructurePassDescriptor() : this(ObjectiveC.AllocInit(MTLAccelerationStructurePassDescriptorBindings.Class))
    {
    }

    public MTLAccelerationStructurePassDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray SampleBufferAttachments
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructurePassDescriptorBindings.SampleBufferAttachments));
    }

    public static MTLAccelerationStructurePassDescriptor AccelerationStructurePassDescriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLAccelerationStructurePassDescriptorBindings.Class, MTLAccelerationStructurePassDescriptorBindings.AccelerationStructurePassDescriptor);

        return new(nativePtr);
    }
}

file static class MTLAccelerationStructurePassDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLAccelerationStructurePassDescriptor");

    public static readonly Selector AccelerationStructurePassDescriptor = "accelerationStructurePassDescriptor";

    public static readonly Selector SampleBufferAttachments = "sampleBufferAttachments";
}
