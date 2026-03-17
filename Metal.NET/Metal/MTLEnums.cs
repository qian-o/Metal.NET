namespace Metal.NET;

[Flags]
public enum MTLResourceUsage : ulong
{
    Read = 1,

    Write = 2,

    [Obsolete("Use MTLResourceUsageRead instead")]
    Sample = 4
}

[Flags]
public enum MTLBarrierScope : ulong
{
    Buffers = 1,

    Textures = 2,

    RenderTargets = 4
}

[Flags]
public enum MTLStages : ulong
{
    Vertex = 1,

    Fragment = 2,

    Tile = 4,

    Object = 8,

    Mesh = 16,

    ResourceState = 67108864,

    Dispatch = 134217728,

    Blit = 268435456,

    AccelerationStructure = 536870912,

    MachineLearning = 1073741824,

    All = 9223372036854775807
}

public enum MTLPurgeableState : ulong
{
    KeepCurrent = 1,

    NonVolatile = 2,

    Volatile = 3,

    Empty = 4
}

public enum MTLCPUCacheMode : ulong
{
    DefaultCache = 0,

    WriteCombined = 1
}

public enum MTLStorageMode : ulong
{
    Shared = 0,

    Managed = 1,

    Private = 2,

    Memoryless = 3
}

public enum MTLHazardTrackingMode : ulong
{
    Default = 0,

    Untracked = 1,

    Tracked = 2
}

[Flags]
public enum MTLResourceOptions : ulong
{
    CPUCacheModeDefaultCache = 0,

    CPUCacheModeWriteCombined = 1,

    StorageModeShared = 0,

    StorageModeManaged = 16,

    StorageModePrivate = 32,

    StorageModeMemoryless = 48,

    HazardTrackingModeDefault = 0,

    HazardTrackingModeUntracked = 256,

    HazardTrackingModeTracked = 512,

    [Obsolete("Use MTLResourceCPUCacheModeDefaultCache instead")]
    OptionCPUCacheModeDefault = 0,

    [Obsolete("Use MTLResourceCPUCacheModeWriteCombined instead")]
    OptionCPUCacheModeWriteCombined = 1
}

public enum MTLSparsePageSize : long
{
    MTL16 = 101,

    MTL64 = 102,

    MTL256 = 103
}

public enum MTLBufferSparseTier : long
{
    None = 0,

    MTL1 = 1
}

public enum MTLTextureSparseTier : long
{
    None = 0,

    MTL1 = 1,

    MTL2 = 2
}

public enum MTLPixelFormat : ulong
{
    Invalid = 0,

    A8Unorm = 1,

    R8Unorm = 10,

    R8Unorm_sRGB = 11,

    R8Snorm = 12,

    R8Uint = 13,

    R8Sint = 14,

    R16Unorm = 20,

    R16Snorm = 22,

    R16Uint = 23,

    R16Sint = 24,

    R16Float = 25,

    RG8Unorm = 30,

    RG8Unorm_sRGB = 31,

    RG8Snorm = 32,

    RG8Uint = 33,

    RG8Sint = 34,

    B5G6R5Unorm = 40,

    A1BGR5Unorm = 41,

    ABGR4Unorm = 42,

    BGR5A1Unorm = 43,

    R32Uint = 53,

    R32Sint = 54,

    R32Float = 55,

    RG16Unorm = 60,

    RG16Snorm = 62,

    RG16Uint = 63,

    RG16Sint = 64,

    RG16Float = 65,

    RGBA8Unorm = 70,

    RGBA8Unorm_sRGB = 71,

    RGBA8Snorm = 72,

    RGBA8Uint = 73,

    RGBA8Sint = 74,

    BGRA8Unorm = 80,

    BGRA8Unorm_sRGB = 81,

    RGB10A2Unorm = 90,

    RGB10A2Uint = 91,

    RG11B10Float = 92,

    RGB9E5Float = 93,

    BGR10A2Unorm = 94,

    BGR10_XR = 554,

    BGR10_XR_sRGB = 555,

    RG32Uint = 103,

    RG32Sint = 104,

    RG32Float = 105,

    RGBA16Unorm = 110,

    RGBA16Snorm = 112,

    RGBA16Uint = 113,

    RGBA16Sint = 114,

    RGBA16Float = 115,

    BGRA10_XR = 552,

    BGRA10_XR_sRGB = 553,

    RGBA32Uint = 123,

