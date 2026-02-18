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
        get => (MTLLibraryType)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLLibrarySelector.Type);
    }

    public static implicit operator nint(MTLLibrary value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLLibrary(nint value)
    {
        return new(value);
    }

    public MTLFunction NewFunction(NSString functionName)
    {
        MTLFunction result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.NewFunctionWithName, functionName.NativePtr));

        return result;
    }

    public MTLFunction NewFunction(NSString name, MTLFunctionConstantValues constantValues, out NSError? error)
    {
        MTLFunction result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.NewFunctionWithNameConstantValuesError, name.NativePtr, constantValues.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLFunction NewFunction(MTLFunctionDescriptor descriptor, out NSError? error)
    {
        MTLFunction result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.NewFunctionWithDescriptorError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLFunction NewIntersectionFunction(MTLIntersectionFunctionDescriptor descriptor, out NSError? error)
    {
        MTLFunction result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.NewIntersectionFunctionWithDescriptorError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLFunctionReflection ReflectionForFunction(NSString functionName)
    {
        MTLFunctionReflection result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.ReflectionForFunctionWithName, functionName.NativePtr));

        return result;
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

    public static readonly Selector NewFunctionWithName = Selector.Register("newFunctionWithName:");

    public static readonly Selector NewFunctionWithNameConstantValuesError = Selector.Register("newFunctionWithName:constantValues:error:");

    public static readonly Selector NewFunctionWithDescriptorError = Selector.Register("newFunctionWithDescriptor:error:");

    public static readonly Selector NewIntersectionFunctionWithDescriptorError = Selector.Register("newIntersectionFunctionWithDescriptor:error:");

    public static readonly Selector ReflectionForFunctionWithName = Selector.Register("reflectionForFunctionWithName:");
}
