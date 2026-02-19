namespace Metal.NET;

public class MTLVertexBufferLayoutDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLVertexBufferLayoutDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLVertexBufferLayoutDescriptorBindings.Class))
    {
    }

    public MTLVertexStepFunction StepFunction
    {
        get => (MTLVertexStepFunction)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLVertexBufferLayoutDescriptorBindings.StepFunction);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexBufferLayoutDescriptorBindings.SetStepFunction, (nuint)value);
    }

    public nuint StepRate
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLVertexBufferLayoutDescriptorBindings.StepRate);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexBufferLayoutDescriptorBindings.SetStepRate, value);
    }

    public nuint Stride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLVertexBufferLayoutDescriptorBindings.Stride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexBufferLayoutDescriptorBindings.SetStride, value);
    }
}

file static class MTLVertexBufferLayoutDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLVertexBufferLayoutDescriptor");

    public static readonly Selector SetStepFunction = Selector.Register("setStepFunction:");

    public static readonly Selector SetStepRate = Selector.Register("setStepRate:");

    public static readonly Selector SetStride = Selector.Register("setStride:");

    public static readonly Selector StepFunction = Selector.Register("stepFunction");

    public static readonly Selector StepRate = Selector.Register("stepRate");

    public static readonly Selector Stride = Selector.Register("stride");
}
