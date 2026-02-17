using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLRenderPipelineState_Selectors
{
    internal static readonly Selector functionHandle_stage_ = Selector.Register("functionHandle:stage:");
    internal static readonly Selector newIntersectionFunctionTable_stage_ = Selector.Register("newIntersectionFunctionTable:stage:");
    internal static readonly Selector newRenderPipelineDescriptor = Selector.Register("newRenderPipelineDescriptor");
    internal static readonly Selector newRenderPipelineState_error_ = Selector.Register("newRenderPipelineState:error:");
    internal static readonly Selector newVisibleFunctionTable_stage_ = Selector.Register("newVisibleFunctionTable:stage:");
}

public class MTLRenderPipelineState : IDisposable
{
    public nint NativePtr { get; }

    public MTLRenderPipelineState(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLRenderPipelineState o) => o.NativePtr;
    public static implicit operator MTLRenderPipelineState(nint ptr) => new MTLRenderPipelineState(ptr);

    ~MTLRenderPipelineState() => Release();

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

    public MTLFunctionHandle FunctionHandle(NSString name, nuint stage)
    {
        var __r = new MTLFunctionHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRenderPipelineState_Selectors.functionHandle_stage_, name.NativePtr, (nint)stage));
        return __r;
    }

    public MTLFunctionHandle FunctionHandle(MTL4BinaryFunction function, nuint stage)
    {
        var __r = new MTLFunctionHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRenderPipelineState_Selectors.functionHandle_stage_, function.NativePtr, (nint)stage));
        return __r;
    }

    public MTLFunctionHandle FunctionHandle(MTLFunction function, nuint stage)
    {
        var __r = new MTLFunctionHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRenderPipelineState_Selectors.functionHandle_stage_, function.NativePtr, (nint)stage));
        return __r;
    }

    public MTLIntersectionFunctionTable NewIntersectionFunctionTable(MTLIntersectionFunctionTableDescriptor descriptor, nuint stage)
    {
        var __r = new MTLIntersectionFunctionTable(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRenderPipelineState_Selectors.newIntersectionFunctionTable_stage_, descriptor.NativePtr, (nint)stage));
        return __r;
    }

    public MTL4PipelineDescriptor NewRenderPipelineDescriptor()
    {
        var __r = new MTL4PipelineDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRenderPipelineState_Selectors.newRenderPipelineDescriptor));
        return __r;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTL4RenderPipelineBinaryFunctionsDescriptor binaryFunctionsDescriptor, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLRenderPipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRenderPipelineState_Selectors.newRenderPipelineState_error_, binaryFunctionsDescriptor.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTLRenderPipelineFunctionsDescriptor additionalBinaryFunctions, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLRenderPipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRenderPipelineState_Selectors.newRenderPipelineState_error_, additionalBinaryFunctions.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLVisibleFunctionTable NewVisibleFunctionTable(MTLVisibleFunctionTableDescriptor descriptor, nuint stage)
    {
        var __r = new MTLVisibleFunctionTable(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRenderPipelineState_Selectors.newVisibleFunctionTable_stage_, descriptor.NativePtr, (nint)stage));
        return __r;
    }

}
