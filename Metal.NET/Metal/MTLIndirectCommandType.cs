namespace Metal.NET;

[Flags]
public enum MTLIndirectCommandType : ulong
{
    MTLIndirectCommandTypeDraw = 1,

    MTLIndirectCommandTypeDrawIndexed = 2,

    MTLIndirectCommandTypeDrawPatches = 4,

    MTLIndirectCommandTypeDrawIndexedPatches = 8,

    MTLIndirectCommandTypeConcurrentDispatch = 32,

    MTLIndirectCommandTypeConcurrentDispatchThreads = 64,

    MTLIndirectCommandTypeDrawMeshThreadgroups = 128,

    MTLIndirectCommandTypeDrawMeshThreads = 256
}
