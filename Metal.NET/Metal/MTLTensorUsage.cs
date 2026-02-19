namespace Metal.NET;

[Flags]
public enum MTLTensorUsage : ulong
{
    Compute = 1,

    Render = 2,

    MachineLearning = 4
}
