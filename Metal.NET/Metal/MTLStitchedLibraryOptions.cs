namespace Metal.NET;

[Flags]
public enum MTLStitchedLibraryOptions : ulong
{
    None = 0,

    FailOnBinaryArchiveMiss = 1,

    StoreLibraryInMetalPipelinesScript = 2
}
