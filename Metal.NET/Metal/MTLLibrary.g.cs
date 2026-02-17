#nullable enable

namespace Metal.NET;

file class MTLLibrarySelector
{
    public static readonly Selector NewFunction_ = Selector.Register("newFunction:");
    public static readonly Selector NewFunction_constantValues_error_ = Selector.Register("newFunction:constantValues:error:");
    public static readonly Selector NewFunction_error_ = Selector.Register("newFunction:error:");
    public static readonly Selector NewFunction_pConstantValues_completionHandler_ = Selector.Register("newFunction:pConstantValues:completionHandler:");
    public static readonly Selector NewFunction_completionHandler_ = Selector.Register("newFunction:completionHandler:");
    public static readonly Selector NewIntersectionFunction_error_ = Selector.Register("newIntersectionFunction:error:");
    public static readonly Selector NewIntersectionFunction_completionHandler_ = Selector.Register("newIntersectionFunction:completionHandler:");
    public static readonly Selector ReflectionForFunction_ = Selector.Register("reflectionForFunction:");
    public static readonly Selector SetLabel_ = Selector.Register("setLabel:");
}

public class MTLLibrary : IDisposable
{
    public MTLLibrary(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        var result = new MTLFunction(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLLibrarySelector.NewFunction_, functionName.NativePtr));

        return result;
    }

    public MTLFunction NewFunction(NSString name, MTLFunctionConstantValues constantValues, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLFunction(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLLibrarySelector.NewFunction_constantValues_error_, name.NativePtr, constantValues.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLFunction NewFunction(MTLFunctionDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLFunction(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLLibrarySelector.NewFunction_error_, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public void NewFunction(NSString pFunctionName, MTLFunctionConstantValues pConstantValues, nint completionHandler)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLibrarySelector.NewFunction_pConstantValues_completionHandler_, pFunctionName.NativePtr, pConstantValues.NativePtr, completionHandler);
    }

    public void NewFunction(MTLFunctionDescriptor pDescriptor, nint completionHandler)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLibrarySelector.NewFunction_completionHandler_, pDescriptor.NativePtr, completionHandler);
    }

    public MTLFunction NewIntersectionFunction(MTLIntersectionFunctionDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLFunction(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLLibrarySelector.NewIntersectionFunction_error_, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public void NewIntersectionFunction(MTLIntersectionFunctionDescriptor pDescriptor, nint completionHandler)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLibrarySelector.NewIntersectionFunction_completionHandler_, pDescriptor.NativePtr, completionHandler);
    }

    public MTLFunctionReflection ReflectionForFunction(NSString functionName)
    {
        var result = new MTLFunctionReflection(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLLibrarySelector.ReflectionForFunction_, functionName.NativePtr));

        return result;
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLibrarySelector.SetLabel_, label.NativePtr);
    }

}
