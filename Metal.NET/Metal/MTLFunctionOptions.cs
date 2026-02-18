namespace Metal.NET;

[Flags]
public enum MTLFunctionOptions : ulong
{
    MTLFunctionOptionNone = 0,
    MTLFunctionOptionCompileToBinary = 1,
    MTLFunctionOptionStoreFunctionInMetalPipelinesScript = 2,
    MTLFunctionOptionStoreFunctionInMetalScript = 2,
    MTLFunctionOptionFailOnBinaryArchiveMiss = 4,
    MTLFunctionOptionPipelineIndependent = 8
}
