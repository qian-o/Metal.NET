namespace Metal.NET;

[Flags]
public enum MTLTensorUsage : uint
{
    Compute = 1,

    Render = 2,

    MachineLearning = 4
}
