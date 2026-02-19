namespace Metal.NET;

[Flags]
public enum MTLAccelerationStructureRefitOptions : ulong
{
    VertexData = 1,

    PerPrimitiveData = 2
}
