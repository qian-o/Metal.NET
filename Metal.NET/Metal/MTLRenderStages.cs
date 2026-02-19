namespace Metal.NET;

[Flags]
public enum MTLRenderStages : ulong
{
    Vertex = 1,

    Fragment = 2,

    Tile = 4,

    Object = 8,

    Mesh = 16
}
