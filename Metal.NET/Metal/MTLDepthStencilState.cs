namespace Metal.NET;

public class MTLDepthStencilState(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLDepthStencilState>
{
    public static MTLDepthStencilState Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLDepthStencilStateBindings.Device);
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLDepthStencilStateBindings.GpuResourceID);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLDepthStencilStateBindings.Label);
    }
}

file static class MTLDepthStencilStateBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector Label = "label";
}
