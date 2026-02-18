namespace Metal.NET;

public class MTLComputePassDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLComputePassDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLComputePassDescriptorSelector.Class))
    {
    }

    public MTLDispatchType DispatchType
    {
        get => (MTLDispatchType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePassDescriptorSelector.DispatchType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePassDescriptorSelector.SetDispatchType, (nuint)value);
    }

    public MTLComputePassSampleBufferAttachmentDescriptorArray? SampleBufferAttachments
    {
        get => GetNullableObject<MTLComputePassSampleBufferAttachmentDescriptorArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePassDescriptorSelector.SampleBufferAttachments));
    }

    public static MTLComputePassDescriptor? ComputePassDescriptor()
    {
        return GetNullableObject<MTLComputePassDescriptor>(ObjectiveCRuntime.MsgSendPtr(MTLComputePassDescriptorSelector.Class, MTLComputePassDescriptorSelector.ComputePassDescriptor));
    }
}

file static class MTLComputePassDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLComputePassDescriptor");

    public static readonly Selector ComputePassDescriptor = Selector.Register("computePassDescriptor");

    public static readonly Selector DispatchType = Selector.Register("dispatchType");

    public static readonly Selector SampleBufferAttachments = Selector.Register("sampleBufferAttachments");

    public static readonly Selector SetDispatchType = Selector.Register("setDispatchType:");
}
