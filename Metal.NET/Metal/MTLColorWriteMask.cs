namespace Metal.NET;

[Flags]
public enum MTLColorWriteMask : uint
{
    None = 0,

    Red = 8,

    Green = 4,

    Blue = 2,

    Alpha = 1,

    All = 15,

    Unspecialized = 16
}
