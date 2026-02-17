namespace Metal.NET;

public enum MTLBindingType : int
{
    BindingTypeBuffer = 0,

    BindingTypeThreadgroupMemory = 1,

    BindingTypeTexture = 2,

    BindingTypeSampler = 3,

    BindingTypeImageblockData = 16,

    BindingTypeImageblock = 17,

    BindingTypeVisibleFunctionTable = 24,

    BindingTypePrimitiveAccelerationStructure = 25,

    BindingTypeInstanceAccelerationStructure = 26,

    BindingTypeIntersectionFunctionTable = 27,

    BindingTypeObjectPayload = 34,

    BindingTypeTensor = 37
}
