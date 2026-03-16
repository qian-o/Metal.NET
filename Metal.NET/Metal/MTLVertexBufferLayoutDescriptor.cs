namespace Metal.NET;

/// <summary>An object that configures how a render pipeline fetches data to send to the vertex function.</summary>
public class MTLVertexBufferLayoutDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLVertexBufferLayoutDescriptor>
{
    #region INativeObject
    public static new MTLVertexBufferLayoutDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLVertexBufferLayoutDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLVertexBufferLayoutDescriptor() : this(ObjectiveC.AllocInit(MTLVertexBufferLayoutDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Organizing the vertex buffer layout - Properties

    /// <summary>The circumstances under which the vertex and its attributes are presented to the vertex function.</summary>
    public MTLVertexStepFunction StepFunction
    {
        get => (MTLVertexStepFunction)ObjectiveC.MsgSendULong(NativePtr, MTLVertexBufferLayoutDescriptorBindings.StepFunction);
        set => ObjectiveC.MsgSend(NativePtr, MTLVertexBufferLayoutDescriptorBindings.SetStepFunction, (nuint)value);
    }

    /// <summary>The interval at which the vertex and its attributes are presented to the vertex function.</summary>
    public nuint StepRate
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLVertexBufferLayoutDescriptorBindings.StepRate);
        set => ObjectiveC.MsgSend(NativePtr, MTLVertexBufferLayoutDescriptorBindings.SetStepRate, value);
    }

    /// <summary>The number of bytes between the first byte of two consecutive vertices in a buffer.</summary>
    public nuint Stride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLVertexBufferLayoutDescriptorBindings.Stride);
        set => ObjectiveC.MsgSend(NativePtr, MTLVertexBufferLayoutDescriptorBindings.SetStride, value);
    }
    #endregion
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
