namespace Metal.NET;

public class MTLFunctionHandle(nint nativePtr) : NativeObject(nativePtr)
{

    public MTLDevice? Device
    {
        get => GetNullableObject<MTLDevice>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionHandleSelector.Device));
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
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionHandleSelector.Name));
    }
}

file static class MTLFunctionHandleSelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector FunctionType = Selector.Register("functionType");

    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector Name = Selector.Register("name");
}
