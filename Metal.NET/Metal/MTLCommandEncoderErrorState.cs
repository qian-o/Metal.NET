namespace Metal.NET;

public enum MTLCommandEncoderErrorState : long
{
    Unknown = 0,

    Completed = 1,

    Affected = 2,

    Pending = 3,

    Faulted = 4
}
