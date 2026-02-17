namespace Metal.NET;

[Flags]
public enum MTLResourceUsage : uint
{
    Read = 1,

    Write = 2,

    Sample = 4
}
