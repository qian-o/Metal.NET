namespace Metal.NET;

public class MTLSamplerState(nint nativePtr) : NativeObject(nativePtr)
{

    public MTLDevice? Device
    {
        get => GetNullableObject<MTLDevice>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSamplerStateSelector.Device));
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLSamplerStateSelector.GpuResourceID);
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSamplerStateSelector.Label));
    }
}

file static class MTLSamplerStateSelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector Label = Selector.Register("label");
}
