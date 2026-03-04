namespace Metal.NET;

public class MTLDepthStencilState(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTLDepthStencilState>
{
    #region INativeObject
    public static MTLDepthStencilState Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLDepthStencilState New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLDepthStencilStateBindings.Device);
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLDepthStencilStateBindings.GpuResourceID);
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
