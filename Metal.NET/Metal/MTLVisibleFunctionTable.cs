namespace Metal.NET;

public class MTLVisibleFunctionTable(nint nativePtr, bool ownsReference, bool allowGCRelease) : MTLResource(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLVisibleFunctionTable>
{
    public static new MTLVisibleFunctionTable Null { get; } = new(0, false, false);

    public static new MTLVisibleFunctionTable Create(nint nativePtr, bool ownsReference, bool allowGCRelease) => new(nativePtr, ownsReference, allowGCRelease);

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
