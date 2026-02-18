namespace Metal.NET;

[Flags]
public enum MTLColorWriteMask : ulong
{
    MTLColorWriteMaskNone = 0,
    MTLColorWriteMaskRed = 8,
    MTLColorWriteMaskGreen = 4,
    MTLColorWriteMaskBlue = 2,
    MTLColorWriteMaskAlpha = 1,
    MTLColorWriteMaskAll = 15,
    MTLColorWriteMaskUnspecialized = 16
}
