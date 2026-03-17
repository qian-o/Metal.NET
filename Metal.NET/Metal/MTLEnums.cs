namespace Metal.NET;

/// <summary>
/// Enumeration for controlling alpha-to-coverage state of a pipeline state object.
/// </summary>
public enum MTL4AlphaToCoverageState : long
{
    /// <summary>
    /// Disables alpha-to-coverage.
    /// </summary>
    Disabled = 0,

    /// <summary>
    /// Enables alpha-to-coverage.
    /// </summary>
    Enabled = 1
}

/// <summary>
/// Enumeration for controlling alpha-to-one state of a pipeline state object.
/// </summary>
public enum MTL4AlphaToOneState : long
{
    /// <summary>
    /// Disables alpha-to-one.
    /// </summary>
    Disabled = 0,

    /// <summary>
    /// Enables alpha-to-one.
    /// </summary>
    Enabled = 1
}

/// <summary>
/// Options for configuring the creation of binary functions.
/// </summary>
[Flags]
public enum MTL4BinaryFunctionOptions : ulong
{
    None = 0,

    /// <summary>
    /// Compiles the function to have its function handles return a constant MTLResourceID across all pipeline states. The function needs to be linked to the pipeline that will use this function.
    /// </summary>
    PipelineIndependent = 2
}

/// <summary>
/// Enumeration for controlling the blend state of a pipeline state object.
/// </summary>
public enum MTL4BlendState : long
{
    /// <summary>
    /// Disables blending.
    /// </summary>
    Disabled = 0,

    /// <summary>
    /// Enables blending.
    /// </summary>
    Enabled = 1,

    /// <summary>
    /// Defers determining the blending stage.
    /// </summary>
    Unspecialized = 2
}

public enum MTL4CommandQueueError : long
{
    None = 0,

    Timeout = 1,

    NotPermitted = 2,

    OutOfMemory = 3,

    DeviceRemoved = 4,

    AccessRevoked = 5,

    Internal = 6
}

/// <summary>
/// Represents the status of a compiler task.
/// </summary>
public enum MTL4CompilerTaskStatus : long
{
    /// <summary>
    /// No status.
    /// </summary>
    None = 0,

    /// <summary>
    /// The compiler task is currently scheduled.
    /// </summary>
    Scheduled = 1,

    /// <summary>
    /// The compiler task is currently compiling.
    /// </summary>
    Compiling = 2,

    /// <summary>
    /// The compiler task is finished.
    /// </summary>
    Finished = 3
}

/// <summary>
/// Defines the type of a  and the contents of its entries.
/// </summary>
public enum MTL4CounterHeapType : long
{
    /// <summary>
    /// Specifies that  entries contain invalid data.
    /// </summary>
    Invalid = 0,

    /// <summary>
    /// Specifies that  entries contain GPU timestamp data.
    /// </summary>
    Timestamp = 1
}

/// <summary>
/// Enumeration for controlling support for .
/// </summary>
public enum MTL4IndirectCommandBufferSupportState : long
{
    /// <summary>
    /// Disables support for indirect command buffers.
    /// </summary>
    Disabled = 0,

    /// <summary>
    /// Enables support for indirect command buffers.
    /// </summary>
    Enabled = 1
}

/// <summary>
/// Enumerates possible behaviors of how a pipeline maps its logical outputs to its color attachments.
/// </summary>
public enum MTL4LogicalToPhysicalColorAttachmentMappingState : long
{
    /// <summary>
    /// Treats the logical color attachment descriptor array for render and tile render pipelines to match the physical one.
    /// </summary>
    Identity = 0,

    /// <summary>
    /// Deduces the color attachment mapping by inheriting it from the color attachment map of the current encoder.
    /// </summary>
    Inherited = 1
}

/// <summary>
/// Configuration options for pipeline dataset serializer objects.
/// </summary>
[Flags]
public enum MTL4PipelineDataSetSerializerConfiguration : ulong
{
    /// <summary>
    /// Enables serializing pipeline scripts.
    /// </summary>
    CaptureDescriptors = 1,

    /// <summary>
    /// Enables serializing pipeline binary functions.
    /// </summary>
    CaptureBinaries = 2
}

/// <summary>
/// Custom render pass options you specify at encoder creation time.
/// </summary>
[Flags]
public enum MTL4RenderEncoderOptions : ulong
{
    None = 0,

    /// <summary>
    /// Configures the render pass as suspending.
    /// </summary>
    Suspending = 1,

    /// <summary>
    /// Configures the render pass to as resuming.
    /// </summary>
    Resuming = 2
}

/// <summary>
/// Option mask for requesting reflection information at pipeline build time.
/// </summary>
[Flags]
public enum MTL4ShaderReflection : ulong
{
    None = 0,

    /// <summary>
    /// Requests reflection information for bindings.
    /// </summary>
    BindingInfo = 1,

    /// <summary>
    /// Requests reflection information for buffer types.
    /// </summary>
    BufferTypeInfo = 2
}

/// <summary>
/// Provides a hint to the system about the desired accuracy when writing GPU counter timestamps.
/// </summary>
public enum MTL4TimestampGranularity : long
{
    /// <summary>
    /// A minimally-invasive timestamp which may be less precise.
    /// </summary>
    Relaxed = 0,

    /// <summary>
    /// A timestamp as precise as possible.
    /// </summary>
    Precise = 1
}

/// <summary>
/// Memory consistency options for synchronization commands.
/// </summary>
[Flags]
public enum MTL4VisibilityOptions : ulong
{
    None = 0,

    /// <summary>
    /// Flushes caches to the GPU (device) memory coherence point.
    /// </summary>
    Device = 1,

    /// <summary>
    /// Flushes caches to ensure that aliased virtual addresses are memory consistent.
    /// </summary>
    ResourceAlias = 2
}

/// <summary>
/// Options for specifying different kinds of instance types.
/// </summary>
public enum MTLAccelerationStructureInstanceDescriptorType : ulong
{
    /// <summary>
    /// An option specifying that the instance uses the default characteristics.
    /// </summary>
    Default = 0,

    /// <summary>
    /// An option specifying that the instance contains a user identifier.
    /// </summary>
    UserID = 1,

    /// <summary>
    /// An option specifying that the instance contains motion data.
    /// </summary>
    Motion = 2,

    /// <summary>
    /// An option that enables an instance descriptor memory layout the GPU can populate.
    /// </summary>
    Indirect = 3,

    /// <summary>
    /// An option specifying that the instance contains motion data, and enables using an instance descriptor memory layout that the GPU can populate.
    /// </summary>
    IndirectMotion = 4
}

/// <summary>
/// Options for adjusting the behavior of an instanced acceleration structure.
/// </summary>
[Flags]
public enum MTLAccelerationStructureInstanceOptions : uint
{
    None = 0,

    /// <summary>
    /// An option that turns off culling for this instance if ray intersector has culling enabled.
    /// </summary>
    DisableTriangleCulling = 1,

    /// <summary>
    /// Specifies that the instance specifies front facing triangles in counter-clockwise order.
    /// </summary>
    TriangleFrontFacingWindingCounterClockwise = 2,

    /// <summary>
    /// Specifies that intersectors should treat the instance as opaque.
    /// </summary>
    Opaque = 4,

    /// <summary>
    /// Specifies that intersectors should treat the instance as non-opaque.
    /// </summary>
    NonOpaque = 8
}

[Flags]
public enum MTLAccelerationStructureRefitOptions : ulong
{
    VertexData = 1,

    PerPrimitiveData = 2
}

/// <summary>
/// Options that affect how Metal builds an acceleration structure and the behavior of that acceleration structure.
/// </summary>
[Flags]
public enum MTLAccelerationStructureUsage : ulong
{
    None = 0,

    /// <summary>
    /// An option that lets you update an acceleration structure after creating it.
    /// </summary>
    Refit = 1,

    /// <summary>
    /// An option that instructs Metal to build an acceleration structure quickly.
    /// </summary>
    PreferFastBuild = 2,

    /// <summary>
    /// An option that increases an acceleration structure’s storage capacity.
    /// </summary>
    ExtendedLimits = 4,

    /// <summary>
    /// An option that instructs Metal to prioritize building an acceleration structure with better intersection performance.
    /// </summary>
    PreferFastIntersection = 16,

    /// <summary>
    /// An option that instructs Metal to prioritize building an acceleration structure that needs less memory.
    /// </summary>
    MinimizeMemory = 32
}

/// <summary>
/// The values that determine the limits and capabilities of argument buffers.
/// </summary>
public enum MTLArgumentBuffersTier : ulong
{
    MTL1 = 0,

    MTL2 = 1
}

/// <summary>
/// The resource type for an argument of a function.
/// </summary>
public enum MTLArgumentType : ulong
{
    /// <summary>
    /// The argument is a buffer.
    /// </summary>
    [Obsolete]
    Buffer = 0,

    /// <summary>
    /// The argument is a pointer to threadgroup memory.
    /// </summary>
    [Obsolete]
    ThreadgroupMemory = 1,

    /// <summary>
    /// The argument is a texture.
    /// </summary>
    [Obsolete]
    Texture = 2,

    /// <summary>
    /// The argument is a texture sampler.
    /// </summary>
    [Obsolete]
    Sampler = 3,

    /// <summary>
    /// The argument is imageblock data.
    /// </summary>
    [Obsolete]
    ImageblockData = 16,

    /// <summary>
    /// The argument is an imageblock.
    /// </summary>
    [Obsolete]
    Imageblock = 17,

    /// <summary>
    /// The argument is a visible function table.
    /// </summary>
    [Obsolete]
    VisibleFunctionTable = 24,

    /// <summary>
    /// The argument is a bottom-level ray tracing acceleraton structure for a set of primitives.
    /// </summary>
    [Obsolete]
    PrimitiveAccelerationStructure = 25,

    /// <summary>
    /// The argument is a top-level ray tracing acceleration structure for a set of instances.
    /// </summary>
    [Obsolete]
    InstanceAccelerationStructure = 26,

    /// <summary>
    /// The argument is an intersection function table.
    /// </summary>
    [Obsolete]
    IntersectionFunctionTable = 27
}

/// <summary>
/// The data format options for acceleration structures.
/// </summary>
public enum MTLAttributeFormat : ulong
{
    /// <summary>
    /// A sentinel value that represents an invalid attribute format.
    /// </summary>
    Invalid = 0,

    /// <summary>
    /// A two-component vector with 8-bit, unsigned integer values.
    /// </summary>
    UChar2 = 1,

    /// <summary>
    /// A three-component vector with 8-bit, unsigned integer values.
    /// </summary>
    UChar3 = 2,

    /// <summary>
    /// A four-component vector with 8-bit, unsigned integer values.
    /// </summary>
    UChar4 = 3,

    /// <summary>
    /// A two-component vector with 8-bit, signed integer values.
    /// </summary>
    Char2 = 4,

    /// <summary>
    /// A three-component vector with 8-bit, signed integer values.
    /// </summary>
    Char3 = 5,

    /// <summary>
    /// A four-component vector with 8-bit, signed integer values.
    /// </summary>
    Char4 = 6,

    /// <summary>
    /// A two-component vector with 8-bit, normalized, unsigned integer values.
    /// </summary>
    UChar2Normalized = 7,

    /// <summary>
    /// A three-component vector with 8-bit, normalized, unsigned integer values.
    /// </summary>
    UChar3Normalized = 8,

    /// <summary>
    /// A four-component vector with 8-bit, normalized, unsigned integer values.
    /// </summary>
    UChar4Normalized = 9,

    /// <summary>
    /// A two-component vector with 8-bit, normalized, signed integer values.
    /// </summary>
    Char2Normalized = 10,

    /// <summary>
    /// A three-component vector with 8-bit, normalized, signed integer values.
    /// </summary>
    Char3Normalized = 11,

    /// <summary>
    /// A four-component vector with 8-bit, normalized, signed integer values.
    /// </summary>
    Char4Normalized = 12,

    /// <summary>
    /// A two-component vector with 16-bit, unsigned integer values.
    /// </summary>
    UShort2 = 13,

    /// <summary>
    /// A three-component vector with 16-bit, unsigned integer values.
    /// </summary>
    UShort3 = 14,

    /// <summary>
    /// A four-component vector with 16-bit, unsigned integer values.
    /// </summary>
    UShort4 = 15,

    /// <summary>
    /// A two-component vector with 16-bit, signed integer values.
    /// </summary>
    Short2 = 16,

    /// <summary>
    /// A three-component vector with 16-bit, signed integer values.
    /// </summary>
    Short3 = 17,

    /// <summary>
    /// A four-component vector with 16-bit, signed integer values.
    /// </summary>
    Short4 = 18,

    /// <summary>
    /// Two unsigned normalized 16-bit values
    /// </summary>
    UShort2Normalized = 19,

    /// <summary>
    /// A three-component vector with 16-bit, normalized, unsigned integer values.
    /// </summary>
    UShort3Normalized = 20,

    /// <summary>
    /// A four-component vector with 16-bit, normalized, unsigned integer values.
    /// </summary>
    UShort4Normalized = 21,

    /// <summary>
    /// A two-component vector with 16-bit, normalized, signed integer values.
    /// </summary>
    Short2Normalized = 22,

    /// <summary>
    /// A three-component vector with 16-bit, normalized, signed integer values.
    /// </summary>
    Short3Normalized = 23,

    /// <summary>
    /// A four-component vector with 16-bit, normalized, signed integer values.
    /// </summary>
    Short4Normalized = 24,

    /// <summary>
    /// A two-component vector with 16-bit floating-point values.
    /// </summary>
    Half2 = 25,

    /// <summary>
    /// A three-component vector with 16-bit floating-point values.
    /// </summary>
    Half3 = 26,

    /// <summary>
    /// A four-component vector with 16-bit floating-point values.
    /// </summary>
    Half4 = 27,

    /// <summary>
    /// A 32-bit floating-point value.
    /// </summary>
    Float = 28,

    /// <summary>
    /// A two-component vector with 32-bit floating-point values.
    /// </summary>
    Float2 = 29,

    /// <summary>
    /// A three-component vector with 32-bit floating-point values.
    /// </summary>
    Float3 = 30,

    /// <summary>
    /// A four-component vector with 32-bit floating-point values.
    /// </summary>
    Float4 = 31,

    /// <summary>
    /// A 32-bit, signed integer value.
    /// </summary>
    Int = 32,

    /// <summary>
    /// A two-component vector with 32-bit, signed integer values.
    /// </summary>
    Int2 = 33,

    /// <summary>
    /// A three-component vector with 32-bit, signed integer values.
    /// </summary>
    Int3 = 34,

    /// <summary>
    /// A four-component vector with 32-bit, signed integer values.
    /// </summary>
    Int4 = 35,

    /// <summary>
    /// A 32-bit, unsigned integer value.
    /// </summary>
    UInt = 36,

    /// <summary>
    /// A two-component vector with 32-bit, unsigned integer values.
    /// </summary>
    UInt2 = 37,

    /// <summary>
    /// A three-component vector with 32-bit, unsigned integer values.
    /// </summary>
    UInt3 = 38,

    /// <summary>
    /// A four-component vector with 32-bit, unsigned integer values.
    /// </summary>
    UInt4 = 39,

    /// <summary>
    /// One packed 32-bit value with four normalized signed two’s complement integer values, arranged as 10 bits, 10 bits, 10 bits, and 2 bits.
    /// </summary>
    Int1010102Normalized = 40,

    /// <summary>
    /// One packed 32-bit value with four normalized unsigned integer values, arranged as 10 bits, 10 bits, 10 bits, and 2 bits.
    /// </summary>
    UInt1010102Normalized = 41,

    /// <summary>
    /// Four unsigned normalized 8-bit values, arranged as blue, green, red, and alpha components.
    /// </summary>
    UChar4Normalized_BGRA = 42,

    /// <summary>
    /// An 8-bit, unsigned integer value.
    /// </summary>
    UChar = 45,

    /// <summary>
    /// An 8-bit, signed integer value.
    /// </summary>
    Char = 46,

