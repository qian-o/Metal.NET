namespace Metal.NET;

public enum MTLTessellationPartitionMode : uint
{
    TessellationPartitionModePow2 = 0,

    TessellationPartitionModeInteger = 1,

    TessellationPartitionModeFractionalOdd = 2,

    TessellationPartitionModeFractionalEven = 3
}
