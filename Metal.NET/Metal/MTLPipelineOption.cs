namespace Metal.NET;

[Flags]
public enum MTLPipelineOption : uint
{
    None = 0,

    ArgumentInfo = 1,

    BindingInfo = 1,

    BufferTypeInfo = 2,

    FailOnBinaryArchiveMiss = 4
}
