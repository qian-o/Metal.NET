namespace Metal.NET;

public enum MTLStepFunction : uint
{
    StepFunctionConstant = 0,

    StepFunctionPerVertex = 1,

    StepFunctionPerInstance = 2,

    StepFunctionPerPatch = 3,

    StepFunctionPerPatchControlPoint = 4,

    StepFunctionThreadPositionInGridX = 5,

    StepFunctionThreadPositionInGridY = 6,

    StepFunctionThreadPositionInGridXIndexed = 7,

    StepFunctionThreadPositionInGridYIndexed = 8
}
