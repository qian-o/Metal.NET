namespace Metal.NET;

public class MTLCommandBufferDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLCommandBufferDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLCommandBufferDescriptorBindings.Class))
    {
    }

    public MTLCommandBufferErrorOption ErrorOptions
    {
        get => (MTLCommandBufferErrorOption)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLCommandBufferDescriptorBindings.ErrorOptions);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferDescriptorBindings.SetErrorOptions, (nuint)value);
    }

    public MTLLogState? LogState
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferDescriptorBindings.LogState);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLLogState(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferDescriptorBindings.SetLogState, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public bool RetainedReferences
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCommandBufferDescriptorBindings.RetainedReferences);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferDescriptorBindings.SetRetainedReferences, (Bool8)value);
    }
}

file static class MTLCommandBufferDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLCommandBufferDescriptor");

    public static readonly Selector ErrorOptions = Selector.Register("errorOptions");

    public static readonly Selector LogState = Selector.Register("logState");

    public static readonly Selector RetainedReferences = Selector.Register("retainedReferences");

    public static readonly Selector SetErrorOptions = Selector.Register("setErrorOptions:");

    public static readonly Selector SetLogState = Selector.Register("setLogState:");

    public static readonly Selector SetRetainedReferences = Selector.Register("setRetainedReferences:");
}
