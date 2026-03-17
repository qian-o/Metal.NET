namespace Metal.NET;

/// <summary>
/// An instance that configures new  instances.
/// </summary>
public class MTLDepthStencilDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLDepthStencilDescriptor>
{
    #region INativeObject
    public static new MTLDepthStencilDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLDepthStencilDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLDepthStencilDescriptor() : this(ObjectiveC.AllocInit(MTLDepthStencilDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Specifying depth operations - Properties

    /// <summary>
    /// The comparison that is performed between a fragment’s depth value and the depth value in the attachment, which determines whether to discard the fragment.
    /// </summary>
    public MTLCompareFunction DepthCompareFunction
    {
        get => (MTLCompareFunction)ObjectiveC.MsgSendULong(NativePtr, MTLDepthStencilDescriptorBindings.DepthCompareFunction);
        set => ObjectiveC.MsgSend(NativePtr, MTLDepthStencilDescriptorBindings.SetDepthCompareFunction, (nuint)value);
    }

    /// <summary>
    /// A Boolean value that indicates whether depth values can be written to the depth attachment.
    /// </summary>
    public Bool8 IsDepthWriteEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDepthStencilDescriptorBindings.IsDepthWriteEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLDepthStencilDescriptorBindings.SetDepthWriteEnabled, value);
    }
    #endregion

    #region Specifying stencil descriptors for primitives - Properties

    /// <summary>
    /// The stencil descriptor for back-facing primitives.
    /// </summary>
    public MTLStencilDescriptor BackFaceStencil
    {
        get => GetProperty(ref field, MTLDepthStencilDescriptorBindings.BackFaceStencil);
        set => SetProperty(ref field, MTLDepthStencilDescriptorBindings.SetBackFaceStencil, value);
    }

    /// <summary>
    /// The stencil descriptor for front-facing primitives.
    /// </summary>
    public MTLStencilDescriptor FrontFaceStencil
    {
        get => GetProperty(ref field, MTLDepthStencilDescriptorBindings.FrontFaceStencil);
        set => SetProperty(ref field, MTLDepthStencilDescriptorBindings.SetFrontFaceStencil, value);
    }
    #endregion

    #region Identifying properties - Properties

    /// <summary>
    /// A string that identifies this object.
    /// </summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLDepthStencilDescriptorBindings.Label);
        set => SetProperty(ref field, MTLDepthStencilDescriptorBindings.SetLabel, value);
    }
    #endregion

    /// <summary>
    /// Deprecated: please use isDepthWriteEnabled instead
    /// </summary>
    [Obsolete("please use isDepthWriteEnabled instead")]
    public Bool8 DepthWriteEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDepthStencilDescriptorBindings.DepthWriteEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLDepthStencilDescriptorBindings.SetDepthWriteEnabled, value);
    }
}

file static class MTLDepthStencilDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLDepthStencilDescriptor");

    public static readonly Selector BackFaceStencil = "backFaceStencil";

    public static readonly Selector DepthCompareFunction = "depthCompareFunction";

    public static readonly Selector DepthWriteEnabled = "isDepthWriteEnabled";

    public static readonly Selector FrontFaceStencil = "frontFaceStencil";

    public static readonly Selector IsDepthWriteEnabled = "isDepthWriteEnabled";

    public static readonly Selector Label = "label";

    public static readonly Selector SetBackFaceStencil = "setBackFaceStencil:";

    public static readonly Selector SetDepthCompareFunction = "setDepthCompareFunction:";

    public static readonly Selector SetDepthWriteEnabled = "setDepthWriteEnabled:";

    public static readonly Selector SetFrontFaceStencil = "setFrontFaceStencil:";

    public static readonly Selector SetLabel = "setLabel:";
}
