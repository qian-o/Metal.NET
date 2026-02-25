namespace Metal.NET;

public class MTLCommandBufferDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLCommandBufferDescriptor>
{
    public static MTLCommandBufferDescriptor Null { get; } = new(0, false);

    public static MTLCommandBufferDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLCommandBufferDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLCommandBufferDescriptorBindings.Class), true)
    {
        GC.ReRegisterForFinalize(this);
    }

    public MTLCommandBufferErrorOption ErrorOptions
    {
        get => (MTLCommandBufferErrorOption)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLCommandBufferDescriptorBindings.ErrorOptions);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferDescriptorBindings.SetErrorOptions, (nuint)value);
    }

    public MTLLogState LogState
    {
        get => GetProperty(ref field, MTLCommandBufferDescriptorBindings.LogState);
        set => SetProperty(ref field, MTLCommandBufferDescriptorBindings.SetLogState, value);
    }

    public Bool8 RetainedReferences
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCommandBufferDescriptorBindings.RetainedReferences);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferDescriptorBindings.SetRetainedReferences, value);
    }
}

file static class MTLCommandBufferDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLCommandBufferDescriptor");

    public static readonly Selector ErrorOptions = "errorOptions";

    public static readonly Selector LogState = "logState";

    public static readonly Selector RetainedReferences = "retainedReferences";

    public static readonly Selector SetErrorOptions = "setErrorOptions:";

    public static readonly Selector SetLogState = "setLogState:";

    public static readonly Selector SetRetainedReferences = "setRetainedReferences:";
}
