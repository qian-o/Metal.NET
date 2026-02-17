namespace Metal.NET;

public class MTLAccelerationStructureDescriptor : IDisposable
{
    public MTLAccelerationStructureDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLAccelerationStructureDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureDescriptor");

    public MTLAccelerationStructureDescriptor() : this(ObjectiveCRuntime.MsgSendPtr(ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc")), Selector.Register("init")))
    {
    }

    public nuint Usage
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureDescriptorSelector.Usage);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureDescriptorSelector.SetUsage, (nuint)value);
    }

}

file class MTLAccelerationStructureDescriptorSelector
{
    public static readonly Selector Usage = Selector.Register("usage");

    public static readonly Selector SetUsage = Selector.Register("setUsage:");
}
