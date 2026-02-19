namespace Metal.NET;

public readonly struct MTLLibrary(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.Device);
            return ptr is not 0 ? new MTLDevice(ptr) : default;
        }
    }

    public NSArray? FunctionNames
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.FunctionNames);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
    }

    public NSString? InstallName
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.InstallName);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLLibraryBindings.SetLabel, value?.NativePtr ?? 0);
    }

    public MTLLibraryType Type
    {
        get => (MTLLibraryType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.Type);
    }

    public MTLFunction? NewFunction(NSString functionName)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.NewFunction, functionName.NativePtr);
        return ptr is not 0 ? new MTLFunction(ptr) : default;
    }

    public MTLFunction? NewFunction(NSString name, MTLFunctionConstantValues constantValues, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.NewFunction, name.NativePtr, constantValues.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLFunction(ptr) : default;
    }

    public MTLFunction? NewFunction(MTLFunctionDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.NewFunction, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLFunction(ptr) : default;
    }

    public MTLFunction? NewIntersectionFunction(MTLIntersectionFunctionDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.NewIntersectionFunction, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLFunction(ptr) : default;
    }

    public MTLFunctionReflection? ReflectionForFunction(NSString functionName)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.ReflectionForFunction, functionName.NativePtr);
        return ptr is not 0 ? new MTLFunctionReflection(ptr) : default;
    }
}

file static class MTLLibraryBindings
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector FunctionNames = Selector.Register("functionNames");

    public static readonly Selector InstallName = Selector.Register("installName");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector NewFunction = Selector.Register("newFunctionWithName:");

    public static readonly Selector NewIntersectionFunction = Selector.Register("newIntersectionFunctionWithDescriptor:error:");

    public static readonly Selector ReflectionForFunction = Selector.Register("reflectionForFunctionWithName:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector Type = Selector.Register("type");
}
