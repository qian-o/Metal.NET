namespace Metal.NET;

public class MTLVertexBufferLayoutDescriptor : IDisposable
{
    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLVertexBufferLayoutDescriptor");

    public MTLVertexBufferLayoutDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    public MTLVertexBufferLayoutDescriptor() : this(ObjectiveCRuntime.AllocInit(s_class))
    {
    }

    ~MTLVertexBufferLayoutDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLVertexStepFunction StepFunction
    {
        get => (MTLVertexStepFunction)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLVertexBufferLayoutDescriptorSelector.StepFunction));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexBufferLayoutDescriptorSelector.SetStepFunction, (uint)value);
    }

    public nuint StepRate
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLVertexBufferLayoutDescriptorSelector.StepRate);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexBufferLayoutDescriptorSelector.SetStepRate, (nuint)value);
    }

    public nuint Stride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLVertexBufferLayoutDescriptorSelector.Stride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexBufferLayoutDescriptorSelector.SetStride, (nuint)value);
    }

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

}

file class MTLVertexBufferLayoutDescriptorSelector
{
    public static readonly Selector StepFunction = Selector.Register("stepFunction");

    public static readonly Selector SetStepFunction = Selector.Register("setStepFunction:");

    public static readonly Selector StepRate = Selector.Register("stepRate");

    public static readonly Selector SetStepRate = Selector.Register("setStepRate:");

    public static readonly Selector Stride = Selector.Register("stride");

    public static readonly Selector SetStride = Selector.Register("setStride:");
}
