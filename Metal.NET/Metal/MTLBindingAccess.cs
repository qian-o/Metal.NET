namespace Metal.NET;

public enum MTLBindingAccess : ulong
{
    ReadOnly = 0,

    ReadWrite = 1,

    WriteOnly = 2,

    ArgumentAccessReadOnly = 0,

    ArgumentAccessReadWrite = 1,

    ArgumentAccessWriteOnly = 2
}
