namespace Metal.NET;

[Flags]
public enum MTLRenderStages : uint
{
    RenderStageVertex = 1,

    RenderStageFragment = 2,

    RenderStageTile = 4,

    RenderStageObject = 8,

    RenderStageMesh = 16
}
