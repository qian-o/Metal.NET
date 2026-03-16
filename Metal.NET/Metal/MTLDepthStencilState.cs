namespace Metal.NET;

/// <summary>A depth and stencil state instance that specifies the depth and stencil configuration and operations used in a render pass.</summary>
public class MTLDepthStencilState(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLDepthStencilState>
{
    #region INativeObject
    public static new MTLDepthStencilState Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLDepthStencilState New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Identifying properties - Properties

    /// <summary>The device from which this state object was created.</summary>
    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLDepthStencilStateBindings.Device);
    }

    /// <summary>A string that identifies this object.</summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLDepthStencilStateBindings.Label);
    }
    #endregion

    #region Instance Properties - Properties

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLDepthStencilStateBindings.GpuResourceID);
    }
    #endregion
}

file static class MTLDepthStencilStateBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector Label = "label";
}
