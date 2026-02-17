namespace Metal.NET;

public class MTLComputePassDescriptor : IDisposable
{
    public MTLComputePassDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLComputePassDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLComputePassDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLComputePassDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLComputePassDescriptor");

    public static MTLComputePassDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLComputePassDescriptor(ptr);
    }

    public void SetDispatchType(MTLDispatchType dispatchType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePassDescriptorSelector.SetDispatchType, (nint)(uint)dispatchType);
    }

    public static MTLComputePassDescriptor ComputePassDescriptor()
    {
        var result = new MTLComputePassDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLComputePassDescriptorSelector.ComputePassDescriptor));

        return result;
    }

}

file class MTLComputePassDescriptorSelector
{
    public static readonly Selector SetDispatchType = Selector.Register("setDispatchType:");
    public static readonly Selector ComputePassDescriptor = Selector.Register("computePassDescriptor");
}
