namespace Metal.NET;

public class MTLVisibleFunctionTable(nint nativePtr) : MTLResource(nativePtr)
{
    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLVisibleFunctionTableSelector.GpuResourceID);
    }

    public static implicit operator nint(MTLVisibleFunctionTable value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLVisibleFunctionTable(nint value)
    {
        return new(value);
    }

    public void SetFunction(MTLFunctionHandle function, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLVisibleFunctionTableSelector.SetFunctionAtIndex, function.NativePtr, index);
    }
}

file class MTLVisibleFunctionTableSelector
{
    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector SetFunctionAtIndex = Selector.Register("setFunction:atIndex:");
}
