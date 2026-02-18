namespace Metal.NET;

public enum MTLTessellationFactorStepFunction : ulong
{
    TessellationFactorStepFunctionConstant = 0,

    TessellationFactorStepFunctionPerPatch = 1,

    TessellationFactorStepFunctionPerInstance = 2,

    TessellationFactorStepFunctionPerPatchAndPerInstance = 3
}
