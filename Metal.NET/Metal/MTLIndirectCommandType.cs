namespace Metal.NET;

[Flags]
public enum MTLIndirectCommandType : ulong
{
    Draw = 1,

    DrawIndexed = 2,

    DrawPatches = 4,

    DrawIndexedPatches = 8,

    ConcurrentDispatch = 32,

    ConcurrentDispatchThreads = 64,

    DrawMeshThreadgroups = 128,

    DrawMeshThreads = 256
}
