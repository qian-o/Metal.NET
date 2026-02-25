namespace Metal.NET;

public class MTLVisibleFunctionTable(nint nativePtr, bool ownsReference = true) : MTLResource(nativePtr, ownsReference), INativeObject<MTLVisibleFunctionTable>
{
    public static new MTLVisibleFunctionTable Create(nint nativePtr) => new(nativePtr);

    public static new MTLVisibleFunctionTable CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

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
