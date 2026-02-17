namespace Metal.NET;

public enum MTLLibraryError : uint
{
    Unsupported = 1,

    Internal = 2,

    CompileFailure = 3,

    CompileWarning = 4,

    FunctionNotFound = 5,

    FileNotFound = 6
}
