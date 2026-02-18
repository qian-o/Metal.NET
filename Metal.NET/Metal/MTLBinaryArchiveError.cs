namespace Metal.NET;

public enum MTLBinaryArchiveError : ulong
{
    BinaryArchiveErrorNone = 0,

    BinaryArchiveErrorInvalidFile = 1,

    BinaryArchiveErrorUnexpectedElement = 2,

    BinaryArchiveErrorCompilationFailure = 3,

    BinaryArchiveErrorInternalError = 4
}
