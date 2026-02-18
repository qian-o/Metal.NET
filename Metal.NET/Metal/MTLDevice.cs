using System.Runtime.InteropServices;

namespace Metal.NET;

public partial class MTLDevice : IDisposable
{
    public MTLDevice(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLDevice()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nint Architecture
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.Architecture);
    }

    public Bool8 AreBarycentricCoordsSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.AreBarycentricCoordsSupported);
    }

    public Bool8 AreProgrammableSamplePositionsSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.AreProgrammableSamplePositionsSupported);
    }

    public Bool8 AreRasterOrderGroupsSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.AreRasterOrderGroupsSupported);
    }

    public MTLArgumentBuffersTier ArgumentBuffersSupport
    {
        get => (MTLArgumentBuffersTier)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLDeviceSelector.ArgumentBuffersSupport));
    }

    public Bool8 BarycentricCoordsSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.AreBarycentricCoordsSupported);
    }

    public NSArray CounterSets
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.CounterSets));
    }

    public nuint CurrentAllocatedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceSelector.CurrentAllocatedSize);
    }

    public Bool8 Depth24Stencil8PixelFormatSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.IsDepth24Stencil8PixelFormatSupported);
    }

    public Bool8 HasUnifiedMemory
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.HasUnifiedMemory);
    }

    public Bool8 Headless
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.IsHeadless);
    }

    public Bool8 IsDepth24Stencil8PixelFormatSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.IsDepth24Stencil8PixelFormatSupported);
    }

    public Bool8 IsHeadless
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.IsHeadless);
    }

    public Bool8 IsLowPower
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.IsLowPower);
    }

    public Bool8 IsRemovable
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.IsRemovable);
    }

    public MTLDeviceLocation Location
    {
        get => (MTLDeviceLocation)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLDeviceSelector.Location));
    }

    public nuint LocationNumber
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceSelector.LocationNumber);
    }

    public Bool8 LowPower
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.IsLowPower);
    }

    public nuint MaxArgumentBufferSamplerCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceSelector.MaxArgumentBufferSamplerCount);
    }

    public nuint MaxBufferLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceSelector.MaxBufferLength);
    }

    public nuint MaxThreadgroupMemoryLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceSelector.MaxThreadgroupMemoryLength);
    }

    public MTLSize MaxThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLDeviceSelector.MaxThreadsPerThreadgroup);
    }

    public nuint MaxTransferRate
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceSelector.MaxTransferRate);
    }

    public nuint MaximumConcurrentCompilationTaskCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceSelector.MaximumConcurrentCompilationTaskCount);
    }

    public NSString Name
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.Name));
    }

    public uint PeerCount
    {
        get => ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLDeviceSelector.PeerCount);
    }

    public nuint PeerGroupID
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceSelector.PeerGroupID);
    }

    public uint PeerIndex
    {
        get => ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLDeviceSelector.PeerIndex);
    }

    public Bool8 ProgrammableSamplePositionsSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.AreProgrammableSamplePositionsSupported);
    }

    public nuint QueryTimestampFrequency
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceSelector.QueryTimestampFrequency);
    }

    public Bool8 RasterOrderGroupsSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.AreRasterOrderGroupsSupported);
    }

    public MTLReadWriteTextureTier ReadWriteTextureSupport
    {
        get => (MTLReadWriteTextureTier)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLDeviceSelector.ReadWriteTextureSupport));
    }

    public nuint RecommendedMaxWorkingSetSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceSelector.RecommendedMaxWorkingSetSize);
    }

    public nuint RegistryID
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceSelector.RegistryID);
    }

    public Bool8 Removable
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.IsRemovable);
    }

    public Bool8 ShouldMaximizeConcurrentCompilation
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.ShouldMaximizeConcurrentCompilation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLDeviceSelector.SetShouldMaximizeConcurrentCompilation, value);
    }

    public nuint SparseTileSizeInBytes
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceSelector.SparseTileSizeInBytesForSparsePageSize);
    }

    public Bool8 Supports32BitFloatFiltering
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.Supports32BitFloatFiltering);
    }

    public Bool8 Supports32BitMSAA
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.Supports32BitMSAA);
    }

    public Bool8 SupportsBCTextureCompression
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsBCTextureCompression);
    }

    public Bool8 SupportsDynamicLibraries
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsDynamicLibraries);
    }

    public Bool8 SupportsFunctionPointers
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsFunctionPointers);
    }

    public Bool8 SupportsFunctionPointersFromRender
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsFunctionPointersFromRender);
    }

    public Bool8 SupportsPrimitiveMotionBlur
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsPrimitiveMotionBlur);
    }

    public Bool8 SupportsPullModelInterpolation
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsPullModelInterpolation);
    }

    public Bool8 SupportsQueryTextureLOD
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsQueryTextureLOD);
    }

    public Bool8 SupportsRaytracing
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsRaytracing);
    }

    public Bool8 SupportsRaytracingFromRender
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsRaytracingFromRender);
    }

    public Bool8 SupportsRenderDynamicLibraries
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsRenderDynamicLibraries);
    }

    public Bool8 SupportsShaderBarycentricCoordinates
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsShaderBarycentricCoordinates);
    }

    public nint AccelerationStructureSizes(MTLAccelerationStructureDescriptor descriptor)
    {
        nint result = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.AccelerationStructureSizesWithDescriptor, descriptor.NativePtr);

        return result;
    }

    public void ConvertSparsePixelRegions(MTLRegion pixelRegions, MTLRegion tileRegions, MTLSize tileSize, MTLSparseTextureRegionAlignmentMode mode, nuint numRegions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLDeviceSelector.ConvertSparsePixelRegionsToTileRegionsWithTileSizeAlignmentModeNumRegions, pixelRegions, tileRegions, tileSize, (ulong)mode, numRegions);
    }

    public void ConvertSparseTileRegions(MTLRegion tileRegions, MTLRegion pixelRegions, MTLSize tileSize, nuint numRegions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLDeviceSelector.ConvertSparseTileRegionsToPixelRegionsWithTileSizeNumRegions, tileRegions, pixelRegions, tileSize, numRegions);
    }

    public void GetDefaultSamplePositions(MTLSamplePosition positions, nuint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLDeviceSelector.GetDefaultSamplePositionsCount, positions, count);
    }

    public MTLSizeAndAlign HeapAccelerationStructureSizeAndAlign(nuint size)
    {
        MTLSizeAndAlign result = ObjectiveCRuntime.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceSelector.HeapAccelerationStructureSizeAndAlignWithDescriptor, size);

        return result;
    }

    public MTLSizeAndAlign HeapAccelerationStructureSizeAndAlign(MTLAccelerationStructureDescriptor descriptor)
    {
        MTLSizeAndAlign result = ObjectiveCRuntime.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceSelector.HeapAccelerationStructureSizeAndAlignWithDescriptor, descriptor.NativePtr);

        return result;
    }

    public MTLSizeAndAlign HeapBufferSizeAndAlign(nuint length, MTLResourceOptions options)
    {
        MTLSizeAndAlign result = ObjectiveCRuntime.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceSelector.HeapBufferSizeAndAlignWithLengthOptions, length, (ulong)options);

        return result;
    }

    public MTLSizeAndAlign HeapTextureSizeAndAlign(MTLTextureDescriptor desc)
    {
        MTLSizeAndAlign result = ObjectiveCRuntime.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceSelector.HeapTextureSizeAndAlignWithDescriptor, desc.NativePtr);

        return result;
    }

    public nuint MinimumLinearTextureAlignmentForPixelFormat(MTLPixelFormat format)
    {
        nuint result = ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceSelector.MinimumLinearTextureAlignmentForPixelFormat, (ulong)format);

        return result;
    }

    public nuint MinimumTextureBufferAlignmentForPixelFormat(MTLPixelFormat format)
    {
        nuint result = ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceSelector.MinimumTextureBufferAlignmentForPixelFormat, (ulong)format);

        return result;
    }

    public MTLAccelerationStructure NewAccelerationStructure(nuint size)
    {
        MTLAccelerationStructure result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewAccelerationStructureWithDescriptor, size));

        return result;
    }

    public MTLAccelerationStructure NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor)
    {
        MTLAccelerationStructure result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewAccelerationStructureWithDescriptor, descriptor.NativePtr));

        return result;
    }

    public MTL4Archive NewArchive(NSURL url, out NSError? error)
    {
        MTL4Archive result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewArchiveWithURLError, url.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLArgumentEncoder NewArgumentEncoder(NSArray arguments)
    {
        MTLArgumentEncoder result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewArgumentEncoderWithBufferBinding, arguments.NativePtr));

        return result;
    }

    public MTLArgumentEncoder NewArgumentEncoder(MTLBufferBinding bufferBinding)
    {
        MTLArgumentEncoder result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewArgumentEncoderWithBufferBinding, bufferBinding.NativePtr));

        return result;
    }

    public MTL4ArgumentTable NewArgumentTable(MTL4ArgumentTableDescriptor descriptor, out NSError? error)
    {
        MTL4ArgumentTable result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewArgumentTableWithDescriptorError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLBinaryArchive NewBinaryArchive(MTLBinaryArchiveDescriptor descriptor, out NSError? error)
    {
        MTLBinaryArchive result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewBinaryArchiveWithDescriptorError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLBuffer NewBuffer(nuint length, MTLResourceOptions options)
    {
        MTLBuffer result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewBufferWithLengthOptionsPlacementSparsePageSize, length, (ulong)options));

        return result;
    }

    public MTLBuffer NewBuffer(nint pointer, nuint length, MTLResourceOptions options)
    {
        MTLBuffer result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewBufferWithLengthOptionsPlacementSparsePageSize, pointer, length, (ulong)options));

        return result;
    }

    public MTLBuffer NewBuffer(nuint length, MTLResourceOptions options, MTLSparsePageSize placementSparsePageSize)
    {
        MTLBuffer result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewBufferWithLengthOptionsPlacementSparsePageSize, length, (ulong)options, (ulong)placementSparsePageSize));

        return result;
    }

    public MTL4CommandAllocator NewCommandAllocator()
    {
        MTL4CommandAllocator result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewCommandAllocatorWithDescriptorError));

        return result;
    }

    public MTL4CommandAllocator NewCommandAllocator(MTL4CommandAllocatorDescriptor descriptor, out NSError? error)
    {
        MTL4CommandAllocator result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewCommandAllocatorWithDescriptorError, descriptor.NativePtr, out nint errorPtr));

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
        MTLCommandQueue result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewCommandQueueWithDescriptor));

        return result;
    }

    public MTLCommandQueue NewCommandQueue(nuint maxCommandBufferCount)
    {
        MTLCommandQueue result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewCommandQueueWithDescriptor, maxCommandBufferCount));

        return result;
    }

    public MTLCommandQueue NewCommandQueue(MTLCommandQueueDescriptor descriptor)
    {
        MTLCommandQueue result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewCommandQueueWithDescriptor, descriptor.NativePtr));

        return result;
    }

    public MTL4Compiler NewCompiler(MTL4CompilerDescriptor descriptor, out NSError? error)
    {
        MTL4Compiler result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewCompilerWithDescriptorError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLComputePipelineState NewComputePipelineState(MTLComputePipelineDescriptor descriptor, MTLPipelineOption options, MTLComputePipelineReflection reflection, out NSError? error)
    {
        MTLComputePipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewComputePipelineStateWithDescriptorOptionsCompletionHandler, descriptor.NativePtr, (ulong)options, reflection.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTL4CounterHeap NewCounterHeap(MTL4CounterHeapDescriptor descriptor, out NSError? error)
    {
        MTL4CounterHeap result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewCounterHeapWithDescriptorError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLCounterSampleBuffer NewCounterSampleBuffer(MTLCounterSampleBufferDescriptor descriptor, out NSError? error)
    {
        MTLCounterSampleBuffer result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewCounterSampleBufferWithDescriptorError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLLibrary NewDefaultLibrary()
    {
        MTLLibrary result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewDefaultLibraryWithBundleError));

        return result;
    }

    public MTLLibrary NewDefaultLibrary(nint bundle, out NSError? error)
    {
        MTLLibrary result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewDefaultLibraryWithBundleError, bundle, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLDepthStencilState NewDepthStencilState(MTLDepthStencilDescriptor descriptor)
    {
        MTLDepthStencilState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewDepthStencilStateWithDescriptor, descriptor.NativePtr));

        return result;
    }

    public MTLDynamicLibrary NewDynamicLibrary(MTLLibrary library, out NSError? error)
    {
        MTLDynamicLibrary result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewDynamicLibraryWithURLError, library.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLDynamicLibrary NewDynamicLibrary(NSURL url, out NSError? error)
    {
        MTLDynamicLibrary result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewDynamicLibraryWithURLError, url.NativePtr, out nint errorPtr));

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
        MTLHeap result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewHeapWithDescriptor, descriptor.NativePtr));

        return result;
    }

    public MTLIOCommandQueue NewIOCommandQueue(MTLIOCommandQueueDescriptor descriptor, out NSError? error)
    {
        MTLIOCommandQueue result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewIOCommandQueueWithDescriptorError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLIOFileHandle NewIOFileHandle(NSURL url, out NSError? error)
    {
        MTLIOFileHandle result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewIOFileHandleWithURLCompressionMethodError, url.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLIOFileHandle NewIOFileHandle(NSURL url, MTLIOCompressionMethod compressionMethod, out NSError? error)
    {
        MTLIOFileHandle result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewIOFileHandleWithURLCompressionMethodError, url.NativePtr, (ulong)compressionMethod, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLIOFileHandle NewIOHandle(NSURL url, out NSError? error)
    {
        MTLIOFileHandle result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewIOHandleWithURLCompressionMethodError, url.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLIOFileHandle NewIOHandle(NSURL url, MTLIOCompressionMethod compressionMethod, out NSError? error)
    {
        MTLIOFileHandle result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewIOHandleWithURLCompressionMethodError, url.NativePtr, (ulong)compressionMethod, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLIndirectCommandBuffer NewIndirectCommandBuffer(MTLIndirectCommandBufferDescriptor descriptor, nuint maxCount, MTLResourceOptions options)
    {
        MTLIndirectCommandBuffer result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewIndirectCommandBufferWithDescriptorMaxCommandCountOptions, descriptor.NativePtr, maxCount, (ulong)options));

        return result;
    }

    public MTLLibrary NewLibrary(NSString filepath, out NSError? error)
    {
        MTLLibrary result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewLibraryWithStitchedDescriptorCompletionHandler, filepath.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLLibrary NewLibrary(NSURL url, out NSError? error)
    {
        MTLLibrary result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewLibraryWithStitchedDescriptorCompletionHandler, url.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLLibrary NewLibrary(nint data, out NSError? error)
    {
        MTLLibrary result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewLibraryWithStitchedDescriptorCompletionHandler, data, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLLibrary NewLibrary(NSString source, MTLCompileOptions options, out NSError? error)
    {
        MTLLibrary result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewLibraryWithStitchedDescriptorCompletionHandler, source.NativePtr, options.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLLibrary NewLibrary(MTLStitchedLibraryDescriptor descriptor, out NSError? error)
    {
        MTLLibrary result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewLibraryWithStitchedDescriptorCompletionHandler, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLLogState NewLogState(MTLLogStateDescriptor descriptor, out NSError? error)
    {
        MTLLogState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewLogStateWithDescriptorError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTL4CommandQueue NewMTL4CommandQueue()
    {
        MTL4CommandQueue result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewMTL4CommandQueueWithDescriptorError));

        return result;
    }

    public MTL4CommandQueue NewMTL4CommandQueue(MTL4CommandQueueDescriptor descriptor, out NSError? error)
    {
        MTL4CommandQueue result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewMTL4CommandQueueWithDescriptorError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTL4PipelineDataSetSerializer NewPipelineDataSetSerializer(MTL4PipelineDataSetSerializerDescriptor descriptor)
    {
        MTL4PipelineDataSetSerializer result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewPipelineDataSetSerializerWithDescriptor, descriptor.NativePtr));

        return result;
    }

    public MTLRasterizationRateMap NewRasterizationRateMap(MTLRasterizationRateMapDescriptor descriptor)
    {
        MTLRasterizationRateMap result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewRasterizationRateMapWithDescriptor, descriptor.NativePtr));

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTLRenderPipelineDescriptor descriptor, out NSError? error)
    {
        MTLRenderPipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewRenderPipelineStateWithMeshDescriptorOptionsCompletionHandler, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTLRenderPipelineDescriptor descriptor, MTLPipelineOption options, MTLRenderPipelineReflection reflection, out NSError? error)
    {
        MTLRenderPipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewRenderPipelineStateWithMeshDescriptorOptionsCompletionHandler, descriptor.NativePtr, (ulong)options, reflection.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTLTileRenderPipelineDescriptor descriptor, MTLPipelineOption options, MTLRenderPipelineReflection reflection, out NSError? error)
    {
        MTLRenderPipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewRenderPipelineStateWithMeshDescriptorOptionsCompletionHandler, descriptor.NativePtr, (ulong)options, reflection.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTLMeshRenderPipelineDescriptor descriptor, MTLPipelineOption options, MTLRenderPipelineReflection reflection, out NSError? error)
    {
        MTLRenderPipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewRenderPipelineStateWithMeshDescriptorOptionsCompletionHandler, descriptor.NativePtr, (ulong)options, reflection.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLResidencySet NewResidencySet(MTLResidencySetDescriptor desc, out NSError? error)
    {
        MTLResidencySet result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewResidencySetWithDescriptorError, desc.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLSamplerState NewSamplerState(MTLSamplerDescriptor descriptor)
    {
        MTLSamplerState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewSamplerStateWithDescriptor, descriptor.NativePtr));

        return result;
    }

    public MTLSharedEvent NewSharedEvent()
    {
        MTLSharedEvent result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewSharedEventWithHandle));

        return result;
    }

    public MTLSharedEvent NewSharedEvent(MTLSharedEventHandle sharedEventHandle)
    {
        MTLSharedEvent result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewSharedEventWithHandle, sharedEventHandle.NativePtr));

        return result;
    }

    public MTLTexture NewSharedTexture(MTLTextureDescriptor descriptor)
    {
        MTLTexture result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewSharedTextureWithHandle, descriptor.NativePtr));

        return result;
    }

    public MTLTexture NewSharedTexture(MTLSharedTextureHandle sharedHandle)
    {
        MTLTexture result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewSharedTextureWithHandle, sharedHandle.NativePtr));

        return result;
    }

    public MTLTensor NewTensor(MTLTensorDescriptor descriptor, out NSError? error)
    {
        MTLTensor result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewTensorWithDescriptorError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor)
    {
        MTLTexture result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewTextureWithDescriptorIosurfacePlane, descriptor.NativePtr));

        return result;
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor, nint iosurface, nuint plane)
    {
        MTLTexture result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewTextureWithDescriptorIosurfacePlane, descriptor.NativePtr, iosurface, plane));

        return result;
    }

    public MTLTextureViewPool NewTextureViewPool(MTLResourceViewPoolDescriptor descriptor, out NSError? error)
    {
        MTLTextureViewPool result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewTextureViewPoolWithDescriptorError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public void SampleTimestamps(nuint cpuTimestamp, nuint gpuTimestamp)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLDeviceSelector.SampleTimestampsGpuTimestamp, cpuTimestamp, gpuTimestamp);
    }

    public nuint SizeOfCounterHeapEntry(MTL4CounterHeapType type)
    {
        nuint result = ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceSelector.SizeOfCounterHeapEntry, (ulong)type);

        return result;
    }

    public MTLSize SparseTileSize(MTLTextureType textureType, MTLPixelFormat pixelFormat, nuint sampleCount)
    {
        MTLSize result = ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLDeviceSelector.SparseTileSizeWithTextureTypePixelFormatSampleCountSparsePageSize, (ulong)textureType, (ulong)pixelFormat, sampleCount);

        return result;
    }

    public MTLSize SparseTileSize(MTLTextureType textureType, MTLPixelFormat pixelFormat, nuint sampleCount, MTLSparsePageSize sparsePageSize)
    {
        MTLSize result = ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLDeviceSelector.SparseTileSizeWithTextureTypePixelFormatSampleCountSparsePageSize, (ulong)textureType, (ulong)pixelFormat, sampleCount, (ulong)sparsePageSize);

        return result;
    }

    public Bool8 SupportsCounterSampling(MTLCounterSamplingPoint samplingPoint)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsCounterSampling, (ulong)samplingPoint);

        return result;
    }

    public Bool8 SupportsFamily(MTLGPUFamily gpuFamily)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsFamily, (ulong)gpuFamily);

        return result;
    }

    public Bool8 SupportsFeatureSet(MTLFeatureSet featureSet)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsFeatureSet, (ulong)featureSet);

        return result;
    }

    public Bool8 SupportsRasterizationRateMap(nuint layerCount)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsRasterizationRateMapWithLayerCount, layerCount);

        return result;
    }

    public Bool8 SupportsTextureSampleCount(nuint sampleCount)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsTextureSampleCount, sampleCount);

        return result;
    }

    public Bool8 SupportsVertexAmplificationCount(nuint count)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsVertexAmplificationCount, count);

        return result;
    }

    public MTLSizeAndAlign TensorSizeAndAlign(MTLTensorDescriptor descriptor)
    {
        MTLSizeAndAlign result = ObjectiveCRuntime.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceSelector.TensorSizeAndAlignWithDescriptor, descriptor.NativePtr);

        return result;
    }

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

    [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal", EntryPoint = "MTLCreateSystemDefaultDevice")]
    private static partial nint _MTLCreateSystemDefaultDevice();

    public static MTLDevice MTLCreateSystemDefaultDevice()
    {
        return new(_MTLCreateSystemDefaultDevice());
    }

    [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal", EntryPoint = "MTLCopyAllDevices")]
    private static partial nint _MTLCopyAllDevices();

    public static NSArray MTLCopyAllDevices()
    {
        return new(_MTLCopyAllDevices());
    }

    [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal", EntryPoint = "MTLRemoveDeviceObserver")]
    private static partial void _MTLRemoveDeviceObserver(nint param0);

    public static void MTLRemoveDeviceObserver(nint param0)
    {
        _MTLRemoveDeviceObserver(param0);
    }
}

file class MTLDeviceSelector
{
    public static readonly Selector Architecture = Selector.Register("architecture");

    public static readonly Selector AreBarycentricCoordsSupported = Selector.Register("areBarycentricCoordsSupported");

    public static readonly Selector AreProgrammableSamplePositionsSupported = Selector.Register("areProgrammableSamplePositionsSupported");

    public static readonly Selector AreRasterOrderGroupsSupported = Selector.Register("areRasterOrderGroupsSupported");

    public static readonly Selector ArgumentBuffersSupport = Selector.Register("argumentBuffersSupport");

    public static readonly Selector CounterSets = Selector.Register("counterSets");

    public static readonly Selector CurrentAllocatedSize = Selector.Register("currentAllocatedSize");

    public static readonly Selector IsDepth24Stencil8PixelFormatSupported = Selector.Register("isDepth24Stencil8PixelFormatSupported");

    public static readonly Selector HasUnifiedMemory = Selector.Register("hasUnifiedMemory");

    public static readonly Selector IsHeadless = Selector.Register("isHeadless");

    public static readonly Selector IsLowPower = Selector.Register("isLowPower");

    public static readonly Selector IsRemovable = Selector.Register("isRemovable");

    public static readonly Selector Location = Selector.Register("location");

    public static readonly Selector LocationNumber = Selector.Register("locationNumber");

    public static readonly Selector MaxArgumentBufferSamplerCount = Selector.Register("maxArgumentBufferSamplerCount");

    public static readonly Selector MaxBufferLength = Selector.Register("maxBufferLength");

    public static readonly Selector MaxThreadgroupMemoryLength = Selector.Register("maxThreadgroupMemoryLength");

    public static readonly Selector MaxThreadsPerThreadgroup = Selector.Register("maxThreadsPerThreadgroup");

    public static readonly Selector MaxTransferRate = Selector.Register("maxTransferRate");

    public static readonly Selector MaximumConcurrentCompilationTaskCount = Selector.Register("maximumConcurrentCompilationTaskCount");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector PeerCount = Selector.Register("peerCount");

    public static readonly Selector PeerGroupID = Selector.Register("peerGroupID");

    public static readonly Selector PeerIndex = Selector.Register("peerIndex");

    public static readonly Selector QueryTimestampFrequency = Selector.Register("queryTimestampFrequency");

    public static readonly Selector ReadWriteTextureSupport = Selector.Register("readWriteTextureSupport");

    public static readonly Selector RecommendedMaxWorkingSetSize = Selector.Register("recommendedMaxWorkingSetSize");

    public static readonly Selector RegistryID = Selector.Register("registryID");

    public static readonly Selector ShouldMaximizeConcurrentCompilation = Selector.Register("shouldMaximizeConcurrentCompilation");

    public static readonly Selector SetShouldMaximizeConcurrentCompilation = Selector.Register("setShouldMaximizeConcurrentCompilation:");

    public static readonly Selector SparseTileSizeInBytesForSparsePageSize = Selector.Register("sparseTileSizeInBytesForSparsePageSize:");

    public static readonly Selector Supports32BitFloatFiltering = Selector.Register("supports32BitFloatFiltering");

    public static readonly Selector Supports32BitMSAA = Selector.Register("supports32BitMSAA");

    public static readonly Selector SupportsBCTextureCompression = Selector.Register("supportsBCTextureCompression");

    public static readonly Selector SupportsDynamicLibraries = Selector.Register("supportsDynamicLibraries");

    public static readonly Selector SupportsFunctionPointers = Selector.Register("supportsFunctionPointers");

    public static readonly Selector SupportsFunctionPointersFromRender = Selector.Register("supportsFunctionPointersFromRender");

    public static readonly Selector SupportsPrimitiveMotionBlur = Selector.Register("supportsPrimitiveMotionBlur");

    public static readonly Selector SupportsPullModelInterpolation = Selector.Register("supportsPullModelInterpolation");

    public static readonly Selector SupportsQueryTextureLOD = Selector.Register("supportsQueryTextureLOD");

    public static readonly Selector SupportsRaytracing = Selector.Register("supportsRaytracing");

    public static readonly Selector SupportsRaytracingFromRender = Selector.Register("supportsRaytracingFromRender");

    public static readonly Selector SupportsRenderDynamicLibraries = Selector.Register("supportsRenderDynamicLibraries");

    public static readonly Selector SupportsShaderBarycentricCoordinates = Selector.Register("supportsShaderBarycentricCoordinates");

    public static readonly Selector AccelerationStructureSizesWithDescriptor = Selector.Register("accelerationStructureSizesWithDescriptor:");

    public static readonly Selector ConvertSparsePixelRegionsToTileRegionsWithTileSizeAlignmentModeNumRegions = Selector.Register("convertSparsePixelRegions:toTileRegions:withTileSize:alignmentMode:numRegions:");

    public static readonly Selector ConvertSparseTileRegionsToPixelRegionsWithTileSizeNumRegions = Selector.Register("convertSparseTileRegions:toPixelRegions:withTileSize:numRegions:");

    public static readonly Selector GetDefaultSamplePositionsCount = Selector.Register("getDefaultSamplePositions:count:");

    public static readonly Selector HeapAccelerationStructureSizeAndAlignWithDescriptor = Selector.Register("heapAccelerationStructureSizeAndAlignWithDescriptor:");

    public static readonly Selector HeapBufferSizeAndAlignWithLengthOptions = Selector.Register("heapBufferSizeAndAlignWithLength:options:");

    public static readonly Selector HeapTextureSizeAndAlignWithDescriptor = Selector.Register("heapTextureSizeAndAlignWithDescriptor:");

    public static readonly Selector MinimumLinearTextureAlignmentForPixelFormat = Selector.Register("minimumLinearTextureAlignmentForPixelFormat:");

    public static readonly Selector MinimumTextureBufferAlignmentForPixelFormat = Selector.Register("minimumTextureBufferAlignmentForPixelFormat:");

    public static readonly Selector NewAccelerationStructureWithDescriptor = Selector.Register("newAccelerationStructureWithDescriptor:");

    public static readonly Selector NewArchiveWithURLError = Selector.Register("newArchiveWithURL:error:");

    public static readonly Selector NewArgumentEncoderWithBufferBinding = Selector.Register("newArgumentEncoderWithBufferBinding:");

    public static readonly Selector NewArgumentTableWithDescriptorError = Selector.Register("newArgumentTableWithDescriptor:error:");

    public static readonly Selector NewBinaryArchiveWithDescriptorError = Selector.Register("newBinaryArchiveWithDescriptor:error:");

    public static readonly Selector NewBufferWithLengthOptionsPlacementSparsePageSize = Selector.Register("newBufferWithLength:options:placementSparsePageSize:");

    public static readonly Selector NewCommandAllocatorWithDescriptorError = Selector.Register("newCommandAllocatorWithDescriptor:error:");

    public static readonly Selector NewCommandBuffer = Selector.Register("newCommandBuffer");

    public static readonly Selector NewCommandQueueWithDescriptor = Selector.Register("newCommandQueueWithDescriptor:");

    public static readonly Selector NewCompilerWithDescriptorError = Selector.Register("newCompilerWithDescriptor:error:");

    public static readonly Selector NewComputePipelineStateWithDescriptorOptionsCompletionHandler = Selector.Register("newComputePipelineStateWithDescriptor:options:completionHandler:");

    public static readonly Selector NewCounterHeapWithDescriptorError = Selector.Register("newCounterHeapWithDescriptor:error:");

    public static readonly Selector NewCounterSampleBufferWithDescriptorError = Selector.Register("newCounterSampleBufferWithDescriptor:error:");

    public static readonly Selector NewDefaultLibraryWithBundleError = Selector.Register("newDefaultLibraryWithBundle:error:");

    public static readonly Selector NewDepthStencilStateWithDescriptor = Selector.Register("newDepthStencilStateWithDescriptor:");

    public static readonly Selector NewDynamicLibraryWithURLError = Selector.Register("newDynamicLibraryWithURL:error:");

    public static readonly Selector NewEvent = Selector.Register("newEvent");

    public static readonly Selector NewFence = Selector.Register("newFence");

    public static readonly Selector NewHeapWithDescriptor = Selector.Register("newHeapWithDescriptor:");

    public static readonly Selector NewIOCommandQueueWithDescriptorError = Selector.Register("newIOCommandQueueWithDescriptor:error:");

    public static readonly Selector NewIOFileHandleWithURLCompressionMethodError = Selector.Register("newIOFileHandleWithURL:compressionMethod:error:");

    public static readonly Selector NewIOHandleWithURLCompressionMethodError = Selector.Register("newIOHandleWithURL:compressionMethod:error:");

    public static readonly Selector NewIndirectCommandBufferWithDescriptorMaxCommandCountOptions = Selector.Register("newIndirectCommandBufferWithDescriptor:maxCommandCount:options:");

    public static readonly Selector NewLibraryWithStitchedDescriptorCompletionHandler = Selector.Register("newLibraryWithStitchedDescriptor:completionHandler:");

    public static readonly Selector NewLogStateWithDescriptorError = Selector.Register("newLogStateWithDescriptor:error:");

    public static readonly Selector NewMTL4CommandQueueWithDescriptorError = Selector.Register("newMTL4CommandQueueWithDescriptor:error:");

    public static readonly Selector NewPipelineDataSetSerializerWithDescriptor = Selector.Register("newPipelineDataSetSerializerWithDescriptor:");

    public static readonly Selector NewRasterizationRateMapWithDescriptor = Selector.Register("newRasterizationRateMapWithDescriptor:");

    public static readonly Selector NewRenderPipelineStateWithMeshDescriptorOptionsCompletionHandler = Selector.Register("newRenderPipelineStateWithMeshDescriptor:options:completionHandler:");

    public static readonly Selector NewResidencySetWithDescriptorError = Selector.Register("newResidencySetWithDescriptor:error:");

    public static readonly Selector NewSamplerStateWithDescriptor = Selector.Register("newSamplerStateWithDescriptor:");

    public static readonly Selector NewSharedEventWithHandle = Selector.Register("newSharedEventWithHandle:");

    public static readonly Selector NewSharedTextureWithHandle = Selector.Register("newSharedTextureWithHandle:");

    public static readonly Selector NewTensorWithDescriptorError = Selector.Register("newTensorWithDescriptor:error:");

    public static readonly Selector NewTextureWithDescriptorIosurfacePlane = Selector.Register("newTextureWithDescriptor:iosurface:plane:");

    public static readonly Selector NewTextureViewPoolWithDescriptorError = Selector.Register("newTextureViewPoolWithDescriptor:error:");

    public static readonly Selector SampleTimestampsGpuTimestamp = Selector.Register("sampleTimestamps:gpuTimestamp:");

    public static readonly Selector SizeOfCounterHeapEntry = Selector.Register("sizeOfCounterHeapEntry:");

    public static readonly Selector SparseTileSizeWithTextureTypePixelFormatSampleCountSparsePageSize = Selector.Register("sparseTileSizeWithTextureType:pixelFormat:sampleCount:sparsePageSize:");

    public static readonly Selector SupportsCounterSampling = Selector.Register("supportsCounterSampling:");

    public static readonly Selector SupportsFamily = Selector.Register("supportsFamily:");

    public static readonly Selector SupportsFeatureSet = Selector.Register("supportsFeatureSet:");

    public static readonly Selector SupportsRasterizationRateMapWithLayerCount = Selector.Register("supportsRasterizationRateMapWithLayerCount:");

    public static readonly Selector SupportsTextureSampleCount = Selector.Register("supportsTextureSampleCount:");

    public static readonly Selector SupportsVertexAmplificationCount = Selector.Register("supportsVertexAmplificationCount:");

    public static readonly Selector TensorSizeAndAlignWithDescriptor = Selector.Register("tensorSizeAndAlignWithDescriptor:");
}