    /// <summary>
    /// An 8-bit, normalized, unsigned integer value.
    /// </summary>
    UCharNormalized = 47,

    /// <summary>
    /// An 8-bit, normalized, signed integer value.
    /// </summary>
    CharNormalized = 48,

    /// <summary>
    /// A 16-bit, unsigned integer value.
    /// </summary>
    UShort = 49,

    /// <summary>
    /// A 16-bit, signed integer value.
    /// </summary>
    Short = 50,

    /// <summary>
    /// A 16-bit, normalized, unsigned integer value.
    /// </summary>
    UShortNormalized = 51,

    /// <summary>
    /// A 16-bit, normalized, signed integer value.
    /// </summary>
    ShortNormalized = 52,

    /// <summary>
    /// A 16-bit floating-point value.
    /// </summary>
    Half = 53,

    /// <summary>
    /// One packed 32-bit value representing pixel data containing 11-bit float red and green channels, and a 10-bit float blue channel.
    /// </summary>
    FloatRG11B10 = 54,

    /// <summary>
    /// One packed 32-bit value representing pixel data containing 9-bit float red, green, and blue channels, and a 5-bit float shared exponent channel.
    /// </summary>
    FloatRGB9E5 = 55
}

/// <summary>
/// Describes the types of resources that a barrier operates on.
/// </summary>
[Flags]
public enum MTLBarrierScope : ulong
{
    /// <summary>
    /// The barrier affects any buffer objects.
    /// </summary>
    Buffers = 1,

    /// <summary>
    /// The barrier affects textures.
    /// </summary>
    Textures = 2,

    /// <summary>
    /// The barrier affects any render targets.
    /// </summary>
    RenderTargets = 4
}

/// <summary>
/// An error that occurred when creating a binary shader archive.
/// </summary>
public enum MTLBinaryArchiveError : ulong
{
    /// <summary>
    /// An error code that represents the absence of any problems.
    /// </summary>
    None = 0,

    /// <summary>
    /// An error code that indicates an app is using an invalid reference to an archive file, typically related to a URL.
    /// </summary>
    InvalidFile = 1,

    /// <summary>
    /// An error code that indicates a problem with a configuration, typically in a descriptor or an archive’s inability to add linked functions.
    /// </summary>
    UnexpectedElement = 2,

    /// <summary>
    /// An error code that indicates the archive’s inability to compile its contents, typically when serializing it to a URL.
    /// </summary>
    CompilationFailure = 3,

    /// <summary>
    /// An error code that indicates the Metal framework has an internal problem.
    /// </summary>
    InternalError = 4
}

public enum MTLBindingAccess : ulong
{
    ReadOnly = 0,

    ReadWrite = 1,

    WriteOnly = 2,

    ArgumentAccessReadOnly = 0,

    ArgumentAccessReadWrite = 1,

    ArgumentAccessWriteOnly = 2
}

public enum MTLBindingType : long
{
    Buffer = 0,

    ThreadgroupMemory = 1,

    Texture = 2,

    Sampler = 3,

    ImageblockData = 16,

    Imageblock = 17,

    VisibleFunctionTable = 24,

    PrimitiveAccelerationStructure = 25,

    InstanceAccelerationStructure = 26,

    IntersectionFunctionTable = 27,

    ObjectPayload = 34,

    Tensor = 37
}

/// <summary>
/// The source and destination blend factors are often needed to complete specification of a blend operation. In most cases, the blend factor for both RGB values (F(rgb)) and alpha values (F(a)) are similar to one another, but in some cases, such as MTLBlendFactorSourceAlphaSaturated, the blend factor is slightly different. Four blend factors (MTLBlendFactorBlendColor, MTLBlendFactorOneMinusBlendColor, MTLBlendFactorBlendAlpha, and MTLBlendFactorOneMinusBlendAlpha) refer to a constant blend color value that is set by the  method of MTLRenderCommandEncoder.
/// </summary>
public enum MTLBlendFactor : ulong
{
    /// <summary>
    /// Blend factor of zero.
    /// </summary>
    Zero = 0,

    /// <summary>
    /// Blend factor of one.
    /// </summary>
    One = 1,

    /// <summary>
    /// Blend factor of source values.
    /// </summary>
    SourceColor = 2,

    /// <summary>
    /// Blend factor of one minus source values.
    /// </summary>
    OneMinusSourceColor = 3,

    /// <summary>
    /// Blend factor of source alpha.
    /// </summary>
    SourceAlpha = 4,

    /// <summary>
    /// Blend factor of one minus source alpha.
    /// </summary>
    OneMinusSourceAlpha = 5,

    /// <summary>
    /// Blend factor of destination values.
    /// </summary>
    DestinationColor = 6,

    /// <summary>
    /// Blend factor of one minus destination values.
    /// </summary>
    OneMinusDestinationColor = 7,

    /// <summary>
    /// Blend factor of destination alpha.
    /// </summary>
    DestinationAlpha = 8,

    /// <summary>
    /// Blend factor of one minus destination alpha.
    /// </summary>
    OneMinusDestinationAlpha = 9,

    /// <summary>
    /// Blend factor of the minimum of either source alpha or one minus destination alpha.
    /// </summary>
    SourceAlphaSaturated = 10,

    /// <summary>
    /// A blend factor that applies the blend color’s red, green, and blue components.
    /// </summary>
    BlendColor = 11,

    /// <summary>
    /// A blend factor that applies one minus the blend color’s red, green, and blue components.
    /// </summary>
    OneMinusBlendColor = 12,

    /// <summary>
    /// Blend factor of alpha value.
    /// </summary>
    BlendAlpha = 13,

    /// <summary>
    /// Blend factor of one minus alpha value.
    /// </summary>
    OneMinusBlendAlpha = 14,

    /// <summary>
    /// Blend factor of source values. This option supports dual-source blending and reads from the second color output of the fragment function.
    /// </summary>
    Source1Color = 15,

    /// <summary>
    /// Blend factor of one minus source values. This option supports dual-source blending and reads from the second color output of the fragment function.
    /// </summary>
    OneMinusSource1Color = 16,

    /// <summary>
    /// Blend factor of source alpha. This option supports dual-source blending and reads from the second color output of the fragment function.
    /// </summary>
    Source1Alpha = 17,

    /// <summary>
    /// Blend factor of one minus source alpha. This option supports dual-source blending and reads from the second color output of the fragment function.
    /// </summary>
    OneMinusSource1Alpha = 18,

    /// <summary>
    /// Defers assigning the blend factor.
    /// </summary>
    Unspecialized = 19
}

/// <summary>
/// For every pixel, MTLBlendOperation determines how to combine and weight the source fragment values with the destination values. Some blend operations multiply the source values by a source blend factor (SBF), multiply the destination values by a destination blend factor (DBF), and then combine the results using addition or subtraction. Other blend operations use either a minimum or maximum function to determine the result.
/// </summary>
public enum MTLBlendOperation : ulong
{
    /// <summary>
    /// Add portions of both source and destination pixel values.
    /// </summary>
    Add = 0,

    /// <summary>
    /// Subtract a portion of the destination pixel values from a portion of the source.
    /// </summary>
    Subtract = 1,

    /// <summary>
    /// Subtract a portion of the source values from a portion of the destination pixel values.
    /// </summary>
    ReverseSubtract = 2,

    /// <summary>
    /// Minimum of the source and destination pixel values.
    /// </summary>
    Min = 3,

    /// <summary>
    /// Maximum of the source and destination pixel values.
    /// </summary>
    Max = 4,

    /// <summary>
    /// Defers assigning the blend operation.
    /// </summary>
    Unspecialized = 5
}

/// <summary>
/// The options that enable behavior for some blit operations.
/// </summary>
[Flags]
public enum MTLBlitOption : ulong
{
    None = 0,

    /// <summary>
    /// A blit option that copies the depth portion of a combined depth and stencil texture to or from a buffer.
    /// </summary>
    DepthFromDepthStencil = 1,

    /// <summary>
    /// A blit option that copies the stencil portion of a combined depth and stencil texture to or from a buffer.
    /// </summary>
    StencilFromDepthStencil = 2,

    /// <summary>
    /// A blit option that copies PVRTC data between a texture and a buffer.
    /// </summary>
    RowLinearPVRTC = 4
}

/// <summary>
/// Enumerates the different support levels for sparse buffers.
/// </summary>
public enum MTLBufferSparseTier : long
{
    None = 0,

    MTL1 = 1
}

/// <summary>
/// The kinds of destinations for captured command data.
/// </summary>
public enum MTLCaptureDestination : long
{
    /// <summary>
    /// An option specifying that data should be captured to Xcode and that execution should stop in Xcode after the data is captured.
    /// </summary>
    DeveloperTools = 1,

    /// <summary>
    /// An option specifying that the captured command data should be saved to a GPU trace document.
    /// </summary>
    GPUTraceDocument = 2
}

/// <summary>
/// Errors returned by capture sessions.
/// </summary>
public enum MTLCaptureError : long
{
    /// <summary>
    /// A capture error that indicates the capture options you’re requesting aren’t available.
    /// </summary>
    NotSupported = 1,

    /// <summary>
    /// A capture error that indicates the session is already in progress.
    /// </summary>
    AlreadyCapturing = 2,

    /// <summary>
    /// A capture error that indicates your descriptor has invalid properties.
    /// </summary>
    InvalidDescriptor = 3
}

/// <summary>
/// Values used to specify a mask to permit or restrict writing to color channels of a color value.
/// </summary>
[Flags]
public enum MTLColorWriteMask : ulong
{
    None = 0,

    /// <summary>
    /// The red color channel is enabled.
    /// </summary>
    Red = 8,

    /// <summary>
    /// The green color channel is enabled.
    /// </summary>
    Green = 4,

    /// <summary>
    /// The blue color channel is enabled.
    /// </summary>
    Blue = 2,

    /// <summary>
    /// The alpha color channel is enabled.
    /// </summary>
    Alpha = 1,

    /// <summary>
    /// All color channels are enabled.
    /// </summary>
    All = 15,

    /// <summary>
    /// Defers assigning the color write mask.
    /// </summary>
    Unspecialized = 16
}

/// <summary>
/// The command buffer error codes that indicate why the GPU doesn’t finish executing a command buffer.
/// </summary>
public enum MTLCommandBufferError : ulong
{
    /// <summary>
    /// An error code that represents the absence of any problems.
    /// </summary>
    None = 0,

    /// <summary>
    /// An error code that indicates the Metal framework has an internal problem.
    /// </summary>
    Internal = 1,

    /// <summary>
    /// An error code that indicates the system interrupted and terminated the command buffer before it finished running.
    /// </summary>
    Timeout = 2,

    /// <summary>
    /// An error code that indicates the command buffer generated a page fault the GPU can’t service.
    /// </summary>
    PageFault = 3,

    /// <summary>
    /// A former error code that indicates the system has revoked the Metal device’s access because it’s responsible for too many timeouts or hangs.
    /// </summary>
    [Obsolete("Use accessRevoked instead.")]
    Blacklisted = 4,

    /// <summary>
    /// An error code that indicates the system has revoked the Metal device’s access because it’s responsible for too many timeouts or hangs.
    /// </summary>
    AccessRevoked = 4,

    /// <summary>
    /// An error code that indicates a process doesn’t have access to a GPU device.
    /// </summary>
    NotPermitted = 7,

    /// <summary>
    /// An error code that indicates the GPU device doesn’t have sufficient memory to execute a command buffer.
    /// </summary>
    OutOfMemory = 8,

    /// <summary>
    /// An error code that indicates the command buffer has an invalid reference to resource.
    /// </summary>
    InvalidResource = 9,

    /// <summary>
    /// An error code that indicates the GPU ran out of one or more of its internal resources that support memoryless render pass attachments.
    /// </summary>
    Memoryless = 10,

    /// <summary>
    /// An error code that indicates a person physically removed the GPU device before the command buffer finished running.
    /// </summary>
    DeviceRemoved = 11,

    /// <summary>
    /// An error code that indicates the GPU terminated the command buffer because a kernel function of tile shader used too many stack frames.
    /// </summary>
    StackOverflow = 12
}

/// <summary>
/// Options for reporting errors from a command buffer.
/// </summary>
[Flags]
public enum MTLCommandBufferErrorOption : ulong
{
    None = 0,

    /// <summary>
    /// An option that instructs a command buffer to save additional details about a GPU runtime error.
    /// </summary>
    EncoderExecutionStatus = 1
}

/// <summary>
/// The discrete states for a command buffer that represent its life cycle stages.
/// </summary>
public enum MTLCommandBufferStatus : ulong
{
    /// <summary>
    /// A command buffer’s initial state, which indicates its command queue isn’t reserving a place for it.
    /// </summary>
    NotEnqueued = 0,

    /// <summary>
    /// A command buffer’s second state, which indicates its command queue is reserving a place for it.
    /// </summary>
    Enqueued = 1,

    /// <summary>
    /// A command buffer’s third state, which indicates the command queue is preparing to schedule the command buffer by resolving its dependencies.
    /// </summary>
    Committed = 2,

    /// <summary>
    /// A command buffer’s fourth state, which indicates the command buffer has its resources ready and is waiting for the GPU to run its commands.
    /// </summary>
    Scheduled = 3,

    /// <summary>
    /// A command buffer’s successful, final state, which indicates the GPU finished running the command buffer’s commands without any problems.
    /// </summary>
    Completed = 4,

    /// <summary>
    /// A command buffer’s unsuccessful, final state, which indicates the GPU stopped running the buffer’s commands because of a runtime issue.
    /// </summary>
    Error = 5
}

/// <summary>
/// Possible error conditions for the command encoder’s commands.
/// </summary>
public enum MTLCommandEncoderErrorState : long
{
    /// <summary>
    /// An error state that indicates the command buffer doesn’t know the state of its commands on the GPU.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// A state that indicates the GPU successfully executed the commands without any errors.
    /// </summary>
    Completed = 1,

    /// <summary>
    /// An error state that indicates the GPU failed to fully execute the commands because of an error.
    /// </summary>
    Affected = 2,

    /// <summary>
    /// An error state that indicates the GPU didn’t execute the commands.
    /// </summary>
    Pending = 3,

    /// <summary>
    /// An error state that indicates the commands in the command buffer are the cause of an error.
    /// </summary>
    Faulted = 4
}

/// <summary>
/// Options used to specify how a sample compare operation should be performed on a depth texture.
/// </summary>
public enum MTLCompareFunction : ulong
{
    /// <summary>
    /// A new value never passes the comparison test.
    /// </summary>
    Never = 0,

    /// <summary>
    /// A new value passes the comparison test if it is less than the existing value.
    /// </summary>
    Less = 1,

    /// <summary>
    /// A new value passes the comparison test if it is equal to the existing value.
    /// </summary>
    Equal = 2,

    /// <summary>
    /// A new value passes the comparison test if it is less than or equal to the existing value.
    /// </summary>
    LessEqual = 3,

    /// <summary>
    /// A new value passes the comparison test if it is greater than the existing value.
    /// </summary>
    Greater = 4,

    /// <summary>
    /// A new value passes the comparison test if it is not equal to the existing value.
    /// </summary>
    NotEqual = 5,

    /// <summary>
    /// A new value passes the comparison test if it is greater than or equal to the existing value.
    /// </summary>
    GreaterEqual = 6,

    /// <summary>
    /// A new value always passes the comparison test.
    /// </summary>
    Always = 7
}

public enum MTLCompileSymbolVisibility : long
{
    Default = 0,

    Hidden = 1
}

/// <summary>
/// The error codes that indicate why a GPU driver can’t create a counter sample buffer.
/// </summary>
public enum MTLCounterSampleBufferError : long
{
    /// <summary>
    /// An error code that indicates the GPU device doesn’t have sufficient memory to create a counter sample buffer.
    /// </summary>
    OutOfMemory = 0,

    /// <summary>
    /// An error code that indicates the descriptor for creating a counter sample buffer descriptor has an invalid property.
    /// </summary>
    Invalid = 1,

