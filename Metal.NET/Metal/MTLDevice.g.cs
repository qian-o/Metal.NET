using System.Runtime.InteropServices;

#nullable enable

namespace Metal.NET;

file class MTLDeviceSelector
{
    public static readonly Selector AccelerationStructureSizes_ = Selector.Register("accelerationStructureSizes:");
    public static readonly Selector FunctionHandle_ = Selector.Register("functionHandle:");
    public static readonly Selector HeapAccelerationStructureSizeAndAlign_ = Selector.Register("heapAccelerationStructureSizeAndAlign:");
    public static readonly Selector HeapBufferSizeAndAlign_options_ = Selector.Register("heapBufferSizeAndAlign:options:");
    public static readonly Selector HeapTextureSizeAndAlign_ = Selector.Register("heapTextureSizeAndAlign:");
    public static readonly Selector MinimumLinearTextureAlignmentForPixelFormat_ = Selector.Register("minimumLinearTextureAlignmentForPixelFormat:");
    public static readonly Selector MinimumTextureBufferAlignmentForPixelFormat_ = Selector.Register("minimumTextureBufferAlignmentForPixelFormat:");
    public static readonly Selector NewAccelerationStructure_ = Selector.Register("newAccelerationStructure:");
    public static readonly Selector NewArchive_error_ = Selector.Register("newArchive:error:");
    public static readonly Selector NewArgumentEncoder_ = Selector.Register("newArgumentEncoder:");
    public static readonly Selector NewArgumentTable_error_ = Selector.Register("newArgumentTable:error:");
    public static readonly Selector NewBinaryArchive_error_ = Selector.Register("newBinaryArchive:error:");
    public static readonly Selector NewBuffer_options_ = Selector.Register("newBuffer:options:");
    public static readonly Selector NewBuffer_length_options_ = Selector.Register("newBuffer:length:options:");
    public static readonly Selector NewBuffer_options_placementSparsePageSize_ = Selector.Register("newBuffer:options:placementSparsePageSize:");
    public static readonly Selector NewCommandAllocator = Selector.Register("newCommandAllocator");
    public static readonly Selector NewCommandAllocator_error_ = Selector.Register("newCommandAllocator:error:");
    public static readonly Selector NewCommandBuffer = Selector.Register("newCommandBuffer");
    public static readonly Selector NewCommandQueue = Selector.Register("newCommandQueue");
    public static readonly Selector NewCommandQueue_ = Selector.Register("newCommandQueue:");
    public static readonly Selector NewCompiler_error_ = Selector.Register("newCompiler:error:");
    public static readonly Selector NewComputePipelineState_error_ = Selector.Register("newComputePipelineState:error:");
    public static readonly Selector NewComputePipelineState_options_reflection_error_ = Selector.Register("newComputePipelineState:options:reflection:error:");
    public static readonly Selector NewComputePipelineState_completionHandler_ = Selector.Register("newComputePipelineState:completionHandler:");
    public static readonly Selector NewCounterHeap_error_ = Selector.Register("newCounterHeap:error:");
    public static readonly Selector NewCounterSampleBuffer_error_ = Selector.Register("newCounterSampleBuffer:error:");
    public static readonly Selector NewDefaultLibrary = Selector.Register("newDefaultLibrary");
    public static readonly Selector NewDefaultLibrary_error_ = Selector.Register("newDefaultLibrary:error:");
    public static readonly Selector NewDepthStencilState_ = Selector.Register("newDepthStencilState:");
    public static readonly Selector NewDynamicLibrary_error_ = Selector.Register("newDynamicLibrary:error:");
    public static readonly Selector NewEvent = Selector.Register("newEvent");
    public static readonly Selector NewFence = Selector.Register("newFence");
    public static readonly Selector NewHeap_ = Selector.Register("newHeap:");
    public static readonly Selector NewIOCommandQueue_error_ = Selector.Register("newIOCommandQueue:error:");
    public static readonly Selector NewIOFileHandle_error_ = Selector.Register("newIOFileHandle:error:");
    public static readonly Selector NewIOFileHandle_compressionMethod_error_ = Selector.Register("newIOFileHandle:compressionMethod:error:");
    public static readonly Selector NewIOHandle_error_ = Selector.Register("newIOHandle:error:");
    public static readonly Selector NewIOHandle_compressionMethod_error_ = Selector.Register("newIOHandle:compressionMethod:error:");
    public static readonly Selector NewIndirectCommandBuffer_maxCount_options_ = Selector.Register("newIndirectCommandBuffer:maxCount:options:");
    public static readonly Selector NewLibrary_error_ = Selector.Register("newLibrary:error:");
    public static readonly Selector NewLibrary_options_error_ = Selector.Register("newLibrary:options:error:");
    public static readonly Selector NewLibrary_pOptions_completionHandler_ = Selector.Register("newLibrary:pOptions:completionHandler:");
    public static readonly Selector NewLibrary_completionHandler_ = Selector.Register("newLibrary:completionHandler:");
    public static readonly Selector NewLogState_error_ = Selector.Register("newLogState:error:");
    public static readonly Selector NewMTL4CommandQueue = Selector.Register("newMTL4CommandQueue");
    public static readonly Selector NewMTL4CommandQueue_error_ = Selector.Register("newMTL4CommandQueue:error:");
    public static readonly Selector NewPipelineDataSetSerializer_ = Selector.Register("newPipelineDataSetSerializer:");
    public static readonly Selector NewRasterizationRateMap_ = Selector.Register("newRasterizationRateMap:");
    public static readonly Selector NewRenderPipelineState_error_ = Selector.Register("newRenderPipelineState:error:");
    public static readonly Selector NewRenderPipelineState_options_reflection_error_ = Selector.Register("newRenderPipelineState:options:reflection:error:");
    public static readonly Selector NewRenderPipelineState_completionHandler_ = Selector.Register("newRenderPipelineState:completionHandler:");
    public static readonly Selector NewResidencySet_error_ = Selector.Register("newResidencySet:error:");
    public static readonly Selector NewSamplerState_ = Selector.Register("newSamplerState:");
    public static readonly Selector NewSharedEvent = Selector.Register("newSharedEvent");
    public static readonly Selector NewSharedEvent_ = Selector.Register("newSharedEvent:");
    public static readonly Selector NewSharedTexture_ = Selector.Register("newSharedTexture:");
    public static readonly Selector NewTensor_error_ = Selector.Register("newTensor:error:");
    public static readonly Selector NewTexture_ = Selector.Register("newTexture:");
    public static readonly Selector NewTexture_iosurface_plane_ = Selector.Register("newTexture:iosurface:plane:");
    public static readonly Selector NewTextureViewPool_error_ = Selector.Register("newTextureViewPool:error:");
    public static readonly Selector SampleTimestamps_gpuTimestamp_ = Selector.Register("sampleTimestamps:gpuTimestamp:");
    public static readonly Selector SetShouldMaximizeConcurrentCompilation_ = Selector.Register("setShouldMaximizeConcurrentCompilation:");
    public static readonly Selector SizeOfCounterHeapEntry_ = Selector.Register("sizeOfCounterHeapEntry:");
    public static readonly Selector SparseTileSize_pixelFormat_sampleCount_ = Selector.Register("sparseTileSize:pixelFormat:sampleCount:");
    public static readonly Selector SparseTileSize_pixelFormat_sampleCount_sparsePageSize_ = Selector.Register("sparseTileSize:pixelFormat:sampleCount:sparsePageSize:");
    public static readonly Selector SupportsCounterSampling_ = Selector.Register("supportsCounterSampling:");
    public static readonly Selector SupportsFamily_ = Selector.Register("supportsFamily:");
    public static readonly Selector SupportsFeatureSet_ = Selector.Register("supportsFeatureSet:");
    public static readonly Selector SupportsRasterizationRateMap_ = Selector.Register("supportsRasterizationRateMap:");
    public static readonly Selector SupportsTextureSampleCount_ = Selector.Register("supportsTextureSampleCount:");
    public static readonly Selector SupportsVertexAmplificationCount_ = Selector.Register("supportsVertexAmplificationCount:");
    public static readonly Selector TensorSizeAndAlign_ = Selector.Register("tensorSizeAndAlign:");
}

