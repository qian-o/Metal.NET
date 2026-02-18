namespace Metal.NET;

[Flags]
public enum MTLFunctionOptions : ulong
{
    FunctionOptionNone = 0,

    FunctionOptionCompileToBinary = 1,

    FunctionOptionStoreFunctionInMetalPipelinesScript = 2,

    FunctionOptionStoreFunctionInMetalScript = 2,

    FunctionOptionFailOnBinaryArchiveMiss = 4,

    FunctionOptionPipelineIndependent = 8
}
