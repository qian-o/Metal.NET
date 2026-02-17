namespace Metal.NET;

[Flags]
public enum MTLResourceUsage : uint
{
    ResourceUsageRead = 1,

    ResourceUsageWrite = 2,

    ResourceUsageSample = 4
}
