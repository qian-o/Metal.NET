namespace Metal.NET;

public enum MTLAccelerationStructureInstanceDescriptorType : ulong
{
    AccelerationStructureInstanceDescriptorTypeDefault = 0,

    AccelerationStructureInstanceDescriptorTypeUserID = 1,

    AccelerationStructureInstanceDescriptorTypeMotion = 2,

    AccelerationStructureInstanceDescriptorTypeIndirect = 3,

    AccelerationStructureInstanceDescriptorTypeIndirectMotion = 4
}
