using System.Runtime.InteropServices;

namespace Metal.NET;

public partial class MTLDevice(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLDevice>
{
    public static MTLDevice Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLDevice Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLArchitecture Architecture
    {
        get => GetProperty(ref field, MTLDeviceBindings.Architecture);
    }

    public Bool8 AreBarycentricCoordsSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.AreBarycentricCoordsSupported);
    }

    public Bool8 AreProgrammableSamplePositionsSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.AreProgrammableSamplePositionsSupported);
    }

    public Bool8 AreRasterOrderGroupsSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.AreRasterOrderGroupsSupported);
    }

    public MTLArgumentBuffersTier ArgumentBuffersSupport
    {
        get => (MTLArgumentBuffersTier)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceBindings.ArgumentBuffersSupport);
    }

    public Bool8 BarycentricCoordsSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.BarycentricCoordsSupported);
    }

    public MTLCounterSet[] CounterSets
    {
        get => GetArrayProperty<MTLCounterSet>(MTLDeviceBindings.CounterSets);
    }

    public nuint CurrentAllocatedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceBindings.CurrentAllocatedSize);
    }

    public Bool8 Depth24Stencil8PixelFormatSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.Depth24Stencil8PixelFormatSupported);
    }

    public Bool8 HasUnifiedMemory
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.HasUnifiedMemory);
    }

    public Bool8 Headless
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.Headless);
    }

    public Bool8 IsDepth24Stencil8PixelFormatSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.IsDepth24Stencil8PixelFormatSupported);
    }

    public Bool8 IsHeadless
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.IsHeadless);
    }

    public Bool8 IsLowPower
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.IsLowPower);
    }

    public Bool8 IsRemovable
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

    public Bool8 LowPower
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

    public ulong MaxTransferRate
    {
        get => ObjectiveCRuntime.MsgSendULong(NativePtr, MTLDeviceBindings.MaxTransferRate);
    }

    public nuint MaximumConcurrentCompilationTaskCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceBindings.MaximumConcurrentCompilationTaskCount);
    }

    public NSString Name
    {
        get => GetProperty(ref field, MTLDeviceBindings.Name);
    }

    public uint PeerCount
    {
        get => ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLDeviceBindings.PeerCount);
    }

    public ulong PeerGroupID
    {
        get => ObjectiveCRuntime.MsgSendULong(NativePtr, MTLDeviceBindings.PeerGroupID);
    }

    public uint PeerIndex
    {
        get => ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLDeviceBindings.PeerIndex);
    }

    public Bool8 ProgrammableSamplePositionsSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.ProgrammableSamplePositionsSupported);
    }

    public Bool8 RasterOrderGroupsSupported
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.RasterOrderGroupsSupported);
    }

    public MTLReadWriteTextureTier ReadWriteTextureSupport
    {
        get => (MTLReadWriteTextureTier)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceBindings.ReadWriteTextureSupport);
    }

    public ulong RecommendedMaxWorkingSetSize
    {
        get => ObjectiveCRuntime.MsgSendULong(NativePtr, MTLDeviceBindings.RecommendedMaxWorkingSetSize);
    }

    public ulong RegistryID
    {
        get => ObjectiveCRuntime.MsgSendULong(NativePtr, MTLDeviceBindings.RegistryID);
    }

    public Bool8 Removable
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.Removable);
    }

    public Bool8 ShouldMaximizeConcurrentCompilation
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.ShouldMaximizeConcurrentCompilation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLDeviceBindings.SetShouldMaximizeConcurrentCompilation, value);
    }

    public nuint SparseTileSizeInBytes
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceBindings.SparseTileSizeInBytes);
    }

    public Bool8 Supports32BitFloatFiltering
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.Supports32BitFloatFiltering);
    }

    public Bool8 Supports32BitMSAA
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.Supports32BitMSAA);
    }

    public Bool8 SupportsBCTextureCompression
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsBCTextureCompression);
    }

    public Bool8 SupportsDynamicLibraries
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsDynamicLibraries);
    }

    public Bool8 SupportsFunctionPointers
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsFunctionPointers);
    }

    public Bool8 SupportsFunctionPointersFromRender
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsFunctionPointersFromRender);
    }

    public Bool8 SupportsPrimitiveMotionBlur
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsPrimitiveMotionBlur);
    }

    public Bool8 SupportsPullModelInterpolation
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsPullModelInterpolation);
    }

    public Bool8 SupportsQueryTextureLOD
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsQueryTextureLOD);
    }

    public Bool8 SupportsRaytracing
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsRaytracing);
    }

    public Bool8 SupportsRaytracingFromRender
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsRaytracingFromRender);
    }

    public Bool8 SupportsRenderDynamicLibraries
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsRenderDynamicLibraries);
    }

    public Bool8 SupportsShaderBarycentricCoordinates
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

    public MTLFunctionHandle FunctionHandle(MTLFunction function)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.FunctionHandle, function.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLFunctionHandle FunctionHandle(MTL4BinaryFunction function)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.FunctionHandleWithBinaryFunction, function.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public unsafe void GetDefaultSamplePositions(MTLSamplePosition[] positions)
    {
        fixed (MTLSamplePosition* pPositions = positions)
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLDeviceBindings.GetDefaultSamplePositions, (nint)pPositions, (nuint)positions.Length);
        }
    }

    public MTLSizeAndAlign HeapAccelerationStructureSizeAndAlign(nuint size)
    {
        return ObjectiveCRuntime.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceBindings.HeapAccelerationStructureSizeAndAlign, size);
    }

    public MTLSizeAndAlign HeapAccelerationStructureSizeAndAlign(MTLAccelerationStructureDescriptor descriptor)
    {
        return ObjectiveCRuntime.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceBindings.HeapAccelerationStructureSizeAndAlignWithDescriptor, descriptor.NativePtr);
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

    public MTLAccelerationStructure NewAccelerationStructure(nuint size)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewAccelerationStructure, size);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLAccelerationStructure NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewAccelerationStructureWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4Archive NewArchive(NSURL url, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewArchive, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Borrowed);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLArgumentEncoder NewArgumentEncoder(MTLArgumentDescriptor[] arguments)
    {
        nint pArguments = NSArray.FromArray(arguments);

        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewArgumentEncoder, pArguments);

        ObjectiveCRuntime.Release(pArguments);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLArgumentEncoder NewArgumentEncoder(MTLBufferBinding bufferBinding)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewArgumentEncoderWithBufferBinding, bufferBinding.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4ArgumentTable NewArgumentTable(MTL4ArgumentTableDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewArgumentTable, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Borrowed);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLBinaryArchive NewBinaryArchive(MTLBinaryArchiveDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewBinaryArchive, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Borrowed);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLBuffer NewBuffer(nuint length, MTLResourceOptions options)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewBuffer, length, (nuint)options);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLBuffer NewBuffer(nint pointer, nuint length, MTLResourceOptions options)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewBufferWithByteslengthoptions, pointer, length, (nuint)options);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLBuffer NewBuffer(nuint length, MTLResourceOptions options, MTLSparsePageSize placementSparsePageSize)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewBufferWithLengthoptionsplacementSparsePageSize, length, (nuint)options, (nint)placementSparsePageSize);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CommandAllocator NewCommandAllocator()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewCommandAllocator);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CommandAllocator NewCommandAllocatorWithDescriptor(MTL4CommandAllocatorDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewCommandAllocatorWithDescriptorerror, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Borrowed);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CommandBuffer NewCommandBuffer()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewCommandBuffer);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLCommandQueue NewCommandQueue()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewCommandQueue);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLCommandQueue NewCommandQueueWithMaxCommandBufferCount(nuint maxCommandBufferCount)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewCommandQueueWithMaxCommandBufferCount, maxCommandBufferCount);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLCommandQueue NewCommandQueueWithDescriptor(MTLCommandQueueDescriptor descriptor)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewCommandQueueWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4Compiler NewCompiler(MTL4CompilerDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewCompiler, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Borrowed);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLComputePipelineState NewComputePipelineState(MTLFunction computeFunction, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewComputePipelineState, computeFunction.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Borrowed);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CounterHeap NewCounterHeap(MTL4CounterHeapDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewCounterHeap, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Borrowed);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLCounterSampleBuffer NewCounterSampleBuffer(MTLCounterSampleBufferDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewCounterSampleBuffer, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Borrowed);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLLibrary NewDefaultLibrary()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewDefaultLibrary);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLDepthStencilState NewDepthStencilState(MTLDepthStencilDescriptor descriptor)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewDepthStencilState, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLDynamicLibrary NewDynamicLibrary(MTLLibrary library, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewDynamicLibrary, library.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Borrowed);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLDynamicLibrary NewDynamicLibrary(NSURL url, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewDynamicLibraryWithURLerror, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Borrowed);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLEvent NewEvent()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewEvent);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLFence NewFence()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewFence);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLHeap NewHeap(MTLHeapDescriptor descriptor)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewHeap, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLIOCommandQueue NewIOCommandQueue(MTLIOCommandQueueDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewIOCommandQueue, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Borrowed);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLIOFileHandle NewIOFileHandle(NSURL url, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewIOFileHandle, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Borrowed);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLIOFileHandle NewIOFileHandle(NSURL url, MTLIOCompressionMethod compressionMethod, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewIOFileHandleWithURLcompressionMethoderror, url.NativePtr, (nint)compressionMethod, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Borrowed);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLIOFileHandle NewIOHandle(NSURL url, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewIOHandle, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Borrowed);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLIOFileHandle NewIOHandle(NSURL url, MTLIOCompressionMethod compressionMethod, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewIOHandleWithURLcompressionMethoderror, url.NativePtr, (nint)compressionMethod, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Borrowed);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLIndirectCommandBuffer NewIndirectCommandBuffer(MTLIndirectCommandBufferDescriptor descriptor, nuint maxCount, MTLResourceOptions options)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewIndirectCommandBuffer, descriptor.NativePtr, maxCount, (nuint)options);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLLibrary NewLibrary(NSString filepath, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewLibrary, filepath.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Borrowed);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLLibrary NewLibrary(NSURL url, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewLibraryWithURLerror, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Borrowed);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLLibrary NewLibrary(nint data, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewLibraryWithDataerror, data, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Borrowed);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLLibrary NewLibrary(NSString source, MTLCompileOptions options, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewLibraryWithSourceoptionserror, source.NativePtr, options.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Borrowed);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLLibrary NewLibrary(MTLStitchedLibraryDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewLibraryWithStitchedDescriptorerror, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Borrowed);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLLogState NewLogState(MTLLogStateDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewLogState, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Borrowed);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CommandQueue NewMTL4CommandQueue()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewMTL4CommandQueue);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CommandQueue NewMTL4CommandQueueWithDescriptor(MTL4CommandQueueDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewMTL4CommandQueueWithDescriptorerror, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Borrowed);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4PipelineDataSetSerializer NewPipelineDataSetSerializer(MTL4PipelineDataSetSerializerDescriptor descriptor)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewPipelineDataSetSerializer, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRasterizationRateMap NewRasterizationRateMap(MTLRasterizationRateMapDescriptor descriptor)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewRasterizationRateMap, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTLRenderPipelineDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewRenderPipelineState, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Borrowed);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLResidencySet NewResidencySet(MTLResidencySetDescriptor desc, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewResidencySet, desc.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Borrowed);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLSamplerState NewSamplerState(MTLSamplerDescriptor descriptor)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewSamplerState, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLSharedEvent NewSharedEvent()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewSharedEvent);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLSharedEvent NewSharedEventWithHandle(MTLSharedEventHandle sharedEventHandle)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewSharedEventWithHandle, sharedEventHandle.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLTexture NewSharedTexture(MTLTextureDescriptor descriptor)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewSharedTexture, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLTexture NewSharedTexture(MTLSharedTextureHandle sharedHandle)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewSharedTextureWithHandle, sharedHandle.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLTensor NewTensor(MTLTensorDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewTensor, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Borrowed);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewTexture, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor, nint iosurface, nuint plane)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewTextureWithDescriptoriosurfaceplane, descriptor.NativePtr, iosurface, plane);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLTextureViewPool NewTextureViewPool(MTLResourceViewPoolDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDeviceBindings.NewTextureViewPool, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Borrowed);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public ulong QueryTimestampFrequency()
    {
        return ObjectiveCRuntime.MsgSendULong(NativePtr, MTLDeviceBindings.QueryTimestampFrequency);
    }

    public void SampleTimestamps(out ulong cpuTimestamp, out ulong gpuTimestamp)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLDeviceBindings.SampleTimestamps, out cpuTimestamp, out gpuTimestamp);
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
        return ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLDeviceBindings.SparseTileSizeWithTextureTypepixelFormatsampleCountsparsePageSize, (nuint)textureType, (nuint)pixelFormat, sampleCount, (nint)sparsePageSize);
    }

    public nuint SparseTileSizeInBytesForSparsePageSize(MTLSparsePageSize sparsePageSize)
    {
        return ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDeviceBindings.SparseTileSizeInBytesForSparsePageSize, (nint)sparsePageSize);
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

    [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal", EntryPoint = "MTLCreateSystemDefaultDevice")]
    private static partial nint MTLCreateSystemDefaultDevice();

    public static MTLDevice CreateSystemDefaultDevice()
    {
        nint nativePtr = MTLCreateSystemDefaultDevice();

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal", EntryPoint = "MTLCopyAllDevices")]
    private static partial nint MTLCopyAllDevices();

    public static MTLDevice[] CopyAllDevices()
    {
        nint nativePtr = MTLCopyAllDevices();

        MTLDevice[] result = NSArray.ToArray<MTLDevice>(nativePtr);

        ObjectiveCRuntime.Release(nativePtr);

        return result;
    }
}

file static class MTLDeviceBindings
{
    public static readonly Selector AccelerationStructureSizes = "accelerationStructureSizesWithDescriptor:";

    public static readonly Selector Architecture = "architecture";

    public static readonly Selector AreBarycentricCoordsSupported = "areBarycentricCoordsSupported";

    public static readonly Selector AreProgrammableSamplePositionsSupported = "areProgrammableSamplePositionsSupported";

    public static readonly Selector AreRasterOrderGroupsSupported = "areRasterOrderGroupsSupported";

    public static readonly Selector ArgumentBuffersSupport = "argumentBuffersSupport";

    public static readonly Selector BarycentricCoordsSupported = "areBarycentricCoordsSupported";

    public static readonly Selector ConvertSparsePixelRegions = "convertSparsePixelRegions:toTileRegions:withTileSize:alignmentMode:numRegions:";

    public static readonly Selector ConvertSparseTileRegions = "convertSparseTileRegions:toPixelRegions:withTileSize:numRegions:";

    public static readonly Selector CounterSets = "counterSets";

    public static readonly Selector CurrentAllocatedSize = "currentAllocatedSize";

    public static readonly Selector Depth24Stencil8PixelFormatSupported = "isDepth24Stencil8PixelFormatSupported";

    public static readonly Selector FunctionHandle = "functionHandleWithFunction:";

    public static readonly Selector FunctionHandleWithBinaryFunction = "functionHandleWithBinaryFunction:";

    public static readonly Selector GetDefaultSamplePositions = "getDefaultSamplePositions:count:";

    public static readonly Selector HasUnifiedMemory = "hasUnifiedMemory";

    public static readonly Selector Headless = "isHeadless";

    public static readonly Selector HeapAccelerationStructureSizeAndAlign = "heapAccelerationStructureSizeAndAlignWithSize:";

    public static readonly Selector HeapAccelerationStructureSizeAndAlignWithDescriptor = "heapAccelerationStructureSizeAndAlignWithDescriptor:";

    public static readonly Selector HeapBufferSizeAndAlign = "heapBufferSizeAndAlignWithLength:options:";

    public static readonly Selector HeapTextureSizeAndAlign = "heapTextureSizeAndAlignWithDescriptor:";

    public static readonly Selector IsDepth24Stencil8PixelFormatSupported = "isDepth24Stencil8PixelFormatSupported";

    public static readonly Selector IsHeadless = "isHeadless";

    public static readonly Selector IsLowPower = "isLowPower";

    public static readonly Selector IsRemovable = "isRemovable";

    public static readonly Selector Location = "location";

    public static readonly Selector LocationNumber = "locationNumber";

    public static readonly Selector LowPower = "isLowPower";

    public static readonly Selector MaxArgumentBufferSamplerCount = "maxArgumentBufferSamplerCount";

    public static readonly Selector MaxBufferLength = "maxBufferLength";

    public static readonly Selector MaximumConcurrentCompilationTaskCount = "maximumConcurrentCompilationTaskCount";

    public static readonly Selector MaxThreadgroupMemoryLength = "maxThreadgroupMemoryLength";

    public static readonly Selector MaxThreadsPerThreadgroup = "maxThreadsPerThreadgroup";

    public static readonly Selector MaxTransferRate = "maxTransferRate";

    public static readonly Selector MinimumLinearTextureAlignmentForPixelFormat = "minimumLinearTextureAlignmentForPixelFormat:";

    public static readonly Selector MinimumTextureBufferAlignmentForPixelFormat = "minimumTextureBufferAlignmentForPixelFormat:";

    public static readonly Selector Name = "name";

    public static readonly Selector NewAccelerationStructure = "newAccelerationStructureWithSize:";

    public static readonly Selector NewAccelerationStructureWithDescriptor = "newAccelerationStructureWithDescriptor:";

    public static readonly Selector NewArchive = "newArchiveWithURL:error:";

    public static readonly Selector NewArgumentEncoder = "newArgumentEncoderWithArguments:";

    public static readonly Selector NewArgumentEncoderWithBufferBinding = "newArgumentEncoderWithBufferBinding:";

    public static readonly Selector NewArgumentTable = "newArgumentTableWithDescriptor:error:";

    public static readonly Selector NewBinaryArchive = "newBinaryArchiveWithDescriptor:error:";

    public static readonly Selector NewBuffer = "newBufferWithLength:options:";

    public static readonly Selector NewBufferWithByteslengthoptions = "newBufferWithBytes:length:options:";

    public static readonly Selector NewBufferWithLengthoptionsplacementSparsePageSize = "newBufferWithLength:options:placementSparsePageSize:";

    public static readonly Selector NewCommandAllocator = "newCommandAllocator";

    public static readonly Selector NewCommandAllocatorWithDescriptorerror = "newCommandAllocatorWithDescriptor:error:";

    public static readonly Selector NewCommandBuffer = "newCommandBuffer";

    public static readonly Selector NewCommandQueue = "newCommandQueue";

    public static readonly Selector NewCommandQueueWithDescriptor = "newCommandQueueWithDescriptor:";

    public static readonly Selector NewCommandQueueWithMaxCommandBufferCount = "newCommandQueueWithMaxCommandBufferCount:";

    public static readonly Selector NewCompiler = "newCompilerWithDescriptor:error:";

    public static readonly Selector NewComputePipelineState = "newComputePipelineStateWithFunction:error:";

    public static readonly Selector NewCounterHeap = "newCounterHeapWithDescriptor:error:";

    public static readonly Selector NewCounterSampleBuffer = "newCounterSampleBufferWithDescriptor:error:";

    public static readonly Selector NewDefaultLibrary = "newDefaultLibrary";

    public static readonly Selector NewDepthStencilState = "newDepthStencilStateWithDescriptor:";

    public static readonly Selector NewDynamicLibrary = "newDynamicLibrary:error:";

    public static readonly Selector NewDynamicLibraryWithURLerror = "newDynamicLibraryWithURL:error:";

    public static readonly Selector NewEvent = "newEvent";

    public static readonly Selector NewFence = "newFence";

    public static readonly Selector NewHeap = "newHeapWithDescriptor:";

    public static readonly Selector NewIndirectCommandBuffer = "newIndirectCommandBufferWithDescriptor:maxCommandCount:options:";

    public static readonly Selector NewIOCommandQueue = "newIOCommandQueueWithDescriptor:error:";

    public static readonly Selector NewIOFileHandle = "newIOFileHandleWithURL:error:";

    public static readonly Selector NewIOFileHandleWithURLcompressionMethoderror = "newIOFileHandleWithURL:compressionMethod:error:";

    public static readonly Selector NewIOHandle = "newIOHandleWithURL:error:";

    public static readonly Selector NewIOHandleWithURLcompressionMethoderror = "newIOHandleWithURL:compressionMethod:error:";

    public static readonly Selector NewLibrary = "newLibraryWithFile:error:";

    public static readonly Selector NewLibraryWithDataerror = "newLibraryWithData:error:";

    public static readonly Selector NewLibraryWithSourceoptionserror = "newLibraryWithSource:options:error:";

    public static readonly Selector NewLibraryWithStitchedDescriptorerror = "newLibraryWithStitchedDescriptor:error:";

    public static readonly Selector NewLibraryWithURLerror = "newLibraryWithURL:error:";

    public static readonly Selector NewLogState = "newLogStateWithDescriptor:error:";

    public static readonly Selector NewMTL4CommandQueue = "newMTL4CommandQueue";

    public static readonly Selector NewMTL4CommandQueueWithDescriptorerror = "newMTL4CommandQueueWithDescriptor:error:";

    public static readonly Selector NewPipelineDataSetSerializer = "newPipelineDataSetSerializerWithDescriptor:";

    public static readonly Selector NewRasterizationRateMap = "newRasterizationRateMapWithDescriptor:";

    public static readonly Selector NewRenderPipelineState = "newRenderPipelineStateWithDescriptor:error:";

    public static readonly Selector NewResidencySet = "newResidencySetWithDescriptor:error:";

    public static readonly Selector NewSamplerState = "newSamplerStateWithDescriptor:";

    public static readonly Selector NewSharedEvent = "newSharedEvent";

    public static readonly Selector NewSharedEventWithHandle = "newSharedEventWithHandle:";

    public static readonly Selector NewSharedTexture = "newSharedTextureWithDescriptor:";

    public static readonly Selector NewSharedTextureWithHandle = "newSharedTextureWithHandle:";

    public static readonly Selector NewTensor = "newTensorWithDescriptor:error:";

    public static readonly Selector NewTexture = "newTextureWithDescriptor:";

    public static readonly Selector NewTextureViewPool = "newTextureViewPoolWithDescriptor:error:";

    public static readonly Selector NewTextureWithDescriptoriosurfaceplane = "newTextureWithDescriptor:iosurface:plane:";

    public static readonly Selector PeerCount = "peerCount";

    public static readonly Selector PeerGroupID = "peerGroupID";

    public static readonly Selector PeerIndex = "peerIndex";

    public static readonly Selector ProgrammableSamplePositionsSupported = "areProgrammableSamplePositionsSupported";

    public static readonly Selector QueryTimestampFrequency = "queryTimestampFrequency";

    public static readonly Selector RasterOrderGroupsSupported = "areRasterOrderGroupsSupported";

    public static readonly Selector ReadWriteTextureSupport = "readWriteTextureSupport";

    public static readonly Selector RecommendedMaxWorkingSetSize = "recommendedMaxWorkingSetSize";

    public static readonly Selector RegistryID = "registryID";

    public static readonly Selector Removable = "isRemovable";

    public static readonly Selector SampleTimestamps = "sampleTimestamps:gpuTimestamp:";

    public static readonly Selector SetShouldMaximizeConcurrentCompilation = "setShouldMaximizeConcurrentCompilation:";

    public static readonly Selector ShouldMaximizeConcurrentCompilation = "shouldMaximizeConcurrentCompilation";

    public static readonly Selector SizeOfCounterHeapEntry = "sizeOfCounterHeapEntry:";

    public static readonly Selector SparseTileSize = "sparseTileSizeWithTextureType:pixelFormat:sampleCount:";

    public static readonly Selector SparseTileSizeInBytes = "sparseTileSizeInBytes";

    public static readonly Selector SparseTileSizeInBytesForSparsePageSize = "sparseTileSizeInBytesForSparsePageSize:";

    public static readonly Selector SparseTileSizeWithTextureTypepixelFormatsampleCountsparsePageSize = "sparseTileSizeWithTextureType:pixelFormat:sampleCount:sparsePageSize:";

    public static readonly Selector Supports32BitFloatFiltering = "supports32BitFloatFiltering";

    public static readonly Selector Supports32BitMSAA = "supports32BitMSAA";

    public static readonly Selector SupportsBCTextureCompression = "supportsBCTextureCompression";

    public static readonly Selector SupportsCounterSampling = "supportsCounterSampling:";

    public static readonly Selector SupportsDynamicLibraries = "supportsDynamicLibraries";

    public static readonly Selector SupportsFamily = "supportsFamily:";

    public static readonly Selector SupportsFeatureSet = "supportsFeatureSet:";

    public static readonly Selector SupportsFunctionPointers = "supportsFunctionPointers";

    public static readonly Selector SupportsFunctionPointersFromRender = "supportsFunctionPointersFromRender";

    public static readonly Selector SupportsPrimitiveMotionBlur = "supportsPrimitiveMotionBlur";

    public static readonly Selector SupportsPullModelInterpolation = "supportsPullModelInterpolation";

    public static readonly Selector SupportsQueryTextureLOD = "supportsQueryTextureLOD";

    public static readonly Selector SupportsRasterizationRateMap = "supportsRasterizationRateMapWithLayerCount:";

    public static readonly Selector SupportsRaytracing = "supportsRaytracing";

    public static readonly Selector SupportsRaytracingFromRender = "supportsRaytracingFromRender";

    public static readonly Selector SupportsRenderDynamicLibraries = "supportsRenderDynamicLibraries";

    public static readonly Selector SupportsShaderBarycentricCoordinates = "supportsShaderBarycentricCoordinates";

    public static readonly Selector SupportsTextureSampleCount = "supportsTextureSampleCount:";

    public static readonly Selector SupportsVertexAmplificationCount = "supportsVertexAmplificationCount:";

    public static readonly Selector TensorSizeAndAlign = "tensorSizeAndAlignWithDescriptor:";
}
