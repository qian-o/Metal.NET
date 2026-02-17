namespace Metal.NET;

public class MTL4AccelerationStructureDescriptor : IDisposable
{
    public MTL4AccelerationStructureDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTL4AccelerationStructureDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4AccelerationStructureDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4AccelerationStructureDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTL4AccelerationStructureDescriptor");

    public MTL4AccelerationStructureDescriptor() : this(ObjectiveCRuntime.MsgSendPtr(ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc")), Selector.Register("init")))
    {
    }

}

file class MTL4AccelerationStructureDescriptorSelector
{
}
