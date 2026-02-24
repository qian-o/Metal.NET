namespace Metal.NET;

public class MTLVisibleFunctionTable(nint nativePtr) : MTLResource(nativePtr), INativeObject<MTLVisibleFunctionTable>
{
    public static new MTLVisibleFunctionTable Create(nint nativePtr) => new(nativePtr);

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLVisibleFunctionTableBindings.GpuResourceID);
    }

    public void SetFunction(MTLFunctionHandle function, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLVisibleFunctionTableBindings.SetFunction, function.NativePtr, index);
    }
}

file static class MTLVisibleFunctionTableBindings
{
    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector SetFunction = "setFunction:atIndex:";
}
