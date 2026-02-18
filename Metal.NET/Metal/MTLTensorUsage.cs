namespace Metal.NET;

[Flags]
public enum MTLTensorUsage : ulong
{
    MTLTensorUsageCompute = 1,
    MTLTensorUsageRender = 2,
    MTLTensorUsageMachineLearning = 4
}
