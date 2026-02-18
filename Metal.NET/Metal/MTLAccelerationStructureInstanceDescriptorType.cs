namespace Metal.NET;

public enum MTLAccelerationStructureInstanceDescriptorType : ulong
{
    MTLAccelerationStructureInstanceDescriptorTypeDefault = 0,

    MTLAccelerationStructureInstanceDescriptorTypeUserID = 1,

    MTLAccelerationStructureInstanceDescriptorTypeMotion = 2,

    MTLAccelerationStructureInstanceDescriptorTypeIndirect = 3,

    MTLAccelerationStructureInstanceDescriptorTypeIndirectMotion = 4
}
