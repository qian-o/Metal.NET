namespace Metal.NET;

[Flags]
public enum MTLBlitOption : uint
{
    None = 0,

    DepthFromDepthStencil = 1,

    StencilFromDepthStencil = 2,

    RowLinearPVRTC = 4
}
