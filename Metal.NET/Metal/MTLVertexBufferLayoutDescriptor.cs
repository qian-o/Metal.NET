namespace Metal.NET;

public class MTLVertexBufferLayoutDescriptor : IDisposable
{
    public MTLVertexBufferLayoutDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        var ptr = ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.MsgSendPtr(ptr, Selector.Register("init"));

        return new MTLVertexBufferLayoutDescriptor(ptr);
    }

    public void SetStepFunction(MTLVertexStepFunction stepFunction)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexBufferLayoutDescriptorSelector.SetStepFunction, (nint)(uint)stepFunction);
    }

    public void SetStepRate(uint stepRate)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexBufferLayoutDescriptorSelector.SetStepRate, (nint)stepRate);
    }

    public void SetStride(uint stride)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexBufferLayoutDescriptorSelector.SetStride, (nint)stride);
    }

}

file class MTLVertexBufferLayoutDescriptorSelector
{
    public static readonly Selector SetStepFunction = Selector.Register("setStepFunction:");

    public static readonly Selector SetStepRate = Selector.Register("setStepRate:");

    public static readonly Selector SetStride = Selector.Register("setStride:");
}
