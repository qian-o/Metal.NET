namespace Metal.NET;

public enum MTLTessellationPartitionMode : ulong
{
    TessellationPartitionModePow2 = 0,

    TessellationPartitionModeInteger = 1,

    TessellationPartitionModeFractionalOdd = 2,

    TessellationPartitionModeFractionalEven = 3
}
