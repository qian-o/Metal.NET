namespace Metal.NET;

[Flags]
public enum MTLIndirectCommandType : uint
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
