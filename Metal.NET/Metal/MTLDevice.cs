namespace Metal.NET;

public class MTLDevice(nint nativePtr) : NativeObject(nativePtr)
{

    public MTLArchitecture? Architecture
    {
        get => GetNullableObject<MTLArchitecture>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.Architecture));
    }

    public bool AreBarycentricCoordsSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.AreBarycentricCoordsSupported);
    }

    public bool AreProgrammableSamplePositionsSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.AreProgrammableSamplePositionsSupported);
    }

    public bool AreRasterOrderGroupsSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.AreRasterOrderGroupsSupported);
    }

    public MTLArgumentBuffersTier ArgumentBuffersSupport
    {
        get => (MTLArgumentBuffersTier)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceSelector.ArgumentBuffersSupport);
    }

    public bool BarycentricCoordsSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.BarycentricCoordsSupported);
    }

    public NSArray? CounterSets
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.CounterSets));
    }

    public nuint CurrentAllocatedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceSelector.CurrentAllocatedSize);
    }

    public bool Depth24Stencil8PixelFormatSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.Depth24Stencil8PixelFormatSupported);
    }

    public bool HasUnifiedMemory
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.HasUnifiedMemory);
    }

    public bool Headless
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.Headless);
    }

    public bool IsDepth24Stencil8PixelFormatSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.IsDepth24Stencil8PixelFormatSupported);
    }

    public bool IsHeadless
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.IsHeadless);
    }

    public bool IsLowPower
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.IsLowPower);
    }

    public bool IsRemovable
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.IsRemovable);
    }

    public MTLDeviceLocation Location
    {
        get => (MTLDeviceLocation)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceSelector.Location);
    }

    public nuint LocationNumber
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceSelector.LocationNumber);
    }

    public bool LowPower
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.LowPower);
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

    public NSString? Name
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.Name));
    }

    public MTL4CommandAllocator? NewCommandAllocator
    {
        get => GetNullableObject<MTL4CommandAllocator>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewCommandAllocator));
    }

    public MTL4CommandBuffer? NewCommandBuffer
    {
        get => GetNullableObject<MTL4CommandBuffer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewCommandBuffer));
    }

    public MTLCommandQueue? NewCommandQueue
    {
        get => GetNullableObject<MTLCommandQueue>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewCommandQueue));
    }

    public MTLLibrary? NewDefaultLibrary
    {
        get => GetNullableObject<MTLLibrary>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewDefaultLibrary));
    }

    public MTLEvent? NewEvent
    {
        get => GetNullableObject<MTLEvent>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewEvent));
    }

    public MTLFence? NewFence
    {
        get => GetNullableObject<MTLFence>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewFence));
    }

    public MTL4CommandQueue? NewMTL4CommandQueue
    {
        get => GetNullableObject<MTL4CommandQueue>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewMTL4CommandQueue));
    }

    public MTLSharedEvent? NewSharedEvent
    {
        get => GetNullableObject<MTLSharedEvent>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewSharedEvent));
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

    public bool ProgrammableSamplePositionsSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.ProgrammableSamplePositionsSupported);
    }

    public nuint QueryTimestampFrequency
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceSelector.QueryTimestampFrequency);
    }

    public bool RasterOrderGroupsSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.RasterOrderGroupsSupported);
    }

    public MTLReadWriteTextureTier ReadWriteTextureSupport
    {
        get => (MTLReadWriteTextureTier)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceSelector.ReadWriteTextureSupport);
    }

    public nuint RecommendedMaxWorkingSetSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceSelector.RecommendedMaxWorkingSetSize);
    }

    public nuint RegistryID
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceSelector.RegistryID);
    }

    public bool Removable
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.Removable);
    }

    public bool ShouldMaximizeConcurrentCompilation
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.ShouldMaximizeConcurrentCompilation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLDeviceSelector.SetShouldMaximizeConcurrentCompilation, (Bool8)value);
    }

    public nuint SparseTileSizeInBytes
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceSelector.SparseTileSizeInBytes);
    }

    public bool Supports32BitFloatFiltering
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.Supports32BitFloatFiltering);
    }

    public bool Supports32BitMSAA
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.Supports32BitMSAA);
    }

    public bool SupportsBCTextureCompression
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsBCTextureCompression);
    }

    public bool SupportsDynamicLibraries
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsDynamicLibraries);
    }

    public bool SupportsFunctionPointers
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsFunctionPointers);
    }

    public bool SupportsFunctionPointersFromRender
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsFunctionPointersFromRender);
    }

    public bool SupportsPrimitiveMotionBlur
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsPrimitiveMotionBlur);
    }

    public bool SupportsPullModelInterpolation
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsPullModelInterpolation);
    }

    public bool SupportsQueryTextureLOD
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsQueryTextureLOD);
    }

    public bool SupportsRaytracing
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsRaytracing);
    }

    public bool SupportsRaytracingFromRender
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsRaytracingFromRender);
    }

    public bool SupportsRenderDynamicLibraries
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsRenderDynamicLibraries);
    }

    public bool SupportsShaderBarycentricCoordinates
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsShaderBarycentricCoordinates);
    }

    public MTLAccelerationStructureSizes AccelerationStructureSizes(MTLAccelerationStructureDescriptor descriptor)
    {
        return ObjectiveCRuntime.MsgSendMTLAccelerationStructureSizes(NativePtr, MTLDeviceSelector.AccelerationStructureSizes, descriptor.NativePtr);
    }

    public void ConvertSparsePixelRegions(MTLRegion pixelRegions, MTLRegion tileRegions, MTLSize tileSize, MTLSparseTextureRegionAlignmentMode mode, nuint numRegions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLDeviceSelector.ConvertSparsePixelRegions, pixelRegions, tileRegions, tileSize, (nuint)mode, numRegions);
    }

    public void ConvertSparseTileRegions(MTLRegion tileRegions, MTLRegion pixelRegions, MTLSize tileSize, nuint numRegions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLDeviceSelector.ConvertSparseTileRegions, tileRegions, pixelRegions, tileSize, numRegions);
    }

    public MTLFunctionHandle? FunctionHandle(MTLFunction function)
    {
        return GetNullableObject<MTLFunctionHandle>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.FunctionHandle, function.NativePtr));
    }

    public MTLFunctionHandle? FunctionHandle(MTL4BinaryFunction function)
    {
        return GetNullableObject<MTLFunctionHandle>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.FunctionHandle, function.NativePtr));
    }

    public void GetDefaultSamplePositions(MTLSamplePosition positions, nuint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLDeviceSelector.GetDefaultSamplePositions, positions, count);
    }

    public MTLSizeAndAlign HeapAccelerationStructureSizeAndAlign(nuint size)
    {
        return ObjectiveCRuntime.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceSelector.HeapAccelerationStructureSizeAndAlign, size);
    }

    public MTLSizeAndAlign HeapAccelerationStructureSizeAndAlign(MTLAccelerationStructureDescriptor descriptor)
    {
        return ObjectiveCRuntime.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceSelector.HeapAccelerationStructureSizeAndAlign, descriptor.NativePtr);
    }

    public MTLSizeAndAlign HeapBufferSizeAndAlign(nuint length, MTLResourceOptions options)
    {
        return ObjectiveCRuntime.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceSelector.HeapBufferSizeAndAlign, length, (nuint)options);
    }

    public MTLSizeAndAlign HeapTextureSizeAndAlign(MTLTextureDescriptor desc)
    {
        return ObjectiveCRuntime.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceSelector.HeapTextureSizeAndAlign, desc.NativePtr);
    }

    public nuint MinimumLinearTextureAlignmentForPixelFormat(MTLPixelFormat format)
    {
        return ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceSelector.MinimumLinearTextureAlignmentForPixelFormat, (nuint)format);
    }

    public nuint MinimumTextureBufferAlignmentForPixelFormat(MTLPixelFormat format)
    {
        return ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceSelector.MinimumTextureBufferAlignmentForPixelFormat, (nuint)format);
    }

    public MTLAccelerationStructure? NewAccelerationStructure(nuint size)
    {
        return GetNullableObject<MTLAccelerationStructure>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewAccelerationStructure, size));
    }

    public MTLAccelerationStructure? NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor)
    {
        return GetNullableObject<MTLAccelerationStructure>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewAccelerationStructure, descriptor.NativePtr));
    }

    public MTL4Archive? NewArchive(NSURL url, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewArchive, url.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTL4Archive>(ptr);
    }

    public MTLArgumentEncoder? NewArgumentEncoder(NSArray arguments)
    {
        return GetNullableObject<MTLArgumentEncoder>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewArgumentEncoder, arguments.NativePtr));
    }

    public MTLArgumentEncoder? NewArgumentEncoder(MTLBufferBinding bufferBinding)
    {
        return GetNullableObject<MTLArgumentEncoder>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewArgumentEncoder, bufferBinding.NativePtr));
    }

    public MTL4ArgumentTable? NewArgumentTable(MTL4ArgumentTableDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewArgumentTable, descriptor.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTL4ArgumentTable>(ptr);
    }

    public MTLBinaryArchive? NewBinaryArchive(MTLBinaryArchiveDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewBinaryArchive, descriptor.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLBinaryArchive>(ptr);
    }

    public MTLBuffer? NewBuffer(nuint length, MTLResourceOptions options)
    {
        return GetNullableObject<MTLBuffer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewBuffer, length, (nuint)options));
    }

    public MTLBuffer? NewBuffer(nint pointer, nuint length, MTLResourceOptions options)
    {
        return GetNullableObject<MTLBuffer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewBuffer, pointer, length, (nuint)options));
    }

    public MTLBuffer? NewBuffer(nuint length, MTLResourceOptions options, MTLSparsePageSize placementSparsePageSize)
    {
        return GetNullableObject<MTLBuffer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewBuffer, length, (nuint)options, (nint)placementSparsePageSize));
    }

    public MTL4CommandAllocator? NewCommandAllocatorWithDescriptor(MTL4CommandAllocatorDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewCommandAllocator, descriptor.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTL4CommandAllocator>(ptr);
    }

    public MTLCommandQueue? NewCommandQueueWithMaxCommandBufferCount(nuint maxCommandBufferCount)
    {
        return GetNullableObject<MTLCommandQueue>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewCommandQueue, maxCommandBufferCount));
    }

    public MTLCommandQueue? NewCommandQueueWithDescriptor(MTLCommandQueueDescriptor descriptor)
    {
        return GetNullableObject<MTLCommandQueue>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewCommandQueue, descriptor.NativePtr));
    }

    public MTL4Compiler? NewCompiler(MTL4CompilerDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewCompiler, descriptor.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTL4Compiler>(ptr);
    }

    public MTLComputePipelineState? NewComputePipelineState(MTLFunction computeFunction, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewComputePipelineState, computeFunction.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLComputePipelineState>(ptr);
    }

    public MTL4CounterHeap? NewCounterHeap(MTL4CounterHeapDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewCounterHeap, descriptor.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTL4CounterHeap>(ptr);
    }

    public MTLCounterSampleBuffer? NewCounterSampleBuffer(MTLCounterSampleBufferDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewCounterSampleBuffer, descriptor.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLCounterSampleBuffer>(ptr);
    }

    public MTLDepthStencilState? NewDepthStencilState(MTLDepthStencilDescriptor descriptor)
    {
        return GetNullableObject<MTLDepthStencilState>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewDepthStencilState, descriptor.NativePtr));
    }

    public MTLDynamicLibrary? NewDynamicLibrary(MTLLibrary library, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewDynamicLibrary, library.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLDynamicLibrary>(ptr);
    }

    public MTLDynamicLibrary? NewDynamicLibrary(NSURL url, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewDynamicLibrary, url.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLDynamicLibrary>(ptr);
    }

    public MTLHeap? NewHeap(MTLHeapDescriptor descriptor)
    {
        return GetNullableObject<MTLHeap>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewHeap, descriptor.NativePtr));
    }

    public MTLIOCommandQueue? NewIOCommandQueue(MTLIOCommandQueueDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewIOCommandQueue, descriptor.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLIOCommandQueue>(ptr);
    }

    public MTLIOFileHandle? NewIOFileHandle(NSURL url, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewIOFileHandle, url.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLIOFileHandle>(ptr);
    }

    public MTLIOFileHandle? NewIOFileHandle(NSURL url, MTLIOCompressionMethod compressionMethod, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewIOFileHandle, url.NativePtr, (nint)compressionMethod, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLIOFileHandle>(ptr);
    }

    public MTLIOFileHandle? NewIOHandle(NSURL url, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewIOHandle, url.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLIOFileHandle>(ptr);
    }

    public MTLIOFileHandle? NewIOHandle(NSURL url, MTLIOCompressionMethod compressionMethod, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewIOHandle, url.NativePtr, (nint)compressionMethod, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLIOFileHandle>(ptr);
    }

    public MTLIndirectCommandBuffer? NewIndirectCommandBuffer(MTLIndirectCommandBufferDescriptor descriptor, nuint maxCount, MTLResourceOptions options)
    {
        return GetNullableObject<MTLIndirectCommandBuffer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewIndirectCommandBuffer, descriptor.NativePtr, maxCount, (nuint)options));
    }

    public MTLLibrary? NewLibrary(NSString filepath, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewLibrary, filepath.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLLibrary>(ptr);
    }

    public MTLLibrary? NewLibrary(NSURL url, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewLibrary, url.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLLibrary>(ptr);
    }

    public MTLLibrary? NewLibrary(nint data, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewLibrary, data, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLLibrary>(ptr);
    }

    public MTLLibrary? NewLibrary(NSString source, MTLCompileOptions options, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewLibrary, source.NativePtr, options.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLLibrary>(ptr);
    }

    public MTLLibrary? NewLibrary(MTLStitchedLibraryDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewLibrary, descriptor.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLLibrary>(ptr);
    }

    public MTLLogState? NewLogState(MTLLogStateDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewLogState, descriptor.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLLogState>(ptr);
    }

    public MTL4CommandQueue? NewMTL4CommandQueueWithDescriptor(MTL4CommandQueueDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewMTL4CommandQueue, descriptor.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTL4CommandQueue>(ptr);
    }

    public MTL4PipelineDataSetSerializer? NewPipelineDataSetSerializer(MTL4PipelineDataSetSerializerDescriptor descriptor)
    {
        return GetNullableObject<MTL4PipelineDataSetSerializer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewPipelineDataSetSerializer, descriptor.NativePtr));
    }

    public MTLRasterizationRateMap? NewRasterizationRateMap(MTLRasterizationRateMapDescriptor descriptor)
    {
        return GetNullableObject<MTLRasterizationRateMap>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewRasterizationRateMap, descriptor.NativePtr));
    }

    public MTLRenderPipelineState? NewRenderPipelineState(MTLRenderPipelineDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewRenderPipelineState, descriptor.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLRenderPipelineState>(ptr);
    }

    public MTLResidencySet? NewResidencySet(MTLResidencySetDescriptor desc, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewResidencySet, desc.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLResidencySet>(ptr);
    }

    public MTLSamplerState? NewSamplerState(MTLSamplerDescriptor descriptor)
    {
        return GetNullableObject<MTLSamplerState>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewSamplerState, descriptor.NativePtr));
    }

    public MTLSharedEvent? NewSharedEventWithHandle(MTLSharedEventHandle sharedEventHandle)
    {
        return GetNullableObject<MTLSharedEvent>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewSharedEvent, sharedEventHandle.NativePtr));
    }

    public MTLTexture? NewSharedTexture(MTLTextureDescriptor descriptor)
    {
        return GetNullableObject<MTLTexture>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewSharedTexture, descriptor.NativePtr));
    }

    public MTLTexture? NewSharedTexture(MTLSharedTextureHandle sharedHandle)
    {
        return GetNullableObject<MTLTexture>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewSharedTexture, sharedHandle.NativePtr));
    }

    public MTLTensor? NewTensor(MTLTensorDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewTensor, descriptor.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLTensor>(ptr);
    }

    public MTLTexture? NewTexture(MTLTextureDescriptor descriptor)
    {
        return GetNullableObject<MTLTexture>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewTexture, descriptor.NativePtr));
    }

    public MTLTexture? NewTexture(MTLTextureDescriptor descriptor, nint iosurface, nuint plane)
    {
        return GetNullableObject<MTLTexture>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewTexture, descriptor.NativePtr, iosurface, plane));
    }

    public MTLTextureViewPool? NewTextureViewPool(MTLResourceViewPoolDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceSelector.NewTextureViewPool, descriptor.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLTextureViewPool>(ptr);
    }

    public nuint SizeOfCounterHeapEntry(MTL4CounterHeapType type)
    {
        return ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceSelector.SizeOfCounterHeapEntry, (nint)type);
    }

    public MTLSize SparseTileSize(MTLTextureType textureType, MTLPixelFormat pixelFormat, nuint sampleCount)
    {
        return ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLDeviceSelector.SparseTileSize, (nuint)textureType, (nuint)pixelFormat, sampleCount);
    }

    public MTLSize SparseTileSize(MTLTextureType textureType, MTLPixelFormat pixelFormat, nuint sampleCount, MTLSparsePageSize sparsePageSize)
    {
        return ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLDeviceSelector.SparseTileSize, (nuint)textureType, (nuint)pixelFormat, sampleCount, (nint)sparsePageSize);
    }

    public nuint SparseTileSizeInBytesForSparsePageSize(MTLSparsePageSize sparsePageSize)
    {
        return ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceSelector.SparseTileSizeInBytes, (nint)sparsePageSize);
    }

    public bool SupportsCounterSampling(MTLCounterSamplingPoint samplingPoint)
    {
        return ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsCounterSampling, (nuint)samplingPoint);
    }

    public bool SupportsFamily(MTLGPUFamily gpuFamily)
    {
        return ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsFamily, (nint)gpuFamily);
    }

    public bool SupportsFeatureSet(MTLFeatureSet featureSet)
    {
        return ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsFeatureSet, (nuint)featureSet);
    }

    public bool SupportsRasterizationRateMap(nuint layerCount)
    {
        return ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsRasterizationRateMap, layerCount);
    }

    public bool SupportsTextureSampleCount(nuint sampleCount)
    {
        return ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsTextureSampleCount, sampleCount);
    }

    public bool SupportsVertexAmplificationCount(nuint count)
    {
        return ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceSelector.SupportsVertexAmplificationCount, count);
    }

    public MTLSizeAndAlign TensorSizeAndAlign(MTLTensorDescriptor descriptor)
    {
        return ObjectiveCRuntime.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceSelector.TensorSizeAndAlign, descriptor.NativePtr);
    }
}

