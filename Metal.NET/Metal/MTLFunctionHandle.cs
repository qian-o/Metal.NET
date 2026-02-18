namespace Metal.NET;

public partial class MTLFunctionHandle : NativeObject
{
    public MTLFunctionHandle(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionHandleSelector.Device);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLFunctionType FunctionType
    {
        get => (MTLFunctionType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionHandleSelector.FunctionType);
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLFunctionHandleSelector.GpuResourceID);
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionHandleSelector.Name);
            return ptr is not 0 ? new(ptr) : null;
        }
    }
}

file static class MTLFunctionHandleSelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector FunctionType = Selector.Register("functionType");

    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector Name = Selector.Register("name");
}
