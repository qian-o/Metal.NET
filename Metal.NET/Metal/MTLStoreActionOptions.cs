namespace Metal.NET;

[Flags]
public enum MTLStoreActionOptions : ulong
{
    None = 0,

    CustomSamplePositions = 1,

    ValidMask = 1
}
