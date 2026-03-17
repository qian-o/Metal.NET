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

    public ulong QueryTimestampFrequency
    {
        get => ObjectiveC.MsgSendULong(NativePtr, MTLDeviceBindings.QueryTimestampFrequency);
    }

    public MTLLogState NewLogStateWithDescriptorError(MTLLogStateDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewLogStateWithDescriptor, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLLogState NewLogState(MTLLogStateDescriptor descriptor, out NSError error)
    {
        return NewLogStateWithDescriptorError(descriptor, out error);
    }

    public MTLCommandQueue NewCommandQueue()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewCommandQueue);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLCommandQueue NewCommandQueueWithMaxCommandBufferCount(nuint maxCommandBufferCount)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewCommandQueueWithMaxCommandBufferCount, maxCommandBufferCount);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLCommandQueue NewCommandQueue(nuint maxCommandBufferCount)
    {
        return NewCommandQueueWithMaxCommandBufferCount(maxCommandBufferCount);
    }

    public MTLCommandQueue NewCommandQueueWithDescriptor(MTLCommandQueueDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewCommandQueueWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLCommandQueue NewCommandQueue(MTLCommandQueueDescriptor descriptor)
    {
        return NewCommandQueueWithDescriptor(descriptor);
    }

    public MTLSizeAndAlign HeapTextureSizeAndAlignWithDescriptor(MTLTextureDescriptor desc)
    {
        return ObjectiveC.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceBindings.HeapTextureSizeAndAlignWithDescriptor, desc.NativePtr);
    }

    public MTLSizeAndAlign HeapTextureSizeAndAlign(MTLTextureDescriptor desc)
    {
        return HeapTextureSizeAndAlignWithDescriptor(desc);
    }

    public MTLSizeAndAlign HeapBufferSizeAndAlignWithLengthOptions(nuint length, MTLResourceOptions options)
    {
        return ObjectiveC.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceBindings.HeapBufferSizeAndAlignWithLength, length, (nuint)options);
    }

    public MTLSizeAndAlign HeapBufferSizeAndAlign(nuint length, MTLResourceOptions options)
    {
        return HeapBufferSizeAndAlignWithLengthOptions(length, options);
    }

    public MTLHeap NewHeapWithDescriptor(MTLHeapDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewHeapWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLHeap NewHeap(MTLHeapDescriptor descriptor)
    {
        return NewHeapWithDescriptor(descriptor);
    }

    public MTLBuffer NewBufferWithLengthOptions(nuint length, MTLResourceOptions options)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewBufferWithLength, length, (nuint)options);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLBuffer NewBuffer(nuint length, MTLResourceOptions options)
    {
        return NewBufferWithLengthOptions(length, options);
    }

    public MTLBuffer NewBufferWithBytesLengthOptions(nint pointer, nuint length, MTLResourceOptions options)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewBufferWithBytes, pointer, length, (nuint)options);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLBuffer NewBuffer(nint pointer, nuint length, MTLResourceOptions options)
    {
        return NewBufferWithBytesLengthOptions(pointer, length, options);
    }

    public MTLDepthStencilState NewDepthStencilStateWithDescriptor(MTLDepthStencilDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewDepthStencilStateWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLDepthStencilState NewDepthStencilState(MTLDepthStencilDescriptor descriptor)
    {
        return NewDepthStencilStateWithDescriptor(descriptor);
    }

    public MTLTexture NewTextureWithDescriptor(MTLTextureDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewTextureWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor)
    {
        return NewTextureWithDescriptor(descriptor);
    }

    public MTLTexture NewTextureWithDescriptorIosurfacePlane(MTLTextureDescriptor descriptor, nint iosurface, nuint plane)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewTextureWithDescriptorIosurfacePlane, descriptor.NativePtr, iosurface, plane);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor, nint iosurface, nuint plane)
    {
        return NewTextureWithDescriptorIosurfacePlane(descriptor, iosurface, plane);
    }

    public MTLTexture NewSharedTextureWithDescriptor(MTLTextureDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewSharedTextureWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLTexture NewSharedTexture(MTLTextureDescriptor descriptor)
    {
        return NewSharedTextureWithDescriptor(descriptor);
    }

    public MTLTexture NewSharedTextureWithHandle(MTLSharedTextureHandle sharedHandle)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewSharedTextureWithHandle, sharedHandle.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLTexture NewSharedTexture(MTLSharedTextureHandle sharedHandle)
    {
        return NewSharedTextureWithHandle(sharedHandle);
    }

    public MTLSamplerState NewSamplerStateWithDescriptor(MTLSamplerDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewSamplerStateWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLSamplerState NewSamplerState(MTLSamplerDescriptor descriptor)
    {
        return NewSamplerStateWithDescriptor(descriptor);
    }

    public MTLLibrary NewDefaultLibrary()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewDefaultLibrary);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLLibrary NewDefaultLibraryWithBundleError(NSBundle bundle, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewDefaultLibraryWithBundle, bundle.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLLibrary NewDefaultLibrary(NSBundle bundle, out NSError error)
    {
        return NewDefaultLibraryWithBundleError(bundle, out error);
    }

    /// <summary>
    /// Deprecated: Use -newLibraryWithURL:error: instead
    /// </summary>
    [Obsolete("Use -newLibraryWithURL:error: instead")]
    public MTLLibrary NewLibraryWithFileError(NSString filepath, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewLibraryWithFile, filepath.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLLibrary NewLibrary(NSString filepath, out NSError error)
    {
        return NewLibraryWithFileError(filepath, out error);
    }

    public MTLLibrary NewLibraryWithURLError(NSURL url, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewLibraryWithURL, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLLibrary NewLibrary(NSURL url, out NSError error)
    {
        return NewLibraryWithURLError(url, out error);
    }

    public MTLLibrary NewLibraryWithDataError(DispatchData data, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewLibraryWithData, data.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLLibrary NewLibrary(DispatchData data, out NSError error)
    {
        return NewLibraryWithDataError(data, out error);
    }

    public MTLLibrary NewLibraryWithSourceOptionsError(NSString source, MTLCompileOptions options, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewLibraryWithSource, source.NativePtr, options.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLLibrary NewLibrary(NSString source, MTLCompileOptions options, out NSError error)
    {
        return NewLibraryWithSourceOptionsError(source, options, out error);
    }

    public void NewLibraryWithSourceOptionsCompletionHandler(NSString source, MTLCompileOptions options, MTLNewLibraryCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.NewLibraryWithSourceOptionsCompletionHandler, source.NativePtr, options.NativePtr, completionHandler.NativePtr);
    }

    public void NewLibrary(NSString source, MTLCompileOptions options, MTLNewLibraryCompletionHandler completionHandler)
    {
        NewLibraryWithSourceOptionsCompletionHandler(source, options, completionHandler);
    }

    public MTLLibrary NewLibraryWithStitchedDescriptorError(MTLStitchedLibraryDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewLibraryWithStitchedDescriptor, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLLibrary NewLibrary(MTLStitchedLibraryDescriptor descriptor, out NSError error)
    {
        return NewLibraryWithStitchedDescriptorError(descriptor, out error);
    }

    public void NewLibraryWithStitchedDescriptorCompletionHandler(MTLStitchedLibraryDescriptor descriptor, MTLNewLibraryCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.NewLibraryWithStitchedDescriptorCompletionHandler, descriptor.NativePtr, completionHandler.NativePtr);
    }

    public void NewLibrary(MTLStitchedLibraryDescriptor descriptor, MTLNewLibraryCompletionHandler completionHandler)
    {
        NewLibraryWithStitchedDescriptorCompletionHandler(descriptor, completionHandler);
    }

    public MTLRenderPipelineState NewRenderPipelineStateWithDescriptorError(MTLRenderPipelineDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewRenderPipelineStateWithDescriptor, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTLRenderPipelineDescriptor descriptor, out NSError error)
    {
        return NewRenderPipelineStateWithDescriptorError(descriptor, out error);
    }

    public MTLRenderPipelineState NewRenderPipelineStateWithDescriptorOptionsReflectionError(MTLRenderPipelineDescriptor descriptor, MTLPipelineOption options, out MTLRenderPipelineReflection reflection, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewRenderPipelineStateWithDescriptorOptionsReflectionError, descriptor.NativePtr, (nuint)options, out nint reflectionPtr, out nint errorPtr);

        reflection = new(reflectionPtr, NativeObjectOwnership.Owned);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTLRenderPipelineDescriptor descriptor, MTLPipelineOption options, out MTLRenderPipelineReflection reflection, out NSError error)
    {
        return NewRenderPipelineStateWithDescriptorOptionsReflectionError(descriptor, options, out reflection, out error);
    }

    public void NewRenderPipelineStateWithDescriptorCompletionHandler(MTLRenderPipelineDescriptor descriptor, MTLNewRenderPipelineStateCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.NewRenderPipelineStateWithDescriptorCompletionHandler, descriptor.NativePtr, completionHandler.NativePtr);
    }

    public void NewRenderPipelineState(MTLRenderPipelineDescriptor descriptor, MTLNewRenderPipelineStateCompletionHandler completionHandler)
    {
        NewRenderPipelineStateWithDescriptorCompletionHandler(descriptor, completionHandler);
    }

    public void NewRenderPipelineStateWithDescriptorOptionsCompletionHandler(MTLRenderPipelineDescriptor descriptor, MTLPipelineOption options, MTLNewRenderPipelineStateWithReflectionCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.NewRenderPipelineStateWithDescriptorOptionsCompletionHandler, descriptor.NativePtr, (nuint)options, completionHandler.NativePtr);
    }

    public void NewRenderPipelineState(MTLRenderPipelineDescriptor descriptor, MTLPipelineOption options, MTLNewRenderPipelineStateWithReflectionCompletionHandler completionHandler)
    {
        NewRenderPipelineStateWithDescriptorOptionsCompletionHandler(descriptor, options, completionHandler);
    }

    public MTLComputePipelineState NewComputePipelineStateWithFunctionError(MTLFunction computeFunction, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewComputePipelineStateWithFunction, computeFunction.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLComputePipelineState NewComputePipelineState(MTLFunction computeFunction, out NSError error)
    {
        return NewComputePipelineStateWithFunctionError(computeFunction, out error);
    }

    public MTLComputePipelineState NewComputePipelineStateWithFunctionOptionsReflectionError(MTLFunction computeFunction, MTLPipelineOption options, out MTLComputePipelineReflection reflection, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewComputePipelineStateWithFunctionOptionsReflectionError, computeFunction.NativePtr, (nuint)options, out nint reflectionPtr, out nint errorPtr);

        reflection = new(reflectionPtr, NativeObjectOwnership.Owned);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLComputePipelineState NewComputePipelineState(MTLFunction computeFunction, MTLPipelineOption options, out MTLComputePipelineReflection reflection, out NSError error)
    {
        return NewComputePipelineStateWithFunctionOptionsReflectionError(computeFunction, options, out reflection, out error);
    }

    public void NewComputePipelineStateWithFunctionCompletionHandler(MTLFunction computeFunction, MTLNewComputePipelineStateCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.NewComputePipelineStateWithFunctionCompletionHandler, computeFunction.NativePtr, completionHandler.NativePtr);
    }

    public void NewComputePipelineState(MTLFunction computeFunction, MTLNewComputePipelineStateCompletionHandler completionHandler)
    {
        NewComputePipelineStateWithFunctionCompletionHandler(computeFunction, completionHandler);
    }

    public void NewComputePipelineStateWithFunctionOptionsCompletionHandler(MTLFunction computeFunction, MTLPipelineOption options, MTLNewComputePipelineStateWithReflectionCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.NewComputePipelineStateWithFunctionOptionsCompletionHandler, computeFunction.NativePtr, (nuint)options, completionHandler.NativePtr);
    }

    public void NewComputePipelineState(MTLFunction computeFunction, MTLPipelineOption options, MTLNewComputePipelineStateWithReflectionCompletionHandler completionHandler)
    {
        NewComputePipelineStateWithFunctionOptionsCompletionHandler(computeFunction, options, completionHandler);
    }

    public MTLComputePipelineState NewComputePipelineStateWithDescriptorOptionsReflectionError(MTLComputePipelineDescriptor descriptor, MTLPipelineOption options, out MTLComputePipelineReflection reflection, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewComputePipelineStateWithDescriptor, descriptor.NativePtr, (nuint)options, out nint reflectionPtr, out nint errorPtr);

        reflection = new(reflectionPtr, NativeObjectOwnership.Owned);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLComputePipelineState NewComputePipelineState(MTLComputePipelineDescriptor descriptor, MTLPipelineOption options, out MTLComputePipelineReflection reflection, out NSError error)
    {
        return NewComputePipelineStateWithDescriptorOptionsReflectionError(descriptor, options, out reflection, out error);
    }

    public void NewComputePipelineStateWithDescriptorOptionsCompletionHandler(MTLComputePipelineDescriptor descriptor, MTLPipelineOption options, MTLNewComputePipelineStateWithReflectionCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.NewComputePipelineStateWithDescriptorOptionsCompletionHandler, descriptor.NativePtr, (nuint)options, completionHandler.NativePtr);
    }

    public void NewComputePipelineState(MTLComputePipelineDescriptor descriptor, MTLPipelineOption options, MTLNewComputePipelineStateWithReflectionCompletionHandler completionHandler)
    {
        NewComputePipelineStateWithDescriptorOptionsCompletionHandler(descriptor, options, completionHandler);
    }

    public MTLFence NewFence()
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

    public nuint MinimumLinearTextureAlignmentForPixelFormat(MTLPixelFormat format)
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, MTLDeviceBindings.MinimumLinearTextureAlignmentForPixelFormat, (nuint)format);
    }

    public nuint MinimumTextureBufferAlignmentForPixelFormat(MTLPixelFormat format)
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, MTLDeviceBindings.MinimumTextureBufferAlignmentForPixelFormat, (nuint)format);
    }

    public MTLRenderPipelineState NewRenderPipelineStateWithTileDescriptorOptionsReflectionError(MTLTileRenderPipelineDescriptor descriptor, MTLPipelineOption options, out MTLRenderPipelineReflection reflection, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewRenderPipelineStateWithTileDescriptor, descriptor.NativePtr, (nuint)options, out nint reflectionPtr, out nint errorPtr);

        reflection = new(reflectionPtr, NativeObjectOwnership.Owned);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTLTileRenderPipelineDescriptor descriptor, MTLPipelineOption options, out MTLRenderPipelineReflection reflection, out NSError error)
    {
        return NewRenderPipelineStateWithTileDescriptorOptionsReflectionError(descriptor, options, out reflection, out error);
    }

    public void NewRenderPipelineStateWithTileDescriptorOptionsCompletionHandler(MTLTileRenderPipelineDescriptor descriptor, MTLPipelineOption options, MTLNewRenderPipelineStateWithReflectionCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.NewRenderPipelineStateWithTileDescriptorOptionsCompletionHandler, descriptor.NativePtr, (nuint)options, completionHandler.NativePtr);
    }

    public void NewRenderPipelineState(MTLTileRenderPipelineDescriptor descriptor, MTLPipelineOption options, MTLNewRenderPipelineStateWithReflectionCompletionHandler completionHandler)
    {
        NewRenderPipelineStateWithTileDescriptorOptionsCompletionHandler(descriptor, options, completionHandler);
    }

    public MTLRenderPipelineState NewRenderPipelineStateWithMeshDescriptorOptionsReflectionError(MTLMeshRenderPipelineDescriptor descriptor, MTLPipelineOption options, out MTLRenderPipelineReflection reflection, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewRenderPipelineStateWithMeshDescriptor, descriptor.NativePtr, (nuint)options, out nint reflectionPtr, out nint errorPtr);

        reflection = new(reflectionPtr, NativeObjectOwnership.Owned);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTLMeshRenderPipelineDescriptor descriptor, MTLPipelineOption options, out MTLRenderPipelineReflection reflection, out NSError error)
    {
        return NewRenderPipelineStateWithMeshDescriptorOptionsReflectionError(descriptor, options, out reflection, out error);
    }

    public void NewRenderPipelineStateWithMeshDescriptorOptionsCompletionHandler(MTLMeshRenderPipelineDescriptor descriptor, MTLPipelineOption options, MTLNewRenderPipelineStateWithReflectionCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.NewRenderPipelineStateWithMeshDescriptorOptionsCompletionHandler, descriptor.NativePtr, (nuint)options, completionHandler.NativePtr);
    }

    public void NewRenderPipelineState(MTLMeshRenderPipelineDescriptor descriptor, MTLPipelineOption options, MTLNewRenderPipelineStateWithReflectionCompletionHandler completionHandler)
    {
        NewRenderPipelineStateWithMeshDescriptorOptionsCompletionHandler(descriptor, options, completionHandler);
    }

    public void GetDefaultSamplePositionsCount(MTLSamplePosition positions, nuint count)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.GetDefaultSamplePositions, positions, count);
    }

    public void GetDefaultSamplePositions(MTLSamplePosition positions, nuint count)
    {
        GetDefaultSamplePositionsCount(positions, count);
    }

    public bool SupportsRasterizationRateMapWithLayerCount(nuint layerCount)
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsRasterizationRateMapWithLayerCount, layerCount);
    }

    public bool SupportsRasterizationRateMap(nuint layerCount)
    {
        return SupportsRasterizationRateMapWithLayerCount(layerCount);
    }

    public MTLRasterizationRateMap NewRasterizationRateMapWithDescriptor(MTLRasterizationRateMapDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewRasterizationRateMapWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRasterizationRateMap NewRasterizationRateMap(MTLRasterizationRateMapDescriptor descriptor)
    {
        return NewRasterizationRateMapWithDescriptor(descriptor);
    }

    public MTLIndirectCommandBuffer NewIndirectCommandBufferWithDescriptorMaxCommandCountOptions(MTLIndirectCommandBufferDescriptor descriptor, nuint maxCount, MTLResourceOptions options)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewIndirectCommandBufferWithDescriptor, descriptor.NativePtr, maxCount, (nuint)options);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLIndirectCommandBuffer NewIndirectCommandBuffer(MTLIndirectCommandBufferDescriptor descriptor, nuint maxCount, MTLResourceOptions options)
    {
        return NewIndirectCommandBufferWithDescriptorMaxCommandCountOptions(descriptor, maxCount, options);
    }

    public MTLEvent NewEvent()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewEvent);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLSharedEvent NewSharedEvent()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewSharedEvent);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLSharedEvent NewSharedEventWithHandle(MTLSharedEventHandle sharedEventHandle)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewSharedEventWithHandle, sharedEventHandle.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLSharedEvent NewSharedEvent(MTLSharedEventHandle sharedEventHandle)
    {
        return NewSharedEventWithHandle(sharedEventHandle);
    }

    /// <summary>
    /// Deprecated: Use newIOFileHandleWithURL:error: instead
    /// </summary>
    [Obsolete("Use newIOFileHandleWithURL:error: instead")]
    public MTLIOFileHandle NewIOHandleWithURLError(NSURL url, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewIOHandleWithURL, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLIOFileHandle NewIOHandle(NSURL url, out NSError error)
    {
        return NewIOHandleWithURLError(url, out error);
    }

    public MTLIOCommandQueue NewIOCommandQueueWithDescriptorError(MTLIOCommandQueueDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewIOCommandQueueWithDescriptor, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLIOCommandQueue NewIOCommandQueue(MTLIOCommandQueueDescriptor descriptor, out NSError error)
    {
        return NewIOCommandQueueWithDescriptorError(descriptor, out error);
    }

    /// <summary>
    /// Deprecated: Use newIOFileHandleWithURL:compressionMethod:error: instead
    /// </summary>
    [Obsolete("Use newIOFileHandleWithURL:compressionMethod:error: instead")]
    public MTLIOFileHandle NewIOHandleWithURLCompressionMethodError(NSURL url, MTLIOCompressionMethod compressionMethod, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewIOHandleWithURLCompressionMethodError, url.NativePtr, (nint)compressionMethod, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLIOFileHandle NewIOHandle(NSURL url, MTLIOCompressionMethod compressionMethod, out NSError error)
    {
        return NewIOHandleWithURLCompressionMethodError(url, compressionMethod, out error);
    }

    public MTLIOFileHandle NewIOFileHandleWithURLError(NSURL url, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewIOFileHandleWithURL, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLIOFileHandle NewIOFileHandle(NSURL url, out NSError error)
    {
        return NewIOFileHandleWithURLError(url, out error);
    }

    public MTLIOFileHandle NewIOFileHandleWithURLCompressionMethodError(NSURL url, MTLIOCompressionMethod compressionMethod, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewIOFileHandleWithURLCompressionMethodError, url.NativePtr, (nint)compressionMethod, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLIOFileHandle NewIOFileHandle(NSURL url, MTLIOCompressionMethod compressionMethod, out NSError error)
    {
        return NewIOFileHandleWithURLCompressionMethodError(url, compressionMethod, out error);
    }

    public MTLSize SparseTileSizeWithTextureTypePixelFormatSampleCount(MTLTextureType textureType, MTLPixelFormat pixelFormat, nuint sampleCount)
    {
        return ObjectiveC.MsgSendMTLSize(NativePtr, MTLDeviceBindings.SparseTileSizeWithTextureType, (nuint)textureType, (nuint)pixelFormat, sampleCount);
    }

    public MTLSize SparseTileSize(MTLTextureType textureType, MTLPixelFormat pixelFormat, nuint sampleCount)
    {
        return SparseTileSizeWithTextureTypePixelFormatSampleCount(textureType, pixelFormat, sampleCount);
    }

    public void ConvertSparsePixelRegionsToTileRegionsWithTileSizeAlignmentModeNumRegions(MTLRegion pixelRegions, MTLRegion tileRegions, MTLSize tileSize, MTLSparseTextureRegionAlignmentMode mode, nuint numRegions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.ConvertSparsePixelRegions, pixelRegions, tileRegions, tileSize, (nuint)mode, numRegions);
    }

    public void ConvertSparsePixelRegions(MTLRegion pixelRegions, MTLRegion tileRegions, MTLSize tileSize, MTLSparseTextureRegionAlignmentMode mode, nuint numRegions)
    {
        ConvertSparsePixelRegionsToTileRegionsWithTileSizeAlignmentModeNumRegions(pixelRegions, tileRegions, tileSize, mode, numRegions);
    }

    public void ConvertSparseTileRegionsToPixelRegionsWithTileSizeNumRegions(MTLRegion tileRegions, MTLRegion pixelRegions, MTLSize tileSize, nuint numRegions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.ConvertSparseTileRegions, tileRegions, pixelRegions, tileSize, numRegions);
    }

    public void ConvertSparseTileRegions(MTLRegion tileRegions, MTLRegion pixelRegions, MTLSize tileSize, nuint numRegions)
    {
        ConvertSparseTileRegionsToPixelRegionsWithTileSizeNumRegions(tileRegions, pixelRegions, tileSize, numRegions);
    }

    public nuint SparseTileSizeInBytesForSparsePageSize(MTLSparsePageSize sparsePageSize)
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, MTLDeviceBindings.SparseTileSizeInBytesForSparsePageSize, (nint)sparsePageSize);
    }

    public MTLSize SparseTileSizeWithTextureTypePixelFormatSampleCountSparsePageSize(MTLTextureType textureType, MTLPixelFormat pixelFormat, nuint sampleCount, MTLSparsePageSize sparsePageSize)
    {
        return ObjectiveC.MsgSendMTLSize(NativePtr, MTLDeviceBindings.SparseTileSizeWithTextureTypePixelFormatSampleCountSparsePageSize, (nuint)textureType, (nuint)pixelFormat, sampleCount, (nint)sparsePageSize);
    }

    public MTLSize SparseTileSize(MTLTextureType textureType, MTLPixelFormat pixelFormat, nuint sampleCount, MTLSparsePageSize sparsePageSize)
    {
        return SparseTileSizeWithTextureTypePixelFormatSampleCountSparsePageSize(textureType, pixelFormat, sampleCount, sparsePageSize);
    }

    public MTLCounterSampleBuffer NewCounterSampleBufferWithDescriptorError(MTLCounterSampleBufferDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewCounterSampleBufferWithDescriptor, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLCounterSampleBuffer NewCounterSampleBuffer(MTLCounterSampleBufferDescriptor descriptor, out NSError error)
    {
        return NewCounterSampleBufferWithDescriptorError(descriptor, out error);
    }

    public void SampleTimestampsGpuTimestamp(out ulong cpuTimestamp, out ulong gpuTimestamp)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.SampleTimestamps, out cpuTimestamp, out gpuTimestamp);
    }

    public void SampleTimestamps(out ulong cpuTimestamp, out ulong gpuTimestamp)
    {
        SampleTimestampsGpuTimestamp(out cpuTimestamp, out gpuTimestamp);
    }

    public MTLArgumentEncoder NewArgumentEncoderWithBufferBinding(MTLBufferBinding bufferBinding)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewArgumentEncoderWithBufferBinding, bufferBinding.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLArgumentEncoder NewArgumentEncoder(MTLBufferBinding bufferBinding)
    {
        return NewArgumentEncoderWithBufferBinding(bufferBinding);
    }

    public bool SupportsCounterSampling(MTLCounterSamplingPoint samplingPoint)
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsCounterSampling, (nuint)samplingPoint);
    }

    public bool SupportsVertexAmplificationCount(nuint count)
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsVertexAmplificationCount, count);
    }

    public MTLDynamicLibrary NewDynamicLibraryError(MTLLibrary library, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewDynamicLibrary, library.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLDynamicLibrary NewDynamicLibrary(MTLLibrary library, out NSError error)
    {
        return NewDynamicLibraryError(library, out error);
    }

    public MTLDynamicLibrary NewDynamicLibraryWithURLError(NSURL url, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewDynamicLibraryWithURL, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLDynamicLibrary NewDynamicLibrary(NSURL url, out NSError error)
    {
        return NewDynamicLibraryWithURLError(url, out error);
    }

    public MTLBinaryArchive NewBinaryArchiveWithDescriptorError(MTLBinaryArchiveDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewBinaryArchiveWithDescriptor, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLBinaryArchive NewBinaryArchive(MTLBinaryArchiveDescriptor descriptor, out NSError error)
    {
        return NewBinaryArchiveWithDescriptorError(descriptor, out error);
    }

    public MTLAccelerationStructureSizes AccelerationStructureSizesWithDescriptor(MTLAccelerationStructureDescriptor descriptor)
    {
        return ObjectiveC.MsgSendMTLAccelerationStructureSizes(NativePtr, MTLDeviceBindings.AccelerationStructureSizesWithDescriptor, descriptor.NativePtr);
    }

    public MTLAccelerationStructureSizes AccelerationStructureSizes(MTLAccelerationStructureDescriptor descriptor)
    {
        return AccelerationStructureSizesWithDescriptor(descriptor);
    }

    public MTLAccelerationStructure NewAccelerationStructureWithSize(nuint size)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewAccelerationStructureWithSize, size);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLAccelerationStructure NewAccelerationStructure(nuint size)
    {
        return NewAccelerationStructureWithSize(size);
    }

    public MTLAccelerationStructure NewAccelerationStructureWithDescriptor(MTLAccelerationStructureDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewAccelerationStructureWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLAccelerationStructure NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor)
    {
        return NewAccelerationStructureWithDescriptor(descriptor);
    }

    public MTLSizeAndAlign HeapAccelerationStructureSizeAndAlignWithSize(nuint size)
    {
        return ObjectiveC.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceBindings.HeapAccelerationStructureSizeAndAlignWithSize, size);
    }

    public MTLSizeAndAlign HeapAccelerationStructureSizeAndAlign(nuint size)
    {
        return HeapAccelerationStructureSizeAndAlignWithSize(size);
    }

    public MTLSizeAndAlign HeapAccelerationStructureSizeAndAlignWithDescriptor(MTLAccelerationStructureDescriptor descriptor)
    {
        return ObjectiveC.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceBindings.HeapAccelerationStructureSizeAndAlignWithDescriptor, descriptor.NativePtr);
    }

    public MTLSizeAndAlign HeapAccelerationStructureSizeAndAlign(MTLAccelerationStructureDescriptor descriptor)
    {
        return HeapAccelerationStructureSizeAndAlignWithDescriptor(descriptor);
    }

    public MTLResidencySet NewResidencySetWithDescriptorError(MTLResidencySetDescriptor desc, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewResidencySetWithDescriptor, desc.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLResidencySet NewResidencySet(MTLResidencySetDescriptor desc, out NSError error)
    {
        return NewResidencySetWithDescriptorError(desc, out error);
    }

    public MTLSizeAndAlign TensorSizeAndAlignWithDescriptor(MTLTensorDescriptor descriptor)
    {
        return ObjectiveC.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceBindings.TensorSizeAndAlignWithDescriptor, descriptor.NativePtr);
    }

    public MTLSizeAndAlign TensorSizeAndAlign(MTLTensorDescriptor descriptor)
    {
        return TensorSizeAndAlignWithDescriptor(descriptor);
    }

    public MTLTensor NewTensorWithDescriptorError(MTLTensorDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewTensorWithDescriptor, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLTensor NewTensor(MTLTensorDescriptor descriptor, out NSError error)
    {
        return NewTensorWithDescriptorError(descriptor, out error);
    }

    public MTLFunctionHandle FunctionHandleWithFunction(MTLFunction function)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.FunctionHandleWithFunction, function.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLFunctionHandle FunctionHandle(MTLFunction function)
    {
        return FunctionHandleWithFunction(function);
    }

    public MTL4CommandAllocator NewCommandAllocator()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewCommandAllocator);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CommandAllocator NewCommandAllocatorWithDescriptorError(MTL4CommandAllocatorDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewCommandAllocatorWithDescriptor, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CommandAllocator NewCommandAllocator(MTL4CommandAllocatorDescriptor descriptor, out NSError error)
    {
        return NewCommandAllocatorWithDescriptorError(descriptor, out error);
    }

    public MTL4CommandQueue NewMTL4CommandQueue()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewMTL4CommandQueue);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CommandQueue NewMTL4CommandQueueWithDescriptorError(MTL4CommandQueueDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewMTL4CommandQueueWithDescriptor, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CommandQueue NewMTL4CommandQueue(MTL4CommandQueueDescriptor descriptor, out NSError error)
    {
        return NewMTL4CommandQueueWithDescriptorError(descriptor, out error);
    }

    public MTL4CommandBuffer NewCommandBuffer()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewCommandBuffer);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4ArgumentTable NewArgumentTableWithDescriptorError(MTL4ArgumentTableDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewArgumentTableWithDescriptor, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4ArgumentTable NewArgumentTable(MTL4ArgumentTableDescriptor descriptor, out NSError error)
    {
        return NewArgumentTableWithDescriptorError(descriptor, out error);
    }

    public MTLTextureViewPool NewTextureViewPoolWithDescriptorError(MTLResourceViewPoolDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewTextureViewPoolWithDescriptor, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLTextureViewPool NewTextureViewPool(MTLResourceViewPoolDescriptor descriptor, out NSError error)
    {
        return NewTextureViewPoolWithDescriptorError(descriptor, out error);
    }

    public MTL4Compiler NewCompilerWithDescriptorError(MTL4CompilerDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewCompilerWithDescriptor, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4Compiler NewCompiler(MTL4CompilerDescriptor descriptor, out NSError error)
    {
        return NewCompilerWithDescriptorError(descriptor, out error);
    }

    public MTL4Archive NewArchiveWithURLError(NSURL url, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewArchiveWithURL, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4Archive NewArchive(NSURL url, out NSError error)
    {
        return NewArchiveWithURLError(url, out error);
    }

    public MTL4PipelineDataSetSerializer NewPipelineDataSetSerializerWithDescriptor(MTL4PipelineDataSetSerializerDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewPipelineDataSetSerializerWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4PipelineDataSetSerializer NewPipelineDataSetSerializer(MTL4PipelineDataSetSerializerDescriptor descriptor)
    {
        return NewPipelineDataSetSerializerWithDescriptor(descriptor);
    }

    public MTLBuffer NewBufferWithLengthOptionsPlacementSparsePageSize(nuint length, MTLResourceOptions options, MTLSparsePageSize placementSparsePageSize)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewBufferWithLengthOptionsPlacementSparsePageSize, length, (nuint)options, (nint)placementSparsePageSize);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLBuffer NewBuffer(nuint length, MTLResourceOptions options, MTLSparsePageSize placementSparsePageSize)
    {
        return NewBufferWithLengthOptionsPlacementSparsePageSize(length, options, placementSparsePageSize);
    }

    public MTL4CounterHeap NewCounterHeapWithDescriptorError(MTL4CounterHeapDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewCounterHeapWithDescriptor, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CounterHeap NewCounterHeap(MTL4CounterHeapDescriptor descriptor, out NSError error)
    {
        return NewCounterHeapWithDescriptorError(descriptor, out error);
    }

    public nuint SizeOfCounterHeapEntry(MTL4CounterHeapType type)
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, MTLDeviceBindings.SizeOfCounterHeapEntry, (nint)type);
    }

    public MTLFunctionHandle FunctionHandleWithBinaryFunction(MTL4BinaryFunction function)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.FunctionHandleWithBinaryFunction, function.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLFunctionHandle FunctionHandle(MTL4BinaryFunction function)
    {
        return FunctionHandleWithBinaryFunction(function);
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

    public static readonly Selector ConvertSparsePixelRegions = "convertSparsePixelRegions:toTileRegions:withTileSize:alignmentMode:numRegions:";

    public static readonly Selector ConvertSparseTileRegions = "convertSparseTileRegions:toPixelRegions:withTileSize:numRegions:";

    public static readonly Selector CounterSets = "counterSets";

    public static readonly Selector CurrentAllocatedSize = "currentAllocatedSize";

    public static readonly Selector FunctionHandleWithBinaryFunction = "functionHandleWithBinaryFunction:";

    public static readonly Selector FunctionHandleWithFunction = "functionHandleWithFunction:";

    public static readonly Selector GetDefaultSamplePositions = "getDefaultSamplePositions:count:";

    public static readonly Selector HasUnifiedMemory = "hasUnifiedMemory";

    public static readonly Selector HeapAccelerationStructureSizeAndAlignWithDescriptor = "heapAccelerationStructureSizeAndAlignWithDescriptor:";

    public static readonly Selector HeapAccelerationStructureSizeAndAlignWithSize = "heapAccelerationStructureSizeAndAlignWithSize:";

    public static readonly Selector HeapBufferSizeAndAlignWithLength = "heapBufferSizeAndAlignWithLength:options:";

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

    public static readonly Selector NewArchiveWithURL = "newArchiveWithURL:error:";

    public static readonly Selector NewArgumentEncoderWithBufferBinding = "newArgumentEncoderWithBufferBinding:";

    public static readonly Selector NewArgumentTableWithDescriptor = "newArgumentTableWithDescriptor:error:";

    public static readonly Selector NewBinaryArchiveWithDescriptor = "newBinaryArchiveWithDescriptor:error:";

    public static readonly Selector NewBufferWithBytes = "newBufferWithBytes:length:options:";

    public static readonly Selector NewBufferWithLength = "newBufferWithLength:options:";

    public static readonly Selector NewBufferWithLengthOptionsPlacementSparsePageSize = "newBufferWithLength:options:placementSparsePageSize:";

    public static readonly Selector NewCommandAllocator = "newCommandAllocator";

    public static readonly Selector NewCommandAllocatorWithDescriptor = "newCommandAllocatorWithDescriptor:error:";

    public static readonly Selector NewCommandBuffer = "newCommandBuffer";

    public static readonly Selector NewCommandQueue = "newCommandQueue";

    public static readonly Selector NewCommandQueueWithDescriptor = "newCommandQueueWithDescriptor:";

    public static readonly Selector NewCommandQueueWithMaxCommandBufferCount = "newCommandQueueWithMaxCommandBufferCount:";

    public static readonly Selector NewCompilerWithDescriptor = "newCompilerWithDescriptor:error:";

    public static readonly Selector NewComputePipelineStateWithDescriptor = "newComputePipelineStateWithDescriptor:options:reflection:error:";

    public static readonly Selector NewComputePipelineStateWithDescriptorOptionsCompletionHandler = "newComputePipelineStateWithDescriptor:options:completionHandler:";

    public static readonly Selector NewComputePipelineStateWithFunction = "newComputePipelineStateWithFunction:error:";

    public static readonly Selector NewComputePipelineStateWithFunctionCompletionHandler = "newComputePipelineStateWithFunction:completionHandler:";

    public static readonly Selector NewComputePipelineStateWithFunctionOptionsCompletionHandler = "newComputePipelineStateWithFunction:options:completionHandler:";

    public static readonly Selector NewComputePipelineStateWithFunctionOptionsReflectionError = "newComputePipelineStateWithFunction:options:reflection:error:";

    public static readonly Selector NewCounterHeapWithDescriptor = "newCounterHeapWithDescriptor:error:";

    public static readonly Selector NewCounterSampleBufferWithDescriptor = "newCounterSampleBufferWithDescriptor:error:";

    public static readonly Selector NewDefaultLibrary = "newDefaultLibrary";

    public static readonly Selector NewDefaultLibraryWithBundle = "newDefaultLibraryWithBundle:error:";

    public static readonly Selector NewDepthStencilStateWithDescriptor = "newDepthStencilStateWithDescriptor:";

    public static readonly Selector NewDynamicLibrary = "newDynamicLibrary:error:";

    public static readonly Selector NewDynamicLibraryWithURL = "newDynamicLibraryWithURL:error:";

    public static readonly Selector NewEvent = "newEvent";

    public static readonly Selector NewFence = "newFence";

    public static readonly Selector NewHeapWithDescriptor = "newHeapWithDescriptor:";

    public static readonly Selector NewIndirectCommandBufferWithDescriptor = "newIndirectCommandBufferWithDescriptor:maxCommandCount:options:";

    public static readonly Selector NewIOCommandQueueWithDescriptor = "newIOCommandQueueWithDescriptor:error:";

    public static readonly Selector NewIOFileHandleWithURL = "newIOFileHandleWithURL:error:";

    public static readonly Selector NewIOFileHandleWithURLCompressionMethodError = "newIOFileHandleWithURL:compressionMethod:error:";

    public static readonly Selector NewIOHandleWithURL = "newIOHandleWithURL:error:";

    public static readonly Selector NewIOHandleWithURLCompressionMethodError = "newIOHandleWithURL:compressionMethod:error:";

    public static readonly Selector NewLibraryWithData = "newLibraryWithData:error:";

    public static readonly Selector NewLibraryWithFile = "newLibraryWithFile:error:";

    public static readonly Selector NewLibraryWithSource = "newLibraryWithSource:options:error:";

    public static readonly Selector NewLibraryWithSourceOptionsCompletionHandler = "newLibraryWithSource:options:completionHandler:";

    public static readonly Selector NewLibraryWithStitchedDescriptor = "newLibraryWithStitchedDescriptor:error:";

    public static readonly Selector NewLibraryWithStitchedDescriptorCompletionHandler = "newLibraryWithStitchedDescriptor:completionHandler:";

    public static readonly Selector NewLibraryWithURL = "newLibraryWithURL:error:";

    public static readonly Selector NewLogStateWithDescriptor = "newLogStateWithDescriptor:error:";

    public static readonly Selector NewMTL4CommandQueue = "newMTL4CommandQueue";

    public static readonly Selector NewMTL4CommandQueueWithDescriptor = "newMTL4CommandQueueWithDescriptor:error:";

    public static readonly Selector NewPipelineDataSetSerializerWithDescriptor = "newPipelineDataSetSerializerWithDescriptor:";

    public static readonly Selector NewRasterizationRateMapWithDescriptor = "newRasterizationRateMapWithDescriptor:";

    public static readonly Selector NewRenderPipelineStateWithDescriptor = "newRenderPipelineStateWithDescriptor:error:";

    public static readonly Selector NewRenderPipelineStateWithDescriptorCompletionHandler = "newRenderPipelineStateWithDescriptor:completionHandler:";

    public static readonly Selector NewRenderPipelineStateWithDescriptorOptionsCompletionHandler = "newRenderPipelineStateWithDescriptor:options:completionHandler:";

    public static readonly Selector NewRenderPipelineStateWithDescriptorOptionsReflectionError = "newRenderPipelineStateWithDescriptor:options:reflection:error:";

    public static readonly Selector NewRenderPipelineStateWithMeshDescriptor = "newRenderPipelineStateWithMeshDescriptor:options:reflection:error:";

    public static readonly Selector NewRenderPipelineStateWithMeshDescriptorOptionsCompletionHandler = "newRenderPipelineStateWithMeshDescriptor:options:completionHandler:";

    public static readonly Selector NewRenderPipelineStateWithTileDescriptor = "newRenderPipelineStateWithTileDescriptor:options:reflection:error:";

    public static readonly Selector NewRenderPipelineStateWithTileDescriptorOptionsCompletionHandler = "newRenderPipelineStateWithTileDescriptor:options:completionHandler:";

    public static readonly Selector NewResidencySetWithDescriptor = "newResidencySetWithDescriptor:error:";

    public static readonly Selector NewSamplerStateWithDescriptor = "newSamplerStateWithDescriptor:";

    public static readonly Selector NewSharedEvent = "newSharedEvent";

    public static readonly Selector NewSharedEventWithHandle = "newSharedEventWithHandle:";

    public static readonly Selector NewSharedTextureWithDescriptor = "newSharedTextureWithDescriptor:";

    public static readonly Selector NewSharedTextureWithHandle = "newSharedTextureWithHandle:";

    public static readonly Selector NewTensorWithDescriptor = "newTensorWithDescriptor:error:";

    public static readonly Selector NewTextureViewPoolWithDescriptor = "newTextureViewPoolWithDescriptor:error:";

    public static readonly Selector NewTextureWithDescriptor = "newTextureWithDescriptor:";

    public static readonly Selector NewTextureWithDescriptorIosurfacePlane = "newTextureWithDescriptor:iosurface:plane:";

    public static readonly Selector PeerCount = "peerCount";

    public static readonly Selector PeerGroupID = "peerGroupID";

    public static readonly Selector PeerIndex = "peerIndex";

    public static readonly Selector QueryTimestampFrequency = "queryTimestampFrequency";

    public static readonly Selector ReadWriteTextureSupport = "readWriteTextureSupport";

    public static readonly Selector RecommendedMaxWorkingSetSize = "recommendedMaxWorkingSetSize";

    public static readonly Selector RegistryID = "registryID";

    public static readonly Selector SampleTimestamps = "sampleTimestamps:gpuTimestamp:";

    public static readonly Selector SetShouldMaximizeConcurrentCompilation = "setShouldMaximizeConcurrentCompilation:";

    public static readonly Selector ShouldMaximizeConcurrentCompilation = "shouldMaximizeConcurrentCompilation";

    public static readonly Selector SizeOfCounterHeapEntry = "sizeOfCounterHeapEntry:";

    public static readonly Selector SparseTileSizeInBytes = "sparseTileSizeInBytes";

    public static readonly Selector SparseTileSizeInBytesForSparsePageSize = "sparseTileSizeInBytesForSparsePageSize:";

    public static readonly Selector SparseTileSizeWithTextureType = "sparseTileSizeWithTextureType:pixelFormat:sampleCount:";

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
