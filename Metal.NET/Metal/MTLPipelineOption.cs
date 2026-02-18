namespace Metal.NET;

[Flags]
public enum MTLPipelineOption : ulong
{
    MTLPipelineOptionNone = 0,
    MTLPipelineOptionArgumentInfo = 1,
    MTLPipelineOptionBindingInfo = 1,
    MTLPipelineOptionBufferTypeInfo = 2,
    MTLPipelineOptionFailOnBinaryArchiveMiss = 4
}
