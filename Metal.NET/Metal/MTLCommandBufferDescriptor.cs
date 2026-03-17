namespace Metal.NET;

/// <summary>
/// A configuration that customizes the behavior for a new command buffer.
/// </summary>
public class MTLCommandBufferDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLCommandBufferDescriptor>
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

    #region Configuring the command buffer - Properties

    /// <summary>
    /// The shader logging configuration that the command buffer uses.
    /// </summary>
    public MTLLogState LogState
    {
        get => GetProperty(ref field, MTLCommandBufferDescriptorBindings.LogState);
        set => SetProperty(ref field, MTLCommandBufferDescriptorBindings.SetLogState, value);
    }

    /// <summary>
    /// A Boolean value that indicates whether the command buffer the descriptor creates maintains strong references to the resources it uses.
    /// </summary>
    public Bool8 RetainedReferences
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLCommandBufferDescriptorBindings.RetainedReferences);
        set => ObjectiveC.MsgSend(NativePtr, MTLCommandBufferDescriptorBindings.SetRetainedReferences, value);
    }

    /// <summary>
    /// The reporting configuration that indicates which information the GPU driver stores in a command buffer’s error property.
    /// </summary>
    public MTLCommandBufferErrorOption ErrorOptions
    {
        get => (MTLCommandBufferErrorOption)ObjectiveC.MsgSendULong(NativePtr, MTLCommandBufferDescriptorBindings.ErrorOptions);
        set => ObjectiveC.MsgSend(NativePtr, MTLCommandBufferDescriptorBindings.SetErrorOptions, (nuint)value);
    }
    #endregion
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
