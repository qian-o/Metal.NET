using System.Runtime.InteropServices;

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
        nint result = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.AccelerationStructureSizes, descriptor.NativePtr);

        return result;
    }

    public MTLFunctionHandle FunctionHandle(MTLFunction function)
    {
        MTLFunctionHandle result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.FunctionHandle, function.NativePtr));

        return result;
    }

    public MTLFunctionHandle FunctionHandle(MTL4BinaryFunction function)
    {
        MTLFunctionHandle result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.FunctionHandle, function.NativePtr));

        return result;
    }

    public nuint MinimumLinearTextureAlignmentForPixelFormat(MTLPixelFormat format)
    {
        nuint result = (nuint)(ulong)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.MinimumLinearTextureAlignmentForPixelFormat, (nint)(uint)format);

        return result;
    }

    public nuint MinimumTextureBufferAlignmentForPixelFormat(MTLPixelFormat format)
    {
        nuint result = (nuint)(ulong)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.MinimumTextureBufferAlignmentForPixelFormat, (nint)(uint)format);

        return result;
    }

    public MTLAccelerationStructure NewAccelerationStructure(uint size)
    {
        MTLAccelerationStructure result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewAccelerationStructure, (nint)size));

        return result;
    }

    public MTLAccelerationStructure NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor)
    {
        MTLAccelerationStructure result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewAccelerationStructure, descriptor.NativePtr));

        return result;
    }

    public MTL4Archive NewArchive(NSURL url, out NSError? error)
    {
        MTL4Archive result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewArchiveError, url.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLArgumentEncoder NewArgumentEncoder(NSArray arguments)
    {
        MTLArgumentEncoder result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewArgumentEncoder, arguments.NativePtr));

        return result;
    }

    public MTLArgumentEncoder NewArgumentEncoder(MTLBufferBinding bufferBinding)
    {
        MTLArgumentEncoder result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewArgumentEncoder, bufferBinding.NativePtr));

        return result;
    }

    public MTL4ArgumentTable NewArgumentTable(MTL4ArgumentTableDescriptor descriptor, out NSError? error)
    {
        MTL4ArgumentTable result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewArgumentTableError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLBinaryArchive NewBinaryArchive(MTLBinaryArchiveDescriptor descriptor, out NSError? error)
    {
        MTLBinaryArchive result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewBinaryArchiveError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLBuffer NewBuffer(uint length, uint options)
    {
        MTLBuffer result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewBufferOptions, (nint)length, (nint)options));

        return result;
    }

    public MTLBuffer NewBuffer(int pointer, uint length, uint options)
    {
        MTLBuffer result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewBufferLengthOptions, pointer, (nint)length, (nint)options));

        return result;
    }

    public MTLBuffer NewBuffer(uint length, uint options, MTLSparsePageSize placementSparsePageSize)
    {
        MTLBuffer result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewBufferOptionsPlacementSparsePageSize, (nint)length, (nint)options, (nint)(uint)placementSparsePageSize));

        return result;
    }

    public MTL4CommandAllocator NewCommandAllocator()
    {
        MTL4CommandAllocator result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewCommandAllocator));

        return result;
    }

    public MTL4CommandAllocator NewCommandAllocator(MTL4CommandAllocatorDescriptor descriptor, out NSError? error)
    {
        MTL4CommandAllocator result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewCommandAllocatorError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTL4CommandBuffer NewCommandBuffer()
    {
        MTL4CommandBuffer result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewCommandBuffer));

        return result;
    }

    public MTLCommandQueue NewCommandQueue()
    {
        MTLCommandQueue result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewCommandQueue));

        return result;
    }

    public MTLCommandQueue NewCommandQueue(uint maxCommandBufferCount)
    {
        MTLCommandQueue result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewCommandQueue1, (nint)maxCommandBufferCount));

        return result;
    }

    public MTLCommandQueue NewCommandQueue(MTLCommandQueueDescriptor descriptor)
    {
        MTLCommandQueue result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewCommandQueue1, descriptor.NativePtr));

        return result;
    }

    public MTL4Compiler NewCompiler(MTL4CompilerDescriptor descriptor, out NSError? error)
    {
        MTL4Compiler result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewCompilerError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLComputePipelineState NewComputePipelineState(MTLFunction computeFunction, out NSError? error)
    {
        MTLComputePipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewComputePipelineStateError, computeFunction.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLComputePipelineState NewComputePipelineState(MTLFunction computeFunction, uint options, int reflection, out NSError? error)
    {
        MTLComputePipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewComputePipelineStateOptionsReflectionError, computeFunction.NativePtr, (nint)options, reflection, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLComputePipelineState NewComputePipelineState(MTLComputePipelineDescriptor descriptor, uint options, int reflection, out NSError? error)
    {
        MTLComputePipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewComputePipelineStateOptionsReflectionError, descriptor.NativePtr, (nint)options, reflection, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public void NewComputePipelineState(MTLFunction pFunction, int completionHandler)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLDeviceSelector.NewComputePipelineStateCompletionHandler, pFunction.NativePtr, completionHandler);
    }

    public MTL4CounterHeap NewCounterHeap(MTL4CounterHeapDescriptor descriptor, out NSError? error)
    {
        MTL4CounterHeap result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewCounterHeapError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLCounterSampleBuffer NewCounterSampleBuffer(MTLCounterSampleBufferDescriptor descriptor, out NSError? error)
    {
        MTLCounterSampleBuffer result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewCounterSampleBufferError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLLibrary NewDefaultLibrary()
    {
        MTLLibrary result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewDefaultLibrary));

        return result;
    }

    public MTLLibrary NewDefaultLibrary(int bundle, out NSError? error)
    {
        MTLLibrary result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewDefaultLibraryError, bundle, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLDepthStencilState NewDepthStencilState(MTLDepthStencilDescriptor descriptor)
    {
        MTLDepthStencilState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewDepthStencilState, descriptor.NativePtr));

        return result;
    }

    public MTLDynamicLibrary NewDynamicLibrary(MTLLibrary library, out NSError? error)
    {
        MTLDynamicLibrary result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewDynamicLibraryError, library.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLDynamicLibrary NewDynamicLibrary(NSURL url, out NSError? error)
    {
        MTLDynamicLibrary result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewDynamicLibraryError, url.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLEvent NewEvent()
    {
        MTLEvent result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewEvent));

        return result;
    }

    public MTLFence NewFence()
    {
        MTLFence result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewFence));

        return result;
    }

    public MTLHeap NewHeap(MTLHeapDescriptor descriptor)
    {
        MTLHeap result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewHeap, descriptor.NativePtr));

        return result;
    }

    public MTLIOCommandQueue NewIOCommandQueue(MTLIOCommandQueueDescriptor descriptor, out NSError? error)
    {
        MTLIOCommandQueue result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewIOCommandQueueError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLIOFileHandle NewIOFileHandle(NSURL url, out NSError? error)
    {
        MTLIOFileHandle result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewIOFileHandleError, url.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLIOFileHandle NewIOFileHandle(NSURL url, MTLIOCompressionMethod compressionMethod, out NSError? error)
    {
        MTLIOFileHandle result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewIOFileHandleCompressionMethodError, url.NativePtr, (nint)(uint)compressionMethod, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLIOFileHandle NewIOHandle(NSURL url, out NSError? error)
    {
        MTLIOFileHandle result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewIOHandleError, url.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLIOFileHandle NewIOHandle(NSURL url, MTLIOCompressionMethod compressionMethod, out NSError? error)
    {
        MTLIOFileHandle result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewIOHandleCompressionMethodError, url.NativePtr, (nint)(uint)compressionMethod, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLIndirectCommandBuffer NewIndirectCommandBuffer(MTLIndirectCommandBufferDescriptor descriptor, uint maxCount, uint options)
    {
        MTLIndirectCommandBuffer result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewIndirectCommandBufferMaxCountOptions, descriptor.NativePtr, (nint)maxCount, (nint)options));

        return result;
    }

    public MTLLibrary NewLibrary(NSString filepath, out NSError? error)
    {
        MTLLibrary result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewLibraryError, filepath.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLLibrary NewLibrary(NSURL url, out NSError? error)
    {
        MTLLibrary result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewLibraryError, url.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLLibrary NewLibrary(int data, out NSError? error)
    {
        MTLLibrary result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewLibraryError, data, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLLibrary NewLibrary(NSString source, MTLCompileOptions options, out NSError? error)
    {
        MTLLibrary result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewLibraryOptionsError, source.NativePtr, options.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLLibrary NewLibrary(MTLStitchedLibraryDescriptor descriptor, out NSError? error)
    {
        MTLLibrary result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewLibraryError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public void NewLibrary(NSString pSource, MTLCompileOptions pOptions, int completionHandler)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLDeviceSelector.NewLibraryPOptionsCompletionHandler, pSource.NativePtr, pOptions.NativePtr, completionHandler);
    }

    public void NewLibrary(MTLStitchedLibraryDescriptor pDescriptor, int completionHandler)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLDeviceSelector.NewLibraryCompletionHandler, pDescriptor.NativePtr, completionHandler);
    }

    public MTLLogState NewLogState(MTLLogStateDescriptor descriptor, out NSError? error)
    {
        MTLLogState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewLogStateError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTL4CommandQueue NewMTL4CommandQueue()
    {
        MTL4CommandQueue result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewMTL4CommandQueue));

        return result;
    }

    public MTL4CommandQueue NewMTL4CommandQueue(MTL4CommandQueueDescriptor descriptor, out NSError? error)
    {
        MTL4CommandQueue result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewMTL4CommandQueueError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTL4PipelineDataSetSerializer NewPipelineDataSetSerializer(MTL4PipelineDataSetSerializerDescriptor descriptor)
    {
        MTL4PipelineDataSetSerializer result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewPipelineDataSetSerializer, descriptor.NativePtr));

        return result;
    }

    public MTLRasterizationRateMap NewRasterizationRateMap(MTLRasterizationRateMapDescriptor descriptor)
    {
        MTLRasterizationRateMap result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewRasterizationRateMap, descriptor.NativePtr));

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTLRenderPipelineDescriptor descriptor, out NSError? error)
    {
        MTLRenderPipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewRenderPipelineStateError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTLRenderPipelineDescriptor descriptor, uint options, int reflection, out NSError? error)
    {
        MTLRenderPipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewRenderPipelineStateOptionsReflectionError, descriptor.NativePtr, (nint)options, reflection, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTLTileRenderPipelineDescriptor descriptor, uint options, int reflection, out NSError? error)
    {
        MTLRenderPipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewRenderPipelineStateOptionsReflectionError, descriptor.NativePtr, (nint)options, reflection, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTLMeshRenderPipelineDescriptor descriptor, uint options, int reflection, out NSError? error)
    {
        MTLRenderPipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewRenderPipelineStateOptionsReflectionError, descriptor.NativePtr, (nint)options, reflection, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public void NewRenderPipelineState(MTLRenderPipelineDescriptor pDescriptor, int completionHandler)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLDeviceSelector.NewRenderPipelineStateCompletionHandler, pDescriptor.NativePtr, completionHandler);
    }

    public MTLResidencySet NewResidencySet(MTLResidencySetDescriptor desc, out NSError? error)
    {
        MTLResidencySet result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewResidencySetError, desc.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLSamplerState NewSamplerState(MTLSamplerDescriptor descriptor)
    {
        MTLSamplerState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewSamplerState, descriptor.NativePtr));

        return result;
    }

    public MTLSharedEvent NewSharedEvent()
    {
        MTLSharedEvent result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewSharedEvent));

        return result;
    }

    public MTLSharedEvent NewSharedEvent(MTLSharedEventHandle sharedEventHandle)
    {
        MTLSharedEvent result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewSharedEvent1, sharedEventHandle.NativePtr));

        return result;
    }

    public MTLTexture NewSharedTexture(MTLTextureDescriptor descriptor)
    {
        MTLTexture result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewSharedTexture, descriptor.NativePtr));

        return result;
    }

    public MTLTexture NewSharedTexture(MTLSharedTextureHandle sharedHandle)
    {
        MTLTexture result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewSharedTexture, sharedHandle.NativePtr));

        return result;
    }

    public MTLTensor NewTensor(MTLTensorDescriptor descriptor, out NSError? error)
    {
        MTLTensor result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewTensorError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor)
    {
        MTLTexture result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewTexture, descriptor.NativePtr));

        return result;
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor, int iosurface, uint plane)
    {
        MTLTexture result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewTextureIosurfacePlane, descriptor.NativePtr, iosurface, (nint)plane));

        return result;
    }

    public MTLTextureViewPool NewTextureViewPool(MTLResourceViewPoolDescriptor descriptor, out NSError? error)
    {
        MTLTextureViewPool result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewTextureViewPoolError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public void SampleTimestamps(int cpuTimestamp, int gpuTimestamp)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLDeviceSelector.SampleTimestampsGpuTimestamp, cpuTimestamp, gpuTimestamp);
    }

    public void SetShouldMaximizeConcurrentCompilation(Bool8 shouldMaximizeConcurrentCompilation)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLDeviceSelector.SetShouldMaximizeConcurrentCompilation, (nint)shouldMaximizeConcurrentCompilation.Value);
    }

    public nuint SizeOfCounterHeapEntry(MTL4CounterHeapType type)
    {
        nuint result = (nuint)(ulong)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.SizeOfCounterHeapEntry, (nint)(uint)type);

        return result;
    }

    public Bool8 SupportsCounterSampling(MTLCounterSamplingPoint samplingPoint)
    {
        bool result = (byte)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.SupportsCounterSampling, (nint)(uint)samplingPoint) is not 0;

        return result;
    }

    public Bool8 SupportsFamily(MTLGPUFamily gpuFamily)
    {
        bool result = (byte)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.SupportsFamily, (nint)(uint)gpuFamily) is not 0;

        return result;
    }

    public Bool8 SupportsFeatureSet(MTLFeatureSet featureSet)
    {
        bool result = (byte)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.SupportsFeatureSet, (nint)(uint)featureSet) is not 0;

        return result;
    }

    public Bool8 SupportsRasterizationRateMap(uint layerCount)
    {
        bool result = (byte)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.SupportsRasterizationRateMap, (nint)layerCount) is not 0;

        return result;
    }

    public Bool8 SupportsTextureSampleCount(uint sampleCount)
    {
        bool result = (byte)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.SupportsTextureSampleCount, (nint)sampleCount) is not 0;

        return result;
    }

    public Bool8 SupportsVertexAmplificationCount(uint count)
    {
        bool result = (byte)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.SupportsVertexAmplificationCount, (nint)count) is not 0;

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
