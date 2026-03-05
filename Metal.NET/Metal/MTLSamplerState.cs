namespace Metal.NET;

public class MTLSamplerState(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLSamplerState>
{
    #region INativeObject
    public static new MTLSamplerState Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLSamplerState New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLSamplerStateBindings.Device);
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLSamplerStateBindings.GpuResourceID);
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
