namespace Metal.NET;

public class MTLAccelerationStructurePassDescriptor : IDisposable
{
    public MTLAccelerationStructurePassDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLAccelerationStructurePassDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLAccelerationStructurePassDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLAccelerationStructurePassDescriptor(nint value)
    {
        return new(value);
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLAccelerationStructurePassDescriptor");

    public static MTLAccelerationStructurePassDescriptor AccelerationStructurePassDescriptor()
    {
        MTLAccelerationStructurePassDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(s_class, MTLAccelerationStructurePassDescriptorSelector.AccelerationStructurePassDescriptor));

        return result;
    }

}

file class MTLAccelerationStructurePassDescriptorSelector
{
    public static readonly Selector AccelerationStructurePassDescriptor = Selector.Register("accelerationStructurePassDescriptor");
}
