namespace Metal.NET;

public enum MTLTessellationFactorStepFunction : ulong
{
    Constant = 0,

    PerPatch = 1,

    PerInstance = 2,

    PerPatchAndPerInstance = 3
}
