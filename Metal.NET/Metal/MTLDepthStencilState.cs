namespace Metal.NET;

public class MTLDepthStencilState(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLDepthStencilState>
{
    #region INativeObject
    public static new MTLDepthStencilState Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLDepthStencilState New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSString Label
    {
        get => GetProperty(ref field, MTLDepthStencilStateBindings.Label);
    }

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLDepthStencilStateBindings.Device);
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLDepthStencilStateBindings.GpuResourceID);
    }
}

file static class MTLDepthStencilStateBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector Label = "label";
}
