namespace Metal.NET;

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
