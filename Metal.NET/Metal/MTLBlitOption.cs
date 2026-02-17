namespace Metal.NET;

[Flags]
public enum MTLBlitOption : uint
{
    BlitOptionNone = 0,

    BlitOptionDepthFromDepthStencil = 1,

    BlitOptionStencilFromDepthStencil = 2,

    BlitOptionRowLinearPVRTC = 4
}
