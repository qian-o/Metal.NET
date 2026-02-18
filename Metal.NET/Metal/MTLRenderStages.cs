namespace Metal.NET;

[Flags]
public enum MTLRenderStages : ulong
{
    MTLRenderStageVertex = 1,

    MTLRenderStageFragment = 2,

    MTLRenderStageTile = 4,

    MTLRenderStageObject = 8,

    MTLRenderStageMesh = 16
}