    /// <summary>
    /// An error code that indicates the Metal framework has an internal problem.
    /// </summary>
    Internal = 2
}

/// <summary>
/// Options for different times when you can sample GPU counters.
/// </summary>
public enum MTLCounterSamplingPoint : ulong
{
    /// <summary>
    /// Counter sampling is allowed at the start and end of a render pass’s vertex and fragment stages, and at the start and end of compute and blit passes.
    /// </summary>
    AtStageBoundary = 0,

    /// <summary>
    /// Counter sampling is allowed between draw commands in a render pass.
    /// </summary>
    AtDrawBoundary = 1,

    /// <summary>
    /// Counter sampling is allowed between kernel dispatches in a compute pass.
    /// </summary>
    AtDispatchBoundary = 2,

    /// <summary>
    /// Counter sampling is allowed between tile dispatches in a render pass.
    /// </summary>
    AtTileDispatchBoundary = 3,

    /// <summary>
    /// Counter sampling is allowed between blit commands in a blit pass.
    /// </summary>
    AtBlitBoundary = 4
}

/// <summary>
/// Options for the CPU cache mode that define the CPU mapping of the resource.
/// </summary>
public enum MTLCPUCacheMode : ulong
{
    /// <summary>
    /// The default CPU cache mode for the resource, which guarantees that read and write operations are executed in the expected order.
    /// </summary>
    DefaultCache = 0,

    /// <summary>
    /// A write-combined CPU cache mode that is optimized for resources that the CPU writes into, but never reads.
    /// </summary>
    WriteCombined = 1
}

/// <summary>
/// The mode that determines whether to perform culling and which type of primitive to cull.
/// </summary>
public enum MTLCullMode : ulong
{
    /// <summary>
    /// Does not cull any primitives.
    /// </summary>
    None = 0,

    /// <summary>
    /// Culls front-facing primitives.
    /// </summary>
    Front = 1,

    /// <summary>
    /// Culls back-facing primitives.
    /// </summary>
    Back = 2
}

public enum MTLCurveBasis : long
{
    BSpline = 0,

    CatmullRom = 1,

    Linear = 2,

    Bezier = 3
}

public enum MTLCurveEndCaps : long
{
    None = 0,

    Disk = 1,

    Sphere = 2
}

public enum MTLCurveType : long
{
    Round = 0,

    Flat = 1
}

/// <summary>
/// The parameter type options for GPU functions, such as shaders and compute kernels.
/// </summary>
public enum MTLDataType : ulong
{
    /// <summary>
    /// A sentinel value that represents a GPU function parameter that doesn’t have a valid data type.
    /// </summary>
    None = 0,

    /// <summary>
    /// A structure instance.
    /// </summary>
    Struct = 1,

    /// <summary>
    /// An array instance.
    /// </summary>
    Array = 2,

    /// <summary>
    /// A 32-bit floating-point value.
    /// </summary>
    Float = 3,

    /// <summary>
    /// A two-component vector with 32-bit floating-point values.
    /// </summary>
    Float2 = 4,

    /// <summary>
    /// A three-component vector with 32-bit floating-point values.
    /// </summary>
    Float3 = 5,

    /// <summary>
    /// A four-component vector with 32-bit floating-point values.
    /// </summary>
    Float4 = 6,

    /// <summary>
    /// A 2x2 component matrix with 32-bit floating-point values.
    /// </summary>
    Float2x2 = 7,

    /// <summary>
    /// A 2x3 component matrix with 32-bit floating-point values.
    /// </summary>
    Float2x3 = 8,

    /// <summary>
    /// A 2x4 component matrix with 32-bit floating-point values.
    /// </summary>
    Float2x4 = 9,

    /// <summary>
    /// A 3x2 component matrix with 32-bit floating-point values.
    /// </summary>
    Float3x2 = 10,

    /// <summary>
    /// A 3x3 component matrix with 32-bit floating-point values.
    /// </summary>
    Float3x3 = 11,

    /// <summary>
    /// A 3x4 component matrix with 32-bit floating-point values.
    /// </summary>
    Float3x4 = 12,

    /// <summary>
    /// A 4x2 component matrix with 32-bit floating-point values.
    /// </summary>
    Float4x2 = 13,

    /// <summary>
    /// A 4x3 component matrix with 32-bit floating-point values.
    /// </summary>
    Float4x3 = 14,

    /// <summary>
    /// A 4x4 component matrix with 32-bit floating-point values.
    /// </summary>
    Float4x4 = 15,

    /// <summary>
    /// A 16-bit floating-point value.
    /// </summary>
    Half = 16,

    /// <summary>
    /// A two-component vector with 16-bit floating-point values.
    /// </summary>
    Half2 = 17,

    /// <summary>
    /// A three-component vector with 16-bit floating-point values.
    /// </summary>
    Half3 = 18,

    /// <summary>
    /// A four-component vector with 16-bit floating-point values.
    /// </summary>
    Half4 = 19,

    /// <summary>
    /// A 2x2 component matrix with 16-bit floating-point values.
    /// </summary>
    Half2x2 = 20,

    /// <summary>
    /// A 2x3 component matrix with 16-bit floating-point values.
    /// </summary>
    Half2x3 = 21,

    /// <summary>
    /// A 2x4 component matrix with 16-bit floating-point values.
    /// </summary>
    Half2x4 = 22,

    /// <summary>
    /// A 3x2 component matrix with 16-bit floating-point values.
    /// </summary>
    Half3x2 = 23,

    /// <summary>
    /// A 3x3 component matrix with 16-bit floating-point values.
    /// </summary>
    Half3x3 = 24,

    /// <summary>
    /// A 3x4 component matrix with 16-bit floating-point values.
    /// </summary>
    Half3x4 = 25,

    /// <summary>
    /// A 4x2 component matrix with 16-bit floating-point values.
    /// </summary>
    Half4x2 = 26,

    /// <summary>
    /// A 4x3 component matrix with 16-bit floating-point values.
    /// </summary>
    Half4x3 = 27,

    /// <summary>
    /// A 4x4 component matrix with 16-bit floating-point values.
    /// </summary>
    Half4x4 = 28,

    /// <summary>
    /// A 32-bit, signed integer value.
    /// </summary>
    Int = 29,

    /// <summary>
    /// A two-component vector with 32-bit, signed integer values.
    /// </summary>
    Int2 = 30,

    /// <summary>
    /// A three-component vector with 32-bit, signed integer values.
    /// </summary>
    Int3 = 31,

    /// <summary>
    /// A four-component vector with 32-bit, signed integer values.
    /// </summary>
    Int4 = 32,

    /// <summary>
    /// A 32-bit, unsigned integer value.
    /// </summary>
    UInt = 33,

    /// <summary>
    /// A two-component vector with 32-bit, unsigned integer values.
    /// </summary>
    UInt2 = 34,

    /// <summary>
    /// A three-component vector with 32-bit, unsigned integer values.
    /// </summary>
    UInt3 = 35,

    /// <summary>
    /// A four-component vector with 32-bit, unsigned integer values.
    /// </summary>
    UInt4 = 36,

    /// <summary>
    /// A 16-bit, signed integer value.
    /// </summary>
    Short = 37,

    /// <summary>
    /// A two-component vector with 16-bit, signed integer values.
    /// </summary>
    Short2 = 38,

    /// <summary>
    /// A three-component vector with 16-bit, signed integer values.
    /// </summary>
    Short3 = 39,

    /// <summary>
    /// A four-component vector with 16-bit, signed integer values.
    /// </summary>
    Short4 = 40,

    /// <summary>
    /// A 16-bit, unsigned integer value.
    /// </summary>
    UShort = 41,

    /// <summary>
    /// A two-component vector with 16-bit, unsigned integer values.
    /// </summary>
    UShort2 = 42,

    /// <summary>
    /// A three-component vector with 16-bit, unsigned integer values.
    /// </summary>
    UShort3 = 43,

    /// <summary>
    /// A four-component vector with 16-bit, unsigned integer values.
    /// </summary>
    UShort4 = 44,

    /// <summary>
    /// An 8-bit, signed integer value.
    /// </summary>
    Char = 45,

    /// <summary>
    /// A two-component vector with 8-bit, signed integer values.
    /// </summary>
    Char2 = 46,

    /// <summary>
    /// A three-component vector with 8-bit, signed integer values.
    /// </summary>
    Char3 = 47,

    /// <summary>
    /// A four-component vector with 8-bit, signed integer values.
    /// </summary>
    Char4 = 48,

    /// <summary>
    /// An 8-bit, unsigned integer value.
    /// </summary>
    UChar = 49,

    /// <summary>
    /// A two-component vector with 8-bit, unsigned integer values.
    /// </summary>
    UChar2 = 50,

    /// <summary>
    /// A three-component vector with 8-bit, unsigned integer values.
    /// </summary>
    UChar3 = 51,

    /// <summary>
    /// A four-component vector with 8-bit, unsigned integer values.
    /// </summary>
    UChar4 = 52,

    /// <summary>
    /// A Boolean value.
    /// </summary>
    Bool = 53,

    /// <summary>
    /// A two-component Boolean vector.
    /// </summary>
    Bool2 = 54,

    /// <summary>
    /// A three-component Boolean vector.
    /// </summary>
    Bool3 = 55,

    /// <summary>
    /// A four-component Boolean vector.
    /// </summary>
    Bool4 = 56,

    /// <summary>
    /// A Metal texture resource instance.
    /// </summary>
    Texture = 58,

    /// <summary>
    /// A Metal texture sampler instance.
    /// </summary>
    Sampler = 59,

    /// <summary>
    /// A pointer.
    /// </summary>
    Pointer = 60,

    /// <summary>
    /// An ordinary pixel with one component that’s an 8-bit, normalized, unsigned integer value.
    /// </summary>
    R8Unorm = 62,

    /// <summary>
    /// An ordinary pixel with one component that’s an 8-bit, normalized, signed integer value.
    /// </summary>
    R8Snorm = 63,

    /// <summary>
    /// An ordinary pixel with one component that’s a 16-bit, normalized, unsigned integer value.
    /// </summary>
    R16Unorm = 64,

    /// <summary>
    /// An ordinary pixel with one component that’s a 16-bit, normalized, signed integer value.
    /// </summary>
    R16Snorm = 65,

    /// <summary>
    /// An ordinary pixel with two components, each of which is an 8-bit, normalized, unsigned integer value.
    /// </summary>
    RG8Unorm = 66,

    /// <summary>
    /// An ordinary pixel with two components, each of which is an 8-bit, normalized, signed integer value.
    /// </summary>
    RG8Snorm = 67,

    /// <summary>
    /// An ordinary pixel with two components, each of which is a 16-bit, normalized, unsigned integer value.
    /// </summary>
    RG16Unorm = 68,

    /// <summary>
    /// An ordinary pixel with two components, each of which is a 16-bit, normalized, signed integer value.
    /// </summary>
    RG16Snorm = 69,

    /// <summary>
    /// An ordinary pixel with four components, each of which is an 8-bit, normalized, unsigned integer value.
    /// </summary>
    RGBA8Unorm = 70,

    /// <summary>
    /// An ordinary pixel with four components, each of which is an 8-bit, normalized, unsigned integer value in the sRGB color space.
    /// </summary>
    RGBA8Unorm_sRGB = 71,

    /// <summary>
    /// An ordinary pixel with four components, each of which is an 8-bit, normalized, signed integer value.
    /// </summary>
    RGBA8Snorm = 72,

    /// <summary>
    /// An ordinary pixel with four components, each of which is a 16-bit, normalized, unsigned integer value.
    /// </summary>
    RGBA16Unorm = 73,

    /// <summary>
    /// An ordinary pixel with four components, each of which is a 16-bit, normalized, signed integer value.
    /// </summary>
    RGBA16Snorm = 74,

    /// <summary>
    /// A packed 32-bit format with three color components, each of which is a 10-bit, normalized, unsigned integer value.
    /// </summary>
    RGB10A2Unorm = 75,

    /// <summary>
    /// A packed 32-bit format with three floating-point color components, two of which are 11-bit values, and one is a 10-bit value.
    /// </summary>
    RG11B10Float = 76,

    /// <summary>
    /// A packed 32-bit format with three color components, each of which is a 9-bit floating-point value.
    /// </summary>
    RGB9E5Float = 77,

    /// <summary>
    /// A Metal render pipeline instance.
    /// </summary>
    RenderPipeline = 78,

    /// <summary>
    /// A Metal compute pipeline instance.
    /// </summary>
    ComputePipeline = 79,

    /// <summary>
    /// An indirect command buffer resource instance.
    /// </summary>
    IndirectCommandBuffer = 80,

    /// <summary>
    /// A 64-bit, signed integer value.
    /// </summary>
    Long = 81,

    /// <summary>
    /// A two-component vector with 64-bit, signed integer values.
    /// </summary>
    Long2 = 82,

    /// <summary>
    /// A three-component vector with 64-bit, signed integer values.
    /// </summary>
    Long3 = 83,

    /// <summary>
    /// A four-component vector with 64-bit, signed integer values.
    /// </summary>
    Long4 = 84,

    /// <summary>
    /// A 64-bit, unsigned integer value.
    /// </summary>
    ULong = 85,

    /// <summary>
    /// A two-component vector with 64-bit, unsigned integer values.
    /// </summary>
    ULong2 = 86,

    /// <summary>
    /// A three-component vector with 64-bit, unsigned integer values.
    /// </summary>
    ULong3 = 87,

    /// <summary>
    /// A four-component vector with 64-bit, unsigned integer values.
    /// </summary>
    ULong4 = 88,

    /// <summary>
    /// A table of visible functions that a render or compute pipeline can call.
    /// </summary>
    VisibleFunctionTable = 115,

    /// <summary>
    /// A table of intersection functions that a render or compute pipeline can call.
    /// </summary>
    IntersectionFunctionTable = 116,

    /// <summary>
    /// A low-level ray-tracing acceleration structure for a set of primitives.
    /// </summary>
    PrimitiveAccelerationStructure = 117,

    /// <summary>
    /// A high-level, ray-tracing acceleration structure for a set of low-level primitive instances.
    /// </summary>
    InstanceAccelerationStructure = 118,

    /// <summary>
    /// A 16-bit, brain floating-point value.
    /// </summary>
    BFloat = 121,

    /// <summary>
    /// A two-component vector with 16-bit, brain floating-point values.
    /// </summary>
    BFloat2 = 122,

    /// <summary>
    /// A three-component vector with 16-bit, brain floating-point values.
    /// </summary>
    BFloat3 = 123,

    /// <summary>
    /// A four-component vector with 16-bit, brain floating-point values.
    /// </summary>
    BFloat4 = 124,

    /// <summary>
    /// Represents a data type corresponding to a depth-stencil state object.
    /// </summary>
    DepthStencilState = 139,

    /// <summary>
    /// Represents a data type corresponding to a machine learning tensor.
    /// </summary>
    Tensor = 140
}

/// <summary>
/// The mode that determines how to deal with fragments outside of the near or far planes.
/// </summary>
public enum MTLDepthClipMode : ulong
{
    /// <summary>
    /// Clip fragments outside the near or far planes.
    /// </summary>
    Clip = 0,

    /// <summary>
    /// Clamp fragments outside the near or far planes.
    /// </summary>
    Clamp = 1
}

/// <summary>
/// Indicates the location of the GPU relative to the system it’s connect to.
/// </summary>
public enum MTLDeviceLocation : ulong
{
    /// <summary>
    /// A location that indicates the GPU is permanently connected to the system internally.
    /// </summary>
    BuiltIn = 0,

    /// <summary>
    /// A GPU location that indicates a person connected the GPU to a system’s internal slot.
    /// </summary>
    Slot = 1,

    /// <summary>
    /// A GPU location that indicates a person connected the GPU to the system with an external interface, such as Thunderbolt.
    /// </summary>
    External = 2,

    /// <summary>
    /// A value that indicates the system can’t determine how the GPU connects to it.
    /// </summary>
    Unspecified = 18446744073709551615
}

