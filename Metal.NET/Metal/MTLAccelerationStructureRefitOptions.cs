namespace Metal.NET;

[Flags]
public enum MTLAccelerationStructureRefitOptions : uint
{
    AccelerationStructureRefitOptionVertexData = 1,

    AccelerationStructureRefitOptionPerPrimitiveData = 2
}
