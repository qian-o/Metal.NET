namespace Metal.NET;

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

    public MTLStencilDescriptor BackFaceStencil
    {
        get => GetProperty(ref field, MTLDepthStencilDescriptorBindings.BackFaceStencil);
        set => SetProperty(ref field, MTLDepthStencilDescriptorBindings.SetBackFaceStencil, value);
    }

    public MTLCompareFunction DepthCompareFunction
    {
        get => (MTLCompareFunction)ObjectiveC.MsgSendULong(NativePtr, MTLDepthStencilDescriptorBindings.DepthCompareFunction);
        set => ObjectiveC.MsgSend(NativePtr, MTLDepthStencilDescriptorBindings.SetDepthCompareFunction, (nuint)value);
    }

    /// <summary>Deprecated: please use isDepthWriteEnabled instead</summary>
    [Obsolete("please use isDepthWriteEnabled instead")]
    public Bool8 DepthWriteEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDepthStencilDescriptorBindings.DepthWriteEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLDepthStencilDescriptorBindings.SetDepthWriteEnabled, value);
    }

    public MTLStencilDescriptor FrontFaceStencil
    {
        get => GetProperty(ref field, MTLDepthStencilDescriptorBindings.FrontFaceStencil);
        set => SetProperty(ref field, MTLDepthStencilDescriptorBindings.SetFrontFaceStencil, value);
    }

    public Bool8 IsDepthWriteEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDepthStencilDescriptorBindings.IsDepthWriteEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLDepthStencilDescriptorBindings.SetIsDepthWriteEnabled, value);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLDepthStencilDescriptorBindings.Label);
        set => SetProperty(ref field, MTLDepthStencilDescriptorBindings.SetLabel, value);
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

    public static readonly Selector SetIsDepthWriteEnabled = "setDepthWriteEnabled:";

    public static readonly Selector SetLabel = "setLabel:";
}
