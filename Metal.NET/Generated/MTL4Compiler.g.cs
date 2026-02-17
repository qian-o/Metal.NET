using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4Compiler_Selectors
{
    internal static readonly Selector newBinaryFunction_compilerTaskOptions_error_ = Selector.Register("newBinaryFunction:compilerTaskOptions:error:");
    internal static readonly Selector newComputePipelineState_compilerTaskOptions_error_ = Selector.Register("newComputePipelineState:compilerTaskOptions:error:");
    internal static readonly Selector newComputePipelineState_dynamicLinkingDescriptor_compilerTaskOptions_error_ = Selector.Register("newComputePipelineState:dynamicLinkingDescriptor:compilerTaskOptions:error:");
    internal static readonly Selector newComputePipelineState_options_function_ = Selector.Register("newComputePipelineState:options:function:");
    internal static readonly Selector newDynamicLibrary_error_ = Selector.Register("newDynamicLibrary:error:");
    internal static readonly Selector newDynamicLibrary_function_ = Selector.Register("newDynamicLibrary:function:");
    internal static readonly Selector newLibrary_error_ = Selector.Register("newLibrary:error:");
    internal static readonly Selector newLibrary_function_ = Selector.Register("newLibrary:function:");
    internal static readonly Selector newMachineLearningPipelineState_error_ = Selector.Register("newMachineLearningPipelineState:error:");
    internal static readonly Selector newMachineLearningPipelineState_function_ = Selector.Register("newMachineLearningPipelineState:function:");
    internal static readonly Selector newRenderPipelineState_compilerTaskOptions_error_ = Selector.Register("newRenderPipelineState:compilerTaskOptions:error:");
    internal static readonly Selector newRenderPipelineState_dynamicLinkingDescriptor_compilerTaskOptions_error_ = Selector.Register("newRenderPipelineState:dynamicLinkingDescriptor:compilerTaskOptions:error:");
    internal static readonly Selector newRenderPipelineState_options_function_ = Selector.Register("newRenderPipelineState:options:function:");
    internal static readonly Selector newRenderPipelineStateBySpecialization_pipeline_error_ = Selector.Register("newRenderPipelineStateBySpecialization:pipeline:error:");
    internal static readonly Selector newRenderPipelineStateBySpecialization_pPipeline_function_ = Selector.Register("newRenderPipelineStateBySpecialization:pPipeline:function:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTL4Compiler
{
    public readonly nint NativePtr;

    public MTL4Compiler(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4Compiler o) => o.NativePtr;
    public static implicit operator MTL4Compiler(nint ptr) => new MTL4Compiler(ptr);

    public MTL4BinaryFunction NewBinaryFunction(MTL4BinaryFunctionDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4Compiler_Selectors.newBinaryFunction_compilerTaskOptions_error_, descriptor.NativePtr, compilerTaskOptions.NativePtr, out error);
        return new MTL4BinaryFunction(__result);
    }

    public MTLComputePipelineState NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4Compiler_Selectors.newComputePipelineState_compilerTaskOptions_error_, descriptor.NativePtr, compilerTaskOptions.NativePtr, out error);
        return new MTLComputePipelineState(__result);
    }

    public MTLComputePipelineState NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4Compiler_Selectors.newComputePipelineState_dynamicLinkingDescriptor_compilerTaskOptions_error_, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, out error);
        return new MTLComputePipelineState(__result);
    }

    public MTL4CompilerTask NewComputePipelineState(MTL4ComputePipelineDescriptor pDescriptor, MTL4CompilerTaskOptions options, nint function)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4Compiler_Selectors.newComputePipelineState_options_function_, pDescriptor.NativePtr, options.NativePtr, function);
        return new MTL4CompilerTask(__result);
    }

    public MTLDynamicLibrary NewDynamicLibrary(MTLLibrary library, out NSError error)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4Compiler_Selectors.newDynamicLibrary_error_, library.NativePtr, out error);
        return new MTLDynamicLibrary(__result);
    }

    public MTLDynamicLibrary NewDynamicLibrary(NSURL url, out NSError error)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4Compiler_Selectors.newDynamicLibrary_error_, url.NativePtr, out error);
        return new MTLDynamicLibrary(__result);
    }

    public MTL4CompilerTask NewDynamicLibrary(MTLLibrary pLibrary, nint function)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4Compiler_Selectors.newDynamicLibrary_function_, pLibrary.NativePtr, function);
        return new MTL4CompilerTask(__result);
    }

    public MTL4CompilerTask NewDynamicLibrary(NSURL pURL, nint function)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4Compiler_Selectors.newDynamicLibrary_function_, pURL.NativePtr, function);
        return new MTL4CompilerTask(__result);
    }

    public MTLLibrary NewLibrary(MTL4LibraryDescriptor descriptor, out NSError error)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4Compiler_Selectors.newLibrary_error_, descriptor.NativePtr, out error);
        return new MTLLibrary(__result);
    }

    public MTL4CompilerTask NewLibrary(MTL4LibraryDescriptor pDescriptor, nint function)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4Compiler_Selectors.newLibrary_function_, pDescriptor.NativePtr, function);
        return new MTL4CompilerTask(__result);
    }

    public MTL4MachineLearningPipelineState NewMachineLearningPipelineState(MTL4MachineLearningPipelineDescriptor descriptor, out NSError error)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4Compiler_Selectors.newMachineLearningPipelineState_error_, descriptor.NativePtr, out error);
        return new MTL4MachineLearningPipelineState(__result);
    }

    public MTL4CompilerTask NewMachineLearningPipelineState(MTL4MachineLearningPipelineDescriptor pDescriptor, nint function)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4Compiler_Selectors.newMachineLearningPipelineState_function_, pDescriptor.NativePtr, function);
        return new MTL4CompilerTask(__result);
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4Compiler_Selectors.newRenderPipelineState_compilerTaskOptions_error_, descriptor.NativePtr, compilerTaskOptions.NativePtr, out error);
        return new MTLRenderPipelineState(__result);
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4Compiler_Selectors.newRenderPipelineState_dynamicLinkingDescriptor_compilerTaskOptions_error_, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, out error);
        return new MTLRenderPipelineState(__result);
    }

    public MTL4CompilerTask NewRenderPipelineState(MTL4PipelineDescriptor pDescriptor, MTL4CompilerTaskOptions options, nint function)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4Compiler_Selectors.newRenderPipelineState_options_function_, pDescriptor.NativePtr, options.NativePtr, function);
        return new MTL4CompilerTask(__result);
    }

    public MTLRenderPipelineState NewRenderPipelineStateBySpecialization(MTL4PipelineDescriptor descriptor, MTLRenderPipelineState pipeline, out NSError error)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4Compiler_Selectors.newRenderPipelineStateBySpecialization_pipeline_error_, descriptor.NativePtr, pipeline.NativePtr, out error);
        return new MTLRenderPipelineState(__result);
    }

    public MTL4CompilerTask NewRenderPipelineStateBySpecialization(MTL4PipelineDescriptor pDescriptor, MTLRenderPipelineState pPipeline, nint function)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4Compiler_Selectors.newRenderPipelineStateBySpecialization_pPipeline_function_, pDescriptor.NativePtr, pPipeline.NativePtr, function);
        return new MTL4CompilerTask(__result);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