/// <summary>
/// The type of dispatch method to use when calling encoded functions.
/// </summary>
public enum MTLDispatchType : ulong
{
    /// <summary>
    /// Sets a command encoder to dispatch encoded commands serially during your pass.
    /// </summary>
    Serial = 0,

    /// <summary>
    /// Sets a command encoder to dispatch encoded commands concurrently during your pass.
    /// </summary>
    Concurrent = 1
}

/// <summary>
/// Errors when compiling dynamic libraries.
/// </summary>
public enum MTLDynamicLibraryError : ulong
{
    /// <summary>
    /// An error code that represents the absence of any problems.
    /// </summary>
    None = 0,

    /// <summary>
    /// An error code that indicates an app is using an invalid reference to a library file, typically related to a URL.
    /// </summary>
    InvalidFile = 1,

    /// <summary>
    /// An error code that indicates Metal couldn’t compile a dynamic library.
    /// </summary>
    CompilationFailure = 2,

    /// <summary>
    /// An error code that indicates Metal couldn’t resolve the installation name for a new dynamic library.
    /// </summary>
    UnresolvedInstallName = 3,

    /// <summary>
    /// An error code that indicates a dynamic library couldn’t link to other dynamic libraries.
    /// </summary>
    DependencyLoadFailure = 4,

    /// <summary>
    /// An error code that indicates the GPU device doesn’t support dynamic libraries.
    /// </summary>
    Unsupported = 5
}

/// <summary>
/// The device feature sets that define specific platform, hardware, and software configurations.
/// </summary>
[Obsolete("Use MTLGPUFamily instead.")]
public enum MTLFeatureSet : ulong
{
    _iOS_GPUFamily1_v1 = 0,

    _iOS_GPUFamily2_v1 = 1,

    _iOS_GPUFamily1_v2 = 2,

    _iOS_GPUFamily2_v2 = 3,

    _iOS_GPUFamily3_v1 = 4,

    _iOS_GPUFamily1_v3 = 5,

    _iOS_GPUFamily2_v3 = 6,

    _iOS_GPUFamily3_v2 = 7,

    _iOS_GPUFamily1_v4 = 8,

    _iOS_GPUFamily2_v4 = 9,

    _iOS_GPUFamily3_v3 = 10,

    _iOS_GPUFamily4_v1 = 11,

    _iOS_GPUFamily1_v5 = 12,

    _iOS_GPUFamily2_v5 = 13,

    _iOS_GPUFamily3_v4 = 14,

    _iOS_GPUFamily4_v2 = 15,

    _iOS_GPUFamily5_v1 = 16,

    _macOS_GPUFamily1_v1 = 10000,

    _OSX_GPUFamily1_v1 = 10000,

    _macOS_GPUFamily1_v2 = 10001,

    _OSX_GPUFamily1_v2 = 10001,

    _macOS_ReadWriteTextureTier2 = 10002,

    _OSX_ReadWriteTextureTier2 = 10002,

    _macOS_GPUFamily1_v3 = 10003,

    _macOS_GPUFamily1_v4 = 10004,

    _macOS_GPUFamily2_v1 = 10005,

    _watchOS_GPUFamily1_v1 = 20000,

    _WatchOS_GPUFamily1_v1 = 20000,

    _watchOS_GPUFamily2_v1 = 20001,

    _WatchOS_GPUFamily2_v1 = 20001,

    _tvOS_GPUFamily1_v1 = 30000,

    _TVOS_GPUFamily1_v1 = 30000,

    _tvOS_GPUFamily1_v2 = 30001,

    _tvOS_GPUFamily1_v3 = 30002,

    _tvOS_GPUFamily2_v1 = 30003,

    _tvOS_GPUFamily1_v4 = 30004,

    _tvOS_GPUFamily2_v2 = 30005
}

/// <summary>
/// Options for different kinds of function logs.
/// </summary>
public enum MTLFunctionLogType : ulong
{
    /// <summary>
    /// A message related to usage validation.
    /// </summary>
    Validation = 0
}

/// <summary>
/// Options that define how Metal compiles a GPU function.
/// </summary>
[Flags]
public enum MTLFunctionOptions : ulong
{
    None = 0,

    /// <summary>
    /// An option that instructs the compiler to generate a binary format for dynamic linking.
    /// </summary>
    CompileToBinary = 1,

    /// <summary>
    /// An option that instructs the compiler to store function information for inspecting binary archives.
    /// </summary>
    StoreFunctionInMetalPipelinesScript = 2,

    /// <summary>
    /// An option that instructs the compiler to store function information for inspecting binary archives.
    /// </summary>
    [Obsolete("Use storeFunctionInMetalPipelinesScript instead.")]
    StoreFunctionInMetalScript = 2,

    /// <summary>
    /// An option that instructs the compiler to return an error when a GPU function isn’t in a binary archive.
    /// </summary>
    FailOnBinaryArchiveMiss = 4,

    /// <summary>
    /// An option that generates the same function handle across all pipeline states that link a function, which lets you share function tables across pipeline states.
    /// </summary>
    PipelineIndependent = 8
}

/// <summary>
/// The type of a top-level Metal Shading Language (MSL) function.
/// </summary>
public enum MTLFunctionType : ulong
{
    /// <summary>
    /// A vertex function you can use in a render pipeline state object.
    /// </summary>
    Vertex = 1,

    /// <summary>
    /// A fragment function you can use in a render pipeline state object.
    /// </summary>
    Fragment = 2,

    /// <summary>
    /// A kernel you can use in a compute pipeline state object.
    /// </summary>
    Kernel = 3,

    /// <summary>
    /// A function you can use in a visible function table.
    /// </summary>
    Visible = 5,

    /// <summary>
    /// A function you can use in an intersection function table.
    /// </summary>
    Intersection = 6,

    Mesh = 7,

    Object = 8
}

/// <summary>
/// Represents the functionality for families of GPUs.
/// </summary>
public enum MTLGPUFamily : long
{
    /// <summary>
    /// Represents the Apple family 1 GPU features that correspond to the Apple A7 GPUs.
    /// </summary>
    Apple1 = 1001,

    /// <summary>
    /// Represents the Apple family 2 GPU features that correspond to the Apple A8 GPUs.
    /// </summary>
    Apple2 = 1002,

    /// <summary>
    /// Represents the Apple family 3 GPU features that correspond to the Apple A9 and A10 GPUs.
    /// </summary>
    Apple3 = 1003,

    /// <summary>
    /// Represents the Apple family 4 GPU features that correspond to the Apple A11 GPUs.
    /// </summary>
    Apple4 = 1004,

    /// <summary>
    /// Represents the Apple family 5 GPU features that correspond to the Apple A12 GPUs.
    /// </summary>
    Apple5 = 1005,

    /// <summary>
    /// Represents the Apple family 6 GPU features that correspond to the Apple A13 GPUs.
    /// </summary>
    Apple6 = 1006,

    /// <summary>
    /// Represents the Apple family 7 GPU features that correspond to the Apple A14 and M1 GPUs.
    /// </summary>
    Apple7 = 1007,

    /// <summary>
    /// Represents the Apple family 8 GPU features that correspond to the Apple A15, A16, and M2 GPUs.
    /// </summary>
    Apple8 = 1008,

    /// <summary>
    /// Represents the Apple family 9 GPU features that correspond to the Apple A17, M3, and M4 GPUs.
    /// </summary>
    Apple9 = 1009,

    Apple10 = 1010,

    /// <summary>
    /// Represents the Mac family 1 GPU features.
    /// </summary>
    [Obsolete("Use MTLGPUFamily.mac2 instead.")]
    Mac1 = 2001,

    /// <summary>
    /// Represents the Mac family 2 GPU features.
    /// </summary>
    Mac2 = 2002,

    /// <summary>
    /// Represents the Common family 1 GPU features.
    /// </summary>
    Common1 = 3001,

    /// <summary>
    /// Represents the Common family 2 GPU features.
    /// </summary>
    Common2 = 3002,

    /// <summary>
    /// Represents the Common family 3 GPU features.
    /// </summary>
    Common3 = 3003,

    /// <summary>
    /// Represents a family 1 Mac GPU when running an app you built with Mac Catalyst.
    /// </summary>
    [Obsolete("Use MTLGPUFamily.mac2 instead.")]
    MacCatalyst1 = 4001,

    /// <summary>
    /// Represents a family 2 Mac GPU when running an app you built with Mac Catalyst.
    /// </summary>
    [Obsolete("Use MTLGPUFamily.mac2 instead.")]
    MacCatalyst2 = 4002,

    /// <summary>
    /// Represents the Metal 3 features.
    /// </summary>
    Metal3 = 5001,

    Metal4 = 5002
}

/// <summary>
/// Options that control whether Metal automatically tracks and prevents memory hazards for resources.
/// </summary>
public enum MTLHazardTrackingMode : ulong
{
    /// <summary>
    /// An option that applies the default tracking behavior in Metal based on the resource or heap type you’re creating.
    /// </summary>
    Default = 0,

    /// <summary>
    /// An option that disables automatic memory hazard tracking in Metal for a resource at runtime.
    /// </summary>
    Untracked = 1,

    /// <summary>
    /// An option that directs Metal to apply runtime safeguards that prevent memory hazards when commands access a resource.
    /// </summary>
    Tracked = 2
}

/// <summary>
/// The options you use to choose the heap type.
/// </summary>
public enum MTLHeapType : long
{
    /// <summary>
    /// A heap that automatically places new resource allocations.
    /// </summary>
    Automatic = 0,

    /// <summary>
    /// The app controls placement of resources on the heap.
    /// </summary>
    Placement = 1,

    /// <summary>
    /// The heap contains sparse texture tiles.
    /// </summary>
    Sparse = 2
}

/// <summary>
/// The index type for an index buffer that references vertices of geometric primitives.
/// </summary>
public enum MTLIndexType : ulong
{
    /// <summary>
    /// A 16-bit unsigned integer used as a primitive index.
    /// </summary>
    UInt16 = 0,

    /// <summary>
    /// A 32-bit unsigned integer used as a primitive index.
    /// </summary>
    UInt32 = 1
}

/// <summary>
/// The types of commands that you can encode into the indirect command buffer.
/// </summary>
[Flags]
public enum MTLIndirectCommandType : ulong
{
    /// <summary>
    /// A draw call command.
    /// </summary>
    Draw = 1,

    /// <summary>
    /// An indexed draw call command.
    /// </summary>
    DrawIndexed = 2,

    /// <summary>
    /// A draw call command for tessellated patches.
    /// </summary>
    DrawPatches = 4,

    /// <summary>
    /// An indexed draw call command for tessellated patches.
    /// </summary>
    DrawIndexedPatches = 8,

    /// <summary>
    /// A compute command using a grid aligned to threadgroup boundaries.
    /// </summary>
    ConcurrentDispatch = 32,

    /// <summary>
    /// A compute command using an arbitrarily sized grid.
    /// </summary>
    ConcurrentDispatchThreads = 64,

    DrawMeshThreadgroups = 128,

    DrawMeshThreads = 256
}

/// <summary>
/// Constants for specifying different types of custom intersection functions.
/// </summary>
[Flags]
public enum MTLIntersectionFunctionSignature : ulong
{
    None = 0,

    /// <summary>
    /// A flag indicating that function signature uses instancing.
    /// </summary>
    Instancing = 1,

    /// <summary>
    /// A flag indicating that function signature uses triangle data.
    /// </summary>
    TriangleData = 2,

    /// <summary>
    /// A flag indicating that function signature uses world space data.
    /// </summary>
    WorldSpaceData = 4,

    InstanceMotion = 8,

    PrimitiveMotion = 16,

    ExtendedLimits = 32,

    MaxLevels = 64,

    CurveData = 128,

    IntersectionFunctionBuffer = 256,

    UserData = 512
}

/// <summary>
/// Designates the queue type for a new input/output command queue.
/// </summary>
public enum MTLIOCommandQueueType : long
{
    /// <summary>
    /// Sets a new input/output command queue’s type to a queue that runs commands concurrently.
    /// </summary>
    Concurrent = 0,

    /// <summary>
    /// Sets a new input/output command queue’s type to a queue that runs commands serially.
    /// </summary>
    Serial = 1
}

/// <summary>
/// The compression codecs that Metal supports for input/output handles.
/// </summary>
public enum MTLIOCompressionMethod : long
{
    /// <summary>
    /// Indicates that a file uses the zlib compression algorithm codec.
    /// </summary>
    Zlib = 0,

    /// <summary>
    /// Indicates that a file uses the LZFSE compression algorithm codec.
    /// </summary>
    LZFSE = 1,

    /// <summary>
    /// Indicates that a file uses the LZ4 compression algorithm codec.
    /// </summary>
    LZ4 = 2,

    /// <summary>
    /// Indicates that a file uses the LZMA compression algorithm codec.
    /// </summary>
    LZMA = 3,

    /// <summary>
    /// Indicates that a file uses the LZBitmap compression algorithm codec.
    /// </summary>
    LZBitmap = 4
}

/// <summary>
/// The categories of errors for creating an input/output file handle.
/// </summary>
public enum MTLIOError : long
{
    /// <summary>
    /// An error that represents a problem with a file URL.
    /// </summary>
    URLInvalid = 1,

    /// <summary>
    /// An error that represents a problem internal to the Metal framework.
    /// </summary>
    Internal = 2
}

/// <summary>
/// Designates the priority for a new input/output command queue.
/// </summary>
public enum MTLIOPriority : long
{
    /// <summary>
    /// Sets a new input/output command queue’s priority to a high priority.
    /// </summary>
    High = 0,

    /// <summary>
    /// Designates the normal priority for a new input/output command queue.
    /// </summary>
    Normal = 1,

    /// <summary>
    /// Designates the low priority for a new input/output command queue.
    /// </summary>
    Low = 2
}

/// <summary>
/// Represents the state of an input/output command buffer.
/// </summary>
public enum MTLIOStatus : long
{
    /// <summary>
    /// Indicates the GPU hasn’t finished executing the input/output command buffer.
    /// </summary>
    Pending = 0,

    /// <summary>
    /// Indicates the GPU has successfully abandoned the input/output command buffer.
    /// </summary>
    Cancelled = 1,

    /// <summary>
    /// Indicates the GPU experienced a problem with the input/output command buffer.
    /// </summary>
    Error = 2,

    /// <summary>
    /// Indicates the GPU has successfully finished executing the input/output command buffer.
    /// </summary>
    Complete = 3
}

/// <summary>
/// Metal shading language versions.
/// </summary>
public enum MTLLanguageVersion : ulong
{
    MTL1_0 = 65536,

    MTL1_1 = 65537,

    MTL1_2 = 65538,

    MTL2_0 = 131072,

    MTL2_1 = 131073,

    MTL2_2 = 131074,

    MTL2_3 = 131075,

    MTL2_4 = 131076,

    MTL3_0 = 196608,

    MTL3_1 = 196609,

    MTL3_2 = 196610,

    MTL4_0 = 262144
}

/// <summary>
/// Metal errors related to libraries.
/// </summary>
public enum MTLLibraryError : ulong
{
    /// <summary>
    /// Metal couldn’t support the requested action.
    /// </summary>
    Unsupported = 1,

    /// <summary>
    /// The action caused an internal error.
    /// </summary>
    Internal = 2,

    /// <summary>
    /// The library or function failed to compile.
    /// </summary>
    CompileFailure = 3,

    /// <summary>
    /// The library or function compiled successfully but generated warnings.
    /// </summary>
    CompileWarning = 4,

    /// <summary>
    /// Metal couldn’t find the specified Metal function.
    /// </summary>
    FunctionNotFound = 5,

    /// <summary>
    /// Metal couldn’t find the Metal source file.
    /// </summary>
    FileNotFound = 6
}

/// <summary>
/// The optimization options for the Metal compiler.
/// </summary>
public enum MTLLibraryOptimizationLevel : long
{
    /// <summary>
    /// An optimization option for the Metal compiler that prioritizes runtime performance.
    /// </summary>
    Default = 0,

