namespace Metal.NET;

public class MTLRenderPassDepthAttachmentDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPassDepthAttachmentDescriptor");

    public MTLRenderPassDepthAttachmentDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    public MTLRenderPassDepthAttachmentDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLRenderPassDepthAttachmentDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public double ClearDepth
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, MTLRenderPassDepthAttachmentDescriptorSelector.ClearDepth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptorSelector.SetClearDepth, value);
    }

    public MTLMultisampleDepthResolveFilter DepthResolveFilter
    {
        get => (MTLMultisampleDepthResolveFilter)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLRenderPassDepthAttachmentDescriptorSelector.DepthResolveFilter));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptorSelector.SetDepthResolveFilter, (uint)value);
    }

    public static implicit operator nint(MTLRenderPassDepthAttachmentDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRenderPassDepthAttachmentDescriptor(nint value)
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

file class MTLRenderPassDepthAttachmentDescriptorSelector
{
    public static readonly Selector ClearDepth = Selector.Register("clearDepth");

    public static readonly Selector SetClearDepth = Selector.Register("setClearDepth:");

    public static readonly Selector DepthResolveFilter = Selector.Register("depthResolveFilter");

    public static readonly Selector SetDepthResolveFilter = Selector.Register("setDepthResolveFilter:");
}
