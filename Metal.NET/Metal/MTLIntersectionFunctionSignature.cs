namespace Metal.NET;

[Flags]
public enum MTLIntersectionFunctionSignature : uint
{
    IntersectionFunctionSignatureNone = 0,

    IntersectionFunctionSignatureInstancing = 1,

    IntersectionFunctionSignatureTriangleData = 2,

    IntersectionFunctionSignatureWorldSpaceData = 4,

    IntersectionFunctionSignatureInstanceMotion = 8,

    IntersectionFunctionSignaturePrimitiveMotion = 16,

    IntersectionFunctionSignatureExtendedLimits = 32,

    IntersectionFunctionSignatureMaxLevels = 64,

    IntersectionFunctionSignatureCurveData = 128,

    IntersectionFunctionSignatureIntersectionFunctionBuffer = 256,

    IntersectionFunctionSignatureUserData = 512
}
