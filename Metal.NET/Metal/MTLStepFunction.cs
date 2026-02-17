namespace Metal.NET;

public enum MTLStepFunction : uint
{
    Constant = 0,
    PerVertex = 1,
    PerInstance = 2,
    PerPatch = 3,
    PerPatchControlPoint = 4,
    ThreadPositionInGridX = 5,
    ThreadPositionInGridY = 6,
    ThreadPositionInGridXIndexed = 7,
    ThreadPositionInGridYIndexed = 8
}
