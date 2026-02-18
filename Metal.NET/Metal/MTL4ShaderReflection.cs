namespace Metal.NET;

[Flags]
public enum MTL4ShaderReflection : ulong
{
    MTL4ShaderReflectionNone = 0,

    MTL4ShaderReflectionBindingInfo = 1,

    MTL4ShaderReflectionBufferTypeInfo = 2
}
