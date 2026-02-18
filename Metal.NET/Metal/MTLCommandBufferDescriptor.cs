namespace Metal.NET;

public class MTLCommandBufferDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLCommandBufferDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLCommandBufferDescriptorSelector.Class))
    {
    }

    public MTLCommandBufferErrorOption ErrorOptions
    {
        get => (MTLCommandBufferErrorOption)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLCommandBufferDescriptorSelector.ErrorOptions);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferDescriptorSelector.SetErrorOptions, (nuint)value);
    }

    public MTLLogState? LogState
    {
        get => GetNullableObject<MTLLogState>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferDescriptorSelector.LogState));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferDescriptorSelector.SetLogState, value?.NativePtr ?? 0);
    }

    public bool RetainedReferences
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCommandBufferDescriptorSelector.RetainedReferences);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferDescriptorSelector.SetRetainedReferences, (Bool8)value);
    }
}

file static class MTLCommandBufferDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLCommandBufferDescriptor");

    public static readonly Selector ErrorOptions = Selector.Register("errorOptions");

    public static readonly Selector LogState = Selector.Register("logState");

    public static readonly Selector RetainedReferences = Selector.Register("retainedReferences");

    public static readonly Selector SetErrorOptions = Selector.Register("setErrorOptions:");

    public static readonly Selector SetLogState = Selector.Register("setLogState:");

    public static readonly Selector SetRetainedReferences = Selector.Register("setRetainedReferences:");
}
