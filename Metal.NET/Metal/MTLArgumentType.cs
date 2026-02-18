namespace Metal.NET;

public enum MTLArgumentType : ulong
{
    MTLArgumentTypeBuffer = 0,
    MTLArgumentTypeThreadgroupMemory = 1,
    MTLArgumentTypeTexture = 2,
    MTLArgumentTypeSampler = 3,
    MTLArgumentTypeImageblockData = 16,
    MTLArgumentTypeImageblock = 17,
    MTLArgumentTypeVisibleFunctionTable = 24,
    MTLArgumentTypePrimitiveAccelerationStructure = 25,
    MTLArgumentTypeInstanceAccelerationStructure = 26,
    MTLArgumentTypeIntersectionFunctionTable = 27
}
