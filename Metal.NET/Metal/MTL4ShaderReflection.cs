namespace Metal.NET;

[Flags]
public enum MTL4ShaderReflection : ulong
{
    ShaderReflectionNone = 0,

    ShaderReflectionBindingInfo = 1,

    ShaderReflectionBufferTypeInfo = 2
}
