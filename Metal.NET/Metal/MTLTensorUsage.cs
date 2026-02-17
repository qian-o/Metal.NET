namespace Metal.NET;

[Flags]
public enum MTLTensorUsage : uint
{
    TensorUsageCompute = 1,

    TensorUsageRender = 2,

    TensorUsageMachineLearning = 4
}
