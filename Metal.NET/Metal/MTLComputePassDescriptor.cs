namespace Metal.NET;

public readonly struct MTLComputePassDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLComputePassDescriptor value) => new(value.NativePtr);

    public MTLComputePassDescriptor() : this(ObjectiveC.AllocInit(MTLComputePassDescriptorBindings.Class))
    {
    }

    public MTLComputePassDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public MTLDispatchType DispatchType
    {
        get => (MTLDispatchType)ObjectiveC.MsgSendULong(NativePtr, MTLComputePassDescriptorBindings.DispatchType);
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePassDescriptorBindings.SetDispatchType, (nuint)value);
    }

    public MTLComputePassSampleBufferAttachmentDescriptorArray SampleBufferAttachments
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLComputePassDescriptorBindings.SampleBufferAttachments));
    }

    public static MTLComputePassDescriptor ComputePassDescriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLComputePassDescriptorBindings.Class, MTLComputePassDescriptorBindings.ComputePassDescriptor);

        return new(nativePtr);
    }
}

file static class MTLComputePassDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLComputePassDescriptor");

    public static readonly Selector ComputePassDescriptor = "computePassDescriptor";

    public static readonly Selector DispatchType = "dispatchType";

    public static readonly Selector SampleBufferAttachments = "sampleBufferAttachments";

    public static readonly Selector SetDispatchType = "setDispatchType:";
}
