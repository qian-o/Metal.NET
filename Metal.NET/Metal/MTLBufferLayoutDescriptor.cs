namespace Metal.NET;

public class MTLBufferLayoutDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLBufferLayoutDescriptor>
{
    #region INativeObject
    public static new MTLBufferLayoutDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLBufferLayoutDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLBufferLayoutDescriptor() : this(ObjectiveC.AllocInit(MTLBufferLayoutDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
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
