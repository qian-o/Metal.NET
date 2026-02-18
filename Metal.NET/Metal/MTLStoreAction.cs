namespace Metal.NET;

public enum MTLStoreAction : ulong
{
    StoreActionDontCare = 0,

    StoreActionStore = 1,

    StoreActionMultisampleResolve = 2,

    StoreActionStoreAndMultisampleResolve = 3,

    StoreActionUnknown = 4,

    StoreActionCustomSampleDepthStore = 5
}
