namespace Metal.NET;

public partial class MTLCommandBufferDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLCommandBufferDescriptor>
{
    #region INativeObject
    public static new MTLCommandBufferDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLCommandBufferDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLCommandBufferDescriptor() : this(ObjectiveC.AllocInit(MTLCommandBufferDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
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
        get => GetProperty(ref field, MTLCommandBufferDescriptorBindings.LogState);
        set => SetProperty(ref field, MTLCommandBufferDescriptorBindings.SetLogState, value);
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
