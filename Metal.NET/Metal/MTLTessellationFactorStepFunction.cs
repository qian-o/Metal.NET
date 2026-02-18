namespace Metal.NET;

public enum MTLTessellationFactorStepFunction : ulong
{
    MTLTessellationFactorStepFunctionConstant = 0,

    MTLTessellationFactorStepFunctionPerPatch = 1,

    MTLTessellationFactorStepFunctionPerInstance = 2,

    MTLTessellationFactorStepFunctionPerPatchAndPerInstance = 3
}