    /// <summary>
    /// An optimization option for the Metal compiler that prioritizes minimizing the size of its output binaries, which may also reduce compile time.
    /// </summary>
    Size = 1
}

/// <summary>
/// A set of options for Metal library types.
/// </summary>
public enum MTLLibraryType : long
{
    /// <summary>
    /// A library that can create pipeline state objects.
    /// </summary>
    Executable = 0,

    /// <summary>
    /// A library that you can dynamically link to from other libraries.
    /// </summary>
    Dynamic = 1
}

/// <summary>
/// Types of actions performed for an attachment at the start of a rendering pass.
/// </summary>
public enum MTLLoadAction : ulong
{
    /// <summary>
    /// The GPU has permission to discard the existing contents of the attachment at the start of the render pass, replacing them with arbitrary data.
    /// </summary>
    DontCare = 0,

    /// <summary>
    /// The GPU preserves the existing contents of the attachment at the start of the render pass.
    /// </summary>
    Load = 1,

    /// <summary>
    /// The GPU writes a value to every pixel in the attachment at the start of the render pass.
    /// </summary>
    Clear = 2
}

/// <summary>
/// The supported log levels for shader logging.
/// </summary>
public enum MTLLogLevel : long
{
    /// <summary>
    /// The log level when the log level hasn’t been configured.
    /// </summary>
    Undefined = 0,

    /// <summary>
    /// The log level that captures diagnostic information.
    /// </summary>
    Debug = 1,

    /// <summary>
    /// The log level that captures additional information.
    /// </summary>
    Info = 2,

    /// <summary>
    /// The log level that captures notifications.
    /// </summary>
    Notice = 3,

    /// <summary>
    /// The log level that captures error information.
    /// </summary>
    Error = 4,

    /// <summary>
    /// The log level that captures fault information.
    /// </summary>
    Fault = 5
}

public enum MTLLogStateError : ulong
{
    InvalidSize = 1,

    Invalid = 2
}

/// <summary>
/// Indicates which FP32 math functions Metal uses.
/// </summary>
public enum MTLMathFloatingPointFunctions : long
{
    /// <summary>
    /// An indication that Metal uses the fast version of the 32b floating-point math functions.
    /// </summary>
    Fast = 0,

    /// <summary>
    /// An indication that Metal uses the precise version of the 32b floating-point math functions.
    /// </summary>
    Precise = 1
}

/// <summary>
/// An indication of whether the compiler can perform optimizations for floating-point arithmetic that may violate the IEEE 754 standard.
/// </summary>
public enum MTLMathMode : long
{
    /// <summary>
    /// An indicator of the mode the compiler uses to disable unsafe floating-point optimizations by preventing the compiler from making any transformations that could affect the results.
    /// </summary>
    Safe = 0,

    /// <summary>
    /// An indicator of the mode the compiler uses to make aggressive, potentially lossy assumptions about floating-point math, while honoring Inf/NaN.
    /// </summary>
    Relaxed = 1,

    /// <summary>
    /// An indicator of the mode the compiler uses to make aggressive, potentially lossy assumptions about floating-point math.
    /// </summary>
    Fast = 2
}

public enum MTLMatrixLayout : long
{
    ColumnMajor = 0,

    RowMajor = 1
}

/// <summary>
/// Options for specifying how the acceleration structure handles timestamps that are outside the specified range.
/// </summary>
public enum MTLMotionBorderMode : uint
{
    /// <summary>
    /// A mode that specifies treating times outside the specified endpoint as if they were at the endpoint.
    /// </summary>
    Clamp = 0,

    /// <summary>
    /// A mode that specifies that times outside the specified endpoint need to prevent any ray-intersections with the primitive.
    /// </summary>
    Vanish = 1
}

/// <summary>
/// Filtering options for controlling an MSAA depth resolve operation.
/// </summary>
public enum MTLMultisampleDepthResolveFilter : ulong
{
    /// <summary>
    /// No filter is applied.
    /// </summary>
    Sample0 = 0,

    /// <summary>
    /// The GPU compares all depth samples in the pixel and selects the sample with the smallest value.
    /// </summary>
    Min = 1,

    /// <summary>
    /// The GPU compares all depth samples in the pixel and selects the sample with the largest value.
    /// </summary>
    Max = 2
}

/// <summary>
/// Constants used to control the multisample stencil resolve operation.
/// </summary>
public enum MTLMultisampleStencilResolveFilter : ulong
{
    /// <summary>
    /// Chooses the first stencil sample in the pixel.
    /// </summary>
    Sample0 = 0,

    /// <summary>
    /// Chooses the stencil sample corresponding to the depth sample selected by the depth resolve filter.
    /// </summary>
    DepthResolvedSample = 1
}

/// <summary>
/// The options that determine the mutability of a buffer’s contents.
/// </summary>
public enum MTLMutability : ulong
{
    /// <summary>
    /// The default behavior, based on the buffer’s type.
    /// </summary>
    Default = 0,

    /// <summary>
    /// An option that states that you can modify the buffer’s contents.
    /// </summary>
    Mutable = 1,

    /// <summary>
    /// An option that states that you can’t modify the buffer’s contents.
    /// </summary>
    Immutable = 2
}

/// <summary>
/// Types of tessellation patches that can be inputs of a post-tessellation vertex function.
/// </summary>
public enum MTLPatchType : ulong
{
    /// <summary>
    /// An option that indicates that this isn’t a post-tessellation vertex function.
    /// </summary>
    None = 0,

    /// <summary>
    /// A triangle patch.
    /// </summary>
    Triangle = 1,

    /// <summary>
    /// A quad patch.
    /// </summary>
    Quad = 2
}

/// <summary>
/// Options that determine how Metal prepares the pipeline.
/// </summary>
[Flags]
public enum MTLPipelineOption : ulong
{
    None = 0,

    /// <summary>
    /// An option instance that provides argument information for textures and threadgroup memory.
    /// </summary>
    [Obsolete]
    ArgumentInfo = 1,

    /// <summary>
    /// An option that provides binding information for pipeline state resources.
    /// </summary>
    BindingInfo = 1,

    /// <summary>
    /// An option instance that provides detailed buffer type information for buffer arguments.
    /// </summary>
    BufferTypeInfo = 2,

    /// <summary>
    /// An option that instructs the compiler to return an error when a GPU function isn’t in a binary archive.
    /// </summary>
    FailOnBinaryArchiveMiss = 4
}

/// <summary>
/// The data formats that describe the organization and characteristics of individual pixels in a texture.
/// </summary>
public enum MTLPixelFormat : ulong
{
    /// <summary>
    /// The default value of the pixel format for the MTLRenderPipelineState. You cannot create a texture with this value.
    /// </summary>
    Invalid = 0,

    /// <summary>
    /// Ordinary format with one 8-bit normalized unsigned integer component.
    /// </summary>
    A8Unorm = 1,

    /// <summary>
    /// Ordinary format with one 8-bit normalized unsigned integer component.
    /// </summary>
    R8Unorm = 10,

    /// <summary>
    /// Ordinary format with one 8-bit normalized unsigned integer component with conversion between sRGB and linear space.
    /// </summary>
    R8Unorm_sRGB = 11,

    /// <summary>
    /// Ordinary format with one 8-bit normalized signed integer component.
    /// </summary>
    R8Snorm = 12,

    /// <summary>
    /// Ordinary format with one 8-bit unsigned integer component.
    /// </summary>
    R8Uint = 13,

    /// <summary>
    /// Ordinary format with one 8-bit signed integer component.
    /// </summary>
    R8Sint = 14,

    /// <summary>
    /// Ordinary format with one 16-bit normalized unsigned integer component.
    /// </summary>
    R16Unorm = 20,

    /// <summary>
    /// Ordinary format with one 16-bit normalized signed integer component.
    /// </summary>
    R16Snorm = 22,

    /// <summary>
    /// Ordinary format with one 16-bit unsigned integer component.
    /// </summary>
    R16Uint = 23,

    /// <summary>
    /// Ordinary format with one 16-bit signed integer component.
    /// </summary>
    R16Sint = 24,

    /// <summary>
    /// Ordinary format with one 16-bit floating-point component.
    /// </summary>
    R16Float = 25,

    /// <summary>
    /// Ordinary format with two 8-bit normalized unsigned integer components.
    /// </summary>
    RG8Unorm = 30,

    /// <summary>
    /// Ordinary format with two 8-bit normalized unsigned integer components with conversion between sRGB and linear space.
    /// </summary>
    RG8Unorm_sRGB = 31,

    /// <summary>
    /// Ordinary format with two 8-bit normalized signed integer components.
    /// </summary>
    RG8Snorm = 32,

    /// <summary>
    /// Ordinary format with two 8-bit unsigned integer components.
    /// </summary>
    RG8Uint = 33,

    /// <summary>
    /// Ordinary format with two 8-bit signed integer components.
    /// </summary>
    RG8Sint = 34,

    /// <summary>
    /// Packed 16-bit format with normalized unsigned integer color components: 5 bits for blue, 6 bits for green, 5 bits for red, packed into 16 bits.
    /// </summary>
    B5G6R5Unorm = 40,

    /// <summary>
    /// Packed 16-bit format with normalized unsigned integer color components: 5 bits each for BGR and 1 for alpha, packed into 16 bits.
    /// </summary>
    A1BGR5Unorm = 41,

    /// <summary>
    /// Packed 16-bit format with normalized unsigned integer color components: 4 bits each for ABGR, packed into 16 bits.
    /// </summary>
    ABGR4Unorm = 42,

    /// <summary>
    /// Packed 16-bit format with normalized unsigned integer color components: 5 bits each for BGR and 1 for alpha, packed into 16 bits.
    /// </summary>
    BGR5A1Unorm = 43,

    /// <summary>
    /// Ordinary format with one 32-bit unsigned integer component.
    /// </summary>
    R32Uint = 53,

    /// <summary>
    /// Ordinary format with one 32-bit signed integer component.
    /// </summary>
    R32Sint = 54,

    /// <summary>
    /// Ordinary format with one 32-bit floating-point component.
    /// </summary>
    R32Float = 55,

    /// <summary>
    /// Ordinary format with two 16-bit normalized unsigned integer components.
    /// </summary>
    RG16Unorm = 60,

    /// <summary>
    /// Ordinary format with two 16-bit normalized signed integer components.
    /// </summary>
    RG16Snorm = 62,

    /// <summary>
    /// Ordinary format with two 16-bit unsigned integer components.
    /// </summary>
    RG16Uint = 63,

    /// <summary>
    /// Ordinary format with two 16-bit signed integer components.
    /// </summary>
    RG16Sint = 64,

    /// <summary>
    /// Ordinary format with two 16-bit floating-point components.
    /// </summary>
    RG16Float = 65,

    /// <summary>
    /// Ordinary format with four 8-bit normalized unsigned integer components in RGBA order.
    /// </summary>
    RGBA8Unorm = 70,

    /// <summary>
    /// Ordinary format with four 8-bit normalized unsigned integer components in RGBA order with conversion between sRGB and linear space.
    /// </summary>
    RGBA8Unorm_sRGB = 71,

    /// <summary>
    /// Ordinary format with four 8-bit normalized signed integer components in RGBA order.
    /// </summary>
    RGBA8Snorm = 72,

    /// <summary>
    /// Ordinary format with four 8-bit unsigned integer components in RGBA order.
    /// </summary>
    RGBA8Uint = 73,

    /// <summary>
    /// Ordinary format with four 8-bit signed integer components in RGBA order.
    /// </summary>
    RGBA8Sint = 74,

    /// <summary>
    /// Ordinary format with four 8-bit normalized unsigned integer components in BGRA order.
    /// </summary>
    BGRA8Unorm = 80,

    /// <summary>
    /// Ordinary format with four 8-bit normalized unsigned integer components in BGRA order with conversion between sRGB and linear space.
    /// </summary>
    BGRA8Unorm_sRGB = 81,

    /// <summary>
    /// A 32-bit packed pixel format with four normalized unsigned integer components: 10-bit red, 10-bit green, 10-bit blue, and 2-bit alpha.
    /// </summary>
    RGB10A2Unorm = 90,

    /// <summary>
    /// A 32-bit packed pixel format with four unsigned integer components: 10-bit red, 10-bit green, 10-bit blue, and 2-bit alpha.
    /// </summary>
    RGB10A2Uint = 91,

    /// <summary>
    /// 32-bit format with floating-point color components, 11 bits each for red and green and 10 bits for blue.
    /// </summary>
    RG11B10Float = 92,

    /// <summary>
    /// Packed 32-bit format with floating-point color components: 9 bits each for RGB and 5 bits for an exponent shared by RGB, packed into 32 bits.
    /// </summary>
    RGB9E5Float = 93,

    /// <summary>
    /// A 32-bit packed pixel format with four normalized unsigned integer components: 10-bit blue, 10-bit green, 10-bit red, and 2-bit alpha.
    /// </summary>
    BGR10A2Unorm = 94,

    /// <summary>
    /// A 32-bit extended-range pixel format with three fixed-point components of 10-bit blue, 10-bit green, and 10-bit red.
    /// </summary>
    BGR10_XR = 554,

    /// <summary>
    /// A 32-bit extended-range pixel format with sRGB conversion and three fixed-point components of 10-bit blue, 10-bit green, and 10-bit red.
    /// </summary>
    BGR10_XR_sRGB = 555,

    /// <summary>
    /// Ordinary format with two 32-bit unsigned integer components.
    /// </summary>
    RG32Uint = 103,

    /// <summary>
    /// Ordinary format with two 32-bit signed integer components.
    /// </summary>
    RG32Sint = 104,

    /// <summary>
    /// Ordinary format with two 32-bit floating-point components.
    /// </summary>
    RG32Float = 105,

    /// <summary>
    /// Ordinary format with four 16-bit normalized unsigned integer components in RGBA order.
    /// </summary>
    RGBA16Unorm = 110,

    /// <summary>
    /// Ordinary format with four 16-bit normalized signed integer components in RGBA order.
    /// </summary>
    RGBA16Snorm = 112,

    /// <summary>
    /// Ordinary format with four 16-bit unsigned integer components in RGBA order.
    /// </summary>
    RGBA16Uint = 113,

    /// <summary>
    /// Ordinary format with four 16-bit signed integer components in RGBA order.
    /// </summary>
    RGBA16Sint = 114,

    /// <summary>
    /// Ordinary format with four 16-bit floating-point components in RGBA order.
    /// </summary>
    RGBA16Float = 115,

    /// <summary>
    /// A 64-bit extended-range pixel format with four fixed-point components of 10-bit blue, 10-bit green, 10-bit red, and 10-bit alpha.
    /// </summary>
    BGRA10_XR = 552,

    /// <summary>
    /// A 64-bit extended-range pixel format with sRGB conversion and four fixed-point components of 10-bit blue, 10-bit green, 10-bit red, and 10-bit alpha.
    /// </summary>
    BGRA10_XR_sRGB = 553,

    /// <summary>
    /// Ordinary format with four 32-bit unsigned integer components in RGBA order.
    /// </summary>
    RGBA32Uint = 123,

    /// <summary>
    /// Ordinary format with four 32-bit signed integer components in RGBA order.
    /// </summary>
    RGBA32Sint = 124,

    /// <summary>
    /// Ordinary format with four 32-bit floating-point components in RGBA order.
    /// </summary>
    RGBA32Float = 125,

    /// <summary>
    /// Compressed format with two 16-bit color components and one 32-bit descriptor component.
    /// </summary>
    BC1_RGBA = 130,

    /// <summary>
    /// Compressed format with two 16-bit color components and one 32-bit descriptor component, with conversion between sRGB and linear space.
    /// </summary>
    BC1_RGBA_sRGB = 131,

    /// <summary>
    /// Compressed format with two 64-bit chunks. The first chunk contains two 8-bit alpha components and one 48-bit descriptor component. The second chunk contains two 16-bit color components and one 32-bit descriptor component.
    /// </summary>
    BC2_RGBA = 132,

