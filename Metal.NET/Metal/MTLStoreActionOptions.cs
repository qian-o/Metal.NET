namespace Metal.NET;

[Flags]
public enum MTLStoreActionOptions : ulong
{
    MTLStoreActionOptionNone = 0,
    MTLStoreActionOptionCustomSamplePositions = 1,
    MTLStoreActionOptionValidMask = 1
}
