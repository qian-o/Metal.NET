namespace Metal.NET;

public enum MTLBindingType : long
{
    MTLBindingTypeBuffer = 0,
    MTLBindingTypeThreadgroupMemory = 1,
    MTLBindingTypeTexture = 2,
    MTLBindingTypeSampler = 3,
    MTLBindingTypeImageblockData = 16,
    MTLBindingTypeImageblock = 17,
    MTLBindingTypeVisibleFunctionTable = 24,
    MTLBindingTypePrimitiveAccelerationStructure = 25,
    MTLBindingTypeInstanceAccelerationStructure = 26,
    MTLBindingTypeIntersectionFunctionTable = 27,
    MTLBindingTypeObjectPayload = 34,
    MTLBindingTypeTensor = 37
}
