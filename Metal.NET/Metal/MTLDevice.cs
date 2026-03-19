using System.Runtime.InteropServices;

namespace Metal.NET;

public partial class MTLDevice(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLDevice>
{
    #region INativeObject
    public static new MTLDevice Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLDevice New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSString Name
    {
        get => GetProperty(ref field, MTLDeviceBindings.Name);
    }

    public ulong RegistryID
    {
        get => ObjectiveC.MsgSendULong(NativePtr, MTLDeviceBindings.RegistryID);
    }

    public MTLArchitecture Architecture
    {
        get => GetProperty(ref field, MTLDeviceBindings.Architecture);
    }

    public MTLSize MaxThreadsPerThreadgroup
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLDeviceBindings.MaxThreadsPerThreadgroup);
    }

    public Bool8 IsLowPower
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.IsLowPower);
    }

    public Bool8 IsHeadless
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.IsHeadless);
    }

    public Bool8 IsRemovable
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.IsRemovable);
    }

    public Bool8 HasUnifiedMemory
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.HasUnifiedMemory);
    }

    public ulong RecommendedMaxWorkingSetSize
    {
        get => ObjectiveC.MsgSendULong(NativePtr, MTLDeviceBindings.RecommendedMaxWorkingSetSize);
    }

    public MTLDeviceLocation Location
    {
        get => (MTLDeviceLocation)ObjectiveC.MsgSendULong(NativePtr, MTLDeviceBindings.Location);
    }

    public nuint LocationNumber
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLDeviceBindings.LocationNumber);
    }

    public ulong MaxTransferRate
    {
        get => ObjectiveC.MsgSendULong(NativePtr, MTLDeviceBindings.MaxTransferRate);
    }

    public Bool8 IsDepth24Stencil8PixelFormatSupported
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.IsDepth24Stencil8PixelFormatSupported);
    }

    public MTLReadWriteTextureTier ReadWriteTextureSupport
    {
        get => (MTLReadWriteTextureTier)ObjectiveC.MsgSendULong(NativePtr, MTLDeviceBindings.ReadWriteTextureSupport);
    }

    public MTLArgumentBuffersTier ArgumentBuffersSupport
    {
        get => (MTLArgumentBuffersTier)ObjectiveC.MsgSendULong(NativePtr, MTLDeviceBindings.ArgumentBuffersSupport);
    }

    public Bool8 AreRasterOrderGroupsSupported
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.AreRasterOrderGroupsSupported);
    }

    public Bool8 Supports32BitFloatFiltering
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.Supports32BitFloatFiltering);
    }

    public Bool8 Supports32BitMSAA
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.Supports32BitMSAA);
    }

    public Bool8 SupportsQueryTextureLOD
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsQueryTextureLOD);
    }

    public Bool8 SupportsBCTextureCompression
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsBCTextureCompression);
    }

    public Bool8 SupportsPullModelInterpolation
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsPullModelInterpolation);
    }

    /// <summary>
    /// Deprecated: Use supportsShaderBarycentricCoordinates instead
    /// </summary>
    [Obsolete("Use supportsShaderBarycentricCoordinates instead")]
    public Bool8 AreBarycentricCoordsSupported
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.AreBarycentricCoordsSupported);
    }

    public Bool8 SupportsShaderBarycentricCoordinates
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsShaderBarycentricCoordinates);
    }

    public nuint CurrentAllocatedSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLDeviceBindings.CurrentAllocatedSize);
    }

    public nuint MaxThreadgroupMemoryLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLDeviceBindings.MaxThreadgroupMemoryLength);
    }

    public nuint MaxArgumentBufferSamplerCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLDeviceBindings.MaxArgumentBufferSamplerCount);
    }

    public Bool8 AreProgrammableSamplePositionsSupported
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.AreProgrammableSamplePositionsSupported);
    }

    public ulong PeerGroupID
    {
        get => ObjectiveC.MsgSendULong(NativePtr, MTLDeviceBindings.PeerGroupID);
    }

    public uint PeerIndex
    {
        get => ObjectiveC.MsgSendUInt(NativePtr, MTLDeviceBindings.PeerIndex);
    }

    public uint PeerCount
    {
        get => ObjectiveC.MsgSendUInt(NativePtr, MTLDeviceBindings.PeerCount);
    }

    public nuint SparseTileSizeInBytes
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLDeviceBindings.SparseTileSizeInBytes);
    }

    public nuint MaxBufferLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLDeviceBindings.MaxBufferLength);
    }

    public MTLCounterSet[] CounterSets
    {
        get => GetArrayProperty<MTLCounterSet>(MTLDeviceBindings.CounterSets);
    }

    public Bool8 SupportsDynamicLibraries
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsDynamicLibraries);
    }

    public Bool8 SupportsRenderDynamicLibraries
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsRenderDynamicLibraries);
    }

    public Bool8 SupportsRaytracing
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsRaytracing);
    }

    public Bool8 SupportsFunctionPointers
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsFunctionPointers);
    }

    public Bool8 SupportsFunctionPointersFromRender
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsFunctionPointersFromRender);
    }

    public Bool8 SupportsRaytracingFromRender
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsRaytracingFromRender);
    }

    public Bool8 SupportsPrimitiveMotionBlur
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsPrimitiveMotionBlur);
    }

    public Bool8 ShouldMaximizeConcurrentCompilation
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.ShouldMaximizeConcurrentCompilation);
        set => ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.SetShouldMaximizeConcurrentCompilation, value);
    }

    public nuint MaximumConcurrentCompilationTaskCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLDeviceBindings.MaximumConcurrentCompilationTaskCount);
    }

    public MTLLogState MakeLogState(MTLLogStateDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewLogStateWithDescriptorError, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLCommandQueue MakeCommandQueue()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewCommandQueue);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLCommandQueue MakeCommandQueue(nuint maxCommandBufferCount)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewCommandQueueWithMaxCommandBufferCount, maxCommandBufferCount);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLCommandQueue MakeCommandQueue(MTLCommandQueueDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewCommandQueueWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLSizeAndAlign HeapTextureSizeAndAlign(MTLTextureDescriptor desc)
    {
        return ObjectiveC.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceBindings.HeapTextureSizeAndAlignWithDescriptor, desc.NativePtr);
    }

    public MTLSizeAndAlign HeapBufferSizeAndAlign(nuint length, MTLResourceOptions options)
    {
        return ObjectiveC.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceBindings.HeapBufferSizeAndAlignWithLengthOptions, length, (nuint)options);
    }

    public MTLHeap MakeHeap(MTLHeapDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewHeapWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLBuffer MakeBuffer(nuint length, MTLResourceOptions options)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewBufferWithLengthOptions, length, (nuint)options);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLBuffer MakeBuffer(nint pointer, nuint length, MTLResourceOptions options)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewBufferWithBytesLengthOptions, pointer, length, (nuint)options);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLDepthStencilState MakeDepthStencilState(MTLDepthStencilDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewDepthStencilStateWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLTexture MakeTexture(MTLTextureDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewTextureWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLTexture MakeTexture(MTLTextureDescriptor descriptor, nint iosurface, nuint plane)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewTextureWithDescriptorIosurfacePlane, descriptor.NativePtr, iosurface, plane);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLTexture MakeSharedTexture(MTLTextureDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewSharedTextureWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLTexture MakeSharedTexture(MTLSharedTextureHandle sharedHandle)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewSharedTextureWithHandle, sharedHandle.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLSamplerState MakeSamplerState(MTLSamplerDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewSamplerStateWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLLibrary MakeDefaultLibrary()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewDefaultLibrary);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLLibrary MakeDefaultLibrary(NSBundle bundle, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewDefaultLibraryWithBundleError, bundle.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Deprecated: Use -newLibraryWithURL:error: instead
    /// </summary>
    [Obsolete("Use -newLibraryWithURL:error: instead")]
    public MTLLibrary MakeLibrary(NSString filepath, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewLibraryWithFileError, filepath.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLLibrary MakeLibrary(NSURL url, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewLibraryWithURLError, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLLibrary MakeLibrary(DispatchData data, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewLibraryWithDataError, data.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLLibrary MakeLibrary(NSString source, MTLCompileOptions options, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewLibraryWithSourceOptionsError, source.NativePtr, options.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void MakeLibrary(NSString source, MTLCompileOptions options, MTLNewLibraryCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.NewLibraryWithSourceOptionsCompletionHandler, source.NativePtr, options.NativePtr, completionHandler.NativePtr);
    }

    public MTLLibrary MakeLibrary(MTLStitchedLibraryDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewLibraryWithStitchedDescriptorError, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void MakeLibrary(MTLStitchedLibraryDescriptor descriptor, MTLNewLibraryCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.NewLibraryWithStitchedDescriptorCompletionHandler, descriptor.NativePtr, completionHandler.NativePtr);
    }

    public MTLRenderPipelineState MakeRenderPipelineState(MTLRenderPipelineDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewRenderPipelineStateWithDescriptorError, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRenderPipelineState MakeRenderPipelineState(MTLRenderPipelineDescriptor descriptor, MTLPipelineOption options, out MTLRenderPipelineReflection reflection, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewRenderPipelineStateWithDescriptorOptionsReflectionError, descriptor.NativePtr, (nuint)options, out nint reflectionPtr, out nint errorPtr);

        reflection = new(reflectionPtr, NativeObjectOwnership.Owned);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void MakeRenderPipelineState(MTLRenderPipelineDescriptor descriptor, MTLNewRenderPipelineStateCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.NewRenderPipelineStateWithDescriptorCompletionHandler, descriptor.NativePtr, completionHandler.NativePtr);
    }

    public void MakeRenderPipelineState(MTLRenderPipelineDescriptor descriptor, MTLPipelineOption options, MTLNewRenderPipelineStateWithReflectionCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.NewRenderPipelineStateWithDescriptorOptionsCompletionHandler, descriptor.NativePtr, (nuint)options, completionHandler.NativePtr);
    }

    public MTLComputePipelineState MakeComputePipelineState(MTLFunction computeFunction, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewComputePipelineStateWithFunctionError, computeFunction.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLComputePipelineState MakeComputePipelineState(MTLFunction computeFunction, MTLPipelineOption options, out MTLComputePipelineReflection reflection, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewComputePipelineStateWithFunctionOptionsReflectionError, computeFunction.NativePtr, (nuint)options, out nint reflectionPtr, out nint errorPtr);

        reflection = new(reflectionPtr, NativeObjectOwnership.Owned);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void MakeComputePipelineState(MTLFunction computeFunction, MTLNewComputePipelineStateCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.NewComputePipelineStateWithFunctionCompletionHandler, computeFunction.NativePtr, completionHandler.NativePtr);
    }

    public void MakeComputePipelineState(MTLFunction computeFunction, MTLPipelineOption options, MTLNewComputePipelineStateWithReflectionCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.NewComputePipelineStateWithFunctionOptionsCompletionHandler, computeFunction.NativePtr, (nuint)options, completionHandler.NativePtr);
    }

    public MTLComputePipelineState MakeComputePipelineState(MTLComputePipelineDescriptor descriptor, MTLPipelineOption options, out MTLComputePipelineReflection reflection, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewComputePipelineStateWithDescriptorOptionsReflectionError, descriptor.NativePtr, (nuint)options, out nint reflectionPtr, out nint errorPtr);

        reflection = new(reflectionPtr, NativeObjectOwnership.Owned);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void MakeComputePipelineState(MTLComputePipelineDescriptor descriptor, MTLPipelineOption options, MTLNewComputePipelineStateWithReflectionCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.NewComputePipelineStateWithDescriptorOptionsCompletionHandler, descriptor.NativePtr, (nuint)options, completionHandler.NativePtr);
    }

    public MTLFence MakeFence()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewFence);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Deprecated: Use supportsFamily instead
    /// </summary>
    [Obsolete("Use supportsFamily instead")]
    public bool SupportsFeatureSet(MTLFeatureSet featureSet)
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsFeatureSet, (nuint)featureSet);
    }

    public bool SupportsFamily(MTLGPUFamily gpuFamily)
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsFamily, (nint)gpuFamily);
    }

    public bool SupportsTextureSampleCount(nuint sampleCount)
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsTextureSampleCount, sampleCount);
    }

    public nuint MinimumLinearTextureAlignment(MTLPixelFormat format)
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, MTLDeviceBindings.MinimumLinearTextureAlignmentForPixelFormat, (nuint)format);
    }

    public nuint MinimumTextureBufferAlignment(MTLPixelFormat format)
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, MTLDeviceBindings.MinimumTextureBufferAlignmentForPixelFormat, (nuint)format);
    }

    public MTLRenderPipelineState MakeRenderPipelineState(MTLTileRenderPipelineDescriptor descriptor, MTLPipelineOption options, out MTLRenderPipelineReflection reflection, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewRenderPipelineStateWithTileDescriptorOptionsReflectionError, descriptor.NativePtr, (nuint)options, out nint reflectionPtr, out nint errorPtr);

        reflection = new(reflectionPtr, NativeObjectOwnership.Owned);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void MakeRenderPipelineState(MTLTileRenderPipelineDescriptor descriptor, MTLPipelineOption options, MTLNewRenderPipelineStateWithReflectionCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.NewRenderPipelineStateWithTileDescriptorOptionsCompletionHandler, descriptor.NativePtr, (nuint)options, completionHandler.NativePtr);
    }

    public MTLRenderPipelineState MakeRenderPipelineState(MTLMeshRenderPipelineDescriptor descriptor, MTLPipelineOption options, out MTLRenderPipelineReflection reflection, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewRenderPipelineStateWithMeshDescriptorOptionsReflectionError, descriptor.NativePtr, (nuint)options, out nint reflectionPtr, out nint errorPtr);

        reflection = new(reflectionPtr, NativeObjectOwnership.Owned);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void MakeRenderPipelineState(MTLMeshRenderPipelineDescriptor descriptor, MTLPipelineOption options, MTLNewRenderPipelineStateWithReflectionCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.NewRenderPipelineStateWithMeshDescriptorOptionsCompletionHandler, descriptor.NativePtr, (nuint)options, completionHandler.NativePtr);
    }

    public unsafe void GetDefaultSamplePositions(MTLSamplePosition[] positions)
    {
        fixed (MTLSamplePosition* pPositions = positions)
        {
            ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.GetDefaultSamplePositionsCount, (nint)pPositions, (nuint)positions.Length);
        }
    }

    public bool SupportsRasterizationRateMap(nuint layerCount)
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsRasterizationRateMapWithLayerCount, layerCount);
    }

    public MTLRasterizationRateMap MakeRasterizationRateMap(MTLRasterizationRateMapDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewRasterizationRateMapWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLIndirectCommandBuffer MakeIndirectCommandBuffer(MTLIndirectCommandBufferDescriptor descriptor, nuint maxCount, MTLResourceOptions options)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewIndirectCommandBufferWithDescriptorMaxCommandCountOptions, descriptor.NativePtr, maxCount, (nuint)options);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLEvent MakeEvent()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewEvent);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLSharedEvent MakeSharedEvent()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewSharedEvent);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLSharedEvent MakeSharedEvent(MTLSharedEventHandle sharedEventHandle)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewSharedEventWithHandle, sharedEventHandle.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Deprecated: Use newIOFileHandleWithURL:error: instead
    /// </summary>
    [Obsolete("Use newIOFileHandleWithURL:error: instead")]
    public MTLIOFileHandle MakeIOHandle(NSURL url, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewIOHandleWithURLError, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLIOCommandQueue MakeIOCommandQueue(MTLIOCommandQueueDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewIOCommandQueueWithDescriptorError, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Deprecated: Use newIOFileHandleWithURL:compressionMethod:error: instead
    /// </summary>
    [Obsolete("Use newIOFileHandleWithURL:compressionMethod:error: instead")]
    public MTLIOFileHandle MakeIOHandle(NSURL url, MTLIOCompressionMethod compressionMethod, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewIOHandleWithURLCompressionMethodError, url.NativePtr, (nint)compressionMethod, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLIOFileHandle MakeIOFileHandle(NSURL url, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewIOFileHandleWithURLError, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLIOFileHandle MakeIOFileHandle(NSURL url, MTLIOCompressionMethod compressionMethod, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewIOFileHandleWithURLCompressionMethodError, url.NativePtr, (nint)compressionMethod, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLSize SparseTileSize(MTLTextureType textureType, MTLPixelFormat pixelFormat, nuint sampleCount)
    {
        return ObjectiveC.MsgSendMTLSize(NativePtr, MTLDeviceBindings.SparseTileSizeWithTextureTypePixelFormatSampleCount, (nuint)textureType, (nuint)pixelFormat, sampleCount);
    }

    public void ConvertSparsePixelRegions(MTLRegion pixelRegions, MTLRegion tileRegions, MTLSize tileSize, MTLSparseTextureRegionAlignmentMode mode, nuint numRegions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.ConvertSparsePixelRegionsToTileRegionsWithTileSizeAlignmentModeNumRegions, pixelRegions, tileRegions, tileSize, (nuint)mode, numRegions);
    }

    public void ConvertSparseTileRegions(MTLRegion tileRegions, MTLRegion pixelRegions, MTLSize tileSize, nuint numRegions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.ConvertSparseTileRegionsToPixelRegionsWithTileSizeNumRegions, tileRegions, pixelRegions, tileSize, numRegions);
    }

    public MTLSize SparseTileSize(MTLTextureType textureType, MTLPixelFormat pixelFormat, nuint sampleCount, MTLSparsePageSize sparsePageSize)
    {
        return ObjectiveC.MsgSendMTLSize(NativePtr, MTLDeviceBindings.SparseTileSizeWithTextureTypePixelFormatSampleCountSparsePageSize, (nuint)textureType, (nuint)pixelFormat, sampleCount, (nint)sparsePageSize);
    }

    public MTLCounterSampleBuffer MakeCounterSampleBuffer(MTLCounterSampleBufferDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewCounterSampleBufferWithDescriptorError, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void SampleTimestamps(out ulong cpuTimestamp, out ulong gpuTimestamp)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.SampleTimestampsGpuTimestamp, out cpuTimestamp, out gpuTimestamp);
    }

    public MTLArgumentEncoder MakeArgumentEncoder(MTLBufferBinding bufferBinding)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewArgumentEncoderWithBufferBinding, bufferBinding.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public bool SupportsCounterSampling(MTLCounterSamplingPoint samplingPoint)
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsCounterSampling, (nuint)samplingPoint);
    }

    public bool SupportsVertexAmplificationCount(nuint count)
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsVertexAmplificationCount, count);
    }

    public MTLDynamicLibrary MakeDynamicLibrary(MTLLibrary library, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewDynamicLibraryError, library.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLDynamicLibrary MakeDynamicLibrary(NSURL url, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewDynamicLibraryWithURLError, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLBinaryArchive MakeBinaryArchive(MTLBinaryArchiveDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewBinaryArchiveWithDescriptorError, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLAccelerationStructureSizes AccelerationStructureSizes(MTLAccelerationStructureDescriptor descriptor)
    {
        return ObjectiveC.MsgSendMTLAccelerationStructureSizes(NativePtr, MTLDeviceBindings.AccelerationStructureSizesWithDescriptor, descriptor.NativePtr);
    }

    public MTLAccelerationStructure MakeAccelerationStructure(nuint size)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewAccelerationStructureWithSize, size);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLAccelerationStructure MakeAccelerationStructure(MTLAccelerationStructureDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewAccelerationStructureWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLSizeAndAlign HeapAccelerationStructureSizeAndAlign(nuint size)
    {
        return ObjectiveC.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceBindings.HeapAccelerationStructureSizeAndAlignWithSize, size);
    }

    public MTLSizeAndAlign HeapAccelerationStructureSizeAndAlign(MTLAccelerationStructureDescriptor descriptor)
    {
        return ObjectiveC.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceBindings.HeapAccelerationStructureSizeAndAlignWithDescriptor, descriptor.NativePtr);
    }

    public MTLResidencySet MakeResidencySet(MTLResidencySetDescriptor desc, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewResidencySetWithDescriptorError, desc.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLSizeAndAlign TensorSizeAndAlign(MTLTensorDescriptor descriptor)
    {
        return ObjectiveC.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceBindings.TensorSizeAndAlignWithDescriptor, descriptor.NativePtr);
    }

    public MTLTensor MakeTensor(MTLTensorDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewTensorWithDescriptorError, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLFunctionHandle FunctionHandle(MTLFunction function)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.FunctionHandleWithFunction, function.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CommandAllocator MakeCommandAllocator()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewCommandAllocator);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CommandAllocator MakeCommandAllocator(MTL4CommandAllocatorDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewCommandAllocatorWithDescriptorError, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CommandQueue MakeMTL4CommandQueue()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewMTL4CommandQueue);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CommandQueue MakeMTL4CommandQueue(MTL4CommandQueueDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewMTL4CommandQueueWithDescriptorError, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CommandBuffer MakeCommandBuffer()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewCommandBuffer);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4ArgumentTable MakeArgumentTable(MTL4ArgumentTableDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewArgumentTableWithDescriptorError, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLTextureViewPool MakeTextureViewPool(MTLResourceViewPoolDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewTextureViewPoolWithDescriptorError, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4Compiler MakeCompiler(MTL4CompilerDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewCompilerWithDescriptorError, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4Archive MakeArchive(NSURL url, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewArchiveWithURLError, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4PipelineDataSetSerializer MakePipelineDataSetSerializer(MTL4PipelineDataSetSerializerDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewPipelineDataSetSerializerWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLBuffer MakeBuffer(nuint length, MTLResourceOptions options, MTLSparsePageSize placementSparsePageSize)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewBufferWithLengthOptionsPlacementSparsePageSize, length, (nuint)options, (nint)placementSparsePageSize);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CounterHeap MakeCounterHeap(MTL4CounterHeapDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewCounterHeapWithDescriptorError, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public nuint Size(MTL4CounterHeapType type)
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, MTLDeviceBindings.SizeOfCounterHeapEntry, (nint)type);
    }

    public ulong QueryTimestampFrequency()
    {
        return ObjectiveC.MsgSendULong(NativePtr, MTLDeviceBindings.QueryTimestampFrequency);
    }

    public MTLFunctionHandle FunctionHandle(MTL4BinaryFunction function)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.FunctionHandleWithBinaryFunction, function.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal", EntryPoint = "MTLOriginMake")]
    private static partial MTLOrigin MTLOriginMake(nuint x, nuint y, nuint z);

    public static MTLOrigin OriginMake(nuint x, nuint y, nuint z) => MTLOriginMake(x, y, z);

    [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal", EntryPoint = "MTLSizeMake")]
    private static partial MTLSize MTLSizeMake(nuint width, nuint height, nuint depth);

    public static MTLSize SizeMake(nuint width, nuint height, nuint depth) => MTLSizeMake(width, height, depth);

    [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal", EntryPoint = "MTLRegionMake1D")]
    private static partial MTLRegion MTLRegionMake1D(nuint x, nuint width);

    public static MTLRegion RegionMake1D(nuint x, nuint width) => MTLRegionMake1D(x, width);

    [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal", EntryPoint = "MTLRegionMake2D")]
    private static partial MTLRegion MTLRegionMake2D(nuint x, nuint y, nuint width, nuint height);

    public static MTLRegion RegionMake2D(nuint x, nuint y, nuint width, nuint height) => MTLRegionMake2D(x, y, width, height);

    [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal", EntryPoint = "MTLRegionMake3D")]
    private static partial MTLRegion MTLRegionMake3D(nuint x, nuint y, nuint z, nuint width, nuint height, nuint depth);

    public static MTLRegion RegionMake3D(nuint x, nuint y, nuint z, nuint width, nuint height, nuint depth) => MTLRegionMake3D(x, y, z, width, height, depth);

    [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal", EntryPoint = "MTLSamplePositionMake")]
    private static partial MTLSamplePosition MTLSamplePositionMake(float x, float y);

    public static MTLSamplePosition SamplePositionMake(float x, float y) => MTLSamplePositionMake(x, y);

    [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal", EntryPoint = "MTLCoordinate2DMake")]
    private static partial MTLSamplePosition MTLCoordinate2DMake(float x, float y);

    public static MTLSamplePosition Coordinate2DMake(float x, float y) => MTLCoordinate2DMake(x, y);

    [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal", EntryPoint = "MTLTextureSwizzleChannelsMake")]
    private static partial MTLTextureSwizzleChannels MTLTextureSwizzleChannelsMake(MTLTextureSwizzle r, MTLTextureSwizzle g, MTLTextureSwizzle b, MTLTextureSwizzle a);

    public static MTLTextureSwizzleChannels TextureSwizzleChannelsMake(MTLTextureSwizzle r, MTLTextureSwizzle g, MTLTextureSwizzle b, MTLTextureSwizzle a) => MTLTextureSwizzleChannelsMake(r, g, b, a);

    [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal", EntryPoint = "MTLCreateSystemDefaultDevice")]
    private static partial nint MTLCreateSystemDefaultDevice();

    public static MTLDevice CreateSystemDefaultDevice()
    {
        nint nativePtr = MTLCreateSystemDefaultDevice();

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal", EntryPoint = "MTLRemoveDeviceObserver")]
    private static partial void MTLRemoveDeviceObserver(nint observer);

    public static void RemoveDeviceObserver(NSObject observer) => MTLRemoveDeviceObserver(observer.NativePtr);

    [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal", EntryPoint = "MTLClearColorMake")]
    private static partial MTLClearColor MTLClearColorMake(double red, double green, double blue, double alpha);

    public static MTLClearColor ClearColorMake(double red, double green, double blue, double alpha) => MTLClearColorMake(red, green, blue, alpha);

    [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal", EntryPoint = "MTLPackedFloat3Make")]
    private static partial MTLPackedFloat3 MTLPackedFloat3Make(float x, float y, float z);

    public static MTLPackedFloat3 PackedFloat3Make(float x, float y, float z) => MTLPackedFloat3Make(x, y, z);

    [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal", EntryPoint = "MTLPackedFloatQuaternionMake")]
    private static partial MTLPackedFloatQuaternion MTLPackedFloatQuaternionMake(float x, float y, float z, float w);

    public static MTLPackedFloatQuaternion PackedFloatQuaternionMake(float x, float y, float z, float w) => MTLPackedFloatQuaternionMake(x, y, z, w);

    [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal", EntryPoint = "MTLIndirectCommandBufferExecutionRangeMake")]
    private static partial MTLIndirectCommandBufferExecutionRange MTLIndirectCommandBufferExecutionRangeMake(uint location, uint length);

    public static MTLIndirectCommandBufferExecutionRange IndirectCommandBufferExecutionRangeMake(uint location, uint length) => MTLIndirectCommandBufferExecutionRangeMake(location, length);

    [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal", EntryPoint = "MTLIOCompressionContextDefaultChunkSize")]
    private static partial nuint MTLIOCompressionContextDefaultChunkSize();

    public static nuint IOCompressionContextDefaultChunkSize() => MTLIOCompressionContextDefaultChunkSize();
}

file static class MTLDeviceBindings
{
    public static readonly Selector AccelerationStructureSizesWithDescriptor = "accelerationStructureSizesWithDescriptor:";

    public static readonly Selector Architecture = "architecture";

    public static readonly Selector AreBarycentricCoordsSupported = "areBarycentricCoordsSupported";

    public static readonly Selector AreProgrammableSamplePositionsSupported = "areProgrammableSamplePositionsSupported";

    public static readonly Selector AreRasterOrderGroupsSupported = "areRasterOrderGroupsSupported";

    public static readonly Selector ArgumentBuffersSupport = "argumentBuffersSupport";

    public static readonly Selector ConvertSparsePixelRegionsToTileRegionsWithTileSizeAlignmentModeNumRegions = "convertSparsePixelRegions:toTileRegions:withTileSize:alignmentMode:numRegions:";

    public static readonly Selector ConvertSparseTileRegionsToPixelRegionsWithTileSizeNumRegions = "convertSparseTileRegions:toPixelRegions:withTileSize:numRegions:";

    public static readonly Selector CounterSets = "counterSets";

    public static readonly Selector CurrentAllocatedSize = "currentAllocatedSize";

    public static readonly Selector FunctionHandleWithBinaryFunction = "functionHandleWithBinaryFunction:";

    public static readonly Selector FunctionHandleWithFunction = "functionHandleWithFunction:";

    public static readonly Selector GetDefaultSamplePositionsCount = "getDefaultSamplePositions:count:";

    public static readonly Selector HasUnifiedMemory = "hasUnifiedMemory";

    public static readonly Selector HeapAccelerationStructureSizeAndAlignWithDescriptor = "heapAccelerationStructureSizeAndAlignWithDescriptor:";

    public static readonly Selector HeapAccelerationStructureSizeAndAlignWithSize = "heapAccelerationStructureSizeAndAlignWithSize:";

    public static readonly Selector HeapBufferSizeAndAlignWithLengthOptions = "heapBufferSizeAndAlignWithLength:options:";

    public static readonly Selector HeapTextureSizeAndAlignWithDescriptor = "heapTextureSizeAndAlignWithDescriptor:";

    public static readonly Selector IsDepth24Stencil8PixelFormatSupported = "isDepth24Stencil8PixelFormatSupported";

    public static readonly Selector IsHeadless = "isHeadless";

    public static readonly Selector IsLowPower = "isLowPower";

    public static readonly Selector IsRemovable = "isRemovable";

    public static readonly Selector Location = "location";

    public static readonly Selector LocationNumber = "locationNumber";

    public static readonly Selector MaxArgumentBufferSamplerCount = "maxArgumentBufferSamplerCount";

    public static readonly Selector MaxBufferLength = "maxBufferLength";

    public static readonly Selector MaximumConcurrentCompilationTaskCount = "maximumConcurrentCompilationTaskCount";

    public static readonly Selector MaxThreadgroupMemoryLength = "maxThreadgroupMemoryLength";

    public static readonly Selector MaxThreadsPerThreadgroup = "maxThreadsPerThreadgroup";

    public static readonly Selector MaxTransferRate = "maxTransferRate";

    public static readonly Selector MinimumLinearTextureAlignmentForPixelFormat = "minimumLinearTextureAlignmentForPixelFormat:";

    public static readonly Selector MinimumTextureBufferAlignmentForPixelFormat = "minimumTextureBufferAlignmentForPixelFormat:";

    public static readonly Selector Name = "name";

    public static readonly Selector NewAccelerationStructureWithDescriptor = "newAccelerationStructureWithDescriptor:";

    public static readonly Selector NewAccelerationStructureWithSize = "newAccelerationStructureWithSize:";

    public static readonly Selector NewArchiveWithURLError = "newArchiveWithURL:error:";

    public static readonly Selector NewArgumentEncoderWithBufferBinding = "newArgumentEncoderWithBufferBinding:";

    public static readonly Selector NewArgumentTableWithDescriptorError = "newArgumentTableWithDescriptor:error:";

    public static readonly Selector NewBinaryArchiveWithDescriptorError = "newBinaryArchiveWithDescriptor:error:";

    public static readonly Selector NewBufferWithBytesLengthOptions = "newBufferWithBytes:length:options:";

    public static readonly Selector NewBufferWithLengthOptions = "newBufferWithLength:options:";

    public static readonly Selector NewBufferWithLengthOptionsPlacementSparsePageSize = "newBufferWithLength:options:placementSparsePageSize:";

    public static readonly Selector NewCommandAllocator = "newCommandAllocator";

    public static readonly Selector NewCommandAllocatorWithDescriptorError = "newCommandAllocatorWithDescriptor:error:";

    public static readonly Selector NewCommandBuffer = "newCommandBuffer";

    public static readonly Selector NewCommandQueue = "newCommandQueue";

    public static readonly Selector NewCommandQueueWithDescriptor = "newCommandQueueWithDescriptor:";

    public static readonly Selector NewCommandQueueWithMaxCommandBufferCount = "newCommandQueueWithMaxCommandBufferCount:";

    public static readonly Selector NewCompilerWithDescriptorError = "newCompilerWithDescriptor:error:";

    public static readonly Selector NewComputePipelineStateWithDescriptorOptionsCompletionHandler = "newComputePipelineStateWithDescriptor:options:completionHandler:";

    public static readonly Selector NewComputePipelineStateWithDescriptorOptionsReflectionError = "newComputePipelineStateWithDescriptor:options:reflection:error:";

    public static readonly Selector NewComputePipelineStateWithFunctionCompletionHandler = "newComputePipelineStateWithFunction:completionHandler:";

    public static readonly Selector NewComputePipelineStateWithFunctionError = "newComputePipelineStateWithFunction:error:";

    public static readonly Selector NewComputePipelineStateWithFunctionOptionsCompletionHandler = "newComputePipelineStateWithFunction:options:completionHandler:";

    public static readonly Selector NewComputePipelineStateWithFunctionOptionsReflectionError = "newComputePipelineStateWithFunction:options:reflection:error:";

    public static readonly Selector NewCounterHeapWithDescriptorError = "newCounterHeapWithDescriptor:error:";

    public static readonly Selector NewCounterSampleBufferWithDescriptorError = "newCounterSampleBufferWithDescriptor:error:";

    public static readonly Selector NewDefaultLibrary = "newDefaultLibrary";

    public static readonly Selector NewDefaultLibraryWithBundleError = "newDefaultLibraryWithBundle:error:";

    public static readonly Selector NewDepthStencilStateWithDescriptor = "newDepthStencilStateWithDescriptor:";

    public static readonly Selector NewDynamicLibraryError = "newDynamicLibrary:error:";

    public static readonly Selector NewDynamicLibraryWithURLError = "newDynamicLibraryWithURL:error:";

    public static readonly Selector NewEvent = "newEvent";

    public static readonly Selector NewFence = "newFence";

    public static readonly Selector NewHeapWithDescriptor = "newHeapWithDescriptor:";

    public static readonly Selector NewIndirectCommandBufferWithDescriptorMaxCommandCountOptions = "newIndirectCommandBufferWithDescriptor:maxCommandCount:options:";

    public static readonly Selector NewIOCommandQueueWithDescriptorError = "newIOCommandQueueWithDescriptor:error:";

    public static readonly Selector NewIOFileHandleWithURLCompressionMethodError = "newIOFileHandleWithURL:compressionMethod:error:";

    public static readonly Selector NewIOFileHandleWithURLError = "newIOFileHandleWithURL:error:";

    public static readonly Selector NewIOHandleWithURLCompressionMethodError = "newIOHandleWithURL:compressionMethod:error:";

    public static readonly Selector NewIOHandleWithURLError = "newIOHandleWithURL:error:";

    public static readonly Selector NewLibraryWithDataError = "newLibraryWithData:error:";

    public static readonly Selector NewLibraryWithFileError = "newLibraryWithFile:error:";

    public static readonly Selector NewLibraryWithSourceOptionsCompletionHandler = "newLibraryWithSource:options:completionHandler:";

    public static readonly Selector NewLibraryWithSourceOptionsError = "newLibraryWithSource:options:error:";

    public static readonly Selector NewLibraryWithStitchedDescriptorCompletionHandler = "newLibraryWithStitchedDescriptor:completionHandler:";

    public static readonly Selector NewLibraryWithStitchedDescriptorError = "newLibraryWithStitchedDescriptor:error:";

    public static readonly Selector NewLibraryWithURLError = "newLibraryWithURL:error:";

    public static readonly Selector NewLogStateWithDescriptorError = "newLogStateWithDescriptor:error:";

    public static readonly Selector NewMTL4CommandQueue = "newMTL4CommandQueue";

    public static readonly Selector NewMTL4CommandQueueWithDescriptorError = "newMTL4CommandQueueWithDescriptor:error:";

    public static readonly Selector NewPipelineDataSetSerializerWithDescriptor = "newPipelineDataSetSerializerWithDescriptor:";

    public static readonly Selector NewRasterizationRateMapWithDescriptor = "newRasterizationRateMapWithDescriptor:";

    public static readonly Selector NewRenderPipelineStateWithDescriptorCompletionHandler = "newRenderPipelineStateWithDescriptor:completionHandler:";

    public static readonly Selector NewRenderPipelineStateWithDescriptorError = "newRenderPipelineStateWithDescriptor:error:";

    public static readonly Selector NewRenderPipelineStateWithDescriptorOptionsCompletionHandler = "newRenderPipelineStateWithDescriptor:options:completionHandler:";

    public static readonly Selector NewRenderPipelineStateWithDescriptorOptionsReflectionError = "newRenderPipelineStateWithDescriptor:options:reflection:error:";

    public static readonly Selector NewRenderPipelineStateWithMeshDescriptorOptionsCompletionHandler = "newRenderPipelineStateWithMeshDescriptor:options:completionHandler:";

    public static readonly Selector NewRenderPipelineStateWithMeshDescriptorOptionsReflectionError = "newRenderPipelineStateWithMeshDescriptor:options:reflection:error:";

    public static readonly Selector NewRenderPipelineStateWithTileDescriptorOptionsCompletionHandler = "newRenderPipelineStateWithTileDescriptor:options:completionHandler:";

    public static readonly Selector NewRenderPipelineStateWithTileDescriptorOptionsReflectionError = "newRenderPipelineStateWithTileDescriptor:options:reflection:error:";

    public static readonly Selector NewResidencySetWithDescriptorError = "newResidencySetWithDescriptor:error:";

    public static readonly Selector NewSamplerStateWithDescriptor = "newSamplerStateWithDescriptor:";

    public static readonly Selector NewSharedEvent = "newSharedEvent";

    public static readonly Selector NewSharedEventWithHandle = "newSharedEventWithHandle:";

    public static readonly Selector NewSharedTextureWithDescriptor = "newSharedTextureWithDescriptor:";

    public static readonly Selector NewSharedTextureWithHandle = "newSharedTextureWithHandle:";

    public static readonly Selector NewTensorWithDescriptorError = "newTensorWithDescriptor:error:";

    public static readonly Selector NewTextureViewPoolWithDescriptorError = "newTextureViewPoolWithDescriptor:error:";

    public static readonly Selector NewTextureWithDescriptor = "newTextureWithDescriptor:";

    public static readonly Selector NewTextureWithDescriptorIosurfacePlane = "newTextureWithDescriptor:iosurface:plane:";

    public static readonly Selector PeerCount = "peerCount";

    public static readonly Selector PeerGroupID = "peerGroupID";

    public static readonly Selector PeerIndex = "peerIndex";

    public static readonly Selector QueryTimestampFrequency = "queryTimestampFrequency";

    public static readonly Selector ReadWriteTextureSupport = "readWriteTextureSupport";

    public static readonly Selector RecommendedMaxWorkingSetSize = "recommendedMaxWorkingSetSize";

    public static readonly Selector RegistryID = "registryID";

    public static readonly Selector SampleTimestampsGpuTimestamp = "sampleTimestamps:gpuTimestamp:";

    public static readonly Selector SetShouldMaximizeConcurrentCompilation = "setShouldMaximizeConcurrentCompilation:";

    public static readonly Selector ShouldMaximizeConcurrentCompilation = "shouldMaximizeConcurrentCompilation";

    public static readonly Selector SizeOfCounterHeapEntry = "sizeOfCounterHeapEntry:";

    public static readonly Selector SparseTileSizeInBytes = "sparseTileSizeInBytes";

    public static readonly Selector SparseTileSizeWithTextureTypePixelFormatSampleCount = "sparseTileSizeWithTextureType:pixelFormat:sampleCount:";

    public static readonly Selector SparseTileSizeWithTextureTypePixelFormatSampleCountSparsePageSize = "sparseTileSizeWithTextureType:pixelFormat:sampleCount:sparsePageSize:";

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

    public static readonly Selector SupportsRasterizationRateMapWithLayerCount = "supportsRasterizationRateMapWithLayerCount:";

    public static readonly Selector SupportsRaytracing = "supportsRaytracing";

    public static readonly Selector SupportsRaytracingFromRender = "supportsRaytracingFromRender";

    public static readonly Selector SupportsRenderDynamicLibraries = "supportsRenderDynamicLibraries";

    public static readonly Selector SupportsShaderBarycentricCoordinates = "supportsShaderBarycentricCoordinates";

    public static readonly Selector SupportsTextureSampleCount = "supportsTextureSampleCount:";

    public static readonly Selector SupportsVertexAmplificationCount = "supportsVertexAmplificationCount:";

    public static readonly Selector TensorSizeAndAlignWithDescriptor = "tensorSizeAndAlignWithDescriptor:";
}
