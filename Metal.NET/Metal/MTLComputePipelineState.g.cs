using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLComputePipelineState_Selectors
{
    internal static readonly Selector functionHandle_ = Selector.Register("functionHandle:");
    internal static readonly Selector newComputePipelineStateWithBinaryFunctions_error_ = Selector.Register("newComputePipelineStateWithBinaryFunctions:error:");
    internal static readonly Selector newComputePipelineState_error_ = Selector.Register("newComputePipelineState:error:");
    internal static readonly Selector newIntersectionFunctionTable_ = Selector.Register("newIntersectionFunctionTable:");
    internal static readonly Selector newVisibleFunctionTable_ = Selector.Register("newVisibleFunctionTable:");
}

public class MTLComputePipelineState : IDisposable
{
    public nint NativePtr { get; }

    public MTLComputePipelineState(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLComputePipelineState o) => o.NativePtr;
    public static implicit operator MTLComputePipelineState(nint ptr) => new MTLComputePipelineState(ptr);

    ~MTLComputePipelineState() => Release();

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

    public MTLFunctionHandle FunctionHandle(NSString name)
    {
        var __r = new MTLFunctionHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLComputePipelineState_Selectors.functionHandle_, name.NativePtr));
        return __r;
    }

    public MTLFunctionHandle FunctionHandle(MTL4BinaryFunction function)
    {
        var __r = new MTLFunctionHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLComputePipelineState_Selectors.functionHandle_, function.NativePtr));
        return __r;
    }

    public MTLFunctionHandle FunctionHandle(MTLFunction function)
    {
        var __r = new MTLFunctionHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLComputePipelineState_Selectors.functionHandle_, function.NativePtr));
        return __r;
    }

    public MTLComputePipelineState NewComputePipelineStateWithBinaryFunctions(NSArray additionalBinaryFunctions, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLComputePipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLComputePipelineState_Selectors.newComputePipelineStateWithBinaryFunctions_error_, additionalBinaryFunctions.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLComputePipelineState NewComputePipelineState(NSArray functions, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLComputePipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLComputePipelineState_Selectors.newComputePipelineState_error_, functions.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLIntersectionFunctionTable NewIntersectionFunctionTable(MTLIntersectionFunctionTableDescriptor descriptor)
    {
        var __r = new MTLIntersectionFunctionTable(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLComputePipelineState_Selectors.newIntersectionFunctionTable_, descriptor.NativePtr));
        return __r;
    }

    public MTLVisibleFunctionTable NewVisibleFunctionTable(MTLVisibleFunctionTableDescriptor descriptor)
    {
        var __r = new MTLVisibleFunctionTable(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLComputePipelineState_Selectors.newVisibleFunctionTable_, descriptor.NativePtr));
        return __r;
    }

}
