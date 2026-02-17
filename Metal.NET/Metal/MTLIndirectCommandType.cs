namespace Metal.NET;

[Flags]
public enum MTLIndirectCommandType : uint
{
    IndirectCommandTypeDraw = 1,

    IndirectCommandTypeDrawIndexed = 2,

    IndirectCommandTypeDrawPatches = 4,

    IndirectCommandTypeDrawIndexedPatches = 8,

    IndirectCommandTypeConcurrentDispatch = 32,

    IndirectCommandTypeConcurrentDispatchThreads = 64,

    IndirectCommandTypeDrawMeshThreadgroups = 128,

    IndirectCommandTypeDrawMeshThreads = 256
}
