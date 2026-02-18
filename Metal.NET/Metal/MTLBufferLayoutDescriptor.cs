namespace Metal.NET;

public partial class MTLBufferLayoutDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLBufferLayoutDescriptor");

    public MTLBufferLayoutDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLStepFunction StepFunction
    {
        get => (MTLStepFunction)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLBufferLayoutDescriptorSelector.StepFunction);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLBufferLayoutDescriptorSelector.SetStepFunction, (nuint)value);
    }

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
}

file static class MTLBufferLayoutDescriptorSelector
{
    public static readonly Selector SetStepFunction = Selector.Register("setStepFunction:");

    public static readonly Selector SetStepRate = Selector.Register("setStepRate:");

    public static readonly Selector SetStride = Selector.Register("setStride:");

    public static readonly Selector StepFunction = Selector.Register("stepFunction");

    public static readonly Selector StepRate = Selector.Register("stepRate");

    public static readonly Selector Stride = Selector.Register("stride");
}
