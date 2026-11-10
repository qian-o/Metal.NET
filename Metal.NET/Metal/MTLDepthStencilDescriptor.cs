namespace Metal.NET;

public readonly struct MTLDepthStencilDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLDepthStencilDescriptor value) => new(value.NativePtr);

    public MTLDepthStencilDescriptor() : this(ObjectiveC.AllocInit(MTLDepthStencilDescriptorBindings.Class))
    {
    }

    public MTLDepthStencilDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLCompareFunction DepthCompareFunction
    {
        get => (MTLCompareFunction)ObjectiveC.MsgSendULong(NativePtr, MTLDepthStencilDescriptorBindings.DepthCompareFunction);
        set => ObjectiveC.MsgSend(NativePtr, MTLDepthStencilDescriptorBindings.SetDepthCompareFunction, (nuint)value);
    }

    public Bool8 IsDepthWriteEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDepthStencilDescriptorBindings.IsDepthWriteEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLDepthStencilDescriptorBindings.SetDepthWriteEnabled, value);
    }

    public MTLStencilDescriptor FrontFaceStencil
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLDepthStencilDescriptorBindings.FrontFaceStencil));
        set => ObjectiveC.MsgSend(NativePtr, MTLDepthStencilDescriptorBindings.SetFrontFaceStencil, value.NativePtr);
    }

    public MTLStencilDescriptor BackFaceStencil
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLDepthStencilDescriptorBindings.BackFaceStencil));
        set => ObjectiveC.MsgSend(NativePtr, MTLDepthStencilDescriptorBindings.SetBackFaceStencil, value.NativePtr);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLDepthStencilDescriptorBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLDepthStencilDescriptorBindings.SetLabel, value.NativePtr);
    }
}

file static class MTLDepthStencilDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLDepthStencilDescriptor");

    public static readonly Selector BackFaceStencil = "backFaceStencil";

    public static readonly Selector DepthCompareFunction = "depthCompareFunction";

    public static readonly Selector FrontFaceStencil = "frontFaceStencil";

    public static readonly Selector IsDepthWriteEnabled = "isDepthWriteEnabled";

    public static readonly Selector Label = "label";

    public static readonly Selector SetBackFaceStencil = "setBackFaceStencil:";

    public static readonly Selector SetDepthCompareFunction = "setDepthCompareFunction:";

    public static readonly Selector SetDepthWriteEnabled = "setDepthWriteEnabled:";

    public static readonly Selector SetFrontFaceStencil = "setFrontFaceStencil:";

    public static readonly Selector SetLabel = "setLabel:";
}
