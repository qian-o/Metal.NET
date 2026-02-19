namespace Metal.NET;

[Flags]
public enum MTLPipelineOption : ulong
{
    None = 0,

    ArgumentInfo = 1,

    BindingInfo = 1,

    BufferTypeInfo = 2,

    FailOnBinaryArchiveMiss = 4
}
