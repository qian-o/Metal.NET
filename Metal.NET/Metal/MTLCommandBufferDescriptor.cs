namespace Metal.NET;

public readonly struct MTLCommandBufferDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLCommandBufferDescriptor value) => new(value.NativePtr);

    public MTLCommandBufferDescriptor() : this(ObjectiveC.AllocInit(MTLCommandBufferDescriptorBindings.Class))
    {
    }

    public MTLCommandBufferDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public Bool8 RetainedReferences
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLCommandBufferDescriptorBindings.RetainedReferences);
        set => ObjectiveC.MsgSend(NativePtr, MTLCommandBufferDescriptorBindings.SetRetainedReferences, value);
    }

    public MTLCommandBufferErrorOption ErrorOptions
    {
        get => (MTLCommandBufferErrorOption)ObjectiveC.MsgSendULong(NativePtr, MTLCommandBufferDescriptorBindings.ErrorOptions);
        set => ObjectiveC.MsgSend(NativePtr, MTLCommandBufferDescriptorBindings.SetErrorOptions, (nuint)value);
    }

    public MTLLogState LogState
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferDescriptorBindings.LogState));
        set => ObjectiveC.MsgSend(NativePtr, MTLCommandBufferDescriptorBindings.SetLogState, value.NativePtr);
    }
}

file static class MTLCommandBufferDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLCommandBufferDescriptor");

    public static readonly Selector ErrorOptions = "errorOptions";

    public static readonly Selector LogState = "logState";

    public static readonly Selector RetainedReferences = "retainedReferences";

    public static readonly Selector SetErrorOptions = "setErrorOptions:";

    public static readonly Selector SetLogState = "setLogState:";

    public static readonly Selector SetRetainedReferences = "setRetainedReferences:";
}
