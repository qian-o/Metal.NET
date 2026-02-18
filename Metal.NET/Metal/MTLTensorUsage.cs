namespace Metal.NET;

[Flags]
public enum MTLTensorUsage : ulong
{
    TensorUsageCompute = 1,

    TensorUsageRender = 2,

    TensorUsageMachineLearning = 4
}
