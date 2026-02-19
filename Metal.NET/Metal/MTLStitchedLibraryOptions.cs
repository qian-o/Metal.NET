namespace Metal.NET;

[Flags]
public enum MTLStitchedLibraryOptions : ulong
{
    StitchedLibraryOptionNone = 0,

    StitchedLibraryOptionFailOnBinaryArchiveMiss = 1,

    StitchedLibraryOptionStoreLibraryInMetalPipelinesScript = 2
}
