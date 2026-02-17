namespace Metal.NET;

public class MTLAccelerationStructurePassDescriptor : IDisposable
{
    public MTLAccelerationStructurePassDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLAccelerationStructurePassDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructurePassDescriptor");

    public MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray SampleBufferAttachments
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructurePassDescriptorSelector.SampleBufferAttachments));
    }

    public static implicit operator nint(MTLAccelerationStructurePassDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLAccelerationStructurePassDescriptor(nint value)
    {
        return new(value);
    }

    public static MTLAccelerationStructurePassDescriptor AccelerationStructurePassDescriptor()
    {
        MTLAccelerationStructurePassDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(Class, MTLAccelerationStructurePassDescriptorSelector.AccelerationStructurePassDescriptor));

        return result;
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTLAccelerationStructurePassDescriptorSelector
{
    public static readonly Selector SampleBufferAttachments = Selector.Register("sampleBufferAttachments");

    public static readonly Selector AccelerationStructurePassDescriptor = Selector.Register("accelerationStructurePassDescriptor");
}
