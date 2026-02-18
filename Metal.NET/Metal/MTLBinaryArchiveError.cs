namespace Metal.NET;

public enum MTLBinaryArchiveError : ulong
{
    MTLBinaryArchiveErrorNone = 0,

    MTLBinaryArchiveErrorInvalidFile = 1,

    MTLBinaryArchiveErrorUnexpectedElement = 2,

    MTLBinaryArchiveErrorCompilationFailure = 3,

    MTLBinaryArchiveErrorInternalError = 4
}
