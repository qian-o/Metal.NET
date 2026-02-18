namespace Metal.NET;

public enum MTLStepFunction : ulong
{
    MTLStepFunctionConstant = 0,
    MTLStepFunctionPerVertex = 1,
    MTLStepFunctionPerInstance = 2,
    MTLStepFunctionPerPatch = 3,
    MTLStepFunctionPerPatchControlPoint = 4,
    MTLStepFunctionThreadPositionInGridX = 5,
    MTLStepFunctionThreadPositionInGridY = 6,
    MTLStepFunctionThreadPositionInGridXIndexed = 7,
    MTLStepFunctionThreadPositionInGridYIndexed = 8
}