public partial class MTLDevice : IDisposable
{
    public MTLDevice(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLDevice()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLDevice value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLDevice(nint value)
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

    public nint AccelerationStructureSizes(MTLAccelerationStructureDescriptor descriptor)
    {
        var result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.AccelerationStructureSizes_, descriptor.NativePtr);

        return result;
    }

    public MTLFunctionHandle FunctionHandle(MTLFunction function)
    {
        var result = new MTLFunctionHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.FunctionHandle_, function.NativePtr));

        return result;
    }

    public MTLFunctionHandle FunctionHandle(MTL4BinaryFunction function)
    {
        var result = new MTLFunctionHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.FunctionHandle_, function.NativePtr));

        return result;
    }

    public nuint MinimumLinearTextureAlignmentForPixelFormat(MTLPixelFormat format)
    {
        var result = (nuint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.MinimumLinearTextureAlignmentForPixelFormat_, (nint)(uint)format);

        return result;
    }

    public nuint MinimumTextureBufferAlignmentForPixelFormat(MTLPixelFormat format)
    {
        var result = (nuint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.MinimumTextureBufferAlignmentForPixelFormat_, (nint)(uint)format);

        return result;
    }

    public MTLAccelerationStructure NewAccelerationStructure(nuint size)
    {
        var result = new MTLAccelerationStructure(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewAccelerationStructure_, (nint)size));

        return result;
    }

    public MTLAccelerationStructure NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor)
    {
        var result = new MTLAccelerationStructure(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewAccelerationStructure_, descriptor.NativePtr));

        return result;
    }

    public MTL4Archive NewArchive(NSURL url, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTL4Archive(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewArchive_error_, url.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLArgumentEncoder NewArgumentEncoder(NSArray arguments)
    {
        var result = new MTLArgumentEncoder(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewArgumentEncoder_, arguments.NativePtr));

        return result;
    }

    public MTLArgumentEncoder NewArgumentEncoder(MTLBufferBinding bufferBinding)
    {
        var result = new MTLArgumentEncoder(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewArgumentEncoder_, bufferBinding.NativePtr));

        return result;
    }

    public MTL4ArgumentTable NewArgumentTable(MTL4ArgumentTableDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTL4ArgumentTable(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewArgumentTable_error_, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLBinaryArchive NewBinaryArchive(MTLBinaryArchiveDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLBinaryArchive(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewBinaryArchive_error_, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLBuffer NewBuffer(nuint length, nuint options)
    {
        var result = new MTLBuffer(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewBuffer_options_, (nint)length, (nint)options));

        return result;
    }

    public MTLBuffer NewBuffer(nint pointer, nuint length, nuint options)
    {
        var result = new MTLBuffer(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewBuffer_length_options_, pointer, (nint)length, (nint)options));

        return result;
    }

    public MTLBuffer NewBuffer(nuint length, nuint options, MTLSparsePageSize placementSparsePageSize)
    {
        var result = new MTLBuffer(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewBuffer_options_placementSparsePageSize_, (nint)length, (nint)options, (nint)(uint)placementSparsePageSize));

        return result;
    }

    public MTL4CommandAllocator NewCommandAllocator()
    {
        var result = new MTL4CommandAllocator(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewCommandAllocator));

        return result;
    }

    public MTL4CommandAllocator NewCommandAllocator(MTL4CommandAllocatorDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTL4CommandAllocator(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewCommandAllocator_error_, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTL4CommandBuffer NewCommandBuffer()
    {
        var result = new MTL4CommandBuffer(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewCommandBuffer));

        return result;
    }

    public MTLCommandQueue NewCommandQueue()
    {
        var result = new MTLCommandQueue(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewCommandQueue));

        return result;
    }

    public MTLCommandQueue NewCommandQueue(nuint maxCommandBufferCount)
    {
        var result = new MTLCommandQueue(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewCommandQueue_, (nint)maxCommandBufferCount));

        return result;
    }

    public MTLCommandQueue NewCommandQueue(MTLCommandQueueDescriptor descriptor)
    {
        var result = new MTLCommandQueue(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewCommandQueue_, descriptor.NativePtr));

        return result;
    }

    public MTL4Compiler NewCompiler(MTL4CompilerDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTL4Compiler(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewCompiler_error_, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLComputePipelineState NewComputePipelineState(MTLFunction computeFunction, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLComputePipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewComputePipelineState_error_, computeFunction.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLComputePipelineState NewComputePipelineState(MTLFunction computeFunction, nuint options, nint reflection, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLComputePipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewComputePipelineState_options_reflection_error_, computeFunction.NativePtr, (nint)options, reflection, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLComputePipelineState NewComputePipelineState(MTLComputePipelineDescriptor descriptor, nuint options, nint reflection, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLComputePipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewComputePipelineState_options_reflection_error_, descriptor.NativePtr, (nint)options, reflection, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public void NewComputePipelineState(MTLFunction pFunction, nint completionHandler)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDeviceSelector.NewComputePipelineState_completionHandler_, pFunction.NativePtr, completionHandler);
    }

    public MTL4CounterHeap NewCounterHeap(MTL4CounterHeapDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTL4CounterHeap(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewCounterHeap_error_, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLCounterSampleBuffer NewCounterSampleBuffer(MTLCounterSampleBufferDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLCounterSampleBuffer(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewCounterSampleBuffer_error_, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLLibrary NewDefaultLibrary()
    {
        var result = new MTLLibrary(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewDefaultLibrary));

        return result;
    }

    public MTLLibrary NewDefaultLibrary(nint bundle, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLLibrary(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewDefaultLibrary_error_, bundle, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLDepthStencilState NewDepthStencilState(MTLDepthStencilDescriptor descriptor)
    {
        var result = new MTLDepthStencilState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewDepthStencilState_, descriptor.NativePtr));

        return result;
    }

    public MTLDynamicLibrary NewDynamicLibrary(MTLLibrary library, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLDynamicLibrary(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewDynamicLibrary_error_, library.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLDynamicLibrary NewDynamicLibrary(NSURL url, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLDynamicLibrary(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewDynamicLibrary_error_, url.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLEvent NewEvent()
    {
        var result = new MTLEvent(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewEvent));

        return result;
    }

    public MTLFence NewFence()
    {
        var result = new MTLFence(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewFence));

        return result;
    }

    public MTLHeap NewHeap(MTLHeapDescriptor descriptor)
    {
        var result = new MTLHeap(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewHeap_, descriptor.NativePtr));

        return result;
    }

    public MTLIOCommandQueue NewIOCommandQueue(MTLIOCommandQueueDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLIOCommandQueue(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewIOCommandQueue_error_, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLIOFileHandle NewIOFileHandle(NSURL url, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLIOFileHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewIOFileHandle_error_, url.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLIOFileHandle NewIOFileHandle(NSURL url, MTLIOCompressionMethod compressionMethod, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLIOFileHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewIOFileHandle_compressionMethod_error_, url.NativePtr, (nint)(uint)compressionMethod, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLIOFileHandle NewIOHandle(NSURL url, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLIOFileHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewIOHandle_error_, url.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLIOFileHandle NewIOHandle(NSURL url, MTLIOCompressionMethod compressionMethod, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLIOFileHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewIOHandle_compressionMethod_error_, url.NativePtr, (nint)(uint)compressionMethod, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLIndirectCommandBuffer NewIndirectCommandBuffer(MTLIndirectCommandBufferDescriptor descriptor, nuint maxCount, nuint options)
    {
        var result = new MTLIndirectCommandBuffer(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewIndirectCommandBuffer_maxCount_options_, descriptor.NativePtr, (nint)maxCount, (nint)options));

        return result;
    }

    public MTLLibrary NewLibrary(NSString filepath, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLLibrary(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewLibrary_error_, filepath.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLLibrary NewLibrary(NSURL url, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLLibrary(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewLibrary_error_, url.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLLibrary NewLibrary(nint data, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLLibrary(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewLibrary_error_, data, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLLibrary NewLibrary(NSString source, MTLCompileOptions options, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLLibrary(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewLibrary_options_error_, source.NativePtr, options.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLLibrary NewLibrary(MTLStitchedLibraryDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLLibrary(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewLibrary_error_, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public void NewLibrary(NSString pSource, MTLCompileOptions pOptions, nint completionHandler)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDeviceSelector.NewLibrary_pOptions_completionHandler_, pSource.NativePtr, pOptions.NativePtr, completionHandler);
    }

    public void NewLibrary(MTLStitchedLibraryDescriptor pDescriptor, nint completionHandler)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDeviceSelector.NewLibrary_completionHandler_, pDescriptor.NativePtr, completionHandler);
    }

    public MTLLogState NewLogState(MTLLogStateDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLLogState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewLogState_error_, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTL4CommandQueue NewMTL4CommandQueue()
    {
        var result = new MTL4CommandQueue(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewMTL4CommandQueue));

        return result;
    }

    public MTL4CommandQueue NewMTL4CommandQueue(MTL4CommandQueueDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTL4CommandQueue(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewMTL4CommandQueue_error_, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTL4PipelineDataSetSerializer NewPipelineDataSetSerializer(MTL4PipelineDataSetSerializerDescriptor descriptor)
    {
        var result = new MTL4PipelineDataSetSerializer(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewPipelineDataSetSerializer_, descriptor.NativePtr));

        return result;
    }

    public MTLRasterizationRateMap NewRasterizationRateMap(MTLRasterizationRateMapDescriptor descriptor)
    {
        var result = new MTLRasterizationRateMap(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewRasterizationRateMap_, descriptor.NativePtr));

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTLRenderPipelineDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLRenderPipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewRenderPipelineState_error_, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTLRenderPipelineDescriptor descriptor, nuint options, nint reflection, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLRenderPipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewRenderPipelineState_options_reflection_error_, descriptor.NativePtr, (nint)options, reflection, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTLTileRenderPipelineDescriptor descriptor, nuint options, nint reflection, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLRenderPipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewRenderPipelineState_options_reflection_error_, descriptor.NativePtr, (nint)options, reflection, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTLMeshRenderPipelineDescriptor descriptor, nuint options, nint reflection, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLRenderPipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewRenderPipelineState_options_reflection_error_, descriptor.NativePtr, (nint)options, reflection, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public void NewRenderPipelineState(MTLRenderPipelineDescriptor pDescriptor, nint completionHandler)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDeviceSelector.NewRenderPipelineState_completionHandler_, pDescriptor.NativePtr, completionHandler);
    }

    public MTLResidencySet NewResidencySet(MTLResidencySetDescriptor desc, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLResidencySet(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewResidencySet_error_, desc.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLSamplerState NewSamplerState(MTLSamplerDescriptor descriptor)
    {
        var result = new MTLSamplerState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewSamplerState_, descriptor.NativePtr));

        return result;
    }

    public MTLSharedEvent NewSharedEvent()
    {
        var result = new MTLSharedEvent(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewSharedEvent));

        return result;
    }

    public MTLSharedEvent NewSharedEvent(MTLSharedEventHandle sharedEventHandle)
    {
        var result = new MTLSharedEvent(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewSharedEvent_, sharedEventHandle.NativePtr));

        return result;
    }

    public MTLTexture NewSharedTexture(MTLTextureDescriptor descriptor)
    {
        var result = new MTLTexture(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewSharedTexture_, descriptor.NativePtr));

        return result;
    }

    public MTLTexture NewSharedTexture(MTLSharedTextureHandle sharedHandle)
    {
        var result = new MTLTexture(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewSharedTexture_, sharedHandle.NativePtr));

        return result;
    }

    public MTLTensor NewTensor(MTLTensorDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLTensor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewTensor_error_, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor)
    {
        var result = new MTLTexture(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewTexture_, descriptor.NativePtr));

        return result;
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor, nint iosurface, nuint plane)
    {
        var result = new MTLTexture(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewTexture_iosurface_plane_, descriptor.NativePtr, iosurface, (nint)plane));

        return result;
    }

    public MTLTextureViewPool NewTextureViewPool(MTLResourceViewPoolDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLTextureViewPool(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewTextureViewPool_error_, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public void SampleTimestamps(nint cpuTimestamp, nint gpuTimestamp)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDeviceSelector.SampleTimestamps_gpuTimestamp_, cpuTimestamp, gpuTimestamp);
    }

    public void SetShouldMaximizeConcurrentCompilation(Bool8 shouldMaximizeConcurrentCompilation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDeviceSelector.SetShouldMaximizeConcurrentCompilation_, (nint)shouldMaximizeConcurrentCompilation.Value);
    }

    public nuint SizeOfCounterHeapEntry(MTL4CounterHeapType type)
    {
        var result = (nuint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.SizeOfCounterHeapEntry_, (nint)(uint)type);

        return result;
    }

    public Bool8 SupportsCounterSampling(MTLCounterSamplingPoint samplingPoint)
    {
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.SupportsCounterSampling_, (nint)(uint)samplingPoint) is not 0;

        return result;
    }

    public Bool8 SupportsFamily(MTLGPUFamily gpuFamily)
    {
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.SupportsFamily_, (nint)(uint)gpuFamily) is not 0;

        return result;
    }

    public Bool8 SupportsFeatureSet(MTLFeatureSet featureSet)
    {
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.SupportsFeatureSet_, (nint)(uint)featureSet) is not 0;

        return result;
    }

    public Bool8 SupportsRasterizationRateMap(nuint layerCount)
    {
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.SupportsRasterizationRateMap_, (nint)layerCount) is not 0;

        return result;
    }

    public Bool8 SupportsTextureSampleCount(nuint sampleCount)
    {
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.SupportsTextureSampleCount_, (nint)sampleCount) is not 0;

        return result;
    }

    public Bool8 SupportsVertexAmplificationCount(nuint count)
    {
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.SupportsVertexAmplificationCount_, (nint)count) is not 0;

        return result;
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
