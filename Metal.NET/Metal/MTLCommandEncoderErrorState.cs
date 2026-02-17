namespace Metal.NET;

public enum MTLCommandEncoderErrorState : int
{
    CommandEncoderErrorStateUnknown = 0,

    CommandEncoderErrorStateCompleted = 1,

    CommandEncoderErrorStateAffected = 2,

    CommandEncoderErrorStatePending = 3,

    CommandEncoderErrorStateFaulted = 4
}
