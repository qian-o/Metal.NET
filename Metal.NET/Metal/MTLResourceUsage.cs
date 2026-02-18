namespace Metal.NET;

[Flags]
public enum MTLResourceUsage : ulong
{
    ResourceUsageRead = 1,

    ResourceUsageWrite = 2,

    ResourceUsageSample = 4
}
