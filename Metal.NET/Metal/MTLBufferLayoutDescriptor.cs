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

    public MTLBufferLayoutDescriptor() : this(ObjectiveCRuntime.MsgSendPtr(ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc")), Selector.Register("init")))
    {
    }

    public MTLStepFunction StepFunction
    {
        get => (MTLStepFunction)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLBufferLayoutDescriptorSelector.StepFunction));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLBufferLayoutDescriptorSelector.SetStepFunction, (uint)value);
    }

    public nuint StepRate
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLBufferLayoutDescriptorSelector.StepRate);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLBufferLayoutDescriptorSelector.SetStepRate, (nuint)value);
    }

    public nuint Stride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLBufferLayoutDescriptorSelector.Stride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLBufferLayoutDescriptorSelector.SetStride, (nuint)value);
    }

}

file class MTLBufferLayoutDescriptorSelector
{
    public static readonly Selector StepFunction = Selector.Register("stepFunction");

    public static readonly Selector SetStepFunction = Selector.Register("setStepFunction:");

    public static readonly Selector StepRate = Selector.Register("stepRate");

    public static readonly Selector SetStepRate = Selector.Register("setStepRate:");

    public static readonly Selector Stride = Selector.Register("stride");

    public static readonly Selector SetStride = Selector.Register("setStride:");
}
