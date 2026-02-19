namespace Metal.NET;

[Flags]
public enum MTLStages : ulong
{
    Vertex = 1,

    Fragment = 2,

    Tile = 4,

    Object = 8,

    Mesh = 16,

    ResourceState = 67108864,

    Dispatch = 134217728,

    Blit = 268435456,

    AccelerationStructure = 536870912,

    MachineLearning = 1073741824,

    All = 9223372036854775807
}
