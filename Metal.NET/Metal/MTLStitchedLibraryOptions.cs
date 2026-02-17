namespace Metal.NET;

[Flags]
public enum MTLStitchedLibraryOptions : uint
{
    StitchedLibraryOptionNone = 0,

    StitchedLibraryOptionFailOnBinaryArchiveMiss = 1,

    StitchedLibraryOptionStoreLibraryInMetalPipelinesScript = 2
}
