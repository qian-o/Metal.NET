namespace Metal.NET;

public class MTLVisibleFunctionTable(nint nativePtr, NativeObjectOwnership ownership) : MTLResource(nativePtr, ownership), INativeObject<MTLVisibleFunctionTable>
{
    #region INativeObject
    public static new MTLVisibleFunctionTable Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLVisibleFunctionTable New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLVisibleFunctionTableBindings.GpuResourceID);
    }

    public void SetFunctionAtIndex(MTLFunctionHandle function, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLVisibleFunctionTableBindings.SetFunction, function.NativePtr, index);
    }

    public void SetFunction(MTLFunctionHandle function, nuint index)
    {
        SetFunctionAtIndex(function, index);
    }
}

file static class MTLVisibleFunctionTableBindings
{
    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector SetFunction = "setFunction:atIndex:";
}
