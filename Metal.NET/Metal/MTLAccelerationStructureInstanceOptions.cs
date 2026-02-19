namespace Metal.NET;

[Flags]
public enum MTLAccelerationStructureInstanceOptions : uint
{
    None = 0,

    DisableTriangleCulling = 1,

    TriangleFrontFacingWindingCounterClockwise = 2,

    Opaque = 4,

    NonOpaque = 8
}
