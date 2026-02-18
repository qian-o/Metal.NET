namespace Metal.NET;

public enum MTLStencilOperation : ulong
{
    StencilOperationKeep = 0,

    StencilOperationZero = 1,

    StencilOperationReplace = 2,

    StencilOperationIncrementClamp = 3,

    StencilOperationDecrementClamp = 4,

    StencilOperationInvert = 5,

    StencilOperationIncrementWrap = 6,

    StencilOperationDecrementWrap = 7
}
