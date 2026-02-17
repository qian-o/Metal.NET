using System.Runtime.InteropServices;

#nullable enable

namespace Metal.NET;

public partial class MTLDevice : IDisposable
{
    public MTLDevice(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        var result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.AccelerationStructureSizes, descriptor.NativePtr);

        return result;
    }

    public MTLFunctionHandle FunctionHandle(MTLFunction function)
    {
        var result = new MTLFunctionHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.FunctionHandle, function.NativePtr));

        return result;
    }

    public MTLFunctionHandle FunctionHandle(MTL4BinaryFunction function)
    {
        var result = new MTLFunctionHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.FunctionHandle, function.NativePtr));

        return result;
    }

    public nuint MinimumLinearTextureAlignmentForPixelFormat(MTLPixelFormat format)
    {
        var result = (nuint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.MinimumLinearTextureAlignmentForPixelFormat, (nint)(uint)format);

        return result;
    }

    public nuint MinimumTextureBufferAlignmentForPixelFormat(MTLPixelFormat format)
    {
        var result = (nuint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.MinimumTextureBufferAlignmentForPixelFormat, (nint)(uint)format);

        return result;
    }

    public MTLAccelerationStructure NewAccelerationStructure(uint size)
    {
        var result = new MTLAccelerationStructure(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewAccelerationStructure, (nint)size));

        return result;
    }

    public MTLAccelerationStructure NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor)
    {
        var result = new MTLAccelerationStructure(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewAccelerationStructure, descriptor.NativePtr));

        return result;
    }

    public MTL4Archive NewArchive(NSURL url, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTL4Archive(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewArchiveError, url.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLArgumentEncoder NewArgumentEncoder(NSArray arguments)
    {
        var result = new MTLArgumentEncoder(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewArgumentEncoder, arguments.NativePtr));

        return result;
    }

    public MTLArgumentEncoder NewArgumentEncoder(MTLBufferBinding bufferBinding)
    {
        var result = new MTLArgumentEncoder(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewArgumentEncoder, bufferBinding.NativePtr));

        return result;
    }

    public MTL4ArgumentTable NewArgumentTable(MTL4ArgumentTableDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTL4ArgumentTable(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewArgumentTableError, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLBinaryArchive NewBinaryArchive(MTLBinaryArchiveDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLBinaryArchive(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewBinaryArchiveError, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLBuffer NewBuffer(uint length, uint options)
    {
        var result = new MTLBuffer(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewBufferOptions, (nint)length, (nint)options));

        return result;
    }

    public MTLBuffer NewBuffer(int pointer, uint length, uint options)
    {
        var result = new MTLBuffer(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewBufferLengthOptions, pointer, (nint)length, (nint)options));

        return result;
    }

    public MTLBuffer NewBuffer(uint length, uint options, MTLSparsePageSize placementSparsePageSize)
    {
        var result = new MTLBuffer(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewBufferOptionsPlacementSparsePageSize, (nint)length, (nint)options, (nint)(uint)placementSparsePageSize));

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
        var result = new MTL4CommandAllocator(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewCommandAllocatorError, descriptor.NativePtr, out errorPtr));
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

    public MTLCommandQueue NewCommandQueue(uint maxCommandBufferCount)
    {
        var result = new MTLCommandQueue(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewCommandQueue1, (nint)maxCommandBufferCount));

        return result;
    }

    public MTLCommandQueue NewCommandQueue(MTLCommandQueueDescriptor descriptor)
    {
        var result = new MTLCommandQueue(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewCommandQueue1, descriptor.NativePtr));

        return result;
    }

    public MTL4Compiler NewCompiler(MTL4CompilerDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTL4Compiler(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewCompilerError, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLComputePipelineState NewComputePipelineState(MTLFunction computeFunction, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLComputePipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewComputePipelineStateError, computeFunction.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLComputePipelineState NewComputePipelineState(MTLFunction computeFunction, uint options, int reflection, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLComputePipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewComputePipelineStateOptionsReflectionError, computeFunction.NativePtr, (nint)options, reflection, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLComputePipelineState NewComputePipelineState(MTLComputePipelineDescriptor descriptor, uint options, int reflection, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLComputePipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewComputePipelineStateOptionsReflectionError, descriptor.NativePtr, (nint)options, reflection, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public void NewComputePipelineState(MTLFunction pFunction, int completionHandler)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDeviceSelector.NewComputePipelineStateCompletionHandler, pFunction.NativePtr, completionHandler);
    }

    public MTL4CounterHeap NewCounterHeap(MTL4CounterHeapDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTL4CounterHeap(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewCounterHeapError, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLCounterSampleBuffer NewCounterSampleBuffer(MTLCounterSampleBufferDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLCounterSampleBuffer(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewCounterSampleBufferError, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLLibrary NewDefaultLibrary()
    {
        var result = new MTLLibrary(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewDefaultLibrary));

        return result;
    }

    public MTLLibrary NewDefaultLibrary(int bundle, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLLibrary(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewDefaultLibraryError, bundle, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLDepthStencilState NewDepthStencilState(MTLDepthStencilDescriptor descriptor)
    {
        var result = new MTLDepthStencilState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewDepthStencilState, descriptor.NativePtr));

        return result;
    }

    public MTLDynamicLibrary NewDynamicLibrary(MTLLibrary library, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLDynamicLibrary(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewDynamicLibraryError, library.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLDynamicLibrary NewDynamicLibrary(NSURL url, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLDynamicLibrary(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewDynamicLibraryError, url.NativePtr, out errorPtr));
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
        var result = new MTLHeap(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewHeap, descriptor.NativePtr));

        return result;
    }

    public MTLIOCommandQueue NewIOCommandQueue(MTLIOCommandQueueDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLIOCommandQueue(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewIOCommandQueueError, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLIOFileHandle NewIOFileHandle(NSURL url, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLIOFileHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewIOFileHandleError, url.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLIOFileHandle NewIOFileHandle(NSURL url, MTLIOCompressionMethod compressionMethod, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLIOFileHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewIOFileHandleCompressionMethodError, url.NativePtr, (nint)(uint)compressionMethod, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLIOFileHandle NewIOHandle(NSURL url, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLIOFileHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewIOHandleError, url.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLIOFileHandle NewIOHandle(NSURL url, MTLIOCompressionMethod compressionMethod, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLIOFileHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewIOHandleCompressionMethodError, url.NativePtr, (nint)(uint)compressionMethod, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLIndirectCommandBuffer NewIndirectCommandBuffer(MTLIndirectCommandBufferDescriptor descriptor, uint maxCount, uint options)
    {
        var result = new MTLIndirectCommandBuffer(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewIndirectCommandBufferMaxCountOptions, descriptor.NativePtr, (nint)maxCount, (nint)options));

        return result;
    }

    public MTLLibrary NewLibrary(NSString filepath, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLLibrary(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewLibraryError, filepath.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLLibrary NewLibrary(NSURL url, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLLibrary(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewLibraryError, url.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLLibrary NewLibrary(int data, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLLibrary(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewLibraryError, data, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLLibrary NewLibrary(NSString source, MTLCompileOptions options, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLLibrary(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewLibraryOptionsError, source.NativePtr, options.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLLibrary NewLibrary(MTLStitchedLibraryDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLLibrary(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewLibraryError, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public void NewLibrary(NSString pSource, MTLCompileOptions pOptions, int completionHandler)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDeviceSelector.NewLibraryPOptionsCompletionHandler, pSource.NativePtr, pOptions.NativePtr, completionHandler);
    }

    public void NewLibrary(MTLStitchedLibraryDescriptor pDescriptor, int completionHandler)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDeviceSelector.NewLibraryCompletionHandler, pDescriptor.NativePtr, completionHandler);
    }

    public MTLLogState NewLogState(MTLLogStateDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLLogState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewLogStateError, descriptor.NativePtr, out errorPtr));
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
        var result = new MTL4CommandQueue(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewMTL4CommandQueueError, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTL4PipelineDataSetSerializer NewPipelineDataSetSerializer(MTL4PipelineDataSetSerializerDescriptor descriptor)
    {
        var result = new MTL4PipelineDataSetSerializer(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewPipelineDataSetSerializer, descriptor.NativePtr));

        return result;
    }

    public MTLRasterizationRateMap NewRasterizationRateMap(MTLRasterizationRateMapDescriptor descriptor)
    {
        var result = new MTLRasterizationRateMap(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewRasterizationRateMap, descriptor.NativePtr));

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTLRenderPipelineDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLRenderPipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewRenderPipelineStateError, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTLRenderPipelineDescriptor descriptor, uint options, int reflection, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLRenderPipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewRenderPipelineStateOptionsReflectionError, descriptor.NativePtr, (nint)options, reflection, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTLTileRenderPipelineDescriptor descriptor, uint options, int reflection, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLRenderPipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewRenderPipelineStateOptionsReflectionError, descriptor.NativePtr, (nint)options, reflection, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTLMeshRenderPipelineDescriptor descriptor, uint options, int reflection, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLRenderPipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewRenderPipelineStateOptionsReflectionError, descriptor.NativePtr, (nint)options, reflection, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public void NewRenderPipelineState(MTLRenderPipelineDescriptor pDescriptor, int completionHandler)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDeviceSelector.NewRenderPipelineStateCompletionHandler, pDescriptor.NativePtr, completionHandler);
    }

    public MTLResidencySet NewResidencySet(MTLResidencySetDescriptor desc, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLResidencySet(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewResidencySetError, desc.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLSamplerState NewSamplerState(MTLSamplerDescriptor descriptor)
    {
        var result = new MTLSamplerState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewSamplerState, descriptor.NativePtr));

        return result;
    }

    public MTLSharedEvent NewSharedEvent()
    {
        var result = new MTLSharedEvent(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewSharedEvent));

        return result;
    }

    public MTLSharedEvent NewSharedEvent(MTLSharedEventHandle sharedEventHandle)
    {
        var result = new MTLSharedEvent(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewSharedEvent1, sharedEventHandle.NativePtr));

        return result;
    }

    public MTLTexture NewSharedTexture(MTLTextureDescriptor descriptor)
    {
        var result = new MTLTexture(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewSharedTexture, descriptor.NativePtr));

        return result;
    }

    public MTLTexture NewSharedTexture(MTLSharedTextureHandle sharedHandle)
    {
        var result = new MTLTexture(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewSharedTexture, sharedHandle.NativePtr));

        return result;
    }

    public MTLTensor NewTensor(MTLTensorDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLTensor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewTensorError, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor)
    {
        var result = new MTLTexture(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewTexture, descriptor.NativePtr));

        return result;
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor, int iosurface, uint plane)
    {
        var result = new MTLTexture(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewTextureIosurfacePlane, descriptor.NativePtr, iosurface, (nint)plane));

        return result;
    }

    public MTLTextureViewPool NewTextureViewPool(MTLResourceViewPoolDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLTextureViewPool(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.NewTextureViewPoolError, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public void SampleTimestamps(int cpuTimestamp, int gpuTimestamp)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDeviceSelector.SampleTimestampsGpuTimestamp, cpuTimestamp, gpuTimestamp);
    }

    public void SetShouldMaximizeConcurrentCompilation(Bool8 shouldMaximizeConcurrentCompilation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDeviceSelector.SetShouldMaximizeConcurrentCompilation, (nint)shouldMaximizeConcurrentCompilation.Value);
    }

    public nuint SizeOfCounterHeapEntry(MTL4CounterHeapType type)
    {
        var result = (nuint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.SizeOfCounterHeapEntry, (nint)(uint)type);

        return result;
    }

    public Bool8 SupportsCounterSampling(MTLCounterSamplingPoint samplingPoint)
    {
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.SupportsCounterSampling, (nint)(uint)samplingPoint) is not 0;

        return result;
    }

    public Bool8 SupportsFamily(MTLGPUFamily gpuFamily)
    {
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.SupportsFamily, (nint)(uint)gpuFamily) is not 0;

        return result;
    }

    public Bool8 SupportsFeatureSet(MTLFeatureSet featureSet)
    {
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.SupportsFeatureSet, (nint)(uint)featureSet) is not 0;

        return result;
    }

    public Bool8 SupportsRasterizationRateMap(uint layerCount)
    {
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.SupportsRasterizationRateMap, (nint)layerCount) is not 0;

        return result;
    }

    public Bool8 SupportsTextureSampleCount(uint sampleCount)
    {
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.SupportsTextureSampleCount, (nint)sampleCount) is not 0;

        return result;
    }

    public Bool8 SupportsVertexAmplificationCount(uint count)
    {
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDeviceSelector.SupportsVertexAmplificationCount, (nint)count) is not 0;

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

file class MTLDeviceSelector
{
    public static readonly Selector AccelerationStructureSizes = Selector.Register("accelerationStructureSizes:");
    public static readonly Selector FunctionHandle = Selector.Register("functionHandle:");
    public static readonly Selector HeapAccelerationStructureSizeAndAlign = Selector.Register("heapAccelerationStructureSizeAndAlign:");
    public static readonly Selector HeapBufferSizeAndAlignOptions = Selector.Register("heapBufferSizeAndAlign:options:");
    public static readonly Selector HeapTextureSizeAndAlign = Selector.Register("heapTextureSizeAndAlign:");
    public static readonly Selector MinimumLinearTextureAlignmentForPixelFormat = Selector.Register("minimumLinearTextureAlignmentForPixelFormat:");
    public static readonly Selector MinimumTextureBufferAlignmentForPixelFormat = Selector.Register("minimumTextureBufferAlignmentForPixelFormat:");
    public static readonly Selector NewAccelerationStructure = Selector.Register("newAccelerationStructure:");
    public static readonly Selector NewArchiveError = Selector.Register("newArchive:error:");
    public static readonly Selector NewArgumentEncoder = Selector.Register("newArgumentEncoder:");
    public static readonly Selector NewArgumentTableError = Selector.Register("newArgumentTable:error:");
    public static readonly Selector NewBinaryArchiveError = Selector.Register("newBinaryArchive:error:");
    public static readonly Selector NewBufferOptions = Selector.Register("newBuffer:options:");
    public static readonly Selector NewBufferLengthOptions = Selector.Register("newBuffer:length:options:");
    public static readonly Selector NewBufferOptionsPlacementSparsePageSize = Selector.Register("newBuffer:options:placementSparsePageSize:");
    public static readonly Selector NewCommandAllocator = Selector.Register("newCommandAllocator");
    public static readonly Selector NewCommandAllocatorError = Selector.Register("newCommandAllocator:error:");
    public static readonly Selector NewCommandBuffer = Selector.Register("newCommandBuffer");
    public static readonly Selector NewCommandQueue = Selector.Register("newCommandQueue");
    public static readonly Selector NewCommandQueue1 = Selector.Register("newCommandQueue:");
    public static readonly Selector NewCompilerError = Selector.Register("newCompiler:error:");
    public static readonly Selector NewComputePipelineStateError = Selector.Register("newComputePipelineState:error:");
    public static readonly Selector NewComputePipelineStateOptionsReflectionError = Selector.Register("newComputePipelineState:options:reflection:error:");
    public static readonly Selector NewComputePipelineStateCompletionHandler = Selector.Register("newComputePipelineState:completionHandler:");
    public static readonly Selector NewCounterHeapError = Selector.Register("newCounterHeap:error:");
    public static readonly Selector NewCounterSampleBufferError = Selector.Register("newCounterSampleBuffer:error:");
    public static readonly Selector NewDefaultLibrary = Selector.Register("newDefaultLibrary");
    public static readonly Selector NewDefaultLibraryError = Selector.Register("newDefaultLibrary:error:");
    public static readonly Selector NewDepthStencilState = Selector.Register("newDepthStencilState:");
    public static readonly Selector NewDynamicLibraryError = Selector.Register("newDynamicLibrary:error:");
    public static readonly Selector NewEvent = Selector.Register("newEvent");
    public static readonly Selector NewFence = Selector.Register("newFence");
    public static readonly Selector NewHeap = Selector.Register("newHeap:");
    public static readonly Selector NewIOCommandQueueError = Selector.Register("newIOCommandQueue:error:");
    public static readonly Selector NewIOFileHandleError = Selector.Register("newIOFileHandle:error:");
    public static readonly Selector NewIOFileHandleCompressionMethodError = Selector.Register("newIOFileHandle:compressionMethod:error:");
    public static readonly Selector NewIOHandleError = Selector.Register("newIOHandle:error:");
    public static readonly Selector NewIOHandleCompressionMethodError = Selector.Register("newIOHandle:compressionMethod:error:");
    public static readonly Selector NewIndirectCommandBufferMaxCountOptions = Selector.Register("newIndirectCommandBuffer:maxCount:options:");
    public static readonly Selector NewLibraryError = Selector.Register("newLibrary:error:");
    public static readonly Selector NewLibraryOptionsError = Selector.Register("newLibrary:options:error:");
    public static readonly Selector NewLibraryPOptionsCompletionHandler = Selector.Register("newLibrary:pOptions:completionHandler:");
    public static readonly Selector NewLibraryCompletionHandler = Selector.Register("newLibrary:completionHandler:");
    public static readonly Selector NewLogStateError = Selector.Register("newLogState:error:");
    public static readonly Selector NewMTL4CommandQueue = Selector.Register("newMTL4CommandQueue");
    public static readonly Selector NewMTL4CommandQueueError = Selector.Register("newMTL4CommandQueue:error:");
    public static readonly Selector NewPipelineDataSetSerializer = Selector.Register("newPipelineDataSetSerializer:");
    public static readonly Selector NewRasterizationRateMap = Selector.Register("newRasterizationRateMap:");
    public static readonly Selector NewRenderPipelineStateError = Selector.Register("newRenderPipelineState:error:");
    public static readonly Selector NewRenderPipelineStateOptionsReflectionError = Selector.Register("newRenderPipelineState:options:reflection:error:");
    public static readonly Selector NewRenderPipelineStateCompletionHandler = Selector.Register("newRenderPipelineState:completionHandler:");
    public static readonly Selector NewResidencySetError = Selector.Register("newResidencySet:error:");
    public static readonly Selector NewSamplerState = Selector.Register("newSamplerState:");
    public static readonly Selector NewSharedEvent = Selector.Register("newSharedEvent");
    public static readonly Selector NewSharedEvent1 = Selector.Register("newSharedEvent:");
    public static readonly Selector NewSharedTexture = Selector.Register("newSharedTexture:");
    public static readonly Selector NewTensorError = Selector.Register("newTensor:error:");
    public static readonly Selector NewTexture = Selector.Register("newTexture:");
    public static readonly Selector NewTextureIosurfacePlane = Selector.Register("newTexture:iosurface:plane:");
    public static readonly Selector NewTextureViewPoolError = Selector.Register("newTextureViewPool:error:");
    public static readonly Selector SampleTimestampsGpuTimestamp = Selector.Register("sampleTimestamps:gpuTimestamp:");
    public static readonly Selector SetShouldMaximizeConcurrentCompilation = Selector.Register("setShouldMaximizeConcurrentCompilation:");
    public static readonly Selector SizeOfCounterHeapEntry = Selector.Register("sizeOfCounterHeapEntry:");
    public static readonly Selector SparseTileSizePixelFormatSampleCount = Selector.Register("sparseTileSize:pixelFormat:sampleCount:");
    public static readonly Selector SparseTileSizePixelFormatSampleCountSparsePageSize = Selector.Register("sparseTileSize:pixelFormat:sampleCount:sparsePageSize:");
    public static readonly Selector SupportsCounterSampling = Selector.Register("supportsCounterSampling:");
    public static readonly Selector SupportsFamily = Selector.Register("supportsFamily:");
    public static readonly Selector SupportsFeatureSet = Selector.Register("supportsFeatureSet:");
    public static readonly Selector SupportsRasterizationRateMap = Selector.Register("supportsRasterizationRateMap:");
    public static readonly Selector SupportsTextureSampleCount = Selector.Register("supportsTextureSampleCount:");
    public static readonly Selector SupportsVertexAmplificationCount = Selector.Register("supportsVertexAmplificationCount:");
    public static readonly Selector TensorSizeAndAlign = Selector.Register("tensorSizeAndAlign:");
}
