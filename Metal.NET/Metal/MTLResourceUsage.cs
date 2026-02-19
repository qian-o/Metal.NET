namespace Metal.NET;

[Flags]
public enum MTLResourceUsage : ulong
{
    Read = 1,

    Write = 2,

    Sample = 4
}
