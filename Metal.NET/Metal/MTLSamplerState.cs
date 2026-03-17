namespace Metal.NET;

/// <summary>
/// An instance that defines how a texture should be sampled.
/// </summary>
public class MTLSamplerState(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLSamplerState>
{
    #region INativeObject
    public static new MTLSamplerState Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLSamplerState New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Identifying the sampler - Properties

    /// <summary>
    /// The device object that created the sampler.
    /// </summary>
    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLSamplerStateBindings.Device);
    }

    /// <summary>
    /// A string that identifies the sampler.
    /// </summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLSamplerStateBindings.Label);
    }
    #endregion

    #region Instance Properties - Properties

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLSamplerStateBindings.GpuResourceID);
    }
    #endregion
}

file static class MTLSamplerStateBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector Label = "label";
}