    /// <summary>
    /// Compressed format with two 64-bit chunks, with conversion between sRGB and linear space. The first chunk contains two 8-bit alpha components and one 48-bit descriptor component. The second chunk contains two 16-bit color components and one 32-bit descriptor component.
    /// </summary>
    BC2_RGBA_sRGB = 133,

    /// <summary>
    /// Compressed format with two 64-bit chunks. The first chunk contains two 8-bit alpha components and one 48-bit descriptor component. The second chunk contains two 16-bit color components and one 32-bit descriptor component.
    /// </summary>
    BC3_RGBA = 134,

    /// <summary>
    /// Compressed format with two 64-bit chunks, with conversion between sRGB and linear space. The first chunk contains two 8-bit alpha components and one 48-bit descriptor component. The second chunk contains two 16-bit color components and one 32-bit descriptor component.
    /// </summary>
    BC3_RGBA_sRGB = 135,

    /// <summary>
    /// Compressed format with one normalized unsigned integer component.
    /// </summary>
    BC4_RUnorm = 140,

    /// <summary>
    /// Compressed format with one normalized signed integer component.
    /// </summary>
    BC4_RSnorm = 141,

    /// <summary>
    /// Compressed format with two normalized unsigned integer components.
    /// </summary>
    BC5_RGUnorm = 142,

    /// <summary>
    /// Compressed format with two normalized signed integer components.
    /// </summary>
    BC5_RGSnorm = 143,

    /// <summary>
    /// Compressed format with four floating-point components.
    /// </summary>
    BC6H_RGBFloat = 150,

    /// <summary>
    /// Compressed format with four unsigned floating-point components.
    /// </summary>
    BC6H_RGBUfloat = 151,

    /// <summary>
    /// Compressed format with four normalized unsigned integer components.
    /// </summary>
    BC7_RGBAUnorm = 152,

    /// <summary>
    /// Compressed format with four normalized unsigned integer components, with conversion between sRGB and linear space.
    /// </summary>
    BC7_RGBAUnorm_sRGB = 153,

    /// <summary>
    /// A compressed format that uses PVRTC compression and 2bpp for RGB components.
    /// </summary>
    [Obsolete("Use one of the other formats with astc/ASTC, etc2/ETC2, or bc/BC instead.")]
    PVRTC_RGB_2BPP = 160,

    /// <summary>
    /// A compressed format that uses PVRTC compression and 2bpp for RGB components with a conversion between sRGB and linear space.
    /// </summary>
    [Obsolete("Use one of the other formats with astc/ASTC, etc2/ETC2, or bc/BC instead.")]
    PVRTC_RGB_2BPP_sRGB = 161,

    /// <summary>
    /// A compressed format that uses PVRTC compression and 4bpp for RGB components.
    /// </summary>
    [Obsolete("Use one of the other formats with astc/ASTC, etc2/ETC2, or bc/BC instead.")]
    PVRTC_RGB_4BPP = 162,

    /// <summary>
    /// A compressed format that uses PVRTC compression and 4bpp for RGB components with a conversion between sRGB and linear space.
    /// </summary>
    [Obsolete("Use one of the other formats with astc/ASTC, etc2/ETC2, or bc/BC instead.")]
    PVRTC_RGB_4BPP_sRGB = 163,

    /// <summary>
    /// A compressed format that uses PVRTC compression and 2bpp for RGBA components.
    /// </summary>
    [Obsolete("Use one of the other formats with astc/ASTC, etc2/ETC2, or bc/BC instead.")]
    PVRTC_RGBA_2BPP = 164,

    /// <summary>
    /// A compressed format that uses PVRTC compression and 2bpp for RGBA components with a conversion between sRGB and linear space.
    /// </summary>
    [Obsolete("Use one of the other formats with astc/ASTC, etc2/ETC2, or bc/BC instead.")]
    PVRTC_RGBA_2BPP_sRGB = 165,

    /// <summary>
    /// A compressed format that uses PVRTC compression and 4bpp for RGBA components.
    /// </summary>
    [Obsolete("Use one of the other formats with astc/ASTC, etc2/ETC2, or bc/BC instead.")]
    PVRTC_RGBA_4BPP = 166,

    /// <summary>
    /// A compressed format that uses PVRTC compression and 4bpp for RGBA components with a conversion between sRGB and linear space.
    /// </summary>
    [Obsolete("Use one of the other formats with astc/ASTC, etc2/ETC2, or bc/BC instead.")]
    PVRTC_RGBA_4BPP_sRGB = 167,

    /// <summary>
    /// Compressed format using EAC compression with one normalized unsigned integer component.
    /// </summary>
    EAC_R11Unorm = 170,

    /// <summary>
    /// Compressed format using EAC compression with one normalized signed integer component.
    /// </summary>
    EAC_R11Snorm = 172,

    /// <summary>
    /// Compressed format using EAC compression with two normalized unsigned integer components.
    /// </summary>
    EAC_RG11Unorm = 174,

    /// <summary>
    /// Compressed format using EAC compression with two normalized signed integer components.
    /// </summary>
    EAC_RG11Snorm = 176,

    /// <summary>
    /// Compressed format using EAC compression with four 8-bit components.
    /// </summary>
    EAC_RGBA8 = 178,

    /// <summary>
    /// Compressed format using EAC compression with four 8-bit components with conversion between sRGB and linear space.
    /// </summary>
    EAC_RGBA8_sRGB = 179,

    /// <summary>
    /// Compressed format using ETC2 compression with three 8-bit components.
    /// </summary>
    ETC2_RGB8 = 180,

    /// <summary>
    /// Compressed format using ETC2 compression with three 8-bit components with conversion between sRGB and linear space.
    /// </summary>
    ETC2_RGB8_sRGB = 181,

    /// <summary>
    /// Compressed format using ETC2 compression with four 8-bit components.
    /// </summary>
    ETC2_RGB8A1 = 182,

    /// <summary>
    /// Compressed format using ETC2 compression with four 8-bit components with conversion between sRGB and linear space.
    /// </summary>
    ETC2_RGB8A1_sRGB = 183,

    /// <summary>
    /// ASTC-compressed format with low-dynamic-range content, conversion between sRGB and linear space, a block width of 4, and a block height of 4.
    /// </summary>
    ASTC_4x4_sRGB = 186,

    /// <summary>
    /// ASTC-compressed format with low-dynamic-range content, conversion between sRGB and linear space, a block width of 5, and a block height of 4.
    /// </summary>
    ASTC_5x4_sRGB = 187,

    /// <summary>
    /// ASTC-compressed format with low-dynamic-range content, conversion between sRGB and linear space, a block width of 5, and a block height of 5.
    /// </summary>
    ASTC_5x5_sRGB = 188,

    /// <summary>
    /// ASTC-compressed format with low-dynamic-range content, conversion between sRGB and linear space, a block width of 6, and a block height of 5.
    /// </summary>
    ASTC_6x5_sRGB = 189,

    /// <summary>
    /// ASTC-compressed format with low-dynamic-range content, conversion between sRGB and linear space, a block width of 6, and a block height of 6.
    /// </summary>
    ASTC_6x6_sRGB = 190,

    /// <summary>
    /// ASTC-compressed format with low-dynamic-range content, conversion between sRGB and linear space, a block width of 8, and a block height of 5.
    /// </summary>
    ASTC_8x5_sRGB = 192,

    /// <summary>
    /// ASTC-compressed format with low-dynamic-range content, conversion between sRGB and linear space, a block width of 8, and a block height of 6.
    /// </summary>
    ASTC_8x6_sRGB = 193,

    /// <summary>
    /// ASTC-compressed format with low-dynamic-range content, conversion between sRGB and linear space, a block width of 8, and a block height of 8.
    /// </summary>
    ASTC_8x8_sRGB = 194,

    /// <summary>
    /// ASTC-compressed format with low-dynamic-range content, conversion between sRGB and linear space, a block width of 10, and a block height of 5.
    /// </summary>
    ASTC_10x5_sRGB = 195,

    /// <summary>
    /// ASTC-compressed format with low-dynamic-range content, conversion between sRGB and linear space, a block width of 10, and a block height of 6.
    /// </summary>
    ASTC_10x6_sRGB = 196,

    /// <summary>
    /// ASTC-compressed format with low-dynamic-range content, conversion between sRGB and linear space, a block width of 10, and a block height of 8.
    /// </summary>
    ASTC_10x8_sRGB = 197,

    /// <summary>
    /// ASTC-compressed format with low-dynamic-range content, conversion between sRGB and linear space, a block width of 10, and a block height of 10.
    /// </summary>
    ASTC_10x10_sRGB = 198,

    /// <summary>
    /// ASTC-compressed format with low-dynamic-range content, conversion between sRGB and linear space, a block width of 12, and a block height of 10.
    /// </summary>
    ASTC_12x10_sRGB = 199,

    /// <summary>
    /// ASTC-compressed format with low-dynamic-range content, conversion between sRGB and linear space, a block width of 12, and a block height of 12.
    /// </summary>
    ASTC_12x12_sRGB = 200,

    /// <summary>
    /// ASTC-compressed format with low-dynamic-range content, a block width of 4, and a block height of 4.
    /// </summary>
    ASTC_4x4_LDR = 204,

    /// <summary>
    /// ASTC-compressed format with low-dynamic-range content, a block width of 5, and a block height of 4.
    /// </summary>
    ASTC_5x4_LDR = 205,

    /// <summary>
    /// ASTC-compressed format with low-dynamic-range content, a block width of 5, and a block height of 5.
    /// </summary>
    ASTC_5x5_LDR = 206,

    /// <summary>
    /// ASTC-compressed format with low-dynamic-range content, a block width of 6, and a block height of 5.
    /// </summary>
    ASTC_6x5_LDR = 207,

    /// <summary>
    /// ASTC-compressed format with low-dynamic-range content, a block width of 6, and a block height of 6.
    /// </summary>
    ASTC_6x6_LDR = 208,

    /// <summary>
    /// ASTC-compressed format with low-dynamic-range content, a block width of 8, and a block height of 5.
    /// </summary>
    ASTC_8x5_LDR = 210,

    /// <summary>
    /// ASTC-compressed format with low-dynamic-range content, a block width of 8, and a block height of 6.
    /// </summary>
    ASTC_8x6_LDR = 211,

    /// <summary>
    /// ASTC-compressed format with low-dynamic-range content, a block width of 8, and a block height of 8.
    /// </summary>
    ASTC_8x8_LDR = 212,

    /// <summary>
    /// ASTC-compressed format with low-dynamic-range content, a block width of 10, and a block height of 5.
    /// </summary>
    ASTC_10x5_LDR = 213,

    /// <summary>
    /// ASTC-compressed format with low-dynamic-range content, a block width of 10, and a block height of 6.
    /// </summary>
    ASTC_10x6_LDR = 214,

    /// <summary>
    /// ASTC-compressed format with low-dynamic-range content, a block width of 10, and a block height of 8.
    /// </summary>
    ASTC_10x8_LDR = 215,

    /// <summary>
    /// ASTC-compressed format with low-dynamic-range content, a block width of 10, and a block height of 10.
    /// </summary>
    ASTC_10x10_LDR = 216,

    /// <summary>
    /// ASTC-compressed format with low-dynamic-range content, a block width of 12, and a block height of 10.
    /// </summary>
    ASTC_12x10_LDR = 217,

    /// <summary>
    /// ASTC-compressed format with low-dynamic-range content, a block width of 12, and a block height of 12.
    /// </summary>
    ASTC_12x12_LDR = 218,

    /// <summary>
    /// ASTC-compressed format with high-dynamic-range content, a block width of 4, and a block height of 4.
    /// </summary>
    ASTC_4x4_HDR = 222,

    /// <summary>
    /// ASTC-compressed format with high-dynamic range content, a block width of 5, and a block height of 4.
    /// </summary>
    ASTC_5x4_HDR = 223,

    /// <summary>
    /// ASTC-compressed format with high-dynamic range content, a block width of 5, and a block height of 5.
    /// </summary>
    ASTC_5x5_HDR = 224,

    /// <summary>
    /// ASTC-compressed format with high-dynamic range content, a block width of 6, and a block height of 5.
    /// </summary>
    ASTC_6x5_HDR = 225,

    /// <summary>
    /// ASTC-compressed format with high-dynamic range content, a block width of 6, and a block height of 6.
    /// </summary>
    ASTC_6x6_HDR = 226,

    /// <summary>
    /// ASTC-compressed format with high-dynamic range content, a block width of 8, and a block height of 5.
    /// </summary>
    ASTC_8x5_HDR = 228,

    /// <summary>
    /// ASTC-compressed format with high-dynamic range content, a block width of 8, and a block height of 6.
    /// </summary>
    ASTC_8x6_HDR = 229,

    /// <summary>
    /// ASTC-compressed format with high-dynamic range content, a block width of 8, and a block height of 8.
    /// </summary>
    ASTC_8x8_HDR = 230,

    /// <summary>
    /// ASTC-compressed format with high-dynamic range content, a block width of 10, and a block height of 5.
    /// </summary>
    ASTC_10x5_HDR = 231,

    /// <summary>
    /// ASTC-compressed format with high-dynamic range content, a block width of 10, and a block height of 6.
    /// </summary>
    ASTC_10x6_HDR = 232,

    /// <summary>
    /// ASTC-compressed format with high-dynamic range content, a block width of 10, and a block height of 8.
    /// </summary>
    ASTC_10x8_HDR = 233,

    /// <summary>
    /// ASTC-compressed format with high-dynamic range content, a block width of 10, and a block height of 10.
    /// </summary>
    ASTC_10x10_HDR = 234,

    /// <summary>
    /// ASTC-compressed format with high-dynamic range content, a block width of 12, and a block height of 10.
    /// </summary>
    ASTC_12x10_HDR = 235,

    /// <summary>
    /// ASTC-compressed format with high-dynamic range content, a block width of 12, and a block height of 12.
    /// </summary>
    ASTC_12x12_HDR = 236,

    /// <summary>
    /// A pixel format where the red and green components are subsampled horizontally.
    /// </summary>
    GBGR422 = 240,

    /// <summary>
    /// A pixel format where the red and green components are subsampled horizontally.
    /// </summary>
    BGRG422 = 241,

    /// <summary>
    /// A pixel format for a depth-render target that has a 16-bit normalized, unsigned-integer component.
    /// </summary>
    Depth16Unorm = 250,

    /// <summary>
    /// A pixel format with one 32-bit floating-point component, used for a depth render target.
    /// </summary>
    Depth32Float = 252,

    /// <summary>
    /// A pixel format with an 8-bit unsigned integer component, used for a stencil render target.
    /// </summary>
    Stencil8 = 253,

    /// <summary>
    /// A 32-bit combined depth and stencil pixel format with a 24-bit normalized unsigned integer for depth and an 8-bit unsigned integer for stencil.
    /// </summary>
    Depth24Unorm_Stencil8 = 255,

    /// <summary>
    /// A 40-bit combined depth and stencil pixel format with a 32-bit floating-point value for depth and an 8-bit unsigned integer for stencil.
    /// </summary>
    Depth32Float_Stencil8 = 260,

    /// <summary>
    /// A stencil pixel format used to read the stencil value from a texture with a combined 32-bit depth and 8-bit stencil value.
    /// </summary>
    X32_Stencil8 = 261,

    /// <summary>
    /// A stencil pixel format used to read the stencil value from a texture with a combined 24-bit depth and 8-bit stencil value.
    /// </summary>
    X24_Stencil8 = 262,

    Unspecialized = 263
}

/// <summary>
/// The primitive topologies available for rendering.
/// </summary>
public enum MTLPrimitiveTopologyClass : ulong
{
    /// <summary>
    /// An unspecified primitive.
    /// </summary>
    Unspecified = 0,

    /// <summary>
    /// A point primitive.
    /// </summary>
    Point = 1,

    /// <summary>
    /// A line primitive.
    /// </summary>
    Line = 2,

