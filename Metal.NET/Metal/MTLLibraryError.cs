namespace Metal.NET;

public enum MTLLibraryError : ulong
{
    MTLLibraryErrorUnsupported = 1,

    MTLLibraryErrorInternal = 2,

    MTLLibraryErrorCompileFailure = 3,

    MTLLibraryErrorCompileWarning = 4,

    MTLLibraryErrorFunctionNotFound = 5,

    MTLLibraryErrorFileNotFound = 6
}
