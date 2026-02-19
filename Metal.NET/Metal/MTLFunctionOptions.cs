namespace Metal.NET;

[Flags]
public enum MTLFunctionOptions : ulong
{
    None = 0,

    CompileToBinary = 1,

    StoreFunctionInMetalPipelinesScript = 2,

    StoreFunctionInMetalScript = 2,

    FailOnBinaryArchiveMiss = 4,

    PipelineIndependent = 8
}
