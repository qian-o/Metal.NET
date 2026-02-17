namespace Metal.NET;

[Flags]
public enum MTLStoreActionOptions : uint
{
    StoreActionOptionNone = 0,

    StoreActionOptionCustomSamplePositions = 1,

    StoreActionOptionValidMask = 1
}
