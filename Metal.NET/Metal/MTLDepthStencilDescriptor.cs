namespace Metal.NET;

public class MTLDepthStencilDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLDepthStencilDescriptor>
{
    public static MTLDepthStencilDescriptor Null { get; } = new(0, false);

    public static MTLDepthStencilDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLDepthStencilDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLDepthStencilDescriptorBindings.Class), true)
    {
    }

    public MTLStencilDescriptor BackFaceStencil
    {
        get => GetProperty(ref field, MTLDepthStencilDescriptorBindings.BackFaceStencil);
        set => SetProperty(ref field, MTLDepthStencilDescriptorBindings.SetBackFaceStencil, value);
    }

    public MTLCompareFunction DepthCompareFunction
    {
        get => (MTLCompareFunction)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDepthStencilDescriptorBindings.DepthCompareFunction);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLDepthStencilDescriptorBindings.SetDepthCompareFunction, (nuint)value);
    }

    public Bool8 DepthWriteEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDepthStencilDescriptorBindings.DepthWriteEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLDepthStencilDescriptorBindings.SetDepthWriteEnabled, value);
    }

    public MTLStencilDescriptor FrontFaceStencil
    {
        get => GetProperty(ref field, MTLDepthStencilDescriptorBindings.FrontFaceStencil);
        set => SetProperty(ref field, MTLDepthStencilDescriptorBindings.SetFrontFaceStencil, value);
    }

    public Bool8 IsDepthWriteEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDepthStencilDescriptorBindings.IsDepthWriteEnabled);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLDepthStencilDescriptorBindings.Label);
        set => SetProperty(ref field, MTLDepthStencilDescriptorBindings.SetLabel, value);
    }
}

file static class MTLDepthStencilDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLDepthStencilDescriptor");

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
