namespace Metal.NET;

public readonly struct MTLSamplerState(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSamplerStateBindings.Device);
            return ptr is not 0 ? new MTLDevice(ptr) : default;
        }
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLSamplerStateBindings.GpuResourceID);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSamplerStateBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
    }
}

file static class MTLSamplerStateBindings
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector Label = Selector.Register("label");
}
