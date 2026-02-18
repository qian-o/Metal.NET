namespace Metal.NET;

[Flags]
public enum MTLAccelerationStructureInstanceOptions : uint
{
    MTLAccelerationStructureInstanceOptionNone = 0,

    MTLAccelerationStructureInstanceOptionDisableTriangleCulling = 1,

    MTLAccelerationStructureInstanceOptionTriangleFrontFacingWindingCounterClockwise = 2,

    MTLAccelerationStructureInstanceOptionOpaque = 4,

    MTLAccelerationStructureInstanceOptionNonOpaque = 8
}
