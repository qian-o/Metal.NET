using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// The main Metal interface to a GPU that apps use to draw graphics and run computations in parallel.
/// </summary>
public partial class MTLDevice(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLDevice>
{
    #region INativeObject
    public static new MTLDevice Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLDevice New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Instance Properties - Properties

    /// <summary>
    /// The maximum number of concurrent compilation tasks the device is running.
    /// </summary>
    public nuint MaximumConcurrentCompilationTaskCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLDeviceBindings.MaximumConcurrentCompilationTaskCount);
    }

    /// <summary>
    /// A Boolean value that indicates whether the device uses additional CPU threads for compilation tasks.
    /// </summary>
    public Bool8 ShouldMaximizeConcurrentCompilation
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.ShouldMaximizeConcurrentCompilation);
        set => ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.SetShouldMaximizeConcurrentCompilation, value);
    }
    #endregion

    #region Checking compute support - Properties

    /// <summary>
    /// The maximum threadgroup memory available to a compute kernel, in bytes.
    /// </summary>
    public nuint MaxThreadgroupMemoryLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLDeviceBindings.MaxThreadgroupMemoryLength);
    }

    /// <summary>
    /// The maximum number of threads along each dimension of a threadgroup.
    /// </summary>
    public MTLSize MaxThreadsPerThreadgroup
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLDeviceBindings.MaxThreadsPerThreadgroup);
    }
    #endregion

    #region Checking render support - Properties

    /// <summary>
    /// A Boolean value that indicates whether the GPU device supports ray tracing.
    /// </summary>
    public Bool8 SupportsRaytracing
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsRaytracing);
    }

    /// <summary>
    /// A Boolean value that indicates whether the GPU device supports motion blur for ray tracing.
    /// </summary>
    public Bool8 SupportsPrimitiveMotionBlur
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsPrimitiveMotionBlur);
    }

    /// <summary>
    /// A Boolean value that indicates whether you can call ray-tracing functions from a vertex or fragment shader.
    /// </summary>
    public Bool8 SupportsRaytracingFromRender
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsRaytracingFromRender);
    }

    /// <summary>
    /// A Boolean value that indicates whether the GPU can allocate 32-bit integer texture formats and resolve to 32-bit floating-point texture formats.
    /// </summary>
    public Bool8 Supports32BitMSAA
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.Supports32BitMSAA);
    }

    /// <summary>
    /// A Boolean value that indicates whether the GPU can compute multiple interpolations of a fragment function’s input.
    /// </summary>
    public Bool8 SupportsPullModelInterpolation
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsPullModelInterpolation);
    }

    /// <summary>
    /// A Boolean value that indicates whether the GPU supports barycentric coordinates.
    /// </summary>
    public Bool8 SupportsShaderBarycentricCoordinates
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsShaderBarycentricCoordinates);
    }

    /// <summary>
    /// A Boolean value that indicates whether the GPU supports programmable sample positions.
    /// </summary>
    public Bool8 AreProgrammableSamplePositionsSupported
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.AreProgrammableSamplePositionsSupported);
    }

    /// <summary>
    /// A Boolean value that indicates whether the GPU supports raster order groups.
    /// </summary>
    public Bool8 AreRasterOrderGroupsSupported
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.AreRasterOrderGroupsSupported);
    }

    /// <summary>
    /// A Boolean value that indicates whether the GPU supports barycentric coordinates.
    /// </summary>
    [Obsolete("Use supportsShaderBarycentricCoordinates instead.")]
    public Bool8 AreBarycentricCoordsSupported
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.AreBarycentricCoordsSupported);
    }
    #endregion

    #region Checking texture and sampler support - Properties

    /// <summary>
    /// A Boolean value that indicates whether the GPU can filter a texture with a 32-bit floating-point format.
    /// </summary>
    public Bool8 Supports32BitFloatFiltering
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.Supports32BitFloatFiltering);
    }

    /// <summary>
    /// A Boolean value that indicates whether you can use textures that use BC compression.
    /// </summary>
    public Bool8 SupportsBCTextureCompression
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsBCTextureCompression);
    }

    /// <summary>
    /// A Boolean value that indicates whether a device supports a packed depth-and-stencil pixel format.
    /// </summary>
    public Bool8 IsDepth24Stencil8PixelFormatSupported
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.IsDepth24Stencil8PixelFormatSupported);
    }

    /// <summary>
    /// A Boolean value that indicates whether you can query the texture level of detail from within a shader.
    /// </summary>
    public Bool8 SupportsQueryTextureLOD
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsQueryTextureLOD);
    }

    /// <summary>
    /// The GPU device’s texture support tier.
    /// </summary>
    public MTLReadWriteTextureTier ReadWriteTextureSupport
    {
        get => (MTLReadWriteTextureTier)ObjectiveC.MsgSendULong(NativePtr, MTLDeviceBindings.ReadWriteTextureSupport);
    }
    #endregion

    #region Checking function pointer support - Properties

    /// <summary>
    /// A Boolean value that indicates whether the device supports function pointers in compute kernel functions.
    /// </summary>
    public Bool8 SupportsFunctionPointers
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsFunctionPointers);
    }

    /// <summary>
    /// A Boolean value that indicates whether the device supports function pointers in render functions.
    /// </summary>
    public Bool8 SupportsFunctionPointersFromRender
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsFunctionPointersFromRender);
    }
    #endregion

    #region Checking a GPU device’s memory - Properties

    /// <summary>
    /// The total amount of memory, in bytes, the GPU device is using for all of its resources.
    /// </summary>
    public nuint CurrentAllocatedSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLDeviceBindings.CurrentAllocatedSize);
    }

    /// <summary>
    /// An approximation of how much memory, in bytes, this GPU device can allocate without affecting its runtime performance.
    /// </summary>
    public ulong RecommendedMaxWorkingSetSize
    {
        get => ObjectiveC.MsgSendULong(NativePtr, MTLDeviceBindings.RecommendedMaxWorkingSetSize);
    }

    /// <summary>
    /// A Boolean value that indicates whether the GPU shares all of its memory with the CPU.
    /// </summary>
    public Bool8 HasUnifiedMemory
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.HasUnifiedMemory);
    }

    /// <summary>
    /// The highest theoretical rate, in bytes per second, the system can copy between system memory and the GPU’s dedicated memory (VRAM).
    /// </summary>
    public ulong MaxTransferRate
    {
        get => ObjectiveC.MsgSendULong(NativePtr, MTLDeviceBindings.MaxTransferRate);
    }
    #endregion

    #region Sampling a GPU device’s counters - Properties

    /// <summary>
    /// The counter sets supported by the device object.
    /// </summary>
    public MTLCounterSet[] CounterSets
    {
        get => GetArrayProperty<MTLCounterSet>(MTLDeviceBindings.CounterSets);
    }
    #endregion

    #region Identifying a GPU device - Properties

    /// <summary>
    /// The full name of the GPU device.
    /// </summary>
    public NSString Name
    {
        get => GetProperty(ref field, MTLDeviceBindings.Name);
    }

    /// <summary>
    /// The architectural details of the GPU device.
    /// </summary>
    public MTLArchitecture Architecture
    {
        get => GetProperty(ref field, MTLDeviceBindings.Architecture);
    }

    /// <summary>
    /// The GPU device’s registry identifier.
    /// </summary>
    public ulong RegistryID
    {
        get => ObjectiveC.MsgSendULong(NativePtr, MTLDeviceBindings.RegistryID);
    }

    /// <summary>
    /// The physical location of the GPU relative to the system.
    /// </summary>
    public MTLDeviceLocation Location
    {
        get => (MTLDeviceLocation)ObjectiveC.MsgSendULong(NativePtr, MTLDeviceBindings.Location);
    }

    /// <summary>
    /// A specific GPU position based on its general location.
    /// </summary>
    public nuint LocationNumber
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLDeviceBindings.LocationNumber);
    }

    /// <summary>
    /// A Boolean value that indicates whether the GPU lowers its performance to conserve energy.
    /// </summary>
    public Bool8 IsLowPower
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.IsLowPower);
    }

    /// <summary>
    /// A Boolean value that indicates whether the GPU is removable.
    /// </summary>
    public Bool8 IsRemovable
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.IsRemovable);
    }

    /// <summary>
    /// A Boolean value that indicates whether a GPU device doesn’t have a connection to a display.
    /// </summary>
    public Bool8 IsHeadless
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.IsHeadless);
    }

    /// <summary>
    /// The peer group ID the GPU belongs to, if applicable.
    /// </summary>
    public ulong PeerGroupID
    {
        get => ObjectiveC.MsgSendULong(NativePtr, MTLDeviceBindings.PeerGroupID);
    }

    /// <summary>
    /// The total number of GPUs in the peer group, if applicable.
    /// </summary>
    public uint PeerCount
    {
        get => ObjectiveC.MsgSendUInt(NativePtr, MTLDeviceBindings.PeerCount);
    }

    /// <summary>
    /// The unique identifier for a GPU in a peer group.
    /// </summary>
    public uint PeerIndex
    {
        get => ObjectiveC.MsgSendUInt(NativePtr, MTLDeviceBindings.PeerIndex);
    }
    #endregion

    #region Creating buffers - Properties

    /// <summary>
    /// The largest amount of memory, in bytes, that a GPU device can allocate to a buffer instance.
    /// </summary>
    public nuint MaxBufferLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLDeviceBindings.MaxBufferLength);
    }
    #endregion

    #region Working with sparse textures - Properties

    /// <summary>
    /// Returns the size, in bytes, of a sparse tile the GPU device creates with a specific page size.
    /// </summary>
    public nuint SparseTileSizeInBytes
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLDeviceBindings.SparseTileSizeInBytes);
    }
    #endregion

    #region Creating argument buffer encoders - Properties

    /// <summary>
    /// Returns the GPU device’s support tier for argument buffers.
    /// </summary>
    public MTLArgumentBuffersTier ArgumentBuffersSupport
    {
        get => (MTLArgumentBuffersTier)ObjectiveC.MsgSendULong(NativePtr, MTLDeviceBindings.ArgumentBuffersSupport);
    }

    /// <summary>
    /// The maximum number of unique argument buffer samplers per app.
    /// </summary>
    public nuint MaxArgumentBufferSamplerCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLDeviceBindings.MaxArgumentBufferSamplerCount);
    }
    #endregion

    #region Creating dynamic shader libraries - Properties

    /// <summary>
    /// A Boolean value that indicates whether the GPU device can create and use dynamic libraries in compute pipelines.
    /// </summary>
    public Bool8 SupportsDynamicLibraries
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsDynamicLibraries);
    }

    /// <summary>
    /// A Boolean value that indicates whether the GPU device can create and use dynamic libraries in render pipelines.
    /// </summary>
    public Bool8 SupportsRenderDynamicLibraries
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsRenderDynamicLibraries);
    }
    #endregion

    /// <summary>
    /// Deprecated: please use areBarycentricCoordsSupported instead
    /// </summary>
    [Obsolete("please use areBarycentricCoordsSupported instead")]
    public Bool8 BarycentricCoordsSupported
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.BarycentricCoordsSupported);
    }

    /// <summary>
    /// Deprecated: please use isDepth24Stencil8PixelFormatSupported instead
    /// </summary>
    [Obsolete("please use isDepth24Stencil8PixelFormatSupported instead")]
    public Bool8 Depth24Stencil8PixelFormatSupported
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.Depth24Stencil8PixelFormatSupported);
    }

    /// <summary>
    /// Deprecated: please use isHeadless instead
    /// </summary>
    [Obsolete("please use isHeadless instead")]
    public Bool8 Headless
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.Headless);
    }

    /// <summary>
    /// Deprecated: please use isLowPower instead
    /// </summary>
    [Obsolete("please use isLowPower instead")]
    public Bool8 LowPower
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.LowPower);
    }

    /// <summary>
    /// Deprecated: please use areProgrammableSamplePositionsSupported instead
    /// </summary>
    [Obsolete("please use areProgrammableSamplePositionsSupported instead")]
    public Bool8 ProgrammableSamplePositionsSupported
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.ProgrammableSamplePositionsSupported);
    }

    /// <summary>
    /// Deprecated: please use areRasterOrderGroupsSupported instead
    /// </summary>
    [Obsolete("please use areRasterOrderGroupsSupported instead")]
    public Bool8 RasterOrderGroupsSupported
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.RasterOrderGroupsSupported);
    }

    /// <summary>
    /// Deprecated: please use isRemovable instead
    /// </summary>
    [Obsolete("please use isRemovable instead")]
    public Bool8 Removable
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.Removable);
    }

    #region Instance Methods - Methods

    public MTLFunctionHandle FunctionHandle(MTLFunction function)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.FunctionHandle, function.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLFunctionHandle FunctionHandle(MTL4BinaryFunction function)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.FunctionHandleWithBinaryFunction, function.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a new archive from data available at an NSURL address.
    /// </summary>
    public MTL4Archive NewArchive(NSURL url, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewArchive, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a new argument table from an argument table descriptor.
    /// </summary>
    public MTL4ArgumentTable NewArgumentTable(MTL4ArgumentTableDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewArgumentTable, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a new placement sparse buffer of a specific length.
    /// </summary>
    public MTLBuffer NewBuffer(nuint length, MTLResourceOptions options, MTLSparsePageSize placementSparsePageSize)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewBuffer, length, (nuint)options, (nint)placementSparsePageSize);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a new placement sparse buffer of a specific length.
    /// </summary>
    public MTLBuffer NewBuffer(nint pointer, nuint length, MTLResourceOptions options, MTLDeallocator deallocator)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewBuffer, pointer, length, (nuint)options, deallocator.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a new placement sparse buffer of a specific length.
    /// </summary>
    public MTLBuffer NewBuffer(nint pointer, nuint length, MTLResourceOptions options)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewBufferWithByteslengthoptions, pointer, length, (nuint)options);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a new placement sparse buffer of a specific length.
    /// </summary>
    public MTLBuffer NewBuffer(nuint length, MTLResourceOptions options)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewBufferWithLengthoptions, length, (nuint)options);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a new command allocator.
    /// </summary>
    public MTL4CommandAllocator NewCommandAllocatorWithDescriptor(MTL4CommandAllocatorDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewCommandAllocatorWithDescriptorerror, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a new command allocator.
    /// </summary>
    public MTL4CommandAllocator NewCommandAllocator()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewCommandAllocator);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a new command buffer.
    /// </summary>
    public MTL4CommandBuffer NewCommandBuffer()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewCommandBuffer);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a command queue with the provided configuration.
    /// </summary>
    public MTLCommandQueue NewCommandQueueWithDescriptor(MTLCommandQueueDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewCommandQueueWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a command queue with the provided configuration.
    /// </summary>
    public MTLCommandQueue NewCommandQueueWithMaxCommandBufferCount(nuint maxCommandBufferCount)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewCommandQueueWithMaxCommandBufferCount, maxCommandBufferCount);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a command queue with the provided configuration.
    /// </summary>
    public MTLCommandQueue NewCommandQueue()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewCommandQueue);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a new compiler from a compiler descriptor.
    /// </summary>
    public MTL4Compiler NewCompiler(MTL4CompilerDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewCompiler, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a new counter heap configured from a counter heap descriptor.
    /// </summary>
    public MTL4CounterHeap NewCounterHeap(MTL4CounterHeapDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewCounterHeap, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a shader log state with the provided configuration.
    /// </summary>
    public MTLLogState NewLogState(MTLLogStateDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewLogState, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a new command queue.
    /// </summary>
    public MTL4CommandQueue NewMTL4CommandQueue()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewMTL4CommandQueue);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a new command queue.
    /// </summary>
    public MTL4CommandQueue NewMTL4CommandQueueWithDescriptor(MTL4CommandQueueDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewMTL4CommandQueueWithDescriptorerror, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a new pipeline data set serializer instance from a descriptor.
    /// </summary>
    public MTL4PipelineDataSetSerializer NewPipelineDataSetSerializer(MTL4PipelineDataSetSerializerDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewPipelineDataSetSerializer, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a tensor by allocating new memory.
    /// </summary>
    public MTLSizeAndAlign TensorSizeAndAlign(MTLTensorDescriptor descriptor)
    {
        return ObjectiveC.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceBindings.TensorSizeAndAlign, descriptor.NativePtr);
    }

    /// <summary>
    /// Creates a new texture view pool from a resource view pool descriptor.
    /// </summary>
    public MTLTextureViewPool NewTextureViewPool(MTLResourceViewPoolDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewTextureViewPool, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Queries the frequency of the GPU timestamp in ticks per second.
    /// </summary>
    public ulong QueryTimestampFrequency()
    {
        return ObjectiveC.MsgSendULong(NativePtr, MTLDeviceBindings.QueryTimestampFrequency);
    }

    /// <summary>
    /// Returns the size, in bytes, of each entry in a counter heap of a specific counter heap type when your app resolves it into a usable format.
    /// </summary>
    public nuint SizeOfCounterHeapEntry(MTL4CounterHeapType type)
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, MTLDeviceBindings.SizeOfCounterHeapEntry, (nint)type);
    }
    #endregion

    #region Checking a GPU device’s feature support - Methods

    /// <summary>
    /// Returns a Boolean value that indicates whether the GPU device supports the feature set of a specific GPU family.
    /// </summary>
    public bool SupportsFamily(MTLGPUFamily gpuFamily)
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsFamily, (nint)gpuFamily);
    }

    /// <summary>
    /// Returns a Boolean value that indicates whether the GPU device supports a specific feature set.
    /// </summary>
    [Obsolete]
    public bool SupportsFeatureSet(MTLFeatureSet featureSet)
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsFeatureSet, (nuint)featureSet);
    }
    #endregion

    #region Checking render support - Methods

    /// <summary>
    /// Returns a Boolean value that indicates whether the GPU supports an amplification factor.
    /// </summary>
    public bool SupportsVertexAmplificationCount(nuint count)
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsVertexAmplificationCount, count);
    }
    #endregion

    #region Sampling a GPU device’s counters - Methods

    /// <summary>
    /// Returns a Boolean value that indicates whether you can read GPU counters at the specified command boundary.
    /// </summary>
    public bool SupportsCounterSampling(MTLCounterSamplingPoint samplingPoint)
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsCounterSampling, (nuint)samplingPoint);
    }

    /// <summary>
    /// Creates a counter sample buffer.
    /// </summary>
    public MTLCounterSampleBuffer NewCounterSampleBuffer(MTLCounterSampleBufferDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewCounterSampleBuffer, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Sampling GPU and CPU timestamps simultaneously - Methods

    /// <summary>
    /// Captures and returns a CPU timestamp and a GPU timestamp from the same moment in time.
    /// </summary>
    public void SampleTimestamps(out ulong cpuTimestamp, out ulong gpuTimestamp)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.SampleTimestamps, out cpuTimestamp, out gpuTimestamp);
    }
    #endregion

    #region Creating residency sets - Methods

    /// <summary>
    /// Creates a residency set, which can move resources in and out of memory residency.
    /// </summary>
    public MTLResidencySet NewResidencySet(MTLResidencySetDescriptor desc, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewResidencySet, desc.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Creating I/O command queues - Methods

    /// <summary>
    /// Creates an input/output command queue you use to submit commands that load assets from the file system into GPU resources or system memory.
    /// </summary>
    public MTLIOCommandQueue NewIOCommandQueue(MTLIOCommandQueueDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewIOCommandQueue, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Creating I/O file handles - Methods

    /// <summary>
    /// Creates an input/output file handle instance that represents a file at a URL.
    /// </summary>
    public MTLIOFileHandle NewIOFileHandle(NSURL url, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewIOFileHandle, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates an input/output file handle instance that represents a file at a URL.
    /// </summary>
    public MTLIOFileHandle NewIOFileHandle(NSURL url, MTLIOCompressionMethod compressionMethod, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewIOFileHandleWithURLcompressionMethoderror, url.NativePtr, (nint)compressionMethod, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates an input/output file handle instance that represents a file at a URL.
    /// </summary>
    [Obsolete]
    public MTLIOFileHandle NewIOHandle(NSURL url, MTLIOCompressionMethod compressionMethod, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewIOHandle, url.NativePtr, (nint)compressionMethod, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates an input/output file handle instance that represents a file at a URL.
    /// </summary>
    [Obsolete]
    public MTLIOFileHandle NewIOHandle(NSURL url, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewIOHandleWithURLerror, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Creating indirect command buffers - Methods

    /// <summary>
    /// Creates an indirect command buffer instance.
    /// </summary>
    public MTLIndirectCommandBuffer NewIndirectCommandBuffer(MTLIndirectCommandBufferDescriptor descriptor, nuint maxCount, MTLResourceOptions options)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewIndirectCommandBuffer, descriptor.NativePtr, maxCount, (nuint)options);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Creating render pipeline states with vertex shaders - Methods

    /// <summary>
    /// Synchronously creates a render pipeline state.
    /// </summary>
    public MTLRenderPipelineState NewRenderPipelineState(MTLRenderPipelineDescriptor descriptor, MTLPipelineOption options, out MTLRenderPipelineReflection reflection, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewRenderPipelineState, descriptor.NativePtr, (nuint)options, out nint reflectionPtr, out nint errorPtr);

        reflection = new(reflectionPtr, NativeObjectOwnership.Owned);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Synchronously creates a render pipeline state.
    /// </summary>
    public void NewRenderPipelineState(MTLMeshRenderPipelineDescriptor descriptor, MTLPipelineOption options, MTLNewRenderPipelineStateWithReflectionCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.NewRenderPipelineStateWithMeshDescriptoroptionscompletionHandler, descriptor.NativePtr, (nuint)options, completionHandler.NativePtr);
    }

    /// <summary>
    /// Synchronously creates a render pipeline state.
    /// </summary>
    public MTLRenderPipelineState NewRenderPipelineState(MTLMeshRenderPipelineDescriptor descriptor, MTLPipelineOption options, out MTLRenderPipelineReflection reflection, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewRenderPipelineStateWithMeshDescriptoroptionsreflectionerror, descriptor.NativePtr, (nuint)options, out nint reflectionPtr, out nint errorPtr);

        reflection = new(reflectionPtr, NativeObjectOwnership.Owned);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Synchronously creates a render pipeline state.
    /// </summary>
    public void NewRenderPipelineState(MTLTileRenderPipelineDescriptor descriptor, MTLPipelineOption options, MTLNewRenderPipelineStateWithReflectionCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.NewRenderPipelineStateWithTileDescriptoroptionscompletionHandler, descriptor.NativePtr, (nuint)options, completionHandler.NativePtr);
    }

    /// <summary>
    /// Synchronously creates a render pipeline state.
    /// </summary>
    public MTLRenderPipelineState NewRenderPipelineState(MTLTileRenderPipelineDescriptor descriptor, MTLPipelineOption options, out MTLRenderPipelineReflection reflection, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewRenderPipelineStateWithTileDescriptoroptionsreflectionerror, descriptor.NativePtr, (nuint)options, out nint reflectionPtr, out nint errorPtr);

        reflection = new(reflectionPtr, NativeObjectOwnership.Owned);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Synchronously creates a render pipeline state.
    /// </summary>
    public void NewRenderPipelineState(MTLRenderPipelineDescriptor descriptor, MTLPipelineOption options, MTLNewRenderPipelineStateWithReflectionCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.NewRenderPipelineStateWithDescriptoroptionscompletionHandler, descriptor.NativePtr, (nuint)options, completionHandler.NativePtr);
    }

    /// <summary>
    /// Synchronously creates a render pipeline state.
    /// </summary>
    public void NewRenderPipelineState(MTLRenderPipelineDescriptor descriptor, MTLNewRenderPipelineStateCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.NewRenderPipelineStateWithDescriptorcompletionHandler, descriptor.NativePtr, completionHandler.NativePtr);
    }

    /// <summary>
    /// Synchronously creates a render pipeline state.
    /// </summary>
    public MTLRenderPipelineState NewRenderPipelineState(MTLRenderPipelineDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewRenderPipelineStateWithDescriptorerror, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Creating compute pipeline states - Methods

    /// <summary>
    /// Synchronously creates a compute pipeline state and reflection information.
    /// </summary>
    public void NewComputePipelineState(MTLComputePipelineDescriptor descriptor, MTLPipelineOption options, MTLNewComputePipelineStateWithReflectionCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.NewComputePipelineState, descriptor.NativePtr, (nuint)options, completionHandler.NativePtr);
    }

    /// <summary>
    /// Synchronously creates a compute pipeline state and reflection information.
    /// </summary>
    public MTLComputePipelineState NewComputePipelineState(MTLComputePipelineDescriptor descriptor, MTLPipelineOption options, out MTLComputePipelineReflection reflection, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewComputePipelineStateWithDescriptoroptionsreflectionerror, descriptor.NativePtr, (nuint)options, out nint reflectionPtr, out nint errorPtr);

        reflection = new(reflectionPtr, NativeObjectOwnership.Owned);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Synchronously creates a compute pipeline state and reflection information.
    /// </summary>
    public MTLComputePipelineState NewComputePipelineState(MTLFunction computeFunction, MTLPipelineOption options, out MTLComputePipelineReflection reflection, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewComputePipelineStateWithFunctionoptionsreflectionerror, computeFunction.NativePtr, (nuint)options, out nint reflectionPtr, out nint errorPtr);

        reflection = new(reflectionPtr, NativeObjectOwnership.Owned);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Synchronously creates a compute pipeline state and reflection information.
    /// </summary>
    public MTLComputePipelineState NewComputePipelineState(MTLFunction computeFunction, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewComputePipelineStateWithFunctionerror, computeFunction.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Synchronously creates a compute pipeline state and reflection information.
    /// </summary>
    public void NewComputePipelineState(MTLFunction computeFunction, MTLPipelineOption options, MTLNewComputePipelineStateWithReflectionCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.NewComputePipelineStateWithFunctionoptionscompletionHandler, computeFunction.NativePtr, (nuint)options, completionHandler.NativePtr);
    }

    /// <summary>
    /// Synchronously creates a compute pipeline state and reflection information.
    /// </summary>
    public void NewComputePipelineState(MTLFunction computeFunction, MTLNewComputePipelineStateCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.NewComputePipelineStateWithFunctioncompletionHandler, computeFunction.NativePtr, completionHandler.NativePtr);
    }
    #endregion

    #region Creating depth and stencil states - Methods

    /// <summary>
    /// Creates a depth-stencil state instance.
    /// </summary>
    public MTLDepthStencilState NewDepthStencilState(MTLDepthStencilDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewDepthStencilState, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Working with resource heaps - Methods

    /// <summary>
    /// Creates a new GPU heap instance.
    /// </summary>
    public MTLSizeAndAlign HeapAccelerationStructureSizeAndAlign(nuint size)
    {
        return ObjectiveC.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceBindings.HeapAccelerationStructureSizeAndAlign, size);
    }

    /// <summary>
    /// Creates a new GPU heap instance.
    /// </summary>
    public MTLSizeAndAlign HeapAccelerationStructureSizeAndAlign(MTLAccelerationStructureDescriptor descriptor)
    {
        return ObjectiveC.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceBindings.HeapAccelerationStructureSizeAndAlignWithDescriptor, descriptor.NativePtr);
    }

    /// <summary>
    /// Returns the size and alignment, in bytes, of a buffer if you create it from a heap.
    /// </summary>
    public MTLSizeAndAlign HeapBufferSizeAndAlign(nuint length, MTLResourceOptions options)
    {
        return ObjectiveC.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceBindings.HeapBufferSizeAndAlign, length, (nuint)options);
    }

    /// <summary>
    /// Returns the size and alignment, in bytes, of a texture if you create it from a heap.
    /// </summary>
    public MTLSizeAndAlign HeapTextureSizeAndAlign(MTLTextureDescriptor desc)
    {
        return ObjectiveC.MsgSendMTLSizeAndAlign(NativePtr, MTLDeviceBindings.HeapTextureSizeAndAlign, desc.NativePtr);
    }
    #endregion

    #region Creating textures - Methods

    /// <summary>
    /// Creates a new texture instance.
    /// </summary>
    public MTLTexture NewTexture(MTLTextureDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewTexture, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a new texture instance.
    /// </summary>
    public MTLTexture NewTexture(MTLTextureDescriptor descriptor, nint iosurface, nuint plane)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewTextureWithDescriptoriosurfaceplane, descriptor.NativePtr, iosurface, plane);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a texture that you can share across process boundaries.
    /// </summary>
    public MTLTexture NewSharedTexture(MTLTextureDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewSharedTexture, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a texture that you can share across process boundaries.
    /// </summary>
    public MTLTexture NewSharedTexture(MTLSharedTextureHandle sharedHandle)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewSharedTextureWithHandle, sharedHandle.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Returns the minimum alignment the GPU device requires to create a linear texture from a buffer.
    /// </summary>
    public nuint MinimumLinearTextureAlignmentForPixelFormat(MTLPixelFormat format)
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, MTLDeviceBindings.MinimumLinearTextureAlignmentForPixelFormat, (nuint)format);
    }

    /// <summary>
    /// Returns the minimum alignment the GPU device requires to create a texture buffer from a buffer.
    /// </summary>
    public nuint MinimumTextureBufferAlignmentForPixelFormat(MTLPixelFormat format)
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, MTLDeviceBindings.MinimumTextureBufferAlignmentForPixelFormat, (nuint)format);
    }
    #endregion

    #region Creating samplers - Methods

    /// <summary>
    /// Returns a Boolean value that indicates whether the GPU can sample a texture with a specific number of sample points.
    /// </summary>
    public bool SupportsTextureSampleCount(nuint sampleCount)
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsTextureSampleCount, sampleCount);
    }

    /// <summary>
    /// Creates a sampler state instance.
    /// </summary>
    public MTLSamplerState NewSamplerState(MTLSamplerDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewSamplerState, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Returns the default sample locations based on the number of samples.
    /// </summary>
    public unsafe void GetDefaultSamplePositions(MTLSamplePosition[] positions)
    {
        fixed (MTLSamplePosition* pPositions = positions)
        {
            ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.GetDefaultSamplePositions, (nint)pPositions, (nuint)positions.Length);
        }
    }
    #endregion

    #region Working with sparse textures - Methods

    /// <summary>
    /// Returns the dimensions of a sparse tile for a texture that has a specific sparse page size.
    /// </summary>
    public MTLSize SparseTileSize(MTLTextureType textureType, MTLPixelFormat pixelFormat, nuint sampleCount, MTLSparsePageSize sparsePageSize)
    {
        return ObjectiveC.MsgSendMTLSize(NativePtr, MTLDeviceBindings.SparseTileSize, (nuint)textureType, (nuint)pixelFormat, sampleCount, (nint)sparsePageSize);
    }

    /// <summary>
    /// Returns the dimensions of a sparse tile for a texture that has a specific sparse page size.
    /// </summary>
    public MTLSize SparseTileSize(MTLTextureType textureType, MTLPixelFormat pixelFormat, nuint sampleCount)
    {
        return ObjectiveC.MsgSendMTLSize(NativePtr, MTLDeviceBindings.SparseTileSizeWithTextureTypepixelFormatsampleCount, (nuint)textureType, (nuint)pixelFormat, sampleCount);
    }

    /// <summary>
    /// Returns the size, in bytes, of a sparse tile the GPU device creates with a specific page size.
    /// </summary>
    public nuint SparseTileSizeInBytesForSparsePageSize(MTLSparsePageSize sparsePageSize)
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, MTLDeviceBindings.SparseTileSizeInBytesForSparsePageSize, (nint)sparsePageSize);
    }

    /// <summary>
    /// Converts a list of sparse pixel regions to tile regions.
    /// </summary>
    public void ConvertSparsePixelRegions(MTLRegion pixelRegions, MTLRegion tileRegions, MTLSize tileSize, MTLSparseTextureRegionAlignmentMode mode, nuint numRegions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.ConvertSparsePixelRegions, pixelRegions, tileRegions, tileSize, (nuint)mode, numRegions);
    }

    /// <summary>
    /// Converts a list of sparse tile regions to pixel regions.
    /// </summary>
    public void ConvertSparseTileRegions(MTLRegion tileRegions, MTLRegion pixelRegions, MTLSize tileSize, nuint numRegions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.ConvertSparseTileRegions, tileRegions, pixelRegions, tileSize, numRegions);
    }
    #endregion

    #region Creating acceleration structures for ray tracing - Methods

    /// <summary>
    /// Creates a new ray-tracing acceleration structure from a descriptor.
    /// </summary>
    public MTLAccelerationStructureSizes AccelerationStructureSizes(MTLAccelerationStructureDescriptor descriptor)
    {
        return ObjectiveC.MsgSendMTLAccelerationStructureSizes(NativePtr, MTLDeviceBindings.AccelerationStructureSizes, descriptor.NativePtr);
    }
    #endregion

    #region Creating argument buffer encoders - Methods

    /// <summary>
    /// Creates a new argument encoder for an array of arguments.
    /// </summary>
    public MTLArgumentEncoder NewArgumentEncoder(MTLArgumentDescriptor[] arguments)
    {
        nint pArguments = NSArray.FromArray(arguments);

        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewArgumentEncoder, pArguments);

        ObjectiveC.Release(pArguments);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a new argument encoder for an array of arguments.
    /// </summary>
    public MTLArgumentEncoder NewArgumentEncoder(MTLBufferBinding bufferBinding)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewArgumentEncoderWithBufferBinding, bufferBinding.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Creating fences and events - Methods

    /// <summary>
    /// Creates a new memory fence instance.
    /// </summary>
    public MTLFence NewFence()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewFence);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a new event instance that you can use to synchronize commands and resources within the same GPU device.
    /// </summary>
    public MTLEvent NewEvent()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewEvent);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a new shared event instance that you can use to synchronize commands and resources across different GPU devices.
    /// </summary>
    public MTLSharedEvent NewSharedEvent()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewSharedEvent);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a new shared event instance that you can use to synchronize commands and resources across different GPU devices.
    /// </summary>
    public MTLSharedEvent NewSharedEventWithHandle(MTLSharedEventHandle sharedEventHandle)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewSharedEventWithHandle, sharedEventHandle.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Creating rasterization rate maps - Methods

    /// <summary>
    /// Returns a Boolean value that indicates whether the GPU can create a rasterization rate map with a specific number of layers.
    /// </summary>
    public bool SupportsRasterizationRateMap(nuint layerCount)
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLDeviceBindings.SupportsRasterizationRateMap, layerCount);
    }

    /// <summary>
    /// Creates a rasterization rate map instance.
    /// </summary>
    public MTLRasterizationRateMap NewRasterizationRateMap(MTLRasterizationRateMapDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewRasterizationRateMap, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Creating shader libraries - Methods

    /// <summary>
    /// Creates a Metal library instance that contains the functions from your app’s default Metal library.
    /// </summary>
    public MTLLibrary NewDefaultLibraryWithBundle(NSBundle bundle, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewDefaultLibraryWithBundleerror, bundle.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a Metal library instance that contains the functions from your app’s default Metal library.
    /// </summary>
    public MTLLibrary NewDefaultLibrary()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewDefaultLibrary);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a Metal library instance that contains the functions in the Metal library file at a URL.
    /// </summary>
    public MTLLibrary NewLibrary(NSString filepath, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewLibrary, filepath.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a Metal library instance that contains the functions in the Metal library file at a URL.
    /// </summary>
    public void NewLibrary(MTLStitchedLibraryDescriptor descriptor, MTLNewLibraryCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.NewLibraryWithStitchedDescriptorcompletionHandler, descriptor.NativePtr, completionHandler.NativePtr);
    }

    /// <summary>
    /// Creates a Metal library instance that contains the functions in the Metal library file at a URL.
    /// </summary>
    public MTLLibrary NewLibrary(MTLStitchedLibraryDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewLibraryWithStitchedDescriptorerror, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a Metal library instance that contains the functions in the Metal library file at a URL.
    /// </summary>
    public void NewLibrary(NSString source, MTLCompileOptions options, MTLNewLibraryCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLDeviceBindings.NewLibraryWithSourceoptionscompletionHandler, source.NativePtr, options.NativePtr, completionHandler.NativePtr);
    }

    /// <summary>
    /// Creates a Metal library instance that contains the functions in the Metal library file at a URL.
    /// </summary>
    public MTLLibrary NewLibrary(NSString source, MTLCompileOptions options, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewLibraryWithSourceoptionserror, source.NativePtr, options.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a Metal library instance that contains the functions in the Metal library file at a URL.
    /// </summary>
    public MTLLibrary NewLibrary(DispatchData data, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewLibraryWithDataerror, data.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a Metal library instance that contains the functions in the Metal library file at a URL.
    /// </summary>
    public MTLLibrary NewLibrary(NSURL url, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewLibraryWithURLerror, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Creating dynamic shader libraries - Methods

    /// <summary>
    /// Creates a Metal dynamic library instance from a Metal library instance.
    /// </summary>
    public MTLDynamicLibrary NewDynamicLibrary(NSURL url, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewDynamicLibrary, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a Metal dynamic library instance from a Metal library instance.
    /// </summary>
    public MTLDynamicLibrary NewDynamicLibrary(MTLLibrary library, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewDynamicLibraryerror, library.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Creating binary shader archives - Methods

    /// <summary>
    /// Creates a Metal binary archive instance.
    /// </summary>
    public MTLBinaryArchive NewBinaryArchive(MTLBinaryArchiveDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewBinaryArchive, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    public MTLAccelerationStructure NewAccelerationStructure(nuint size)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewAccelerationStructure, size);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLAccelerationStructure NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewAccelerationStructureWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLHeap NewHeap(MTLHeapDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewHeap, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLTensor NewTensor(MTLTensorDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLDeviceBindings.NewTensor, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
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

        ObjectiveC.Release(nativePtr);

        return result;
    }

    [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal", EntryPoint = "MTLRemoveDeviceObserver")]
    private static partial void MTLRemoveDeviceObserver(nint param);

    public static void RemoveDeviceObserver(NSObject param) => MTLRemoveDeviceObserver(param.NativePtr);
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

    public static readonly Selector NewBuffer = "newBufferWithLength:options:placementSparsePageSize:";

    public static readonly Selector NewBufferWithByteslengthoptions = "newBufferWithBytes:length:options:";

    public static readonly Selector NewBufferWithLengthoptions = "newBufferWithLength:options:";

    public static readonly Selector NewCommandAllocator = "newCommandAllocator";

    public static readonly Selector NewCommandAllocatorWithDescriptorerror = "newCommandAllocatorWithDescriptor:error:";

    public static readonly Selector NewCommandBuffer = "newCommandBuffer";

    public static readonly Selector NewCommandQueue = "newCommandQueue";

    public static readonly Selector NewCommandQueueWithDescriptor = "newCommandQueueWithDescriptor:";

    public static readonly Selector NewCommandQueueWithMaxCommandBufferCount = "newCommandQueueWithMaxCommandBufferCount:";

    public static readonly Selector NewCompiler = "newCompilerWithDescriptor:error:";

    public static readonly Selector NewComputePipelineState = "newComputePipelineStateWithDescriptor:options:completionHandler:";

    public static readonly Selector NewComputePipelineStateWithDescriptoroptionsreflectionerror = "newComputePipelineStateWithDescriptor:options:reflection:error:";

    public static readonly Selector NewComputePipelineStateWithFunctioncompletionHandler = "newComputePipelineStateWithFunction:completionHandler:";

    public static readonly Selector NewComputePipelineStateWithFunctionerror = "newComputePipelineStateWithFunction:error:";

    public static readonly Selector NewComputePipelineStateWithFunctionoptionscompletionHandler = "newComputePipelineStateWithFunction:options:completionHandler:";

    public static readonly Selector NewComputePipelineStateWithFunctionoptionsreflectionerror = "newComputePipelineStateWithFunction:options:reflection:error:";

    public static readonly Selector NewCounterHeap = "newCounterHeapWithDescriptor:error:";

    public static readonly Selector NewCounterSampleBuffer = "newCounterSampleBufferWithDescriptor:error:";

    public static readonly Selector NewDefaultLibrary = "newDefaultLibrary";

    public static readonly Selector NewDefaultLibraryWithBundleerror = "newDefaultLibraryWithBundle:error:";

    public static readonly Selector NewDepthStencilState = "newDepthStencilStateWithDescriptor:";

    public static readonly Selector NewDynamicLibrary = "newDynamicLibraryWithURL:error:";

    public static readonly Selector NewDynamicLibraryerror = "newDynamicLibrary:error:";

    public static readonly Selector NewEvent = "newEvent";

    public static readonly Selector NewFence = "newFence";

    public static readonly Selector NewHeap = "newHeapWithDescriptor:";

    public static readonly Selector NewIndirectCommandBuffer = "newIndirectCommandBufferWithDescriptor:maxCommandCount:options:";

    public static readonly Selector NewIOCommandQueue = "newIOCommandQueueWithDescriptor:error:";

    public static readonly Selector NewIOFileHandle = "newIOFileHandleWithURL:error:";

    public static readonly Selector NewIOFileHandleWithURLcompressionMethoderror = "newIOFileHandleWithURL:compressionMethod:error:";

    public static readonly Selector NewIOHandle = "newIOHandleWithURL:compressionMethod:error:";

    public static readonly Selector NewIOHandleWithURLerror = "newIOHandleWithURL:error:";

    public static readonly Selector NewLibrary = "newLibraryWithFile:error:";

    public static readonly Selector NewLibraryWithDataerror = "newLibraryWithData:error:";

    public static readonly Selector NewLibraryWithSourceoptionscompletionHandler = "newLibraryWithSource:options:completionHandler:";

    public static readonly Selector NewLibraryWithSourceoptionserror = "newLibraryWithSource:options:error:";

    public static readonly Selector NewLibraryWithStitchedDescriptorcompletionHandler = "newLibraryWithStitchedDescriptor:completionHandler:";

    public static readonly Selector NewLibraryWithStitchedDescriptorerror = "newLibraryWithStitchedDescriptor:error:";

    public static readonly Selector NewLibraryWithURLerror = "newLibraryWithURL:error:";

    public static readonly Selector NewLogState = "newLogStateWithDescriptor:error:";

    public static readonly Selector NewMTL4CommandQueue = "newMTL4CommandQueue";

    public static readonly Selector NewMTL4CommandQueueWithDescriptorerror = "newMTL4CommandQueueWithDescriptor:error:";

    public static readonly Selector NewPipelineDataSetSerializer = "newPipelineDataSetSerializerWithDescriptor:";

    public static readonly Selector NewRasterizationRateMap = "newRasterizationRateMapWithDescriptor:";

    public static readonly Selector NewRenderPipelineState = "newRenderPipelineStateWithDescriptor:options:reflection:error:";

    public static readonly Selector NewRenderPipelineStateWithDescriptorcompletionHandler = "newRenderPipelineStateWithDescriptor:completionHandler:";

    public static readonly Selector NewRenderPipelineStateWithDescriptorerror = "newRenderPipelineStateWithDescriptor:error:";

    public static readonly Selector NewRenderPipelineStateWithDescriptoroptionscompletionHandler = "newRenderPipelineStateWithDescriptor:options:completionHandler:";

    public static readonly Selector NewRenderPipelineStateWithMeshDescriptoroptionscompletionHandler = "newRenderPipelineStateWithMeshDescriptor:options:completionHandler:";

    public static readonly Selector NewRenderPipelineStateWithMeshDescriptoroptionsreflectionerror = "newRenderPipelineStateWithMeshDescriptor:options:reflection:error:";

    public static readonly Selector NewRenderPipelineStateWithTileDescriptoroptionscompletionHandler = "newRenderPipelineStateWithTileDescriptor:options:completionHandler:";

    public static readonly Selector NewRenderPipelineStateWithTileDescriptoroptionsreflectionerror = "newRenderPipelineStateWithTileDescriptor:options:reflection:error:";

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

    public static readonly Selector SparseTileSize = "sparseTileSizeWithTextureType:pixelFormat:sampleCount:sparsePageSize:";

    public static readonly Selector SparseTileSizeInBytes = "sparseTileSizeInBytes";

    public static readonly Selector SparseTileSizeInBytesForSparsePageSize = "sparseTileSizeInBytesForSparsePageSize:";

    public static readonly Selector SparseTileSizeWithTextureTypepixelFormatsampleCount = "sparseTileSizeWithTextureType:pixelFormat:sampleCount:";

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
