namespace Metal.NET;

[Flags]
public enum MTLResourceUsage : ulong
{
    MTLResourceUsageRead = 1,
    MTLResourceUsageWrite = 2,
    MTLResourceUsageSample = 4
}
