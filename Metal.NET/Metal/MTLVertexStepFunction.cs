namespace Metal.NET;

public enum MTLVertexStepFunction : uint
{
    Constant = 0,

    PerVertex = 1,

    PerInstance = 2,

    PerPatch = 3,

    PerPatchControlPoint = 4
}
