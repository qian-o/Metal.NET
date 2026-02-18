namespace Metal.NET;

[Flags]
public enum MTLColorWriteMask : ulong
{
    ColorWriteMaskNone = 0,

    ColorWriteMaskRed = 8,

    ColorWriteMaskGreen = 4,

    ColorWriteMaskBlue = 2,

    ColorWriteMaskAlpha = 1,

    ColorWriteMaskAll = 15,

    ColorWriteMaskUnspecialized = 16
}
