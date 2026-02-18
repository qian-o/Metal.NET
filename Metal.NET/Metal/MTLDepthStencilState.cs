namespace Metal.NET;

public class MTLDepthStencilState(nint nativePtr) : NativeObject(nativePtr)
{

    public MTLDevice? Device
    {
        get => GetNullableObject<MTLDevice>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDepthStencilStateSelector.Device));
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLDepthStencilStateSelector.GpuResourceID);
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDepthStencilStateSelector.Label));
    }
}

file static class MTLDepthStencilStateSelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector Label = Selector.Register("label");
}
