namespace Metal.NET;

public enum MTLLibraryError : ulong
{
    LibraryErrorUnsupported = 1,

    LibraryErrorInternal = 2,

    LibraryErrorCompileFailure = 3,

    LibraryErrorCompileWarning = 4,

    LibraryErrorFunctionNotFound = 5,

    LibraryErrorFileNotFound = 6
}
