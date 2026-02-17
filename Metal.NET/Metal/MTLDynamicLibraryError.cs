namespace Metal.NET;

public enum MTLDynamicLibraryError : uint
{
    DynamicLibraryErrorNone = 0,

    DynamicLibraryErrorInvalidFile = 1,

    DynamicLibraryErrorCompilationFailure = 2,

    DynamicLibraryErrorUnresolvedInstallName = 3,

    DynamicLibraryErrorDependencyLoadFailure = 4,

    DynamicLibraryErrorUnsupported = 5
}
