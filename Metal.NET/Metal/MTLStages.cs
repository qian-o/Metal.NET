namespace Metal.NET;

[Flags]
public enum MTLStages : uint
{
    StageVertex = 1,

    StageFragment = 2,

    StageTile = 4,

    StageObject = 8,

    StageMesh = 16,

    StageResourceState = 67108864,

    StageDispatch = 134217728,

    StageBlit = 268435456,

    StageAccelerationStructure = 536870912,

    StageMachineLearning = 1073741824,

    StageAll = 4294967295
}