    RGBA32Sint = 124,

    RGBA32Float = 125,

    BC1_RGBA = 130,

    BC1_RGBA_sRGB = 131,

    BC2_RGBA = 132,

    BC2_RGBA_sRGB = 133,

    BC3_RGBA = 134,

    BC3_RGBA_sRGB = 135,

    BC4_RUnorm = 140,

    BC4_RSnorm = 141,

    BC5_RGUnorm = 142,

    BC5_RGSnorm = 143,

    BC6H_RGBFloat = 150,

    BC6H_RGBUfloat = 151,

    BC7_RGBAUnorm = 152,

    BC7_RGBAUnorm_sRGB = 153,

    [Obsolete("Usage of ASTC/ETC2/BC formats is recommended instead.")]
    PVRTC_RGB_2BPP = 160,

    [Obsolete("Usage of ASTC/ETC2/BC formats is recommended instead.")]
    PVRTC_RGB_2BPP_sRGB = 161,

    [Obsolete("Usage of ASTC/ETC2/BC formats is recommended instead.")]
    PVRTC_RGB_4BPP = 162,

    [Obsolete("Usage of ASTC/ETC2/BC formats is recommended instead.")]
    PVRTC_RGB_4BPP_sRGB = 163,

    [Obsolete("Usage of ASTC/ETC2/BC formats is recommended instead.")]
    PVRTC_RGBA_2BPP = 164,

    [Obsolete("Usage of ASTC/ETC2/BC formats is recommended instead.")]
    PVRTC_RGBA_2BPP_sRGB = 165,

    [Obsolete("Usage of ASTC/ETC2/BC formats is recommended instead.")]
    PVRTC_RGBA_4BPP = 166,

    [Obsolete("Usage of ASTC/ETC2/BC formats is recommended instead.")]
    PVRTC_RGBA_4BPP_sRGB = 167,

    EAC_R11Unorm = 170,

    EAC_R11Snorm = 172,

    EAC_RG11Unorm = 174,

    EAC_RG11Snorm = 176,

    EAC_RGBA8 = 178,

    EAC_RGBA8_sRGB = 179,

    ETC2_RGB8 = 180,

    ETC2_RGB8_sRGB = 181,

    ETC2_RGB8A1 = 182,

    ETC2_RGB8A1_sRGB = 183,

    ASTC_4x4_sRGB = 186,

    ASTC_5x4_sRGB = 187,

    ASTC_5x5_sRGB = 188,

    ASTC_6x5_sRGB = 189,

    ASTC_6x6_sRGB = 190,

    ASTC_8x5_sRGB = 192,

    ASTC_8x6_sRGB = 193,

    ASTC_8x8_sRGB = 194,

    ASTC_10x5_sRGB = 195,

    ASTC_10x6_sRGB = 196,

    ASTC_10x8_sRGB = 197,

    ASTC_10x10_sRGB = 198,

    ASTC_12x10_sRGB = 199,

    ASTC_12x12_sRGB = 200,

    ASTC_4x4_LDR = 204,

    ASTC_5x4_LDR = 205,

    ASTC_5x5_LDR = 206,

    ASTC_6x5_LDR = 207,

    ASTC_6x6_LDR = 208,

    ASTC_8x5_LDR = 210,

    ASTC_8x6_LDR = 211,

    ASTC_8x8_LDR = 212,

    ASTC_10x5_LDR = 213,

    ASTC_10x6_LDR = 214,

    ASTC_10x8_LDR = 215,

    ASTC_10x10_LDR = 216,

    ASTC_12x10_LDR = 217,

    ASTC_12x12_LDR = 218,

    ASTC_4x4_HDR = 222,

    ASTC_5x4_HDR = 223,

    ASTC_5x5_HDR = 224,

    ASTC_6x5_HDR = 225,

    ASTC_6x6_HDR = 226,

    ASTC_8x5_HDR = 228,

    ASTC_8x6_HDR = 229,

    ASTC_8x8_HDR = 230,

    ASTC_10x5_HDR = 231,

    ASTC_10x6_HDR = 232,

    ASTC_10x8_HDR = 233,

    ASTC_10x10_HDR = 234,

    ASTC_12x10_HDR = 235,

    ASTC_12x12_HDR = 236,

    GBGR422 = 240,

    BGRG422 = 241,

    Depth16Unorm = 250,

    Depth32Float = 252,

