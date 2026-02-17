namespace Metal.NET;

public class MTLLibrary : IDisposable
{
    public MTLLibrary(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLLibrary()
    {
        Release();
    }

    public nint NativePtr { get; }

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

    public void NewFunction(NSString pFunctionName, MTLFunctionConstantValues pConstantValues, int completionHandler)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLLibrarySelector.NewFunctionPConstantValuesCompletionHandler, pFunctionName.NativePtr, pConstantValues.NativePtr, completionHandler);
    }

    public void NewFunction(MTLFunctionDescriptor pDescriptor, int completionHandler)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLLibrarySelector.NewFunctionCompletionHandler, pDescriptor.NativePtr, completionHandler);
    }

    public MTLFunction NewIntersectionFunction(MTLIntersectionFunctionDescriptor descriptor, out NSError? error)
    {
        MTLFunction result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.NewIntersectionFunctionError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public void NewIntersectionFunction(MTLIntersectionFunctionDescriptor pDescriptor, int completionHandler)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLLibrarySelector.NewIntersectionFunctionCompletionHandler, pDescriptor.NativePtr, completionHandler);
    }

    public MTLFunctionReflection ReflectionForFunction(NSString functionName)
    {
        MTLFunctionReflection result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.ReflectionForFunction, functionName.NativePtr));

        return result;
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLLibrarySelector.SetLabel, label.NativePtr);
    }

}

file class MTLLibrarySelector
{
    public static readonly Selector NewFunction = Selector.Register("newFunction:");

    public static readonly Selector NewFunctionConstantValuesError = Selector.Register("newFunction:constantValues:error:");

    public static readonly Selector NewFunctionError = Selector.Register("newFunction:error:");

    public static readonly Selector NewFunctionPConstantValuesCompletionHandler = Selector.Register("newFunction:pConstantValues:completionHandler:");

    public static readonly Selector NewFunctionCompletionHandler = Selector.Register("newFunction:completionHandler:");

    public static readonly Selector NewIntersectionFunctionError = Selector.Register("newIntersectionFunction:error:");

    public static readonly Selector NewIntersectionFunctionCompletionHandler = Selector.Register("newIntersectionFunction:completionHandler:");

    public static readonly Selector ReflectionForFunction = Selector.Register("reflectionForFunction:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
