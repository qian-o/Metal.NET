namespace Metal.NET;

[Flags]
public enum MTL4ShaderReflection : uint
{
    ShaderReflectionNone = 0,

    ShaderReflectionBindingInfo = 1,

    ShaderReflectionBufferTypeInfo = 2
}
