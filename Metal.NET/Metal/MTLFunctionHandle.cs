namespace Metal.NET;

public class MTLFunctionHandle(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFunctionHandle>
{
    #region INativeObject
    public static new MTLFunctionHandle Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFunctionHandle New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLFunctionHandleBindings.Device);
    }

    public MTLFunctionType FunctionType
    {
        get => (MTLFunctionType)ObjectiveC.MsgSendULong(NativePtr, MTLFunctionHandleBindings.FunctionType);
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLFunctionHandleBindings.GpuResourceID);
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
