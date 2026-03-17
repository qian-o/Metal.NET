namespace Metal.NET;

/// <summary>
/// A table of shader functions visible to your app that you can pass into compute commands to customize the behavior of a shader.
/// </summary>
public class MTLVisibleFunctionTable(nint nativePtr, NativeObjectOwnership ownership) : MTLResource(nativePtr, ownership), INativeObject<MTLVisibleFunctionTable>
{
    #region INativeObject
    public static new MTLVisibleFunctionTable Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLVisibleFunctionTable New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Instance Properties - Properties

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLVisibleFunctionTableBindings.GpuResourceID);
    }
    #endregion

    #region Setting a table entry - Methods

    /// <summary>
    /// Sets a table entry to point to a callable function.
    /// </summary>
    public void SetFunction(MTLFunctionHandle function, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLVisibleFunctionTableBindings.SetFunction, function.NativePtr, index);
    }
    #endregion
}

file static class MTLVisibleFunctionTableBindings
{
    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector SetFunction = "setFunction:atIndex:";
}
