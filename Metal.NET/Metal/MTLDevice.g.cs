using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLDevice_Selectors
{
    internal static readonly Selector accelerationStructureSizes_ = Selector.Register("accelerationStructureSizes:");
    internal static readonly Selector functionHandle_ = Selector.Register("functionHandle:");
    internal static readonly Selector heapAccelerationStructureSizeAndAlign_ = Selector.Register("heapAccelerationStructureSizeAndAlign:");
    internal static readonly Selector heapBufferSizeAndAlign_options_ = Selector.Register("heapBufferSizeAndAlign:options:");
    internal static readonly Selector heapTextureSizeAndAlign_ = Selector.Register("heapTextureSizeAndAlign:");
    internal static readonly Selector minimumLinearTextureAlignmentForPixelFormat_ = Selector.Register("minimumLinearTextureAlignmentForPixelFormat:");
    internal static readonly Selector minimumTextureBufferAlignmentForPixelFormat_ = Selector.Register("minimumTextureBufferAlignmentForPixelFormat:");
    internal static readonly Selector newAccelerationStructure_ = Selector.Register("newAccelerationStructure:");
    internal static readonly Selector newArchive_error_ = Selector.Register("newArchive:error:");
    internal static readonly Selector newArgumentEncoder_ = Selector.Register("newArgumentEncoder:");
    internal static readonly Selector newArgumentTable_error_ = Selector.Register("newArgumentTable:error:");
    internal static readonly Selector newBinaryArchive_error_ = Selector.Register("newBinaryArchive:error:");
    internal static readonly Selector newBuffer_options_ = Selector.Register("newBuffer:options:");
    internal static readonly Selector newBuffer_length_options_ = Selector.Register("newBuffer:length:options:");
    internal static readonly Selector newBuffer_options_placementSparsePageSize_ = Selector.Register("newBuffer:options:placementSparsePageSize:");
    internal static readonly Selector newCommandAllocator = Selector.Register("newCommandAllocator");
    internal static readonly Selector newCommandAllocator_error_ = Selector.Register("newCommandAllocator:error:");
    internal static readonly Selector newCommandBuffer = Selector.Register("newCommandBuffer");
    internal static readonly Selector newCommandQueue = Selector.Register("newCommandQueue");
    internal static readonly Selector newCommandQueue_ = Selector.Register("newCommandQueue:");
    internal static readonly Selector newCompiler_error_ = Selector.Register("newCompiler:error:");
    internal static readonly Selector newComputePipelineState_error_ = Selector.Register("newComputePipelineState:error:");
    internal static readonly Selector newComputePipelineState_options_reflection_error_ = Selector.Register("newComputePipelineState:options:reflection:error:");
    internal static readonly Selector newComputePipelineState_completionHandler_ = Selector.Register("newComputePipelineState:completionHandler:");
    internal static readonly Selector newCounterHeap_error_ = Selector.Register("newCounterHeap:error:");
    internal static readonly Selector newCounterSampleBuffer_error_ = Selector.Register("newCounterSampleBuffer:error:");
    internal static readonly Selector newDefaultLibrary = Selector.Register("newDefaultLibrary");
    internal static readonly Selector newDefaultLibrary_error_ = Selector.Register("newDefaultLibrary:error:");
    internal static readonly Selector newDepthStencilState_ = Selector.Register("newDepthStencilState:");
    internal static readonly Selector newDynamicLibrary_error_ = Selector.Register("newDynamicLibrary:error:");
    internal static readonly Selector newEvent = Selector.Register("newEvent");
    internal static readonly Selector newFence = Selector.Register("newFence");
    internal static readonly Selector newHeap_ = Selector.Register("newHeap:");
    internal static readonly Selector newIOCommandQueue_error_ = Selector.Register("newIOCommandQueue:error:");
    internal static readonly Selector newIOFileHandle_error_ = Selector.Register("newIOFileHandle:error:");
    internal static readonly Selector newIOFileHandle_compressionMethod_error_ = Selector.Register("newIOFileHandle:compressionMethod:error:");
    internal static readonly Selector newIOHandle_error_ = Selector.Register("newIOHandle:error:");
    internal static readonly Selector newIOHandle_compressionMethod_error_ = Selector.Register("newIOHandle:compressionMethod:error:");
    internal static readonly Selector newIndirectCommandBuffer_maxCount_options_ = Selector.Register("newIndirectCommandBuffer:maxCount:options:");
    internal static readonly Selector newLibrary_error_ = Selector.Register("newLibrary:error:");
    internal static readonly Selector newLibrary_options_error_ = Selector.Register("newLibrary:options:error:");
    internal static readonly Selector newLibrary_pOptions_completionHandler_ = Selector.Register("newLibrary:pOptions:completionHandler:");
    internal static readonly Selector newLibrary_completionHandler_ = Selector.Register("newLibrary:completionHandler:");
    internal static readonly Selector newLogState_error_ = Selector.Register("newLogState:error:");
    internal static readonly Selector newMTL4CommandQueue = Selector.Register("newMTL4CommandQueue");
    internal static readonly Selector newMTL4CommandQueue_error_ = Selector.Register("newMTL4CommandQueue:error:");
    internal static readonly Selector newPipelineDataSetSerializer_ = Selector.Register("newPipelineDataSetSerializer:");
    internal static readonly Selector newRasterizationRateMap_ = Selector.Register("newRasterizationRateMap:");
    internal static readonly Selector newRenderPipelineState_error_ = Selector.Register("newRenderPipelineState:error:");
    internal static readonly Selector newRenderPipelineState_options_reflection_error_ = Selector.Register("newRenderPipelineState:options:reflection:error:");
    internal static readonly Selector newRenderPipelineState_completionHandler_ = Selector.Register("newRenderPipelineState:completionHandler:");
    internal static readonly Selector newResidencySet_error_ = Selector.Register("newResidencySet:error:");
    internal static readonly Selector newSamplerState_ = Selector.Register("newSamplerState:");
    internal static readonly Selector newSharedEvent = Selector.Register("newSharedEvent");
    internal static readonly Selector newSharedEvent_ = Selector.Register("newSharedEvent:");
    internal static readonly Selector newSharedTexture_ = Selector.Register("newSharedTexture:");
    internal static readonly Selector newTensor_error_ = Selector.Register("newTensor:error:");
    internal static readonly Selector newTexture_ = Selector.Register("newTexture:");
    internal static readonly Selector newTexture_iosurface_plane_ = Selector.Register("newTexture:iosurface:plane:");
    internal static readonly Selector newTextureViewPool_error_ = Selector.Register("newTextureViewPool:error:");
    internal static readonly Selector sampleTimestamps_gpuTimestamp_ = Selector.Register("sampleTimestamps:gpuTimestamp:");
    internal static readonly Selector setShouldMaximizeConcurrentCompilation_ = Selector.Register("setShouldMaximizeConcurrentCompilation:");
    internal static readonly Selector sizeOfCounterHeapEntry_ = Selector.Register("sizeOfCounterHeapEntry:");
    internal static readonly Selector sparseTileSize_pixelFormat_sampleCount_ = Selector.Register("sparseTileSize:pixelFormat:sampleCount:");
    internal static readonly Selector sparseTileSize_pixelFormat_sampleCount_sparsePageSize_ = Selector.Register("sparseTileSize:pixelFormat:sampleCount:sparsePageSize:");
    internal static readonly Selector supportsCounterSampling_ = Selector.Register("supportsCounterSampling:");
    internal static readonly Selector supportsFamily_ = Selector.Register("supportsFamily:");
    internal static readonly Selector supportsFeatureSet_ = Selector.Register("supportsFeatureSet:");
    internal static readonly Selector supportsRasterizationRateMap_ = Selector.Register("supportsRasterizationRateMap:");
    internal static readonly Selector supportsTextureSampleCount_ = Selector.Register("supportsTextureSampleCount:");
    internal static readonly Selector supportsVertexAmplificationCount_ = Selector.Register("supportsVertexAmplificationCount:");
    internal static readonly Selector tensorSizeAndAlign_ = Selector.Register("tensorSizeAndAlign:");
}

