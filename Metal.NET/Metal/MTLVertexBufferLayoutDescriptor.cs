namespace Metal.NET;

public readonly struct MTLVertexBufferLayoutDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLVertexBufferLayoutDescriptor value) => new(value.NativePtr);

    public MTLVertexBufferLayoutDescriptor() : this(ObjectiveC.AllocInit(MTLVertexBufferLayoutDescriptorBindings.Class))
    {
    }

    public MTLVertexBufferLayoutDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public nuint Stride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLVertexBufferLayoutDescriptorBindings.Stride);
        set => ObjectiveC.MsgSend(NativePtr, MTLVertexBufferLayoutDescriptorBindings.SetStride, value);
    }

    public MTLVertexStepFunction StepFunction
    {
        get => (MTLVertexStepFunction)ObjectiveC.MsgSendULong(NativePtr, MTLVertexBufferLayoutDescriptorBindings.StepFunction);
        set => ObjectiveC.MsgSend(NativePtr, MTLVertexBufferLayoutDescriptorBindings.SetStepFunction, (nuint)value);
    }

    public nuint StepRate
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLVertexBufferLayoutDescriptorBindings.StepRate);
        set => ObjectiveC.MsgSend(NativePtr, MTLVertexBufferLayoutDescriptorBindings.SetStepRate, value);
    }
}

file static class MTLVertexBufferLayoutDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLVertexBufferLayoutDescriptor");

    public static readonly Selector SetStepFunction = "setStepFunction:";

    public static readonly Selector SetStepRate = "setStepRate:";

    public static readonly Selector SetStride = "setStride:";

    public static readonly Selector StepFunction = "stepFunction";

    public static readonly Selector StepRate = "stepRate";

    public static readonly Selector Stride = "stride";
}
