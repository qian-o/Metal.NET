namespace Metal.NET;

[Flags]
public enum MTLStages : ulong
{
    MTLStageVertex = 1,
    MTLStageFragment = 2,
    MTLStageTile = 4,
    MTLStageObject = 8,
    MTLStageMesh = 16,
    MTLStageResourceState = 67108864,
    MTLStageDispatch = 134217728,
    MTLStageBlit = 268435456,
    MTLStageAccelerationStructure = 536870912,
    MTLStageMachineLearning = 1073741824,
    MTLStageAll = 9223372036854775807
}
