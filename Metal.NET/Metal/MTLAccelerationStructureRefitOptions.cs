namespace Metal.NET;

[Flags]
public enum MTLAccelerationStructureRefitOptions : ulong
{
    AccelerationStructureRefitOptionVertexData = 1,

    AccelerationStructureRefitOptionPerPrimitiveData = 2
}
