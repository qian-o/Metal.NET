namespace Metal.NET;

[Flags]
public enum MTLBlitOption : ulong
{
    MTLBlitOptionNone = 0,
    MTLBlitOptionDepthFromDepthStencil = 1,
    MTLBlitOptionStencilFromDepthStencil = 2,
    MTLBlitOptionRowLinearPVRTC = 4
}
