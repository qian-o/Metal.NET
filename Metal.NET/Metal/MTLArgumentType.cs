namespace Metal.NET;

public enum MTLArgumentType : ulong
{
    ArgumentTypeBuffer = 0,

    ArgumentTypeThreadgroupMemory = 1,

    ArgumentTypeTexture = 2,

    ArgumentTypeSampler = 3,

    ArgumentTypeImageblockData = 16,

    ArgumentTypeImageblock = 17,

    ArgumentTypeVisibleFunctionTable = 24,

    ArgumentTypePrimitiveAccelerationStructure = 25,

    ArgumentTypeInstanceAccelerationStructure = 26,

    ArgumentTypeIntersectionFunctionTable = 27
}
