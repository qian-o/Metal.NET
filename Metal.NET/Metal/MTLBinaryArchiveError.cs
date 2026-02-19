namespace Metal.NET;

public enum MTLBinaryArchiveError : ulong
{
    None = 0,

    InvalidFile = 1,

    UnexpectedElement = 2,

    CompilationFailure = 3,

    InternalError = 4
}
