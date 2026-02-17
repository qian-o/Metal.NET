namespace Metal.NET;

public enum MTLDynamicLibraryError : uint
{
    None = 0,
    InvalidFile = 1,
    CompilationFailure = 2,
    UnresolvedInstallName = 3,
    DependencyLoadFailure = 4,
    Unsupported = 5
}
