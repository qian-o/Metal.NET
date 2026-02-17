namespace Metal.NET;

public class MTLDepthStencilDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLDepthStencilDescriptor");

    public MTLDepthStencilDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    public MTLDepthStencilDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLDepthStencilDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLStencilDescriptor BackFaceStencil
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDepthStencilDescriptorSelector.BackFaceStencil));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLDepthStencilDescriptorSelector.SetBackFaceStencil, value.NativePtr);
    }

    public MTLCompareFunction DepthCompareFunction
    {
        get => (MTLCompareFunction)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLDepthStencilDescriptorSelector.DepthCompareFunction));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLDepthStencilDescriptorSelector.SetDepthCompareFunction, (uint)value);
    }

    public Bool8 DepthWriteEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDepthStencilDescriptorSelector.DepthWriteEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLDepthStencilDescriptorSelector.SetDepthWriteEnabled, value);
    }

    public MTLStencilDescriptor FrontFaceStencil
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDepthStencilDescriptorSelector.FrontFaceStencil));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLDepthStencilDescriptorSelector.SetFrontFaceStencil, value.NativePtr);
    }

    public Bool8 IsDepthWriteEnabled => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDepthStencilDescriptorSelector.IsDepthWriteEnabled);

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDepthStencilDescriptorSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLDepthStencilDescriptorSelector.SetLabel, value.NativePtr);
    }

    public static implicit operator nint(MTLDepthStencilDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLDepthStencilDescriptor(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

}

file class MTLDepthStencilDescriptorSelector
{
    public static readonly Selector BackFaceStencil = Selector.Register("backFaceStencil");

    public static readonly Selector SetBackFaceStencil = Selector.Register("setBackFaceStencil:");

    public static readonly Selector DepthCompareFunction = Selector.Register("depthCompareFunction");

    public static readonly Selector SetDepthCompareFunction = Selector.Register("setDepthCompareFunction:");

    public static readonly Selector DepthWriteEnabled = Selector.Register("depthWriteEnabled");

    public static readonly Selector SetDepthWriteEnabled = Selector.Register("setDepthWriteEnabled:");

    public static readonly Selector FrontFaceStencil = Selector.Register("frontFaceStencil");

    public static readonly Selector SetFrontFaceStencil = Selector.Register("setFrontFaceStencil:");

    public static readonly Selector IsDepthWriteEnabled = Selector.Register("isDepthWriteEnabled");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