file static class MTLDeviceSelector
{
    public static readonly Selector AccelerationStructureSizes = Selector.Register("accelerationStructureSizesWithDescriptor:");

    public static readonly Selector Architecture = Selector.Register("architecture");

    public static readonly Selector AreBarycentricCoordsSupported = Selector.Register("areBarycentricCoordsSupported");

    public static readonly Selector AreProgrammableSamplePositionsSupported = Selector.Register("areProgrammableSamplePositionsSupported");

    public static readonly Selector AreRasterOrderGroupsSupported = Selector.Register("areRasterOrderGroupsSupported");

    public static readonly Selector ArgumentBuffersSupport = Selector.Register("argumentBuffersSupport");

    public static readonly Selector BarycentricCoordsSupported = Selector.Register("areBarycentricCoordsSupported");

    public static readonly Selector ConvertSparsePixelRegions = Selector.Register("convertSparsePixelRegions:toTileRegions:withTileSize:alignmentMode:numRegions:");

    public static readonly Selector ConvertSparseTileRegions = Selector.Register("convertSparseTileRegions:toPixelRegions:withTileSize:numRegions:");

    public static readonly Selector CounterSets = Selector.Register("counterSets");

    public static readonly Selector CurrentAllocatedSize = Selector.Register("currentAllocatedSize");

    public static readonly Selector Depth24Stencil8PixelFormatSupported = Selector.Register("isDepth24Stencil8PixelFormatSupported");

    public static readonly Selector FunctionHandle = Selector.Register("functionHandleWithFunction:");

    public static readonly Selector GetDefaultSamplePositions = Selector.Register("getDefaultSamplePositions:count:");

    public static readonly Selector HasUnifiedMemory = Selector.Register("hasUnifiedMemory");

    public static readonly Selector Headless = Selector.Register("isHeadless");

    public static readonly Selector HeapAccelerationStructureSizeAndAlign = Selector.Register("heapAccelerationStructureSizeAndAlignWithSize:");

    public static readonly Selector HeapBufferSizeAndAlign = Selector.Register("heapBufferSizeAndAlignWithLength:options:");

    public static readonly Selector HeapTextureSizeAndAlign = Selector.Register("heapTextureSizeAndAlignWithDescriptor:");

    public static readonly Selector IsDepth24Stencil8PixelFormatSupported = Selector.Register("isDepth24Stencil8PixelFormatSupported");

    public static readonly Selector IsHeadless = Selector.Register("isHeadless");

    public static readonly Selector IsLowPower = Selector.Register("isLowPower");

    public static readonly Selector IsRemovable = Selector.Register("isRemovable");

    public static readonly Selector Location = Selector.Register("location");

    public static readonly Selector LocationNumber = Selector.Register("locationNumber");

    public static readonly Selector LowPower = Selector.Register("isLowPower");

    public static readonly Selector MaxArgumentBufferSamplerCount = Selector.Register("maxArgumentBufferSamplerCount");

    public static readonly Selector MaxBufferLength = Selector.Register("maxBufferLength");

    public static readonly Selector MaximumConcurrentCompilationTaskCount = Selector.Register("maximumConcurrentCompilationTaskCount");

    public static readonly Selector MaxThreadgroupMemoryLength = Selector.Register("maxThreadgroupMemoryLength");

    public static readonly Selector MaxThreadsPerThreadgroup = Selector.Register("maxThreadsPerThreadgroup");

    public static readonly Selector MaxTransferRate = Selector.Register("maxTransferRate");

    public static readonly Selector MinimumLinearTextureAlignmentForPixelFormat = Selector.Register("minimumLinearTextureAlignmentForPixelFormat:");

    public static readonly Selector MinimumTextureBufferAlignmentForPixelFormat = Selector.Register("minimumTextureBufferAlignmentForPixelFormat:");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector NewAccelerationStructure = Selector.Register("newAccelerationStructureWithSize:");

    public static readonly Selector NewArchive = Selector.Register("newArchiveWithURL:error:");

    public static readonly Selector NewArgumentEncoder = Selector.Register("newArgumentEncoderWithArguments:");

    public static readonly Selector NewArgumentTable = Selector.Register("newArgumentTableWithDescriptor:error:");

    public static readonly Selector NewBinaryArchive = Selector.Register("newBinaryArchiveWithDescriptor:error:");

    public static readonly Selector NewBuffer = Selector.Register("newBufferWithLength:options:");

    public static readonly Selector NewCommandAllocator = Selector.Register("newCommandAllocator");

    public static readonly Selector NewCommandBuffer = Selector.Register("newCommandBuffer");

    public static readonly Selector NewCommandQueue = Selector.Register("newCommandQueue");

    public static readonly Selector NewCompiler = Selector.Register("newCompilerWithDescriptor:error:");

    public static readonly Selector NewComputePipelineState = Selector.Register("newComputePipelineStateWithFunction:error:");

    public static readonly Selector NewCounterHeap = Selector.Register("newCounterHeapWithDescriptor:error:");

    public static readonly Selector NewCounterSampleBuffer = Selector.Register("newCounterSampleBufferWithDescriptor:error:");

    public static readonly Selector NewDefaultLibrary = Selector.Register("newDefaultLibrary");

    public static readonly Selector NewDepthStencilState = Selector.Register("newDepthStencilStateWithDescriptor:");

    public static readonly Selector NewDynamicLibrary = Selector.Register("newDynamicLibrary:error:");

    public static readonly Selector NewEvent = Selector.Register("newEvent");

    public static readonly Selector NewFence = Selector.Register("newFence");

    public static readonly Selector NewHeap = Selector.Register("newHeapWithDescriptor:");

    public static readonly Selector NewIndirectCommandBuffer = Selector.Register("newIndirectCommandBufferWithDescriptor:maxCommandCount:options:");

    public static readonly Selector NewIOCommandQueue = Selector.Register("newIOCommandQueueWithDescriptor:error:");

    public static readonly Selector NewIOFileHandle = Selector.Register("newIOFileHandleWithURL:error:");

    public static readonly Selector NewIOHandle = Selector.Register("newIOHandleWithURL:error:");

    public static readonly Selector NewLibrary = Selector.Register("newLibraryWithFile:error:");

    public static readonly Selector NewLogState = Selector.Register("newLogStateWithDescriptor:error:");

    public static readonly Selector NewMTL4CommandQueue = Selector.Register("newMTL4CommandQueue");

    public static readonly Selector NewPipelineDataSetSerializer = Selector.Register("newPipelineDataSetSerializerWithDescriptor:");

    public static readonly Selector NewRasterizationRateMap = Selector.Register("newRasterizationRateMapWithDescriptor:");

    public static readonly Selector NewRenderPipelineState = Selector.Register("newRenderPipelineStateWithDescriptor:error:");

    public static readonly Selector NewResidencySet = Selector.Register("newResidencySetWithDescriptor:error:");

    public static readonly Selector NewSamplerState = Selector.Register("newSamplerStateWithDescriptor:");

    public static readonly Selector NewSharedEvent = Selector.Register("newSharedEvent");

    public static readonly Selector NewSharedTexture = Selector.Register("newSharedTextureWithDescriptor:");

    public static readonly Selector NewTensor = Selector.Register("newTensorWithDescriptor:error:");

    public static readonly Selector NewTexture = Selector.Register("newTextureWithDescriptor:");

    public static readonly Selector NewTextureViewPool = Selector.Register("newTextureViewPoolWithDescriptor:error:");

    public static readonly Selector PeerCount = Selector.Register("peerCount");

    public static readonly Selector PeerGroupID = Selector.Register("peerGroupID");

    public static readonly Selector PeerIndex = Selector.Register("peerIndex");

    public static readonly Selector ProgrammableSamplePositionsSupported = Selector.Register("areProgrammableSamplePositionsSupported");

    public static readonly Selector QueryTimestampFrequency = Selector.Register("queryTimestampFrequency");

    public static readonly Selector RasterOrderGroupsSupported = Selector.Register("areRasterOrderGroupsSupported");

    public static readonly Selector ReadWriteTextureSupport = Selector.Register("readWriteTextureSupport");

    public static readonly Selector RecommendedMaxWorkingSetSize = Selector.Register("recommendedMaxWorkingSetSize");

    public static readonly Selector RegistryID = Selector.Register("registryID");

    public static readonly Selector Removable = Selector.Register("isRemovable");

    public static readonly Selector SetShouldMaximizeConcurrentCompilation = Selector.Register("setShouldMaximizeConcurrentCompilation:");

    public static readonly Selector ShouldMaximizeConcurrentCompilation = Selector.Register("shouldMaximizeConcurrentCompilation");

    public static readonly Selector SizeOfCounterHeapEntry = Selector.Register("sizeOfCounterHeapEntry:");

    public static readonly Selector SparseTileSize = Selector.Register("sparseTileSizeWithTextureType:pixelFormat:sampleCount:");

    public static readonly Selector SparseTileSizeInBytes = Selector.Register("sparseTileSizeInBytes");

    public static readonly Selector Supports32BitFloatFiltering = Selector.Register("supports32BitFloatFiltering");

    public static readonly Selector Supports32BitMSAA = Selector.Register("supports32BitMSAA");

    public static readonly Selector SupportsBCTextureCompression = Selector.Register("supportsBCTextureCompression");

    public static readonly Selector SupportsCounterSampling = Selector.Register("supportsCounterSampling:");

    public static readonly Selector SupportsDynamicLibraries = Selector.Register("supportsDynamicLibraries");

    public static readonly Selector SupportsFamily = Selector.Register("supportsFamily:");

    public static readonly Selector SupportsFeatureSet = Selector.Register("supportsFeatureSet:");

    public static readonly Selector SupportsFunctionPointers = Selector.Register("supportsFunctionPointers");

    public static readonly Selector SupportsFunctionPointersFromRender = Selector.Register("supportsFunctionPointersFromRender");

    public static readonly Selector SupportsPrimitiveMotionBlur = Selector.Register("supportsPrimitiveMotionBlur");

    public static readonly Selector SupportsPullModelInterpolation = Selector.Register("supportsPullModelInterpolation");

    public static readonly Selector SupportsQueryTextureLOD = Selector.Register("supportsQueryTextureLOD");

    public static readonly Selector SupportsRasterizationRateMap = Selector.Register("supportsRasterizationRateMapWithLayerCount:");

    public static readonly Selector SupportsRaytracing = Selector.Register("supportsRaytracing");

    public static readonly Selector SupportsRaytracingFromRender = Selector.Register("supportsRaytracingFromRender");

    public static readonly Selector SupportsRenderDynamicLibraries = Selector.Register("supportsRenderDynamicLibraries");

    public static readonly Selector SupportsShaderBarycentricCoordinates = Selector.Register("supportsShaderBarycentricCoordinates");

    public static readonly Selector SupportsTextureSampleCount = Selector.Register("supportsTextureSampleCount:");

    public static readonly Selector SupportsVertexAmplificationCount = Selector.Register("supportsVertexAmplificationCount:");

    public static readonly Selector TensorSizeAndAlign = Selector.Register("tensorSizeAndAlignWithDescriptor:");
}
