namespace Metal.NET;

public readonly struct MTLVisibleFunctionTable(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

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
    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector SetFunction = Selector.Register("setFunction:atIndex:");
}
