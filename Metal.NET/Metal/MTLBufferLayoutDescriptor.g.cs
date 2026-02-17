namespace Metal.NET;

public class MTLBufferLayoutDescriptor : IDisposable
{
    public MTLBufferLayoutDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLBufferLayoutDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLBufferLayoutDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLBufferLayoutDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLBufferLayoutDescriptor");

    public static MTLBufferLayoutDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLBufferLayoutDescriptor(ptr);
    }

    public void SetStepFunction(MTLStepFunction stepFunction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBufferLayoutDescriptorSelector.SetStepFunction, (nint)(uint)stepFunction);
    }

    public void SetStepRate(uint stepRate)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBufferLayoutDescriptorSelector.SetStepRate, (nint)stepRate);
    }

    public void SetStride(uint stride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBufferLayoutDescriptorSelector.SetStride, (nint)stride);
    }

}

file class MTLBufferLayoutDescriptorSelector
{
    public static readonly Selector SetStepFunction = Selector.Register("setStepFunction:");
    public static readonly Selector SetStepRate = Selector.Register("setStepRate:");
    public static readonly Selector SetStride = Selector.Register("setStride:");
}
