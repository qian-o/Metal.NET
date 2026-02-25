namespace Metal.NET;

public class MTLFunctionHandle(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLFunctionHandle>
{
    public static MTLFunctionHandle Null => Create(0, false);
    public static MTLFunctionHandle Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLFunctionHandleBindings.Device);
    }

    public MTLFunctionType FunctionType
    {
        get => (MTLFunctionType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionHandleBindings.FunctionType);
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLFunctionHandleBindings.GpuResourceID);
    }

    public NSString Name
    {
        get => GetProperty(ref field, MTLFunctionHandleBindings.Name);
    }
}

file static class MTLFunctionHandleBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector FunctionType = "functionType";

    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector Name = "name";
}
