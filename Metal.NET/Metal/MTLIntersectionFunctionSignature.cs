namespace Metal.NET;

[Flags]
public enum MTLIntersectionFunctionSignature : ulong
{
    MTLIntersectionFunctionSignatureNone = 0,

    MTLIntersectionFunctionSignatureInstancing = 1,

    MTLIntersectionFunctionSignatureTriangleData = 2,

    MTLIntersectionFunctionSignatureWorldSpaceData = 4,

    MTLIntersectionFunctionSignatureInstanceMotion = 8,

    MTLIntersectionFunctionSignaturePrimitiveMotion = 16,

    MTLIntersectionFunctionSignatureExtendedLimits = 32,

    MTLIntersectionFunctionSignatureMaxLevels = 64,

    MTLIntersectionFunctionSignatureCurveData = 128,

    MTLIntersectionFunctionSignatureIntersectionFunctionBuffer = 256,

    MTLIntersectionFunctionSignatureUserData = 512
}
