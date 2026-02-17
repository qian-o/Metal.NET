namespace Metal.NET;

file class MTLAccelerationStructureDescriptorSelector
{
    public static readonly Selector SetUsage_ = Selector.Register("setUsage:");
}

public class MTLAccelerationStructureDescriptor : IDisposable
{
    public MTLAccelerationStructureDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
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

    public static MTLAccelerationStructureDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLAccelerationStructureDescriptor(ptr);
    }

    public void SetUsage(nuint usage)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureDescriptorSelector.SetUsage_, (nint)usage);
    }

}
