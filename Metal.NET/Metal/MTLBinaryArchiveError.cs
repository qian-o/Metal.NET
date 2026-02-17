namespace Metal.NET;

public enum MTLBinaryArchiveError : uint
{
    BinaryArchiveErrorNone = 0,

    BinaryArchiveErrorInvalidFile = 1,

    BinaryArchiveErrorUnexpectedElement = 2,

    BinaryArchiveErrorCompilationFailure = 3,

    BinaryArchiveErrorInternalError = 4
}
