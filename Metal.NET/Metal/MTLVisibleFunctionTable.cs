namespace Metal.NET;

public partial class MTLVisibleFunctionTable : NativeObject
{
    public MTLVisibleFunctionTable(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLVisibleFunctionTableSelector.GpuResourceID);
    }

    public void SetFunction(MTLFunctionHandle function, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLVisibleFunctionTableSelector.SetFunction, function.NativePtr, index);
    }
}

file static class MTLVisibleFunctionTableSelector
{
    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector SetFunction = Selector.Register("setFunction::");
}
