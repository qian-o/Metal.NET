namespace Metal.NET;

/// <summary>
/// An object that defines the front-facing or back-facing stencil operations of a depth and stencil state object.
/// </summary>
public class MTLStencilDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLStencilDescriptor>
{
    #region INativeObject
    public static new MTLStencilDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLStencilDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLStencilDescriptor() : this(ObjectiveC.AllocInit(MTLStencilDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Configuring stencil functions and operations - Properties

    /// <summary>
    /// The operation that is performed to update the values in the stencil attachment when the stencil test fails.
    /// </summary>
    public MTLStencilOperation StencilFailureOperation
    {
        get => (MTLStencilOperation)ObjectiveC.MsgSendULong(NativePtr, MTLStencilDescriptorBindings.StencilFailureOperation);
        set => ObjectiveC.MsgSend(NativePtr, MTLStencilDescriptorBindings.SetStencilFailureOperation, (nuint)value);
    }

    /// <summary>
    /// The operation that is performed to update the values in the stencil attachment when the stencil test passes, but the depth test fails.
    /// </summary>
    public MTLStencilOperation DepthFailureOperation
    {
        get => (MTLStencilOperation)ObjectiveC.MsgSendULong(NativePtr, MTLStencilDescriptorBindings.DepthFailureOperation);
        set => ObjectiveC.MsgSend(NativePtr, MTLStencilDescriptorBindings.SetDepthFailureOperation, (nuint)value);
    }

    /// <summary>
    /// The operation that is performed to update the values in the stencil attachment when both the stencil test and the depth test pass.
    /// </summary>
    public MTLStencilOperation DepthStencilPassOperation
    {
        get => (MTLStencilOperation)ObjectiveC.MsgSendULong(NativePtr, MTLStencilDescriptorBindings.DepthStencilPassOperation);
        set => ObjectiveC.MsgSend(NativePtr, MTLStencilDescriptorBindings.SetDepthStencilPassOperation, (nuint)value);
    }

    /// <summary>
    /// The comparison that is performed between the masked reference value and a masked value in the stencil attachment.
    /// </summary>
    public MTLCompareFunction StencilCompareFunction
    {
        get => (MTLCompareFunction)ObjectiveC.MsgSendULong(NativePtr, MTLStencilDescriptorBindings.StencilCompareFunction);
        set => ObjectiveC.MsgSend(NativePtr, MTLStencilDescriptorBindings.SetStencilCompareFunction, (nuint)value);
    }
    #endregion

    #region Configuring stencil bit mask properties - Properties

    /// <summary>
    /// A bitmask that determines from which bits that stencil comparison tests can read.
    /// </summary>
    public uint ReadMask
    {
        get => ObjectiveC.MsgSendUInt(NativePtr, MTLStencilDescriptorBindings.ReadMask);
        set => ObjectiveC.MsgSend(NativePtr, MTLStencilDescriptorBindings.SetReadMask, value);
    }

    /// <summary>
    /// A bitmask that determines to which bits that stencil operations can write.
    /// </summary>
    public uint WriteMask
    {
        get => ObjectiveC.MsgSendUInt(NativePtr, MTLStencilDescriptorBindings.WriteMask);
        set => ObjectiveC.MsgSend(NativePtr, MTLStencilDescriptorBindings.SetWriteMask, value);
    }
    #endregion
}

file static class MTLStencilDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLStencilDescriptor");

    public static readonly Selector DepthFailureOperation = "depthFailureOperation";

    public static readonly Selector DepthStencilPassOperation = "depthStencilPassOperation";

    public static readonly Selector ReadMask = "readMask";

    public static readonly Selector SetDepthFailureOperation = "setDepthFailureOperation:";

    public static readonly Selector SetDepthStencilPassOperation = "setDepthStencilPassOperation:";

    public static readonly Selector SetReadMask = "setReadMask:";

    public static readonly Selector SetStencilCompareFunction = "setStencilCompareFunction:";

    public static readonly Selector SetStencilFailureOperation = "setStencilFailureOperation:";

    public static readonly Selector SetWriteMask = "setWriteMask:";

    public static readonly Selector StencilCompareFunction = "stencilCompareFunction";

    public static readonly Selector StencilFailureOperation = "stencilFailureOperation";

    public static readonly Selector WriteMask = "writeMask";
}
