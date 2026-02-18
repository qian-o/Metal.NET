namespace Metal.NET;

public class MTLLibrary : IDisposable
{
    public MTLLibrary(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLLibrary()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLDevice Device
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.Device));
    }

    public NSArray FunctionNames
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.FunctionNames));
    }

    public NSString InstallName
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.InstallName));
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLLibrarySelector.SetLabel, value.NativePtr);
    }

    public MTLLibraryType Type
    {
        get => (MTLLibraryType)(ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLLibrarySelector.Type));
    }

    public MTLFunction NewFunction(NSString functionName)
    {
        MTLFunction result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.NewFunction, functionName.NativePtr));

        return result;
    }

    public MTLFunction NewFunction(NSString name, MTLFunctionConstantValues constantValues, out NSError? error)
    {
        MTLFunction result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.NewFunctionConstantValuesError, name.NativePtr, constantValues.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLFunction NewFunction(MTLFunctionDescriptor descriptor, out NSError? error)
    {
        MTLFunction result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.NewFunctionError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public void NewFunction(NSString pFunctionName, MTLFunctionConstantValues pConstantValues, nint completionHandler)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLLibrarySelector.NewFunctionPConstantValuesCompletionHandler, pFunctionName.NativePtr, pConstantValues.NativePtr, completionHandler);
    }

    public void NewFunction(MTLFunctionDescriptor pDescriptor, nint completionHandler)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLLibrarySelector.NewFunctionCompletionHandler, pDescriptor.NativePtr, completionHandler);
    }

    public MTLFunction NewIntersectionFunction(MTLIntersectionFunctionDescriptor descriptor, out NSError? error)
    {
        MTLFunction result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.NewIntersectionFunctionError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public void NewIntersectionFunction(MTLIntersectionFunctionDescriptor pDescriptor, nint completionHandler)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLLibrarySelector.NewIntersectionFunctionCompletionHandler, pDescriptor.NativePtr, completionHandler);
    }

    public MTLFunctionReflection ReflectionForFunction(NSString functionName)
    {
        MTLFunctionReflection result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.ReflectionForFunction, functionName.NativePtr));

        return result;
    }

    public static implicit operator nint(MTLLibrary value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLLibrary(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTLLibrarySelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector FunctionNames = Selector.Register("functionNames");

    public static readonly Selector InstallName = Selector.Register("installName");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector Type = Selector.Register("type");

    public static readonly Selector NewFunction = Selector.Register("newFunction:");

    public static readonly Selector NewFunctionConstantValuesError = Selector.Register("newFunction:constantValues:error:");

    public static readonly Selector NewFunctionError = Selector.Register("newFunction:error:");

    public static readonly Selector NewFunctionPConstantValuesCompletionHandler = Selector.Register("newFunction:pConstantValues:completionHandler:");

    public static readonly Selector NewFunctionCompletionHandler = Selector.Register("newFunction:completionHandler:");

    public static readonly Selector NewIntersectionFunctionError = Selector.Register("newIntersectionFunction:error:");

    public static readonly Selector NewIntersectionFunctionCompletionHandler = Selector.Register("newIntersectionFunction:completionHandler:");

    public static readonly Selector ReflectionForFunction = Selector.Register("reflectionForFunction:");
}
