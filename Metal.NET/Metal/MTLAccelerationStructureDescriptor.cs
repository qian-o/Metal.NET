namespace Metal.NET;

public class MTLAccelerationStructureDescriptor : IDisposable
{
    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureDescriptor");

    public MTLAccelerationStructureDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    public MTLAccelerationStructureDescriptor() : this(ObjectiveCRuntime.AllocInit(s_class))
    {
    }

    ~MTLAccelerationStructureDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nuint Usage
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureDescriptorSelector.Usage);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureDescriptorSelector.SetUsage, (nuint)value);
    }

    public static implicit operator nint(MTLAccelerationStructureDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLAccelerationStructureDescriptor(nint value)
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

}

file class MTLAccelerationStructureDescriptorSelector
{
    public static readonly Selector Usage = Selector.Register("usage");

    public static readonly Selector SetUsage = Selector.Register("setUsage:");
}