    /// <summary>
    /// A triangle primitive.
    /// </summary>
    Triangle = 3
}

/// <summary>
/// The geometric primitive type for drawing commands.
/// </summary>
public enum MTLPrimitiveType : ulong
{
    /// <summary>
    /// Rasterize a point at each vertex. The vertex shader needs to provide [[point_size]], or the point size is undefined.
    /// </summary>
    Point = 0,

    /// <summary>
    /// Rasterize a line between each separate pair of vertices, resulting in a series of unconnected lines. If there are an odd number of vertices, the last vertex is ignored.
    /// </summary>
    Line = 1,

    /// <summary>
    /// Rasterize a line between each pair of adjacent vertices, resulting in a series of connected lines (also called a polyline).
    /// </summary>
    LineStrip = 2,

    /// <summary>
    /// For every separate set of three vertices, rasterize a triangle. If the number of vertices is not a multiple of three, either one or two vertices is ignored.
    /// </summary>
    Triangle = 3,

    /// <summary>
    /// For every three adjacent vertices, rasterize a triangle.
    /// </summary>
    TriangleStrip = 4
}

/// <summary>
/// The purgeable state of the resource.
/// </summary>
public enum MTLPurgeableState : ulong
{
    /// <summary>
    /// The current state is queried but doesn’t change.
    /// </summary>
    KeepCurrent = 1,

    /// <summary>
    /// The contents of the resource aren’t allowed to be discarded.
    /// </summary>
    NonVolatile = 2,

    /// <summary>
    /// The system is allowed to discard the resource to free up memory.
    /// </summary>
    Volatile = 3,

    /// <summary>
    /// A state that indicates to the system that it needs to consider the contents of a resource as invalid, typically because you’re discarding it.
    /// </summary>
    Empty = 4
}

/// <summary>
/// The support level for read-write texture formats.
/// </summary>
public enum MTLReadWriteTextureTier : ulong
{
    None = 0,

    MTL1 = 1,

    MTL2 = 2
}

/// <summary>
/// The stages in a render pass that triggers a synchronization command.
/// </summary>
[Flags]
public enum MTLRenderStages : ulong
{
    /// <summary>
    /// The vertex rendering stage.
    /// </summary>
    Vertex = 1,

    /// <summary>
    /// The fragment rendering stage.
    /// </summary>
    Fragment = 2,

    /// <summary>
    /// The tile rendering stage.
    /// </summary>
    Tile = 4,

    /// <summary>
    /// The object rendering stage.
    /// </summary>
    Object = 8,

    /// <summary>
    /// The mesh rendering stage.
    /// </summary>
    Mesh = 16
}

/// <summary>
/// Optional arguments used to set the behavior of a resource.
/// </summary>
[Flags]
public enum MTLResourceOptions : ulong
{
    CPUCacheModeDefaultCache = 0,

    /// <summary>
    /// A write-combined CPU cache mode that is optimized for resources that the CPU writes into, but never reads.
    /// </summary>
    CPUCacheModeWriteCombined = 1,

    /// <summary>
    /// The CPU and GPU share access to the resource, allocated in system memory.
    /// </summary>
    StorageModeShared = 0,

    /// <summary>
    /// The CPU and GPU may maintain separate copies of the resource, and any changes need to be explicitly synchronized.
    /// </summary>
    StorageModeManaged = 16,

    /// <summary>
    /// The resource is only available to the GPU.
    /// </summary>
    StorageModePrivate = 32,

    /// <summary>
    /// The resource’s contents are only available to the GPU, and only exist temporarily during a render pass.
    /// </summary>
    StorageModeMemoryless = 32,

    HazardTrackingModeDefault = 0,

    /// <summary>
    /// A resource option that instructs Metal to ignore memory hazards for a resource at runtime.
    /// </summary>
    HazardTrackingModeUntracked = 256,

    /// <summary>
    /// An option that instructs Metal to apply safeguards for a resource at runtime to avoid memory hazards for the applicable commands.
    /// </summary>
    HazardTrackingModeTracked = 512,

    OptionCPUCacheModeDefault = 0,

    /// <summary>
    /// This constant was deprecated in iOS 9.0 and macOS 10.11.
    /// </summary>
    [Obsolete("Use cpuCacheModeWriteCombined instead.")]
    OptionCPUCacheModeWriteCombined = 1
}

/// <summary>
/// Options that describe how a graphics or compute function uses an argument buffer’s resource.
/// </summary>
[Flags]
public enum MTLResourceUsage : ulong
{
    /// <summary>
    /// An option that enables reading from the resource.
    /// </summary>
    Read = 1,

    /// <summary>
    /// An option that enables writing to the resource.
    /// </summary>
    Write = 2,

    /// <summary>
    /// An option that enables sampling from the resource.
    /// </summary>
    [Obsolete]
    Sample = 4
}

/// <summary>
/// Modes that determine the texture coordinate at each pixel when a fetch falls outside the bounds of a texture.
/// </summary>
public enum MTLSamplerAddressMode : ulong
{
    /// <summary>
    /// Texture coordinates are clamped between 0.0 and 1.0, inclusive.
    /// </summary>
    ClampToEdge = 0,

    /// <summary>
    /// Between -1.0 and 1.0, the texture coordinates are mirrored across the axis; outside -1.0 and 1.0, texture coordinates are clamped.
    /// </summary>
    MirrorClampToEdge = 1,

    /// <summary>
    /// Texture coordinates wrap to the other side of the texture, effectively keeping only the fractional part of the texture coordinate.
    /// </summary>
    Repeat = 2,

    /// <summary>
    /// Between -1.0 and 1.0, the texture coordinates are mirrored across the axis; outside -1.0 and 1.0, the image is repeated.
    /// </summary>
    MirrorRepeat = 3,

    /// <summary>
    /// Out-of-range texture coordinates return transparent zero (0,0,0,0) for images with an alpha channel and return opaque zero (0,0,0,1) for images without an alpha channel.
    /// </summary>
    ClampToZero = 4,

    /// <summary>
    /// Out-of-range texture coordinates return the value specified by the  property.
    /// </summary>
    ClampToBorderColor = 5
}

/// <summary>
/// Values that determine the border color for clamped texture values when the sampler address mode is .
/// </summary>
public enum MTLSamplerBorderColor : ulong
{
    /// <summary>
    /// A transparent black color (0,0,0,0) for texture values outside the border.
    /// </summary>
    TransparentBlack = 0,

    /// <summary>
    /// An opaque black color (0,0,0,1) for texture values outside the border
    /// </summary>
    OpaqueBlack = 1,

    /// <summary>
    /// An opaque white color (1,1,1,1) for texture values outside the border.
    /// </summary>
    OpaqueWhite = 2
}

/// <summary>
/// Filtering options for determining which pixel value is returned within a mipmap level.
/// </summary>
public enum MTLSamplerMinMagFilter : ulong
{
    /// <summary>
    /// Select the single pixel nearest to the sample point.
    /// </summary>
    Nearest = 0,

    /// <summary>
    /// Select two pixels in each dimension and interpolate linearly between them.
    /// </summary>
    Linear = 1
}

/// <summary>
/// Filtering options for determining what pixel value is returned with multiple mipmap levels.
/// </summary>
public enum MTLSamplerMipFilter : ulong
{
    /// <summary>
    /// The texture is sampled from mipmap level 0, and other mipmap levels are ignored.
    /// </summary>
    NotMipmapped = 0,

    /// <summary>
    /// The nearest mipmap level is selected.
    /// </summary>
    Nearest = 1,

    /// <summary>
    /// If the filter falls between mipmap levels, both levels are sampled and the results are determined by linear interpolation between levels.
    /// </summary>
    Linear = 2
}

/// <summary>
/// Configures how the sampler aggregates contributing samples to a final value.
/// </summary>
public enum MTLSamplerReductionMode : ulong
{
    /// <summary>
    /// A reduction mode that adds together the product of each contributing sample value by its weight.
    /// </summary>
    WeightedAverage = 0,

    /// <summary>
    /// A reduction mode that finds the minimum contributing sample value by separately evaluating each channel.
    /// </summary>
    Minimum = 1,

    /// <summary>
    /// A reduction mode that finds the maximum contributing sample value by separately evaluating each channel.
    /// </summary>
    Maximum = 2
}

/// <summary>
/// Indicates whether shader validation in an enabled or disabled state, or neither state.
/// </summary>
public enum MTLShaderValidation : long
{
    /// <summary>
    /// The default value when the property isn’t set.
    /// </summary>
    Default = 0,

    /// <summary>
    /// Enables shader validation.
    /// </summary>
    Enabled = 1,

    /// <summary>
    /// Disables shader validation.
    /// </summary>
    Disabled = 2
}

/// <summary>
/// The page size options, in kilobytes, for sparse textures.
/// </summary>
public enum MTLSparsePageSize : long
{
    MTL16 = 101,

    MTL64 = 102,

    MTL256 = 103
}

/// <summary>
/// Options for sparse texture mapping.
/// </summary>
public enum MTLSparseTextureMappingMode : ulong
{
    /// <summary>
    /// A request to map sparse tiles from the heap to a region in the texture.
    /// </summary>
    Map = 0,

    /// <summary>
    /// A request to remove any mappings for a region in the texture.
    /// </summary>
    Unmap = 1
}

/// <summary>
/// Options used when converting between a pixel-based region within a texture to a tile-based region.
/// </summary>
public enum MTLSparseTextureRegionAlignmentMode : ulong
{
    /// <summary>
    /// The tile region includes any partially covered tiles.
    /// </summary>
    Outward = 0,

    /// <summary>
    /// The tile region ignores partially covered tiles.
    /// </summary>
    Inward = 1
}

/// <summary>
/// The segments of command execution within the Metal pass types.
/// </summary>
[Flags]
public enum MTLStages : ulong
{
    /// <summary>
    /// Represents all vertex shader stage work in a render pass.
    /// </summary>
    Vertex = 1,

    /// <summary>
    /// Represents all fragment shader stage work in a render pass.
    /// </summary>
    Fragment = 2,

    /// <summary>
    /// Represents all tile shading stage work in a render pass.
    /// </summary>
    Tile = 4,

    /// <summary>
    /// Represents all object shader stage work in a render pass.
    /// </summary>
    Object = 8,

    /// <summary>
    /// Represents all mesh shader stage work work in a render pass.
    /// </summary>
    Mesh = 16,

    /// <summary>
    /// Represents all sparse and placement sparse resource mapping updates.
    /// </summary>
    ResourceState = 67108864,

    /// <summary>
    /// Represents all compute dispatches in a compute pass.
    /// </summary>
    Dispatch = 134217728,

    /// <summary>
    /// Represents all blit operations in a pass.
    /// </summary>
    Blit = 268435456,

    /// <summary>
    /// Represents all acceleration structure operations.
    /// </summary>
    AccelerationStructure = 536870912,

    /// <summary>
    /// Represents all machine learning network dispatch operations.
    /// </summary>
    MachineLearning = 1073741824,

    /// <summary>
    /// Convenience mask representing all stages of GPU work.
    /// </summary>
    All = 9223372036854775807
}

/// <summary>
/// The operation performed on a currently stored stencil value when a comparison test passes or fails.
/// </summary>
public enum MTLStencilOperation : ulong
{
    /// <summary>
    /// A stencil operation that doesn’t modify a stencil value.
    /// </summary>
    Keep = 0,

    /// <summary>
    /// A stencil operation that sets a stencil value to zero.
    /// </summary>
    Zero = 1,

    /// <summary>
    /// A stencil operation that replaces a stencil value with a reference value.
    /// </summary>
    Replace = 2,

    /// <summary>
    /// A stencil operation that increases a stencil value by one, but only when the current value isn’t the maximum representable value.
    /// </summary>
    IncrementClamp = 3,

    /// <summary>
    /// A stencil operation that decreases a nonzero stencil value by one.
    /// </summary>
    DecrementClamp = 4,

    /// <summary>
    /// A stencil operation that applies a logical bitwise NOT to a stencil value.
    /// </summary>
    Invert = 5,

    /// <summary>
    /// A stencil operation that decreases a nonzero stencil value by one, or when it’s the maximum representable value, resets it to zero.
    /// </summary>
    IncrementWrap = 6,

    /// <summary>
    /// A stencil operation that decreases a nonzero stencil value by one, or when it’s zero, resets it to the maximum representable value.
    /// </summary>
    DecrementWrap = 7
}

/// <summary>
/// The frequency and locations at which a function fetches attribute data.
/// </summary>
public enum MTLStepFunction : ulong
{
    /// <summary>
    /// The function fetches attribute data once.
    /// </summary>
    Constant = 0,

    /// <summary>
    /// The vertex function fetches data for every vertex.
    /// </summary>
    PerVertex = 1,

    /// <summary>
    /// The function fetches data based on the instance index.
    /// </summary>
    PerInstance = 2,

    /// <summary>
    /// The post-tessellation function fetches data based on the patch index of the patch.
    /// </summary>
    PerPatch = 3,

    /// <summary>
    /// The post-tessellation function fetches data based on the control-point indices associated with the patch.
    /// </summary>
    PerPatchControlPoint = 4,

    /// <summary>
    /// The compute function fetches data based on the thread’s x coordinate.
    /// </summary>
    ThreadPositionInGridX = 5,

    /// <summary>
    /// The compute function fetches data based on the thread’s y coordinate.
    /// </summary>
    ThreadPositionInGridY = 6,

    /// <summary>
    /// The compute function fetches data by using the thread’s x coordinate to look up a value in the index buffer.
    /// </summary>
    ThreadPositionInGridXIndexed = 7,

    /// <summary>
    /// The compute function fetches data by using the thread’s y coordinate to look up a value in the index buffer.
    /// </summary>
    ThreadPositionInGridYIndexed = 8
}

[Flags]
public enum MTLStitchedLibraryOptions : ulong
{
    None = 0,

    /// <summary>
    /// An option that instructs the compiler to return an error when a GPU function for a stitched library isn’t in a binary archive.
    /// </summary>
    FailOnBinaryArchiveMiss = 1,

    StoreLibraryInMetalPipelinesScript = 2
}

/// <summary>
/// Options for the memory location and access permissions for a resource.
/// </summary>
public enum MTLStorageMode : ulong
{
    /// <summary>
    /// The CPU and GPU share access to the resource, allocated in system memory.
    /// </summary>
    Shared = 0,

    /// <summary>
    /// The CPU and GPU may maintain separate copies of the resource, and any changes need to be explicitly synchronized.
    /// </summary>
    Managed = 1,

    /// <summary>
    /// The resource is only available to the GPU.
    /// </summary>
    Private = 2,

    /// <summary>
    /// The resource’s contents are only available to the GPU, and only exist temporarily during a render pass.
    /// </summary>
    Memoryless = 3
}

/// <summary>
/// Types of actions performed for an attachment at the end of a rendering pass.
/// </summary>
public enum MTLStoreAction : ulong
{
    /// <summary>
    /// The GPU has permission to discard the rendered contents of the attachment at the end of the render pass, replacing them with arbitrary data.
    /// </summary>
    DontCare = 0,

    /// <summary>
    /// The GPU stores the rendered contents to the texture.
    /// </summary>
    Store = 1,

    /// <summary>
    /// The GPU resolves the multisampled data to one sample per pixel and stores the data to the resolve texture, discarding the multisample data afterwards.
    /// </summary>
    MultisampleResolve = 2,

    /// <summary>
    /// The GPU stores the multisample data to the multisample texture, resolves the data to a sample per pixel, and stores the data to the resolve texture.
    /// </summary>
    StoreAndMultisampleResolve = 3,

    /// <summary>
    /// The system selects a store action when it encodes the render pass.
    /// </summary>
    Unknown = 4,

    /// <summary>
    /// The GPU stores depth data in a sample-position–agnostic representation.
    /// </summary>
    CustomSampleDepthStore = 5
}

/// <summary>
/// Options that modify a store action.
/// </summary>
[Flags]
public enum MTLStoreActionOptions : ulong
{
    None = 0,

