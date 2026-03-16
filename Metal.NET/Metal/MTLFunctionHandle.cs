namespace Metal.NET;

/// <summary>An object representing a function that you can add to a visible function table.</summary>
public class MTLFunctionHandle(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFunctionHandle>
{
    #region INativeObject
    public static new MTLFunctionHandle Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFunctionHandle New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Querying handle properties - Properties

    /// <summary>The device object that created the shader function.</summary>
    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLFunctionHandleBindings.Device);
    }

    /// <summary>The shader function’s type.</summary>
    public MTLFunctionType FunctionType
    {
        get => (MTLFunctionType)ObjectiveC.MsgSendULong(NativePtr, MTLFunctionHandleBindings.FunctionType);
    }

    /// <summary>The function’s name.</summary>
    public NSString Name
    {
        get => GetProperty(ref field, MTLFunctionHandleBindings.Name);
    }
    #endregion

    #region Instance Properties - Properties

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLFunctionHandleBindings.GpuResourceID);
    }
    #endregion
}

file static class MTLFunctionHandleBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector FunctionType = "functionType";

    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector Name = "name";
}
