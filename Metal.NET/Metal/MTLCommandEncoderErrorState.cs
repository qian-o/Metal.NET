namespace Metal.NET;

public enum MTLCommandEncoderErrorState : long
{
    MTLCommandEncoderErrorStateUnknown = 0,
    MTLCommandEncoderErrorStateCompleted = 1,
    MTLCommandEncoderErrorStateAffected = 2,
    MTLCommandEncoderErrorStatePending = 3,
    MTLCommandEncoderErrorStateFaulted = 4
}
