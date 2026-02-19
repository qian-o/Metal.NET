namespace Metal.NET;

public readonly struct MTLBufferLayoutDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLBufferLayoutDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLBufferLayoutDescriptorBindings.Class))
    {
    }

    public MTLStepFunction StepFunction
    {
        get => (MTLStepFunction)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLBufferLayoutDescriptorBindings.StepFunction);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLBufferLayoutDescriptorBindings.SetStepFunction, (nuint)value);
    }

    public nuint StepRate
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLBufferLayoutDescriptorBindings.StepRate);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLBufferLayoutDescriptorBindings.SetStepRate, value);
    }

    public nuint Stride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLBufferLayoutDescriptorBindings.Stride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLBufferLayoutDescriptorBindings.SetStride, value);
    }
}

file static class MTLBufferLayoutDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLBufferLayoutDescriptor");

    public static readonly Selector SetStepFunction = Selector.Register("setStepFunction:");

    public static readonly Selector SetStepRate = Selector.Register("setStepRate:");

    public static readonly Selector SetStride = Selector.Register("setStride:");

    public static readonly Selector StepFunction = Selector.Register("stepFunction");

    public static readonly Selector StepRate = Selector.Register("stepRate");

    public static readonly Selector Stride = Selector.Register("stride");
}