    /// <summary>
    /// An option that stores data in a sample-position–agnostic representation.
    /// </summary>
    CustomSamplePositions = 1,

    ValidMask = 1
}

/// <summary>
/// The possible data types for the elements of a tensor.
/// </summary>
public enum MTLTensorDataType : long
{
    None = 0,

    Float32 = 3,

    Float16 = 16,

    BFloat16 = 121,

    Int8 = 45,

    UInt8 = 49,

    Int16 = 37,

    UInt16 = 41,

    Int32 = 29,

    UInt32 = 33
}

public enum MTLTensorError : long
{
    None = 0,

    InternalError = 1,

    InvalidDescriptor = 2
}

/// <summary>
/// The type that represents the different contexts for a tensor.
/// </summary>
[Flags]
public enum MTLTensorUsage : ulong
{
    /// <summary>
    /// A tensor context that applies to compute encoders.
    /// </summary>
    Compute = 1,

    /// <summary>
    /// A tensor context that applies to render encoders.
    /// </summary>
    Render = 2,

    /// <summary>
    /// A tensor context that applies to machine learning encoders.
    /// </summary>
    MachineLearning = 4
}

/// <summary>
/// Options for specifying the size of the control point indices in a control point index buffer.
/// </summary>
public enum MTLTessellationControlPointIndexType : ulong
{
    /// <summary>
    /// No size. This value should only be used when drawing patches without a control point index buffer.
    /// </summary>
    None = 0,

    /// <summary>
    /// The size of a 16-bit unsigned integer.
    /// </summary>
    UInt16 = 1,

    /// <summary>
    /// The size of a 32-bit unsigned integer.
    /// </summary>
    UInt32 = 2
}

/// <summary>
/// Options for specifying the format of the tessellation factors in a tessellation factor buffer.
/// </summary>
public enum MTLTessellationFactorFormat : ulong
{
    /// <summary>
    /// A 16-bit floating-point format.
    /// </summary>
    Half = 0
}

/// <summary>
/// Options for specifying the step function that determines the tessellation factors for a patch from the tessellation factor buffer.
/// </summary>
public enum MTLTessellationFactorStepFunction : ulong
{
    /// <summary>
    /// A constant step function. For all instances, the tessellation factor for all patches in a patch draw call is at the offset location in the tessellation factor buffer.
    /// </summary>
    Constant = 0,

    /// <summary>
    /// A per-patch step function. For all instances, the tessellation factor for all patches in a patch draw call is at the offset + (drawPatchIndex * tessellationFactorStride) location in the tessellation factor buffer.
    /// </summary>
    PerPatch = 1,

    /// <summary>
    /// A per-instance step function. For a given instance ID, the tessellation factor for a patch in a patch draw call is at the offset + (instanceID * instanceStride) location in the tessellation factor buffer.
    /// </summary>
    PerInstance = 2,

    /// <summary>
    /// A per-patch and per-instance step function. For a given instance ID, the tessellation factor for a patch in a patch draw call is at the offset + (drawPatchIndex * tessellationFactorStride + instanceID * instanceStride) location in the tessellation factor buffer.
    /// </summary>
    PerPatchAndPerInstance = 3
}

/// <summary>
/// Options for choosing the partition mode that the tessellator applies when deriving the number and spacing of segments for subdividing a corresponding edge.
/// </summary>
public enum MTLTessellationPartitionMode : ulong
{
    /// <summary>
    /// A power of two partitioning mode.
    /// </summary>
    Pow2 = 0,

    /// <summary>
    /// An integer partitioning mode.
    /// </summary>
    Integer = 1,

    /// <summary>
    /// A fractional odd partitioning mode.
    /// </summary>
    FractionalOdd = 2,

    /// <summary>
    /// A fractional even partitioning mode.
    /// </summary>
    FractionalEven = 3
}

public enum MTLTextureCompressionType : long
{
    Lossless = 0,

    Lossy = 1
}

/// <summary>
/// Enumerates the different support levels for sparse textures.
/// </summary>
public enum MTLTextureSparseTier : long
{
    None = 0,

    MTL1 = 1,

    MTL2 = 2
}

/// <summary>
/// A set of options to choose from when creating a texture swizzle pattern.
/// </summary>
public enum MTLTextureSwizzle : byte
{
    /// <summary>
    /// A value of 0.0 is copied to the destination channel.
    /// </summary>
    Zero = 0,

    /// <summary>
    /// A value of 1.0 is copied to the destination channel.
    /// </summary>
    One = 1,

    /// <summary>
    /// The red channel of the source pixel is copied to the destination channel.
    /// </summary>
    Red = 2,

    /// <summary>
    /// The green channel of the source pixel is copied to the destination channel.
    /// </summary>
    Green = 3,

    /// <summary>
    /// The blue channel of the source pixel is copied to the destination channel.
    /// </summary>
    Blue = 4,

    /// <summary>
    /// The alpha channel of the source pixel is copied to the destination channel.
    /// </summary>
    Alpha = 5
}

/// <summary>
/// The dimension of each image, including whether multiple images are arranged into an array or a cube.
/// </summary>
public enum MTLTextureType : ulong
{
    MTL1D = 0,

    MTL1DArray = 1,

    MTL2D = 2,

    MTL2DArray = 3,

    MTL2DMultisample = 4,

    Cube = 5,

    CubeArray = 6,

    MTL3D = 7,

    MTL2DMultisampleArray = 8,

    TextureBuffer = 9
}

/// <summary>
/// An enumeration for the various options that determine how you can use a texture.
/// </summary>
[Flags]
public enum MTLTextureUsage : ulong
{
    /// <summary>
    /// An option for a texture whose usage is unknown.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// An option for reading or sampling from the texture in a shader.
    /// </summary>
    ShaderRead = 1,

    /// <summary>
    /// An option for writing to the texture in a shader.
    /// </summary>
    ShaderWrite = 2,

    /// <summary>
    /// An option for rendering to the texture in a render pass.
    /// </summary>
    RenderTarget = 4,

    /// <summary>
    /// An option to create texture views with a different component layout.
    /// </summary>
    PixelFormatView = 16,

    /// <summary>
    /// An option that enables atomic memory operations on texture elements in shader code.
    /// </summary>
    ShaderAtomic = 32
}

public enum MTLTransformType : long
{
    PackedFloat4x3 = 0,

    Component = 1
}

/// <summary>
/// Specifies how to rasterize triangle and triangle strip primitives.
/// </summary>
public enum MTLTriangleFillMode : ulong
{
    /// <summary>
    /// Rasterize triangle and triangle strip primitives as filled triangles.
    /// </summary>
    Fill = 0,

    /// <summary>
    /// Rasterize triangle and triangle strip primitives as lines.
    /// </summary>
    Lines = 1
}

/// <summary>
/// The vertex data format options for render pipelines.
/// </summary>
public enum MTLVertexFormat : ulong
{
    /// <summary>
    /// A sentinel value that represents an empty set of vertex format options.
    /// </summary>
    Invalid = 0,

    /// <summary>
    /// A two-component vector with 8-bit, unsigned integer values.
    /// </summary>
    UChar2 = 1,

    /// <summary>
    /// A three-component vector with 8-bit, unsigned integer values.
    /// </summary>
    UChar3 = 2,

    /// <summary>
    /// A four-component vector with 8-bit, unsigned integer values.
    /// </summary>
    UChar4 = 3,

    /// <summary>
    /// A two-component vector with 8-bit, signed integer values.
    /// </summary>
    Char2 = 4,

    /// <summary>
    /// A three-component vector with 8-bit, signed integer values.
    /// </summary>
    Char3 = 5,

    /// <summary>
    /// A four-component vector with 8-bit, signed integer values.
    /// </summary>
    Char4 = 6,

    /// <summary>
    /// A two-component vector with 8-bit, normalized, unsigned integer values.
    /// </summary>
    UChar2Normalized = 7,

    /// <summary>
    /// A three-component vector with 8-bit, normalized, unsigned integer values.
    /// </summary>
    UChar3Normalized = 8,

    /// <summary>
    /// A four-component vector with 8-bit, normalized, unsigned integer values.
    /// </summary>
    UChar4Normalized = 9,

    /// <summary>
    /// A two-component vector with 8-bit, normalized, signed integer values.
    /// </summary>
    Char2Normalized = 10,

    /// <summary>
    /// A three-component vector with 8-bit, normalized, signed integer values.
    /// </summary>
    Char3Normalized = 11,

    /// <summary>
    /// A four-component vector with 8-bit, normalized, signed integer values.
    /// </summary>
    Char4Normalized = 12,

    /// <summary>
    /// A two-component vector with 16-bit, unsigned integer values.
    /// </summary>
    UShort2 = 13,

    /// <summary>
    /// A three-component vector with 16-bit, unsigned integer values.
    /// </summary>
    UShort3 = 14,

    /// <summary>
    /// A four-component vector with 16-bit, unsigned integer values.
    /// </summary>
    UShort4 = 15,

    /// <summary>
    /// A two-component vector with 16-bit, signed integer values.
    /// </summary>
    Short2 = 16,

    /// <summary>
    /// A three-component vector with 16-bit, signed integer values.
    /// </summary>
    Short3 = 17,

    /// <summary>
    /// A four-component vector with 16-bit, signed integer values.
    /// </summary>
    Short4 = 18,

    /// <summary>
    /// A two-component vector with 16-bit, normalized, unsigned integer values.
    /// </summary>
    UShort2Normalized = 19,

    /// <summary>
    /// A three-component vector with 16-bit, normalized, unsigned integer values.
    /// </summary>
    UShort3Normalized = 20,

    /// <summary>
    /// A four-component vector with 16-bit, normalized, unsigned integer values.
    /// </summary>
    UShort4Normalized = 21,

    /// <summary>
    /// A two-component vector with 16-bit, normalized, signed integer values.
    /// </summary>
    Short2Normalized = 22,

    /// <summary>
    /// A three-component vector with 16-bit, normalized, signed integer values.
    /// </summary>
    Short3Normalized = 23,

    /// <summary>
    /// A four-component vector with 16-bit, normalized, signed integer values.
    /// </summary>
    Short4Normalized = 24,

    /// <summary>
    /// A two-component vector with 16-bit floating-point values.
    /// </summary>
    Half2 = 25,

    /// <summary>
    /// A three-component vector with 16-bit floating-point values.
    /// </summary>
    Half3 = 26,

    /// <summary>
    /// A four-component vector with 16-bit floating-point values.
    /// </summary>
    Half4 = 27,

    /// <summary>
    /// A 32-bit floating-point value.
    /// </summary>
    Float = 28,

    /// <summary>
    /// A two-component vector with 32-bit floating-point values.
    /// </summary>
    Float2 = 29,

    /// <summary>
    /// A three-component vector with 32-bit floating-point values.
    /// </summary>
    Float3 = 30,

    /// <summary>
    /// A four-component vector with 32-bit floating-point values.
    /// </summary>
    Float4 = 31,

    /// <summary>
    /// A 32-bit, signed integer value.
    /// </summary>
    Int = 32,

    /// <summary>
    /// A two-component vector with 32-bit, signed integer values.
    /// </summary>
    Int2 = 33,

    /// <summary>
    /// A three-component vector with 32-bit, signed integer values.
    /// </summary>
    Int3 = 34,

    /// <summary>
    /// A four-component vector with 32-bit, signed integer values.
    /// </summary>
    Int4 = 35,

    /// <summary>
    /// A 32-bit, unsigned integer value.
    /// </summary>
    UInt = 36,

    /// <summary>
    /// A two-component vector with 32-bit, unsigned integer values.
    /// </summary>
    UInt2 = 37,

    /// <summary>
    /// A three-component vector with 32-bit, unsigned integer values.
    /// </summary>
    UInt3 = 38,

    /// <summary>
    /// A four-component vector with 32-bit, unsigned integer values.
    /// </summary>
    UInt4 = 39,

    /// <summary>
    /// A four-component vector with 10-bit, normalized, signed integer values for red, green, and blue, and a 2-bit value for alpha.
    /// </summary>
    Int1010102Normalized = 40,

    /// <summary>
    /// A four-component vector with 10-bit, normalized, unsigned integer values for red, green, and blue, and a 2-bit value for alpha.
    /// </summary>
    UInt1010102Normalized = 41,

    /// <summary>
    /// A four-component vector with 8-bit, normalized, unsigned integer values for blue, green, red, and alpha.
    /// </summary>
    UChar4Normalized_BGRA = 42,

    /// <summary>
    /// An 8-bit, unsigned integer value.
    /// </summary>
    UChar = 45,

    /// <summary>
    /// An 8-bit, signed integer value.
    /// </summary>
    Char = 46,

    /// <summary>
    /// An 8-bit, normalized, unsigned integer value.
    /// </summary>
    UCharNormalized = 47,

    /// <summary>
    /// An 8-bit, normalized, signed integer value.
    /// </summary>
    CharNormalized = 48,

    /// <summary>
    /// A 16-bit, unsigned integer value.
    /// </summary>
    UShort = 49,

    /// <summary>
    /// A 16-bit, signed integer value.
    /// </summary>
    Short = 50,

    /// <summary>
    /// A 16-bit, normalized, unsigned integer value.
    /// </summary>
    UShortNormalized = 51,

    /// <summary>
    /// A 16-bit, normalized, signed integer value.
    /// </summary>
    ShortNormalized = 52,

    /// <summary>
    /// A 16-bit floating-point value.
    /// </summary>
    Half = 53,

    /// <summary>
    /// A three-component vector with 11-bit floating-point values for red and green, and a 10-bit value for blue.
    /// </summary>
    FloatRG11B10 = 54,

    /// <summary>
    /// A three-component vector with 9-bit floating-point values for red, green, and blue, and a 5-bit shared exponent.
    /// </summary>
    FloatRGB9E5 = 55
}

/// <summary>
/// The frequency with which the vertex function or post-tessellation vertex function fetches attribute data.
/// </summary>
public enum MTLVertexStepFunction : ulong
{
    /// <summary>
    /// The vertex function fetches attribute data once and uses that data for every vertex.
    /// </summary>
    Constant = 0,

    /// <summary>
    /// The vertex function fetches and uses new attribute data for every vertex.
    /// </summary>
    PerVertex = 1,

    /// <summary>
    /// The vertex function regularly fetches new attribute data for a number of instances that is determined by stepRate.
    /// </summary>
    PerInstance = 2,

    /// <summary>
    /// The post-tessellation vertex function fetches data based on the patch index of the patch.
    /// </summary>
    PerPatch = 3,

    /// <summary>
    /// The post-tessellation vertex function fetches data based on the control-point indices associated with the patch.
    /// </summary>
    PerPatchControlPoint = 4
}

/// <summary>
/// The mode that determines what, if anything, the GPU writes to the results buffer, after the GPU executes the render pass.
/// </summary>
public enum MTLVisibilityResultMode : ulong
{
    /// <summary>
    /// The result doesn’t contain any data because visibility testing was disabled.
    /// </summary>
    Disabled = 0,

    /// <summary>
    /// The result records whether any samples passed depth and stencil tests.
    /// </summary>
    Boolean = 1,

    /// <summary>
    /// The result records how many samples passed depth and stencil tests.
    /// </summary>
    Counting = 2
}

/// <summary>
/// This enumeration controls if Metal accumulates visibility results between render encoders or resets them.
/// </summary>
public enum MTLVisibilityResultType : long
{
    /// <summary>
    /// Reset visibility result data when you create a render command encoder.
    /// </summary>
    Reset = 0,

    /// <summary>
    /// Accumulate visibility results data across multiple render passes.
    /// </summary>
    Accumulate = 1
}

/// <summary>
/// The vertex winding rule that determines a front-facing primitive.
/// </summary>
public enum MTLWinding : ulong
{
    /// <summary>
    /// Primitives whose vertices are specified in clockwise order are front-facing.
    /// </summary>
    Clockwise = 0,

    /// <summary>
    /// Primitives whose vertices are specified in counter-clockwise order are front-facing.
    /// </summary>
    CounterClockwise = 1
}
