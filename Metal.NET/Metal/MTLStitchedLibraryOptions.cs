namespace Metal.NET;

[Flags]
public enum MTLStitchedLibraryOptions : ulong
{
    MTLStitchedLibraryOptionNone = 0,

    MTLStitchedLibraryOptionFailOnBinaryArchiveMiss = 1,

    MTLStitchedLibraryOptionStoreLibraryInMetalPipelinesScript = 2
}
