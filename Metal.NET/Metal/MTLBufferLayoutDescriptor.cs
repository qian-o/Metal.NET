namespace Metal.NET;

public class MTLBufferLayoutDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLBufferLayoutDescriptor>
{
    public static MTLBufferLayoutDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLBufferLayoutDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLBufferLayoutDescriptorBindings.Class), true)
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

    public static readonly Selector SetStepFunction = "setStepFunction:";

    public static readonly Selector SetStepRate = "setStepRate:";

    public static readonly Selector SetStride = "setStride:";

    public static readonly Selector StepFunction = "stepFunction";

    public static readonly Selector StepRate = "stepRate";

    public static readonly Selector Stride = "stride";
}
