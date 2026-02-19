namespace Metal.NET;

[Flags]
public enum MTLIntersectionFunctionSignature : ulong
{
    None = 0,

    Instancing = 1,

    TriangleData = 2,

    WorldSpaceData = 4,

    InstanceMotion = 8,

    PrimitiveMotion = 16,

    ExtendedLimits = 32,

    MaxLevels = 64,

    CurveData = 128,

    IntersectionFunctionBuffer = 256,

    UserData = 512
}