    Stencil8 = 253,

    Depth24Unorm_Stencil8 = 255,

    Depth32Float_Stencil8 = 260,

    X32_Stencil8 = 261,

    X24_Stencil8 = 262,

    Unspecialized = 263
}

public enum MTLDataType : ulong
{
    None = 0,

    Struct = 1,

    Array = 2,

    Float = 3,

    Float2 = 4,

    Float3 = 5,

    Float4 = 6,

    Float2x2 = 7,

    Float2x3 = 8,

    Float2x4 = 9,

    Float3x2 = 10,

    Float3x3 = 11,

    Float3x4 = 12,

    Float4x2 = 13,

    Float4x3 = 14,

    Float4x4 = 15,

    Half = 16,

    Half2 = 17,

    Half3 = 18,

    Half4 = 19,

    Half2x2 = 20,

    Half2x3 = 21,

    Half2x4 = 22,

    Half3x2 = 23,

    Half3x3 = 24,

    Half3x4 = 25,

    Half4x2 = 26,

    Half4x3 = 27,

    Half4x4 = 28,

    Int = 29,

    Int2 = 30,

    Int3 = 31,

    Int4 = 32,

    UInt = 33,

    UInt2 = 34,

    UInt3 = 35,

    UInt4 = 36,

    Short = 37,

    Short2 = 38,

    Short3 = 39,

    Short4 = 40,

    UShort = 41,

    UShort2 = 42,

    UShort3 = 43,

    UShort4 = 44,

    Char = 45,

    Char2 = 46,

    Char3 = 47,

    Char4 = 48,

    UChar = 49,

    UChar2 = 50,

    UChar3 = 51,

    UChar4 = 52,

    Bool = 53,

    Bool2 = 54,

    Bool3 = 55,

    Bool4 = 56,

    Texture = 58,

    Sampler = 59,

    Pointer = 60,

    R8Unorm = 62,

    R8Snorm = 63,

    R16Unorm = 64,

    R16Snorm = 65,

    RG8Unorm = 66,

    RG8Snorm = 67,

    RG16Unorm = 68,

    RG16Snorm = 69,

    RGBA8Unorm = 70,

    RGBA8Unorm_sRGB = 71,

    RGBA8Snorm = 72,

    RGBA16Unorm = 73,

    RGBA16Snorm = 74,

    RGB10A2Unorm = 75,

    RG11B10Float = 76,

    RGB9E5Float = 77,

    RenderPipeline = 78,

    ComputePipeline = 79,

    IndirectCommandBuffer = 80,

    Long = 81,

    Long2 = 82,

    Long3 = 83,

    Long4 = 84,

    ULong = 85,

    ULong2 = 86,

    ULong3 = 87,

    ULong4 = 88,

    VisibleFunctionTable = 115,

    IntersectionFunctionTable = 116,

    PrimitiveAccelerationStructure = 117,

    InstanceAccelerationStructure = 118,

    BFloat = 121,

    BFloat2 = 122,

    BFloat3 = 123,

    BFloat4 = 124,

    DepthStencilState = 139,

    Tensor = 140
}

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

[Flags]
public enum MTLTensorUsage : ulong
{
    Compute = 1,

    Render = 2,

    MachineLearning = 4
}

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

public enum MTLTextureSwizzle : byte
{
    Zero = 0,

    One = 1,

    Red = 2,

    Green = 3,

    Blue = 4,

    Alpha = 5
}

[Flags]
public enum MTLTextureUsage : ulong
{
    Unknown = 0,

    ShaderRead = 1,

    ShaderWrite = 2,

    RenderTarget = 4,

    PixelFormatView = 16,

    ShaderAtomic = 32
}

public enum MTLTextureCompressionType : long
{
    Lossless = 0,

    Lossy = 1
}

public enum MTLIndexType : ulong
{
    UInt16 = 0,

    UInt32 = 1
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

public enum MTLArgumentType : ulong
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

    IntersectionFunctionTable = 27
}

public enum MTLBindingAccess : ulong
{
    ReadOnly = 0,

    ReadWrite = 1,

    WriteOnly = 2,

    [Obsolete("Use MTLBindingAccessReadOnly instead")]
    ArgumentAccessReadOnly = 0,

    [Obsolete("Use MTLBindingAccessReadWrite instead")]
    ArgumentAccessReadWrite = 1,

