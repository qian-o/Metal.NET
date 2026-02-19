namespace Metal.NET;

public readonly struct MTLFunctionHandle(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionHandleBindings.Device);
            return ptr is not 0 ? new MTLDevice(ptr) : default;
        }
    }

    public MTLFunctionType FunctionType
    {
        get => (MTLFunctionType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionHandleBindings.FunctionType);
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLFunctionHandleBindings.GpuResourceID);
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionHandleBindings.Name);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
    }
}

file static class MTLFunctionHandleBindings
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector FunctionType = Selector.Register("functionType");

    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector Name = Selector.Register("name");
}
