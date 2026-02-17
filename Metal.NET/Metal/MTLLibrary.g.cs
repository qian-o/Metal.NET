using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLLibrary_Selectors
{
    internal static readonly Selector newFunction_ = Selector.Register("newFunction:");
    internal static readonly Selector newFunction_constantValues_error_ = Selector.Register("newFunction:constantValues:error:");
    internal static readonly Selector newFunction_error_ = Selector.Register("newFunction:error:");
    internal static readonly Selector newFunction_pConstantValues_completionHandler_ = Selector.Register("newFunction:pConstantValues:completionHandler:");
    internal static readonly Selector newFunction_completionHandler_ = Selector.Register("newFunction:completionHandler:");
    internal static readonly Selector newIntersectionFunction_error_ = Selector.Register("newIntersectionFunction:error:");
    internal static readonly Selector newIntersectionFunction_completionHandler_ = Selector.Register("newIntersectionFunction:completionHandler:");
    internal static readonly Selector reflectionForFunction_ = Selector.Register("reflectionForFunction:");
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
}

public class MTLLibrary : IDisposable
{
    public nint NativePtr { get; }

    public MTLLibrary(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLLibrary o) => o.NativePtr;
    public static implicit operator MTLLibrary(nint ptr) => new MTLLibrary(ptr);

    ~MTLLibrary() => Release();

    public void Dispose()
    {
        Release();
        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr != 0)
            ObjectiveCRuntime.Release(NativePtr);
    }

    public MTLFunction NewFunction(NSString functionName)
    {
        var __r = new MTLFunction(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLLibrary_Selectors.newFunction_, functionName.NativePtr));
        return __r;
    }

    public MTLFunction NewFunction(NSString name, MTLFunctionConstantValues constantValues, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLFunction(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLLibrary_Selectors.newFunction_constantValues_error_, name.NativePtr, constantValues.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLFunction NewFunction(MTLFunctionDescriptor descriptor, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLFunction(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLLibrary_Selectors.newFunction_error_, descriptor.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public void NewFunction(NSString pFunctionName, MTLFunctionConstantValues pConstantValues, nint completionHandler)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLibrary_Selectors.newFunction_pConstantValues_completionHandler_, pFunctionName.NativePtr, pConstantValues.NativePtr, completionHandler);
    }

    public void NewFunction(MTLFunctionDescriptor pDescriptor, nint completionHandler)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLibrary_Selectors.newFunction_completionHandler_, pDescriptor.NativePtr, completionHandler);
    }

    public MTLFunction NewIntersectionFunction(MTLIntersectionFunctionDescriptor descriptor, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLFunction(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLLibrary_Selectors.newIntersectionFunction_error_, descriptor.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public void NewIntersectionFunction(MTLIntersectionFunctionDescriptor pDescriptor, nint completionHandler)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLibrary_Selectors.newIntersectionFunction_completionHandler_, pDescriptor.NativePtr, completionHandler);
    }

    public MTLFunctionReflection ReflectionForFunction(NSString functionName)
    {
        var __r = new MTLFunctionReflection(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLLibrary_Selectors.reflectionForFunction_, functionName.NativePtr));
        return __r;
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLibrary_Selectors.setLabel_, label.NativePtr);
    }

}