    [Obsolete("Use MTLBindingAccessWriteOnly instead")]
    ArgumentAccessWriteOnly = 2
}

[Flags]
public enum MTLFunctionOptions : ulong
{
    None = 0,

    CompileToBinary = 1,

    StoreFunctionInMetalPipelinesScript = 2,

    [Obsolete("Use MTLFunctionOptionStoreFunctionInMetalPipelinesScript instead")]
    StoreFunctionInMetalScript = 2,

    FailOnBinaryArchiveMiss = 4,

    PipelineIndependent = 8
}

public enum MTLPatchType : ulong
{
    None = 0,

    Triangle = 1,

    Quad = 2
}

public enum MTLFunctionType : ulong
{
    Vertex = 1,

    Fragment = 2,

    Kernel = 3,

    Visible = 5,

    Intersection = 6,

    Mesh = 7,

    Object = 8
}

public enum MTLLanguageVersion : ulong
{
    [Obsolete("Use a newer language standard")]
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

public enum MTLLibraryType : long
{
    Executable = 0,

    Dynamic = 1
}

public enum MTLLibraryOptimizationLevel : long
{
    Default = 0,

    Size = 1
}

public enum MTLCompileSymbolVisibility : long
{
    Default = 0,

    Hidden = 1
}

public enum MTLMathMode : long
{
    Safe = 0,

    Relaxed = 1,

    Fast = 2
}

public enum MTLMathFloatingPointFunctions : long
{
    Fast = 0,

    Precise = 1
}

public enum MTLLibraryError : ulong
{
    Unsupported = 1,

    Internal = 2,

    CompileFailure = 3,

    CompileWarning = 4,

    FunctionNotFound = 5,

    FileNotFound = 6
}

public enum MTLCounterSampleBufferError : long
{
    OutOfMemory = 0,

    Invalid = 1,

    Internal = 2
}

public enum MTL4CompilerTaskStatus : long
{
    None = 0,

    Scheduled = 1,

    Compiling = 2,

    Finished = 3
}

public enum MTL4CounterHeapType : long
{
    Invalid = 0,

    Timestamp = 1
}

public enum MTL4TimestampGranularity : long
{
    Relaxed = 0,

    Precise = 1
}

public enum MTLIOCompressionMethod : long
{
    Zlib = 0,

    LZFSE = 1,

    LZ4 = 2,

    LZMA = 3,

    LZBitmap = 4
}

public enum MTLFeatureSet : ulong
{
    Ios_GPUFamily1_v1 = 0,

    Ios_GPUFamily2_v1 = 1,

    Ios_GPUFamily1_v2 = 2,

    Ios_GPUFamily2_v2 = 3,

    Ios_GPUFamily3_v1 = 4,

    Ios_GPUFamily1_v3 = 5,

    Ios_GPUFamily2_v3 = 6,

    Ios_GPUFamily3_v2 = 7,

    Ios_GPUFamily1_v4 = 8,

    Ios_GPUFamily2_v4 = 9,

    Ios_GPUFamily3_v3 = 10,

    Ios_GPUFamily4_v1 = 11,

    Ios_GPUFamily1_v5 = 12,

    Ios_GPUFamily2_v5 = 13,

    Ios_GPUFamily3_v4 = 14,

    Ios_GPUFamily4_v2 = 15,

    Ios_GPUFamily5_v1 = 16,

    Macos_GPUFamily1_v1 = 10000,

    OSX_GPUFamily1_v1 = 10000,

    Macos_GPUFamily1_v2 = 10001,

    OSX_GPUFamily1_v2 = 10001,

    Macos_ReadWriteTextureTier2 = 10002,

    OSX_ReadWriteTextureTier2 = 10002,

    Macos_GPUFamily1_v3 = 10003,

    Macos_GPUFamily1_v4 = 10004,

    Macos_GPUFamily2_v1 = 10005,

    Tvos_GPUFamily1_v1 = 30000,

    TVOS_GPUFamily1_v1 = 30000,

    Tvos_GPUFamily1_v2 = 30001,

    Tvos_GPUFamily1_v3 = 30002,

    Tvos_GPUFamily2_v1 = 30003,

    Tvos_GPUFamily1_v4 = 30004,

    Tvos_GPUFamily2_v2 = 30005
}

public enum MTLGPUFamily : long
{
    Apple1 = 1001,

    Apple2 = 1002,

    Apple3 = 1003,

    Apple4 = 1004,

