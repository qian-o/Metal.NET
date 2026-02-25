namespace Metal.NET;

public class MTLSamplerState(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLSamplerState>
{
    public static MTLSamplerState Create(nint nativePtr) => new(nativePtr, true);

    public static MTLSamplerState CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLSamplerStateBindings.Device);
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLSamplerStateBindings.GpuResourceID);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLSamplerStateBindings.Label);
    }
}

file static class MTLSamplerStateBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector Label = "label";
}
