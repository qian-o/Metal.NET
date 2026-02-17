namespace Metal.NET;

file class MTLVertexBufferLayoutDescriptorSelector
{
    public static readonly Selector SetStepFunction_ = Selector.Register("setStepFunction:");
    public static readonly Selector SetStepRate_ = Selector.Register("setStepRate:");
    public static readonly Selector SetStride_ = Selector.Register("setStride:");
}

public class MTLVertexBufferLayoutDescriptor : IDisposable
{
    public MTLVertexBufferLayoutDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLVertexBufferLayoutDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLVertexBufferLayoutDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLVertexBufferLayoutDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLVertexBufferLayoutDescriptor");

    public static MTLVertexBufferLayoutDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLVertexBufferLayoutDescriptor(ptr);
    }

    public void SetStepFunction(MTLVertexStepFunction stepFunction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLVertexBufferLayoutDescriptorSelector.SetStepFunction_, (nint)(uint)stepFunction);
    }

    public void SetStepRate(nuint stepRate)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLVertexBufferLayoutDescriptorSelector.SetStepRate_, (nint)stepRate);
    }

    public void SetStride(nuint stride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLVertexBufferLayoutDescriptorSelector.SetStride_, (nint)stride);
    }

}
