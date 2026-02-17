namespace Metal.NET;

[Flags]
public enum MTLAccelerationStructureInstanceOptions : uint
{
    AccelerationStructureInstanceOptionNone = 0,

    AccelerationStructureInstanceOptionDisableTriangleCulling = 1,

    AccelerationStructureInstanceOptionTriangleFrontFacingWindingCounterClockwise = 2,

    AccelerationStructureInstanceOptionOpaque = 4,

    AccelerationStructureInstanceOptionNonOpaque = 8
}
