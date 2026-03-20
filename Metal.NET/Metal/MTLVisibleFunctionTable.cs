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

    public void SetFunction(MTLFunctionHandle function, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLVisibleFunctionTableBindings.SetFunction_AtIndex, function.NativePtr, index);
    }

    public unsafe void SetFunctions(MTLFunctionHandle[] functions, NSRange range)
    {
        nint* pFunctions = stackalloc nint[functions.Length];
        for (int i = 0; i < functions.Length; i++)
        {
            pFunctions[i] = functions[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLVisibleFunctionTableBindings.SetFunctions_WithRange, (nint)pFunctions, range);
    }
}

file static class MTLVisibleFunctionTableBindings
{
    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector SetFunction_AtIndex = "setFunction:atIndex:";

    public static readonly Selector SetFunctions_WithRange = "setFunctions:withRange:";
}