    Apple5 = 1005,

    Apple6 = 1006,

    Apple7 = 1007,

    Apple8 = 1008,

    Apple9 = 1009,

    Apple10 = 1010,

    [Obsolete("Use MTLGPUFamilyMac2 instead")]
    Mac1 = 2001,

    Mac2 = 2002,

    Common1 = 3001,

    Common2 = 3002,

    Common3 = 3003,

    [Obsolete("Use MTLGPUFamilyMac2 instead")]
    MacCatalyst1 = 4001,

    [Obsolete("Use MTLGPUFamilyMac2 instead")]
    MacCatalyst2 = 4002,

    Metal3 = 5001,

    Metal4 = 5002
}

public enum MTLDeviceLocation : ulong
{
    BuiltIn = 0,

    Slot = 1,

    External = 2,

    Unspecified = 18446744073709551615
}

[Flags]
public enum MTLPipelineOption : ulong
{
    None = 0,

    [Obsolete("Use MTLPipelineOptionBindingInfo instead")]
    ArgumentInfo = 1,

    BindingInfo = 1,

    BufferTypeInfo = 2,

    FailOnBinaryArchiveMiss = 4
}

public enum MTLReadWriteTextureTier : ulong
{
    None = 0,

    MTL1 = 1,

    MTL2 = 2
}

public enum MTLArgumentBuffersTier : ulong
{
    MTL1 = 0,

    MTL2 = 1
}

public enum MTLSparseTextureRegionAlignmentMode : ulong
{
    Outward = 0,

    Inward = 1
}

public enum MTLCounterSamplingPoint : ulong
{
    StageBoundary = 0,

    DrawBoundary = 1,

    DispatchBoundary = 2,

    TileDispatchBoundary = 3,

    BlitBoundary = 4
}

public enum MTLSparseTextureMappingMode : ulong
{
    Map = 0,

    Unmap = 1
}

public enum MTLLoadAction : ulong
{
    DontCare = 0,

    Load = 1,

    Clear = 2
}

public enum MTLStoreAction : ulong
{
    DontCare = 0,

    Store = 1,

    MultisampleResolve = 2,

    StoreAndMultisampleResolve = 3,

    Unknown = 4,

    CustomSampleDepthStore = 5
}

[Flags]
public enum MTLStoreActionOptions : ulong
{
    None = 0,

    CustomSamplePositions = 1
}

public enum MTLVisibilityResultType : long
{
    Reset = 0,

    Accumulate = 1
}

public enum MTLMultisampleDepthResolveFilter : ulong
{
    Sample0 = 0,

    Min = 1,

    Max = 2
}

public enum MTLMultisampleStencilResolveFilter : ulong
{
    Sample0 = 0,

    DepthResolvedSample = 1
}

[Flags]
public enum MTLBlitOption : ulong
{
    None = 0,

    DepthFromDepthStencil = 1,

    StencilFromDepthStencil = 2,

    RowLinearPVRTC = 4
}

public enum MTLCommandBufferStatus : ulong
{
    NotEnqueued = 0,

    Enqueued = 1,

    Committed = 2,

    Scheduled = 3,

    Completed = 4,

    Error = 5
}

public enum MTLCommandBufferError : ulong
{
    None = 0,

    Internal = 1,

    Timeout = 2,

    PageFault = 3,

    [Obsolete("Use MTLCommandBufferErrorAccessRevoked instead")]
    Blacklisted = 4,

    AccessRevoked = 4,

    NotPermitted = 7,

    OutOfMemory = 8,

    InvalidResource = 9,

    Memoryless = 10,

    DeviceRemoved = 11,

    StackOverflow = 12
}

[Flags]
public enum MTLCommandBufferErrorOption : ulong
{
    None = 0,

    EncoderExecutionStatus = 1
}

public enum MTLCommandEncoderErrorState : long
{
    Unknown = 0,

    Completed = 1,

    Affected = 2,

    Pending = 3,

    Faulted = 4
}

public enum MTLDispatchType : ulong
{
    Serial = 0,

    Concurrent = 1
}

public enum MTLCompareFunction : ulong
{
    Never = 0,

    Less = 1,

    Equal = 2,

    LessEqual = 3,

    Greater = 4,

    NotEqual = 5,

    GreaterEqual = 6,

    Always = 7
}

public enum MTLStencilOperation : ulong
{
    Keep = 0,

    Zero = 1,

