namespace Metal.NET;

public partial class MTLSamplerState : NativeObject
{
    public MTLSamplerState(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSamplerStateSelector.Device);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLSamplerStateSelector.GpuResourceID);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSamplerStateSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
    }
}

file static class MTLSamplerStateSelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector Label = Selector.Register("label");
}