public partial class MTLDevice : IDisposable
{
    public nint NativePtr { get; }

    public MTLDevice(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLDevice o) => o.NativePtr;
    public static implicit operator MTLDevice(nint ptr) => new MTLDevice(ptr);

    ~MTLDevice() => Release();

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

    public nint AccelerationStructureSizes(MTLAccelerationStructureDescriptor descriptor)
    {
        var __r = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.accelerationStructureSizes_, descriptor.NativePtr);
        return __r;
    }

    public MTLFunctionHandle FunctionHandle(MTLFunction function)
    {
        var __r = new MTLFunctionHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.functionHandle_, function.NativePtr));
        return __r;
    }

    public MTLFunctionHandle FunctionHandle(MTL4BinaryFunction function)
    {
        var __r = new MTLFunctionHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.functionHandle_, function.NativePtr));
        return __r;
    }

    public nuint MinimumLinearTextureAlignmentForPixelFormat(MTLPixelFormat format)
    {
        var __r = (nuint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.minimumLinearTextureAlignmentForPixelFormat_, (nint)(uint)format);
        return __r;
    }

    public nuint MinimumTextureBufferAlignmentForPixelFormat(MTLPixelFormat format)
    {
        var __r = (nuint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.minimumTextureBufferAlignmentForPixelFormat_, (nint)(uint)format);
        return __r;
    }

    public MTLAccelerationStructure NewAccelerationStructure(nuint size)
    {
        var __r = new MTLAccelerationStructure(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newAccelerationStructure_, (nint)size));
        return __r;
    }

    public MTLAccelerationStructure NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor)
    {
        var __r = new MTLAccelerationStructure(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newAccelerationStructure_, descriptor.NativePtr));
        return __r;
    }

    public MTL4Archive NewArchive(NSURL url, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTL4Archive(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newArchive_error_, url.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLArgumentEncoder NewArgumentEncoder(NSArray arguments)
    {
        var __r = new MTLArgumentEncoder(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newArgumentEncoder_, arguments.NativePtr));
        return __r;
    }

    public MTLArgumentEncoder NewArgumentEncoder(MTLBufferBinding bufferBinding)
    {
        var __r = new MTLArgumentEncoder(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newArgumentEncoder_, bufferBinding.NativePtr));
        return __r;
    }

    public MTL4ArgumentTable NewArgumentTable(MTL4ArgumentTableDescriptor descriptor, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTL4ArgumentTable(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newArgumentTable_error_, descriptor.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLBinaryArchive NewBinaryArchive(MTLBinaryArchiveDescriptor descriptor, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLBinaryArchive(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newBinaryArchive_error_, descriptor.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLBuffer NewBuffer(nuint length, nuint options)
    {
        var __r = new MTLBuffer(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newBuffer_options_, (nint)length, (nint)options));
        return __r;
    }

    public MTLBuffer NewBuffer(nint pointer, nuint length, nuint options)
    {
        var __r = new MTLBuffer(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newBuffer_length_options_, pointer, (nint)length, (nint)options));
        return __r;
    }

    public MTLBuffer NewBuffer(nuint length, nuint options, MTLSparsePageSize placementSparsePageSize)
    {
        var __r = new MTLBuffer(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newBuffer_options_placementSparsePageSize_, (nint)length, (nint)options, (nint)(uint)placementSparsePageSize));
        return __r;
    }

    public MTL4CommandAllocator NewCommandAllocator()
    {
        var __r = new MTL4CommandAllocator(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newCommandAllocator));
        return __r;
    }

    public MTL4CommandAllocator NewCommandAllocator(MTL4CommandAllocatorDescriptor descriptor, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTL4CommandAllocator(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newCommandAllocator_error_, descriptor.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTL4CommandBuffer NewCommandBuffer()
    {
        var __r = new MTL4CommandBuffer(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newCommandBuffer));
        return __r;
    }

    public MTLCommandQueue NewCommandQueue()
    {
        var __r = new MTLCommandQueue(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newCommandQueue));
        return __r;
    }

    public MTLCommandQueue NewCommandQueue(nuint maxCommandBufferCount)
    {
        var __r = new MTLCommandQueue(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newCommandQueue_, (nint)maxCommandBufferCount));
        return __r;
    }

    public MTLCommandQueue NewCommandQueue(MTLCommandQueueDescriptor descriptor)
    {
        var __r = new MTLCommandQueue(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newCommandQueue_, descriptor.NativePtr));
        return __r;
    }

    public MTL4Compiler NewCompiler(MTL4CompilerDescriptor descriptor, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTL4Compiler(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newCompiler_error_, descriptor.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLComputePipelineState NewComputePipelineState(MTLFunction computeFunction, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLComputePipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newComputePipelineState_error_, computeFunction.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLComputePipelineState NewComputePipelineState(MTLFunction computeFunction, nuint options, nint reflection, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLComputePipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newComputePipelineState_options_reflection_error_, computeFunction.NativePtr, (nint)options, reflection, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLComputePipelineState NewComputePipelineState(MTLComputePipelineDescriptor descriptor, nuint options, nint reflection, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLComputePipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newComputePipelineState_options_reflection_error_, descriptor.NativePtr, (nint)options, reflection, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public void NewComputePipelineState(MTLFunction pFunction, nint completionHandler)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDevice_Selectors.newComputePipelineState_completionHandler_, pFunction.NativePtr, completionHandler);
    }

    public MTL4CounterHeap NewCounterHeap(MTL4CounterHeapDescriptor descriptor, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTL4CounterHeap(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newCounterHeap_error_, descriptor.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLCounterSampleBuffer NewCounterSampleBuffer(MTLCounterSampleBufferDescriptor descriptor, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLCounterSampleBuffer(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newCounterSampleBuffer_error_, descriptor.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLLibrary NewDefaultLibrary()
    {
        var __r = new MTLLibrary(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newDefaultLibrary));
        return __r;
    }

    public MTLLibrary NewDefaultLibrary(nint bundle, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLLibrary(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newDefaultLibrary_error_, bundle, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLDepthStencilState NewDepthStencilState(MTLDepthStencilDescriptor descriptor)
    {
        var __r = new MTLDepthStencilState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newDepthStencilState_, descriptor.NativePtr));
        return __r;
    }

    public MTLDynamicLibrary NewDynamicLibrary(MTLLibrary library, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLDynamicLibrary(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newDynamicLibrary_error_, library.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLDynamicLibrary NewDynamicLibrary(NSURL url, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLDynamicLibrary(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newDynamicLibrary_error_, url.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLEvent NewEvent()
    {
        var __r = new MTLEvent(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newEvent));
        return __r;
    }

    public MTLFence NewFence()
    {
        var __r = new MTLFence(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newFence));
        return __r;
    }

    public MTLHeap NewHeap(MTLHeapDescriptor descriptor)
    {
        var __r = new MTLHeap(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newHeap_, descriptor.NativePtr));
        return __r;
    }

    public MTLIOCommandQueue NewIOCommandQueue(MTLIOCommandQueueDescriptor descriptor, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLIOCommandQueue(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newIOCommandQueue_error_, descriptor.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLIOFileHandle NewIOFileHandle(NSURL url, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLIOFileHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newIOFileHandle_error_, url.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLIOFileHandle NewIOFileHandle(NSURL url, MTLIOCompressionMethod compressionMethod, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLIOFileHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newIOFileHandle_compressionMethod_error_, url.NativePtr, (nint)(uint)compressionMethod, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLIOFileHandle NewIOHandle(NSURL url, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLIOFileHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newIOHandle_error_, url.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLIOFileHandle NewIOHandle(NSURL url, MTLIOCompressionMethod compressionMethod, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLIOFileHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newIOHandle_compressionMethod_error_, url.NativePtr, (nint)(uint)compressionMethod, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLIndirectCommandBuffer NewIndirectCommandBuffer(MTLIndirectCommandBufferDescriptor descriptor, nuint maxCount, nuint options)
    {
        var __r = new MTLIndirectCommandBuffer(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newIndirectCommandBuffer_maxCount_options_, descriptor.NativePtr, (nint)maxCount, (nint)options));
        return __r;
    }

    public MTLLibrary NewLibrary(NSString filepath, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLLibrary(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newLibrary_error_, filepath.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLLibrary NewLibrary(NSURL url, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLLibrary(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newLibrary_error_, url.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLLibrary NewLibrary(nint data, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLLibrary(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newLibrary_error_, data, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLLibrary NewLibrary(NSString source, MTLCompileOptions options, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLLibrary(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newLibrary_options_error_, source.NativePtr, options.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLLibrary NewLibrary(MTLStitchedLibraryDescriptor descriptor, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLLibrary(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newLibrary_error_, descriptor.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public void NewLibrary(NSString pSource, MTLCompileOptions pOptions, nint completionHandler)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDevice_Selectors.newLibrary_pOptions_completionHandler_, pSource.NativePtr, pOptions.NativePtr, completionHandler);
    }

    public void NewLibrary(MTLStitchedLibraryDescriptor pDescriptor, nint completionHandler)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDevice_Selectors.newLibrary_completionHandler_, pDescriptor.NativePtr, completionHandler);
    }

    public MTLLogState NewLogState(MTLLogStateDescriptor descriptor, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLLogState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newLogState_error_, descriptor.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTL4CommandQueue NewMTL4CommandQueue()
    {
        var __r = new MTL4CommandQueue(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newMTL4CommandQueue));
        return __r;
    }

    public MTL4CommandQueue NewMTL4CommandQueue(MTL4CommandQueueDescriptor descriptor, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTL4CommandQueue(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newMTL4CommandQueue_error_, descriptor.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTL4PipelineDataSetSerializer NewPipelineDataSetSerializer(MTL4PipelineDataSetSerializerDescriptor descriptor)
    {
        var __r = new MTL4PipelineDataSetSerializer(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newPipelineDataSetSerializer_, descriptor.NativePtr));
        return __r;
    }

    public MTLRasterizationRateMap NewRasterizationRateMap(MTLRasterizationRateMapDescriptor descriptor)
    {
        var __r = new MTLRasterizationRateMap(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newRasterizationRateMap_, descriptor.NativePtr));
        return __r;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTLRenderPipelineDescriptor descriptor, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLRenderPipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newRenderPipelineState_error_, descriptor.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTLRenderPipelineDescriptor descriptor, nuint options, nint reflection, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLRenderPipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newRenderPipelineState_options_reflection_error_, descriptor.NativePtr, (nint)options, reflection, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTLTileRenderPipelineDescriptor descriptor, nuint options, nint reflection, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLRenderPipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newRenderPipelineState_options_reflection_error_, descriptor.NativePtr, (nint)options, reflection, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTLMeshRenderPipelineDescriptor descriptor, nuint options, nint reflection, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLRenderPipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newRenderPipelineState_options_reflection_error_, descriptor.NativePtr, (nint)options, reflection, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public void NewRenderPipelineState(MTLRenderPipelineDescriptor pDescriptor, nint completionHandler)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDevice_Selectors.newRenderPipelineState_completionHandler_, pDescriptor.NativePtr, completionHandler);
    }

    public MTLResidencySet NewResidencySet(MTLResidencySetDescriptor desc, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLResidencySet(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newResidencySet_error_, desc.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLSamplerState NewSamplerState(MTLSamplerDescriptor descriptor)
    {
        var __r = new MTLSamplerState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newSamplerState_, descriptor.NativePtr));
        return __r;
    }

    public MTLSharedEvent NewSharedEvent()
    {
        var __r = new MTLSharedEvent(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newSharedEvent));
        return __r;
    }

    public MTLSharedEvent NewSharedEvent(MTLSharedEventHandle sharedEventHandle)
    {
        var __r = new MTLSharedEvent(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newSharedEvent_, sharedEventHandle.NativePtr));
        return __r;
    }

    public MTLTexture NewSharedTexture(MTLTextureDescriptor descriptor)
    {
        var __r = new MTLTexture(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newSharedTexture_, descriptor.NativePtr));
        return __r;
    }

    public MTLTexture NewSharedTexture(MTLSharedTextureHandle sharedHandle)
    {
        var __r = new MTLTexture(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newSharedTexture_, sharedHandle.NativePtr));
        return __r;
    }

    public MTLTensor NewTensor(MTLTensorDescriptor descriptor, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLTensor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newTensor_error_, descriptor.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor)
    {
        var __r = new MTLTexture(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newTexture_, descriptor.NativePtr));
        return __r;
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor, nint iosurface, nuint plane)
    {
        var __r = new MTLTexture(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newTexture_iosurface_plane_, descriptor.NativePtr, iosurface, (nint)plane));
        return __r;
    }

    public MTLTextureViewPool NewTextureViewPool(MTLResourceViewPoolDescriptor descriptor, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLTextureViewPool(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.newTextureViewPool_error_, descriptor.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public void SampleTimestamps(nint cpuTimestamp, nint gpuTimestamp)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDevice_Selectors.sampleTimestamps_gpuTimestamp_, cpuTimestamp, gpuTimestamp);
    }

    public void SetShouldMaximizeConcurrentCompilation(Bool8 shouldMaximizeConcurrentCompilation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDevice_Selectors.setShouldMaximizeConcurrentCompilation_, (nint)shouldMaximizeConcurrentCompilation.Value);
    }

    public nuint SizeOfCounterHeapEntry(MTL4CounterHeapType type)
    {
        var __r = (nuint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.sizeOfCounterHeapEntry_, (nint)(uint)type);
        return __r;
    }

    public Bool8 SupportsCounterSampling(MTLCounterSamplingPoint samplingPoint)
    {
        var __r = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.supportsCounterSampling_, (nint)(uint)samplingPoint) != 0;
        return __r;
    }

    public Bool8 SupportsFamily(MTLGPUFamily gpuFamily)
    {
        var __r = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.supportsFamily_, (nint)(uint)gpuFamily) != 0;
        return __r;
    }

    public Bool8 SupportsFeatureSet(MTLFeatureSet featureSet)
    {
        var __r = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.supportsFeatureSet_, (nint)(uint)featureSet) != 0;
        return __r;
    }

    public Bool8 SupportsRasterizationRateMap(nuint layerCount)
    {
        var __r = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.supportsRasterizationRateMap_, (nint)layerCount) != 0;
        return __r;
    }

    public Bool8 SupportsTextureSampleCount(nuint sampleCount)
    {
        var __r = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.supportsTextureSampleCount_, (nint)sampleCount) != 0;
        return __r;
    }

    public Bool8 SupportsVertexAmplificationCount(nuint count)
    {
        var __r = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDevice_Selectors.supportsVertexAmplificationCount_, (nint)count) != 0;
        return __r;
    }

    [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal", EntryPoint = "MTLCreateSystemDefaultDevice")]
    private static partial nint MTLCreateSystemDefaultDevice();

    public static MTLDevice CreateSystemDefaultDevice()
    {
        return new MTLDevice(MTLCreateSystemDefaultDevice());
    }

    [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal", EntryPoint = "MTLCopyAllDevices")]
    private static partial nint MTLCopyAllDevices();

    public static NSArray CopyAllDevices()
    {
        return new NSArray(MTLCopyAllDevices());
    }

    [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal", EntryPoint = "MTLCopyAllDevicesWithObserver")]
    private static partial nint MTLCopyAllDevicesWithObserver(nint pOutObserver, nint handler);

    public static NSArray CopyAllDevicesWithObserver(nint pOutObserver, nint handler)
    {
        return new NSArray(MTLCopyAllDevicesWithObserver(pOutObserver, handler));
    }

    [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal", EntryPoint = "MTLRemoveDeviceObserver")]
    private static partial void MTLRemoveDeviceObserver(nint pObserver);

    public static void RemoveDeviceObserver(nint pObserver)
    {
        MTLRemoveDeviceObserver(pObserver);
    }

}
