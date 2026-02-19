namespace Metal.NET;

public class MTLVisibleFunctionTable(nint nativePtr, bool owned) : MTLResource(nativePtr, owned)
{
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
