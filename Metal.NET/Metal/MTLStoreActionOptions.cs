namespace Metal.NET;

[Flags]
public enum MTLStoreActionOptions : ulong
{
    StoreActionOptionNone = 0,

    StoreActionOptionCustomSamplePositions = 1,

    StoreActionOptionValidMask = 1
}
