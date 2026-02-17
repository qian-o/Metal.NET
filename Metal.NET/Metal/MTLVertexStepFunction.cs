namespace Metal.NET;

public enum MTLVertexStepFunction : uint
{
    VertexStepFunctionConstant = 0,

    VertexStepFunctionPerVertex = 1,

    VertexStepFunctionPerInstance = 2,

    VertexStepFunctionPerPatch = 3,

    VertexStepFunctionPerPatchControlPoint = 4
}
