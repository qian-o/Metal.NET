namespace Metal.NET;

[Flags]
public enum MTLAccelerationStructureRefitOptions : ulong
{
    MTLAccelerationStructureRefitOptionVertexData = 1,
    MTLAccelerationStructureRefitOptionPerPrimitiveData = 2
}
