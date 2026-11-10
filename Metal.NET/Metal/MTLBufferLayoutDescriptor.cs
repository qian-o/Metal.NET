namespace Metal.NET;

public readonly struct MTLBufferLayoutDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLBufferLayoutDescriptor value) => new(value.NativePtr);

    public MTLBufferLayoutDescriptor() : this(ObjectiveC.AllocInit(MTLBufferLayoutDescriptorBindings.Class))
    {
    }

    public MTLBufferLayoutDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public nuint Stride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLBufferLayoutDescriptorBindings.Stride);
        set => ObjectiveC.MsgSend(NativePtr, MTLBufferLayoutDescriptorBindings.SetStride, value);
    }

    public MTLStepFunction StepFunction
    {
        get => (MTLStepFunction)ObjectiveC.MsgSendULong(NativePtr, MTLBufferLayoutDescriptorBindings.StepFunction);
        set => ObjectiveC.MsgSend(NativePtr, MTLBufferLayoutDescriptorBindings.SetStepFunction, (nuint)value);
    }

    public nuint StepRate
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLBufferLayoutDescriptorBindings.StepRate);
        set => ObjectiveC.MsgSend(NativePtr, MTLBufferLayoutDescriptorBindings.SetStepRate, value);
    }
}

file static class MTLBufferLayoutDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLBufferLayoutDescriptor");

    public static readonly Selector SetStepFunction = "setStepFunction:";

    public static readonly Selector SetStepRate = "setStepRate:";

    public static readonly Selector SetStride = "setStride:";

    public static readonly Selector StepFunction = "stepFunction";

    public static readonly Selector StepRate = "stepRate";

    public static readonly Selector Stride = "stride";
}