    Replace = 2,

    IncrementClamp = 3,

    DecrementClamp = 4,

    Invert = 5,

    IncrementWrap = 6,

    DecrementWrap = 7
}

public enum MTLVertexFormat : ulong
{
    Invalid = 0,

    UChar2 = 1,

    UChar3 = 2,

    UChar4 = 3,

    Char2 = 4,

    Char3 = 5,

    Char4 = 6,

    UChar2Normalized = 7,

    UChar3Normalized = 8,

    UChar4Normalized = 9,

    Char2Normalized = 10,

    Char3Normalized = 11,

    Char4Normalized = 12,

    UShort2 = 13,

    UShort3 = 14,

    UShort4 = 15,

    Short2 = 16,

    Short3 = 17,

    Short4 = 18,

    UShort2Normalized = 19,

    UShort3Normalized = 20,

    UShort4Normalized = 21,

    Short2Normalized = 22,

    Short3Normalized = 23,

    Short4Normalized = 24,

    Half2 = 25,

    Half3 = 26,

    Half4 = 27,

    Float = 28,

    Float2 = 29,

    Float3 = 30,

    Float4 = 31,

    Int = 32,

    Int2 = 33,

    Int3 = 34,

    Int4 = 35,

    UInt = 36,

    UInt2 = 37,

    UInt3 = 38,

    UInt4 = 39,

    Int1010102Normalized = 40,

    UInt1010102Normalized = 41,

    UChar4Normalized_BGRA = 42,

    UChar = 45,

    Char = 46,

    UCharNormalized = 47,

    CharNormalized = 48,

    UShort = 49,

    Short = 50,

    UShortNormalized = 51,

    ShortNormalized = 52,

    Half = 53,

    FloatRG11B10 = 54,

    FloatRGB9E5 = 55
}

public enum MTLVertexStepFunction : ulong
{
    Constant = 0,

    PerVertex = 1,

    PerInstance = 2,

    PerPatch = 3,

    PerPatchControlPoint = 4
}

public enum MTLAttributeFormat : ulong
{
    Invalid = 0,

    UChar2 = 1,

    UChar3 = 2,

    UChar4 = 3,

    Char2 = 4,

    Char3 = 5,

    Char4 = 6,

    UChar2Normalized = 7,

    UChar3Normalized = 8,

    UChar4Normalized = 9,

    Char2Normalized = 10,

    Char3Normalized = 11,

    Char4Normalized = 12,

    UShort2 = 13,

    UShort3 = 14,

    UShort4 = 15,

    Short2 = 16,

    Short3 = 17,

    Short4 = 18,

    UShort2Normalized = 19,

    UShort3Normalized = 20,

    UShort4Normalized = 21,

    Short2Normalized = 22,

    Short3Normalized = 23,

    Short4Normalized = 24,

    Half2 = 25,

    Half3 = 26,

    Half4 = 27,

    Float = 28,

    Float2 = 29,

    Float3 = 30,

    Float4 = 31,

    Int = 32,

    Int2 = 33,

    Int3 = 34,

    Int4 = 35,

    UInt = 36,

    UInt2 = 37,

    UInt3 = 38,

    UInt4 = 39,

    Int1010102Normalized = 40,

    UInt1010102Normalized = 41,

    UChar4Normalized_BGRA = 42,

    UChar = 45,

    Char = 46,

    UCharNormalized = 47,

    CharNormalized = 48,

    UShort = 49,

    Short = 50,

    UShortNormalized = 51,

    ShortNormalized = 52,

    Half = 53,

    FloatRG11B10 = 54,

    FloatRGB9E5 = 55
}

public enum MTLStepFunction : ulong
{
    Constant = 0,

    PerVertex = 1,

    PerInstance = 2,

    PerPatch = 3,

    PerPatchControlPoint = 4,

    ThreadPositionInGridX = 5,

    ThreadPositionInGridY = 6,

    ThreadPositionInGridXIndexed = 7,

    ThreadPositionInGridYIndexed = 8
}

public enum MTLMutability : ulong
{
    Default = 0,

    Mutable = 1,

    Immutable = 2
}

public enum MTLShaderValidation : long
{
    Default = 0,

    Enabled = 1,

    Disabled = 2
}

public enum MTLPrimitiveType : ulong
{
    Point = 0,

    Line = 1,

    LineStrip = 2,

    Triangle = 3,

