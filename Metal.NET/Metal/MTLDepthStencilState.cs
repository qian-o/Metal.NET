namespace Metal.NET;

public partial class MTLDepthStencilState : NativeObject
{
    public MTLDepthStencilState(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDepthStencilStateSelector.Device);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLDepthStencilStateSelector.GpuResourceID);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDepthStencilStateSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
    }
}

file static class MTLDepthStencilStateSelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector Label = Selector.Register("label");
}
