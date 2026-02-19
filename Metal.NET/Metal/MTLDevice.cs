namespace Metal.NET;

public readonly struct MTLDevice(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLArchitecture? Architecture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.Architecture);
            return ptr is not 0 ? new MTLArchitecture(ptr) : default;
        }
    }

    public bool AreBarycentricCoordsSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.AreBarycentricCoordsSupported);
    }

    public bool AreProgrammableSamplePositionsSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.AreProgrammableSamplePositionsSupported);
    }

    public bool AreRasterOrderGroupsSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.AreRasterOrderGroupsSupported);
    }

    public MTLArgumentBuffersTier ArgumentBuffersSupport
    {
        get => (MTLArgumentBuffersTier)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceBindings.ArgumentBuffersSupport);
    }

    public bool BarycentricCoordsSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.BarycentricCoordsSupported);
    }

    public NSArray? CounterSets
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.CounterSets);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
    }

    public nuint CurrentAllocatedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceBindings.CurrentAllocatedSize);
    }

    public bool Depth24Stencil8PixelFormatSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.Depth24Stencil8PixelFormatSupported);
    }

    public bool HasUnifiedMemory
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.HasUnifiedMemory);
    }

    public bool Headless
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.Headless);
    }

    public bool IsDepth24Stencil8PixelFormatSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.IsDepth24Stencil8PixelFormatSupported);
    }

    public bool IsHeadless
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.IsHeadless);
    }

    public bool IsLowPower
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.IsLowPower);
    }

    public bool IsRemovable
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.IsRemovable);
    }

    public MTLDeviceLocation Location
    {
        get => (MTLDeviceLocation)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceBindings.Location);
    }

    public nuint LocationNumber
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceBindings.LocationNumber);
    }

    public bool LowPower
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.LowPower);
    }

    public nuint MaxArgumentBufferSamplerCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceBindings.MaxArgumentBufferSamplerCount);
    }

    public nuint MaxBufferLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceBindings.MaxBufferLength);
    }

    public nuint MaxThreadgroupMemoryLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceBindings.MaxThreadgroupMemoryLength);
    }

    public MTLSize MaxThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLDeviceBindings.MaxThreadsPerThreadgroup);
    }

    public nuint MaxTransferRate
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceBindings.MaxTransferRate);
    }

    public nuint MaximumConcurrentCompilationTaskCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceBindings.MaximumConcurrentCompilationTaskCount);
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.Name);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
    }

    public MTL4CommandAllocator? NewCommandAllocator
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewCommandAllocator);
            return ptr is not 0 ? new MTL4CommandAllocator(ptr) : default;
        }
    }

    public MTL4CommandBuffer? NewCommandBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewCommandBuffer);
            return ptr is not 0 ? new MTL4CommandBuffer(ptr) : default;
        }
    }

    public MTLCommandQueue? NewCommandQueue
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewCommandQueue);
            return ptr is not 0 ? new MTLCommandQueue(ptr) : default;
        }
    }

    public MTLLibrary? NewDefaultLibrary
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewDefaultLibrary);
            return ptr is not 0 ? new MTLLibrary(ptr) : default;
        }
    }

    public MTLEvent? NewEvent
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewEvent);
            return ptr is not 0 ? new MTLEvent(ptr) : default;
        }
    }

    public MTLFence? NewFence
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewFence);
            return ptr is not 0 ? new MTLFence(ptr) : default;
        }
    }

    public MTL4CommandQueue? NewMTL4CommandQueue
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewMTL4CommandQueue);
            return ptr is not 0 ? new MTL4CommandQueue(ptr) : default;
        }
    }

    public MTLSharedEvent? NewSharedEvent
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewSharedEvent);
            return ptr is not 0 ? new MTLSharedEvent(ptr) : default;
        }
    }

    public uint PeerCount
    {
        get => ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLDeviceBindings.PeerCount);
    }

    public nuint PeerGroupID
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceBindings.PeerGroupID);
    }

    public uint PeerIndex
    {
        get => ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLDeviceBindings.PeerIndex);
    }

    public bool ProgrammableSamplePositionsSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.ProgrammableSamplePositionsSupported);
    }

    public nuint QueryTimestampFrequency
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceBindings.QueryTimestampFrequency);
    }

    public bool RasterOrderGroupsSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.RasterOrderGroupsSupported);
    }

    public MTLReadWriteTextureTier ReadWriteTextureSupport
    {
        get => (MTLReadWriteTextureTier)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceBindings.ReadWriteTextureSupport);
    }

    public nuint RecommendedMaxWorkingSetSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceBindings.RecommendedMaxWorkingSetSize);
    }

    public nuint RegistryID
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceBindings.RegistryID);
    }

    public bool Removable
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.Removable);
    }

    public bool ShouldMaximizeConcurrentCompilation
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.ShouldMaximizeConcurrentCompilation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLDeviceBindings.SetShouldMaximizeConcurrentCompilation, (Bool8)value);
    }

    public nuint SparseTileSizeInBytes
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceBindings.SparseTileSizeInBytes);
    }

    public bool Supports32BitFloatFiltering
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.Supports32BitFloatFiltering);
    }

    public bool Supports32BitMSAA
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.Supports32BitMSAA);
    }

    public bool SupportsBCTextureCompression
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsBCTextureCompression);
    }

    public bool SupportsDynamicLibraries
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsDynamicLibraries);
    }

    public bool SupportsFunctionPointers
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsFunctionPointers);
    }

    public bool SupportsFunctionPointersFromRender
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsFunctionPointersFromRender);
    }

    public bool SupportsPrimitiveMotionBlur
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsPrimitiveMotionBlur);
    }

    public bool SupportsPullModelInterpolation
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsPullModelInterpolation);
    }

    public bool SupportsQueryTextureLOD
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsQueryTextureLOD);
    }

    public bool SupportsRaytracing
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsRaytracing);
    }

    public bool SupportsRaytracingFromRender
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsRaytracingFromRender);
    }

    public bool SupportsRenderDynamicLibraries
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsRenderDynamicLibraries);
    }

    public bool SupportsShaderBarycentricCoordinates
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsShaderBarycentricCoordinates);
    }

    public MTLAccelerationStructureSizes AccelerationStructureSizes(MTLAccelerationStructureDescriptor descriptor)
    {
        return ObjectiveCRuntime.MsgSendMTLAccelerationStructureSizes(NativePtr, MTLDeviceBindings.AccelerationStructureSizes, descriptor.NativePtr);
    }

    public void ConvertSparsePixelRegions(MTLRegion pixelRegions, MTLRegion tileRegions, MTLSize tileSize, MTLSparseTextureRegionAlignmentMode mode, nuint numRegions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLDeviceBindings.ConvertSparsePixelRegions, pixelRegions, tileRegions, tileSize, (nuint)mode, numRegions);
    }

    public void ConvertSparseTileRegions(MTLRegion tileRegions, MTLRegion pixelRegions, MTLSize tileSize, nuint numRegions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLDeviceBindings.ConvertSparseTileRegions, tileRegions, pixelRegions, tileSize, numRegions);
    }

    public MTLFunctionHandle? FunctionHandle(MTLFunction function)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.FunctionHandle, function.NativePtr);
        return ptr is not 0 ? new MTLFunctionHandle(ptr) : default;
    }

    public MTLFunctionHandle? FunctionHandle(MTL4BinaryFunction function)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.FunctionHandle, function.NativePtr);
        return ptr is not 0 ? new MTLFunctionHandle(ptr) : default;
    }

    public void GetDefaultSamplePositions(MTLSamplePosition positions, nuint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLDeviceBindings.GetDefaultSamplePositions, positions, count);
    }

    public MTLSizeAndAlign HeapAccelerationStructureSizeAndAlign(nuint size)
    {
        return ObjectiveCRuntime.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceBindings.HeapAccelerationStructureSizeAndAlign, size);
    }

    public MTLSizeAndAlign HeapAccelerationStructureSizeAndAlign(MTLAccelerationStructureDescriptor descriptor)
    {
        return ObjectiveCRuntime.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceBindings.HeapAccelerationStructureSizeAndAlign, descriptor.NativePtr);
    }

    public MTLSizeAndAlign HeapBufferSizeAndAlign(nuint length, MTLResourceOptions options)
    {
        return ObjectiveCRuntime.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceBindings.HeapBufferSizeAndAlign, length, (nuint)options);
    }

    public MTLSizeAndAlign HeapTextureSizeAndAlign(MTLTextureDescriptor desc)
    {
        return ObjectiveCRuntime.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceBindings.HeapTextureSizeAndAlign, desc.NativePtr);
    }

    public nuint MinimumLinearTextureAlignmentForPixelFormat(MTLPixelFormat format)
    {
        return ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceBindings.MinimumLinearTextureAlignmentForPixelFormat, (nuint)format);
    }

    public nuint MinimumTextureBufferAlignmentForPixelFormat(MTLPixelFormat format)
    {
        return ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceBindings.MinimumTextureBufferAlignmentForPixelFormat, (nuint)format);
    }

    public MTLAccelerationStructure? NewAccelerationStructure(nuint size)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewAccelerationStructure, size);
        return ptr is not 0 ? new MTLAccelerationStructure(ptr) : default;
    }

    public MTLAccelerationStructure? NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewAccelerationStructure, descriptor.NativePtr);
        return ptr is not 0 ? new MTLAccelerationStructure(ptr) : default;
    }

    public MTL4Archive? NewArchive(NSURL url, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewArchive, url.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTL4Archive(ptr) : default;
    }

    public MTLArgumentEncoder? NewArgumentEncoder(NSArray arguments)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewArgumentEncoder, arguments.NativePtr);
        return ptr is not 0 ? new MTLArgumentEncoder(ptr) : default;
    }

    public MTLArgumentEncoder? NewArgumentEncoder(MTLBufferBinding bufferBinding)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewArgumentEncoder, bufferBinding.NativePtr);
        return ptr is not 0 ? new MTLArgumentEncoder(ptr) : default;
    }

    public MTL4ArgumentTable? NewArgumentTable(MTL4ArgumentTableDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewArgumentTable, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTL4ArgumentTable(ptr) : default;
    }

    public MTLBinaryArchive? NewBinaryArchive(MTLBinaryArchiveDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewBinaryArchive, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLBinaryArchive(ptr) : default;
    }

    public MTLBuffer? NewBuffer(nuint length, MTLResourceOptions options)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewBuffer, length, (nuint)options);
        return ptr is not 0 ? new MTLBuffer(ptr) : default;
    }

    public MTLBuffer? NewBuffer(nint pointer, nuint length, MTLResourceOptions options)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewBuffer, pointer, length, (nuint)options);
        return ptr is not 0 ? new MTLBuffer(ptr) : default;
    }

    public MTLBuffer? NewBuffer(nuint length, MTLResourceOptions options, MTLSparsePageSize placementSparsePageSize)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewBuffer, length, (nuint)options, (nint)placementSparsePageSize);
        return ptr is not 0 ? new MTLBuffer(ptr) : default;
    }

    public MTL4CommandAllocator? NewCommandAllocatorWithDescriptor(MTL4CommandAllocatorDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewCommandAllocator, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTL4CommandAllocator(ptr) : default;
    }

    public MTLCommandQueue? NewCommandQueueWithMaxCommandBufferCount(nuint maxCommandBufferCount)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewCommandQueue, maxCommandBufferCount);
        return ptr is not 0 ? new MTLCommandQueue(ptr) : default;
    }

    public MTLCommandQueue? NewCommandQueueWithDescriptor(MTLCommandQueueDescriptor descriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewCommandQueue, descriptor.NativePtr);
        return ptr is not 0 ? new MTLCommandQueue(ptr) : default;
    }

    public MTL4Compiler? NewCompiler(MTL4CompilerDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewCompiler, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTL4Compiler(ptr) : default;
    }

    public MTLComputePipelineState? NewComputePipelineState(MTLFunction computeFunction, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewComputePipelineState, computeFunction.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLComputePipelineState(ptr) : default;
    }

    public MTL4CounterHeap? NewCounterHeap(MTL4CounterHeapDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewCounterHeap, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTL4CounterHeap(ptr) : default;
    }

    public MTLCounterSampleBuffer? NewCounterSampleBuffer(MTLCounterSampleBufferDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewCounterSampleBuffer, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLCounterSampleBuffer(ptr) : default;
    }

    public MTLDepthStencilState? NewDepthStencilState(MTLDepthStencilDescriptor descriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewDepthStencilState, descriptor.NativePtr);
        return ptr is not 0 ? new MTLDepthStencilState(ptr) : default;
    }

    public MTLDynamicLibrary? NewDynamicLibrary(MTLLibrary library, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewDynamicLibrary, library.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLDynamicLibrary(ptr) : default;
    }

    public MTLDynamicLibrary? NewDynamicLibrary(NSURL url, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewDynamicLibrary, url.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLDynamicLibrary(ptr) : default;
    }

    public MTLHeap? NewHeap(MTLHeapDescriptor descriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewHeap, descriptor.NativePtr);
        return ptr is not 0 ? new MTLHeap(ptr) : default;
    }

    public MTLIOCommandQueue? NewIOCommandQueue(MTLIOCommandQueueDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewIOCommandQueue, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLIOCommandQueue(ptr) : default;
    }

    public MTLIOFileHandle? NewIOFileHandle(NSURL url, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewIOFileHandle, url.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLIOFileHandle(ptr) : default;
    }

    public MTLIOFileHandle? NewIOFileHandle(NSURL url, MTLIOCompressionMethod compressionMethod, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewIOFileHandle, url.NativePtr, (nint)compressionMethod, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLIOFileHandle(ptr) : default;
    }

    public MTLIOFileHandle? NewIOHandle(NSURL url, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewIOHandle, url.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLIOFileHandle(ptr) : default;
    }

    public MTLIOFileHandle? NewIOHandle(NSURL url, MTLIOCompressionMethod compressionMethod, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewIOHandle, url.NativePtr, (nint)compressionMethod, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLIOFileHandle(ptr) : default;
    }

    public MTLIndirectCommandBuffer? NewIndirectCommandBuffer(MTLIndirectCommandBufferDescriptor descriptor, nuint maxCount, MTLResourceOptions options)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewIndirectCommandBuffer, descriptor.NativePtr, maxCount, (nuint)options);
        return ptr is not 0 ? new MTLIndirectCommandBuffer(ptr) : default;
    }

    public MTLLibrary? NewLibrary(NSString filepath, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewLibrary, filepath.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLLibrary(ptr) : default;
    }

    public MTLLibrary? NewLibrary(NSURL url, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewLibrary, url.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLLibrary(ptr) : default;
    }

    public MTLLibrary? NewLibrary(nint data, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewLibrary, data, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLLibrary(ptr) : default;
    }

    public MTLLibrary? NewLibrary(NSString source, MTLCompileOptions options, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewLibrary, source.NativePtr, options.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLLibrary(ptr) : default;
    }

    public MTLLibrary? NewLibrary(MTLStitchedLibraryDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewLibrary, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLLibrary(ptr) : default;
    }

    public MTLLogState? NewLogState(MTLLogStateDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewLogState, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLLogState(ptr) : default;
    }

    public MTL4CommandQueue? NewMTL4CommandQueueWithDescriptor(MTL4CommandQueueDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewMTL4CommandQueue, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTL4CommandQueue(ptr) : default;
    }

    public MTL4PipelineDataSetSerializer? NewPipelineDataSetSerializer(MTL4PipelineDataSetSerializerDescriptor descriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewPipelineDataSetSerializer, descriptor.NativePtr);
        return ptr is not 0 ? new MTL4PipelineDataSetSerializer(ptr) : default;
    }

    public MTLRasterizationRateMap? NewRasterizationRateMap(MTLRasterizationRateMapDescriptor descriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewRasterizationRateMap, descriptor.NativePtr);
        return ptr is not 0 ? new MTLRasterizationRateMap(ptr) : default;
    }

    public MTLRenderPipelineState? NewRenderPipelineState(MTLRenderPipelineDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewRenderPipelineState, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLRenderPipelineState(ptr) : default;
    }

    public MTLResidencySet? NewResidencySet(MTLResidencySetDescriptor desc, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewResidencySet, desc.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLResidencySet(ptr) : default;
    }

    public MTLSamplerState? NewSamplerState(MTLSamplerDescriptor descriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewSamplerState, descriptor.NativePtr);
        return ptr is not 0 ? new MTLSamplerState(ptr) : default;
    }

    public MTLSharedEvent? NewSharedEventWithHandle(MTLSharedEventHandle sharedEventHandle)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewSharedEvent, sharedEventHandle.NativePtr);
        return ptr is not 0 ? new MTLSharedEvent(ptr) : default;
    }

    public MTLTexture? NewSharedTexture(MTLTextureDescriptor descriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewSharedTexture, descriptor.NativePtr);
        return ptr is not 0 ? new MTLTexture(ptr) : default;
    }

    public MTLTexture? NewSharedTexture(MTLSharedTextureHandle sharedHandle)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewSharedTexture, sharedHandle.NativePtr);
        return ptr is not 0 ? new MTLTexture(ptr) : default;
    }

    public MTLTensor? NewTensor(MTLTensorDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewTensor, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLTensor(ptr) : default;
    }

    public MTLTexture? NewTexture(MTLTextureDescriptor descriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewTexture, descriptor.NativePtr);
        return ptr is not 0 ? new MTLTexture(ptr) : default;
    }

    public MTLTexture? NewTexture(MTLTextureDescriptor descriptor, nint iosurface, nuint plane)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewTexture, descriptor.NativePtr, iosurface, plane);
        return ptr is not 0 ? new MTLTexture(ptr) : default;
    }

    public MTLTextureViewPool? NewTextureViewPool(MTLResourceViewPoolDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewTextureViewPool, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLTextureViewPool(ptr) : default;
    }

    public nuint SizeOfCounterHeapEntry(MTL4CounterHeapType type)
    {
        return ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceBindings.SizeOfCounterHeapEntry, (nint)type);
    }

    public MTLSize SparseTileSize(MTLTextureType textureType, MTLPixelFormat pixelFormat, nuint sampleCount)
    {
        return ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLDeviceBindings.SparseTileSize, (nuint)textureType, (nuint)pixelFormat, sampleCount);
    }

    public MTLSize SparseTileSize(MTLTextureType textureType, MTLPixelFormat pixelFormat, nuint sampleCount, MTLSparsePageSize sparsePageSize)
    {
        return ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLDeviceBindings.SparseTileSize, (nuint)textureType, (nuint)pixelFormat, sampleCount, (nint)sparsePageSize);
    }

    public nuint SparseTileSizeInBytesForSparsePageSize(MTLSparsePageSize sparsePageSize)
    {
        return ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceBindings.SparseTileSizeInBytes, (nint)sparsePageSize);
    }

    public bool SupportsCounterSampling(MTLCounterSamplingPoint samplingPoint)
    {
        return ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsCounterSampling, (nuint)samplingPoint);
    }

    public bool SupportsFamily(MTLGPUFamily gpuFamily)
    {
        return ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsFamily, (nint)gpuFamily);
    }

    public bool SupportsFeatureSet(MTLFeatureSet featureSet)
    {
        return ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsFeatureSet, (nuint)featureSet);
    }

    public bool SupportsRasterizationRateMap(nuint layerCount)
    {
        return ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsRasterizationRateMap, layerCount);
    }

    public bool SupportsTextureSampleCount(nuint sampleCount)
    {
        return ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsTextureSampleCount, sampleCount);
    }

    public bool SupportsVertexAmplificationCount(nuint count)
    {
        return ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsVertexAmplificationCount, count);
    }

    public MTLSizeAndAlign TensorSizeAndAlign(MTLTensorDescriptor descriptor)
    {
        return ObjectiveCRuntime.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceBindings.TensorSizeAndAlign, descriptor.NativePtr);
    }
}

file static class MTLDeviceBindings
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