    TriangleStrip = 4
}

public enum MTLVisibilityResultMode : ulong
{
    Disabled = 0,

    Boolean = 1,

    Counting = 2
}

public enum MTLCullMode : ulong
{
    None = 0,

    Front = 1,

    Back = 2
}

public enum MTLWinding : ulong
{
    Clockwise = 0,

    CounterClockwise = 1
}

public enum MTLDepthClipMode : ulong
{
    Clip = 0,

    Clamp = 1
}

public enum MTLTriangleFillMode : ulong
{
    Fill = 0,

    Lines = 1
}

[Flags]
public enum MTLRenderStages : ulong
{
    Vertex = 1,

    Fragment = 2,

    Tile = 4,

    Object = 8,

    Mesh = 16
}

public enum MTLBlendFactor : ulong
{
    Zero = 0,

    One = 1,

    SourceColor = 2,

    OneMinusSourceColor = 3,

    SourceAlpha = 4,

    OneMinusSourceAlpha = 5,

    DestinationColor = 6,

    OneMinusDestinationColor = 7,

    DestinationAlpha = 8,

    OneMinusDestinationAlpha = 9,

    SourceAlphaSaturated = 10,

    BlendColor = 11,

    OneMinusBlendColor = 12,

    BlendAlpha = 13,

    OneMinusBlendAlpha = 14,

    Source1Color = 15,

    OneMinusSource1Color = 16,

    Source1Alpha = 17,

    OneMinusSource1Alpha = 18,

    Unspecialized = 19
}

public enum MTLBlendOperation : ulong
{
    Add = 0,

    Subtract = 1,

    ReverseSubtract = 2,

    Min = 3,

    Max = 4,

    Unspecialized = 5
}

[Flags]
public enum MTLColorWriteMask : ulong
{
    None = 0,

    Red = 8,

    Green = 4,

    Blue = 2,

    Alpha = 1,

    All = 15,

    Unspecialized = 16
}

public enum MTLPrimitiveTopologyClass : ulong
{
    Unspecified = 0,

    Point = 1,

    Line = 2,

    Triangle = 3
}

public enum MTLTessellationPartitionMode : ulong
{
    Pow2 = 0,

    Integer = 1,

    FractionalOdd = 2,

    FractionalEven = 3
}

public enum MTLTessellationFactorStepFunction : ulong
{
    Constant = 0,

    PerPatch = 1,

    PerInstance = 2,

    PerPatchAndPerInstance = 3
}

public enum MTLTessellationFactorFormat : ulong
{
    Half = 0
}

public enum MTLTessellationControlPointIndexType : ulong
{
    None = 0,

    UInt16 = 1,

    UInt32 = 2
}

public enum MTLSamplerMinMagFilter : ulong
{
    Nearest = 0,

    Linear = 1
}

public enum MTLSamplerMipFilter : ulong
{
    NotMipmapped = 0,

    Nearest = 1,

    Linear = 2
}

public enum MTLSamplerAddressMode : ulong
{
    ClampToEdge = 0,

    MirrorClampToEdge = 1,

    Repeat = 2,

    MirrorRepeat = 3,

    ClampToZero = 4,

    ClampToBorderColor = 5
}

public enum MTLSamplerBorderColor : ulong
{
    TransparentBlack = 0,

    OpaqueBlack = 1,

    OpaqueWhite = 2
}

public enum MTLSamplerReductionMode : ulong
{
    WeightedAverage = 0,

    Minimum = 1,

    Maximum = 2
}

[Flags]
public enum MTLAccelerationStructureRefitOptions : ulong
{
    VertexData = 1,

    PerPrimitiveData = 2
}

[Flags]
public enum MTLAccelerationStructureUsage : ulong
{
    None = 0,

    Refit = 1,

    PreferFastBuild = 2,

    ExtendedLimits = 4,

    PreferFastIntersection = 16,

    MinimizeMemory = 32
}

[Flags]
public enum MTLAccelerationStructureInstanceOptions : uint
{
    None = 0,

    DisableTriangleCulling = 1,

    TriangleFrontFacingWindingCounterClockwise = 2,

    Opaque = 4,

    NonOpaque = 8
}

public enum MTLMatrixLayout : long
{
    ColumnMajor = 0,

    RowMajor = 1
}

public enum MTLMotionBorderMode : uint
{
    Clamp = 0,

    Vanish = 1
}

public enum MTLCurveType : long
{
    Round = 0,

