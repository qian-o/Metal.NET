namespace Metal.NET;

public partial class MTLLibrary : NativeObject
{
    public MTLLibrary(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.Device);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public NSArray? FunctionNames
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.FunctionNames);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public NSString? InstallName
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.InstallName);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLLibrarySelector.SetLabel, value?.NativePtr ?? 0);
    }

    public MTLLibraryType Type
    {
        get => (MTLLibraryType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.Type);
    }

    public MTLFunction? NewFunction(NSString functionName)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.NewFunction, functionName.NativePtr);
        return ptr is not 0 ? new(ptr) : null;
    }

    public MTLFunction? NewFunction(NSString name, MTLFunctionConstantValues constantValues, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.NewFunction, name.NativePtr, constantValues.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new(errorPtr) : null;
        return ptr is not 0 ? new(ptr) : null;
    }

    public MTLFunction? NewIntersectionFunction(MTLIntersectionFunctionDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.NewIntersectionFunction, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new(errorPtr) : null;
        return ptr is not 0 ? new(ptr) : null;
    }

    public MTLFunctionReflection? ReflectionForFunction(NSString functionName)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.ReflectionForFunction, functionName.NativePtr);
        return ptr is not 0 ? new(ptr) : null;
    }
}

file static class MTLLibrarySelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector FunctionNames = Selector.Register("functionNames");

    public static readonly Selector InstallName = Selector.Register("installName");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector NewFunction = Selector.Register("newFunction:");

    public static readonly Selector NewIntersectionFunction = Selector.Register("newIntersectionFunction:::");

    public static readonly Selector ReflectionForFunction = Selector.Register("reflectionForFunction:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector Type = Selector.Register("type");
}
