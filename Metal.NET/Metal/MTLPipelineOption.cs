namespace Metal.NET;

[Flags]
public enum MTLPipelineOption : ulong
{
    PipelineOptionNone = 0,

    PipelineOptionArgumentInfo = 1,

    PipelineOptionBindingInfo = 1,

    PipelineOptionBufferTypeInfo = 2,

    PipelineOptionFailOnBinaryArchiveMiss = 4
}
