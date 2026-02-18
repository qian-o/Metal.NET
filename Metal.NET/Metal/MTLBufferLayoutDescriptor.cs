namespace Metal.NET;

public class MTLBufferLayoutDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLBufferLayoutDescriptor");

    public MTLBufferLayoutDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLBufferLayoutDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLBufferLayoutDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nuint StepRate
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLBufferLayoutDescriptorSelector.StepRate);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLBufferLayoutDescriptorSelector.SetStepRate, value);
    }

    public nuint Stride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLBufferLayoutDescriptorSelector.Stride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLBufferLayoutDescriptorSelector.SetStride, value);
    }

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
}

file class MTLBufferLayoutDescriptorSelector
{
    public static readonly Selector StepRate = Selector.Register("stepRate");

    public static readonly Selector SetStepRate = Selector.Register("setStepRate:");

    public static readonly Selector Stride = Selector.Register("stride");

    public static readonly Selector SetStride = Selector.Register("setStride:");
}
