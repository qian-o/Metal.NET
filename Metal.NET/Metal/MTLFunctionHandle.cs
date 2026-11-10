namespace Metal.NET;

public readonly struct MTLFunctionHandle(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLFunctionHandle value) => new(value.NativePtr);

    public MTLFunctionHandle Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLFunctionType FunctionType
    {
        get => (MTLFunctionType)ObjectiveC.MsgSendULong(NativePtr, MTLFunctionHandleBindings.FunctionType);
    }

    public NSString Name
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionHandleBindings.Name));
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionHandleBindings.Device));
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLFunctionHandleBindings.GpuResourceID);
    }
}

file static class MTLFunctionHandleBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector FunctionType = "functionType";

    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector Name = "name";
}
