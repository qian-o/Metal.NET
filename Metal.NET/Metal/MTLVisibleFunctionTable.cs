namespace Metal.NET;

public class MTLVisibleFunctionTable(nint nativePtr, bool ownsReference) : MTLResource(nativePtr, ownsReference), INativeObject<MTLVisibleFunctionTable>
{
    public static new MTLVisibleFunctionTable Null { get; } = new(0, false);

    public static new MTLVisibleFunctionTable Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

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