    Flat = 1
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

public enum MTLAccelerationStructureInstanceDescriptorType : ulong
{
    Default = 0,

    UserID = 1,

    Motion = 2,

    Indirect = 3,

    IndirectMotion = 4
}

public enum MTLTransformType : long
{
    PackedFloat4x3 = 0,

    Component = 1
}

public enum MTLHeapType : long
{
    Automatic = 0,

    Placement = 1,

    Sparse = 2
}

[Flags]
public enum MTL4VisibilityOptions : ulong
{
    None = 0,

    Device = 1,

    ResourceAlias = 2
}

[Flags]
public enum MTL4RenderEncoderOptions : ulong
{
    None = 0,

    Suspending = 1,

    Resuming = 2
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

public enum MTLCaptureError : long
{
    NotSupported = 1,

    AlreadyCapturing = 2,

    InvalidDescriptor = 3
}

public enum MTLCaptureDestination : long
{
    DeveloperTools = 1,

    GPUTraceDocument = 2
}

[Flags]
public enum MTLIndirectCommandType : ulong
{
    Draw = 1,

    DrawIndexed = 2,

    DrawPatches = 4,

    DrawIndexedPatches = 8,

    ConcurrentDispatch = 32,

    ConcurrentDispatchThreads = 64,

    DrawMeshThreadgroups = 128,

    DrawMeshThreads = 256
}

public enum MTLFunctionLogType : ulong
{
    Validation = 0
}

public enum MTLDynamicLibraryError : ulong
{
    None = 0,

    InvalidFile = 1,

    CompilationFailure = 2,

    UnresolvedInstallName = 3,

    DependencyLoadFailure = 4,

    Unsupported = 5
}

public enum MTLLogLevel : long
{
    Undefined = 0,

    Debug = 1,

    Info = 2,

    Notice = 3,

    Error = 4,

    Fault = 5
}

public enum MTLLogStateError : ulong
{
    InvalidSize = 1,

    Invalid = 2
}

public enum MTLBinaryArchiveError : ulong
{
    None = 0,

    InvalidFile = 1,

    UnexpectedElement = 2,

    CompilationFailure = 3,

    InternalError = 4
}

[Flags]
public enum MTLIntersectionFunctionSignature : ulong
{
    None = 0,

    Instancing = 1,

    TriangleData = 2,

    WorldSpaceData = 4,

    InstanceMotion = 8,

    PrimitiveMotion = 16,

    ExtendedLimits = 32,

    MaxLevels = 64,

    CurveData = 128,

    IntersectionFunctionBuffer = 256,

    UserData = 512
}

[Flags]
public enum MTLStitchedLibraryOptions : ulong
{
    None = 0,

    FailOnBinaryArchiveMiss = 1,

    StoreLibraryInMetalPipelinesScript = 2
}

public enum MTLIOPriority : long
{
    High = 0,

    Normal = 1,

    Low = 2
}

public enum MTLIOCommandQueueType : long
{
    Concurrent = 0,

    Serial = 1
}

public enum MTLIOError : long
{
    URLInvalid = 1,

    Internal = 2
}

public enum MTLIOStatus : long
{
    Pending = 0,

    Cancelled = 1,

    Error = 2,

    Complete = 3
}

public enum MTLIOCompressionStatus : long
{
    Complete = 0,

    Error = 1
}

[Flags]
public enum MTL4ShaderReflection : ulong
{
    None = 0,

    BindingInfo = 1,

    BufferTypeInfo = 2
}

public enum MTL4AlphaToOneState : long
{
    Disabled = 0,

    Enabled = 1
}

public enum MTL4AlphaToCoverageState : long
{
    Disabled = 0,

    Enabled = 1
}

public enum MTL4BlendState : long
{
    Disabled = 0,

    Enabled = 1,

    Unspecialized = 2
}

public enum MTL4IndirectCommandBufferSupportState : long
{
    Disabled = 0,

    Enabled = 1
}

public enum MTL4LogicalToPhysicalColorAttachmentMappingState : long
{
    Identity = 0,

    Inherited = 1
}

[Flags]
public enum MTL4PipelineDataSetSerializerConfiguration : ulong
{
    Descriptors = 1,

    Binaries = 2
}

[Flags]
public enum MTL4BinaryFunctionOptions : ulong
{
    None = 0,

    PipelineIndependent = 2
}
