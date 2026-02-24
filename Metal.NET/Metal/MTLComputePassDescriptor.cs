namespace Metal.NET;

public class MTLComputePassDescriptor(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTLComputePassDescriptor>
{
    public static MTLComputePassDescriptor Create(nint nativePtr) => new(nativePtr);

    public MTLComputePassDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLComputePassDescriptorBindings.Class))
    {
    }

    public MTLDispatchType DispatchType
    {
        get => (MTLDispatchType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePassDescriptorBindings.DispatchType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePassDescriptorBindings.SetDispatchType, (nuint)value);
    }

    public MTLComputePassSampleBufferAttachmentDescriptorArray SampleBufferAttachments
    {
        get => GetProperty(ref field, MTLComputePassDescriptorBindings.SampleBufferAttachments);
    }

    public static MTLComputePassDescriptor ComputePassDescriptor()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLComputePassDescriptorBindings.Class, MTLComputePassDescriptorBindings.ComputePassDescriptor);

        return new(nativePtr);
    }
}

file static class MTLComputePassDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLComputePassDescriptor");

    public static readonly Selector ComputePassDescriptor = "computePassDescriptor";

    public static readonly Selector DispatchType = "dispatchType";

    public static readonly Selector SampleBufferAttachments = "sampleBufferAttachments";

    public static readonly Selector SetDispatchType = "setDispatchType:";
}
