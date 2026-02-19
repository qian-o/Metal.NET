namespace Metal.NET;

public class MTLLibrary(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLDevice? Device
    {
        get => GetProperty(ref field, MTLLibraryBindings.Device);
    }

    public NSArray? FunctionNames
    {
        get => GetProperty(ref field, MTLLibraryBindings.FunctionNames);
    }

    public NSString? InstallName
    {
        get => GetProperty(ref field, MTLLibraryBindings.InstallName);
    }

    public NSString? Label
    {
        get => GetProperty(ref field, MTLLibraryBindings.Label);
        set => SetProperty(ref field, MTLLibraryBindings.SetLabel, value);
    }

    public MTLLibraryType Type
    {
        get => (MTLLibraryType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.Type);
    }

    public MTLFunction? NewFunction(NSString functionName)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.NewFunction, functionName.NativePtr);
        return ptr is not 0 ? new MTLFunction(ptr) : null;
    }

    public MTLFunction? NewFunction(NSString name, MTLFunctionConstantValues constantValues, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.NewFunction, name.NativePtr, constantValues.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;
        return ptr is not 0 ? new MTLFunction(ptr) : null;
    }

    public MTLFunction? NewFunction(MTLFunctionDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.NewFunction, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;
        return ptr is not 0 ? new MTLFunction(ptr) : null;
    }

    public MTLFunction? NewIntersectionFunction(MTLIntersectionFunctionDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.NewIntersectionFunction, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;
        return ptr is not 0 ? new MTLFunction(ptr) : null;
    }

    public MTLFunctionReflection? ReflectionForFunction(NSString functionName)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.ReflectionForFunction, functionName.NativePtr);
        return ptr is not 0 ? new MTLFunctionReflection(ptr) : null;
    }
}

file static class MTLLibraryBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector FunctionNames = "functionNames";

    public static readonly Selector InstallName = "installName";

    public static readonly Selector Label = "label";

    public static readonly Selector NewFunction = "newFunctionWithName:";

    public static readonly Selector NewIntersectionFunction = "newIntersectionFunctionWithDescriptor:error:";

    public static readonly Selector ReflectionForFunction = "reflectionForFunctionWithName:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector Type = "type";
}
