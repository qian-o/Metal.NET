namespace Metal.NET;

/// <summary>
/// A specialized memory buffer that stores a GPU’s counter set data.
/// </summary>
public class MTLCounterSampleBuffer(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLCounterSampleBuffer>
{
    #region INativeObject
    public static new MTLCounterSampleBuffer Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLCounterSampleBuffer New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Inspecting the counter sample buffer’s configuration - Properties

    /// <summary>
    /// A string that identifies the counter sample buffer.
    /// </summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLCounterSampleBufferBindings.Label);
    }

    /// <summary>
    /// The GPU device instance that owns the counter sample buffer.
    /// </summary>
    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLCounterSampleBufferBindings.Device);
    }

    /// <summary>
    /// The number of samples in the buffer.
    /// </summary>
    public nuint SampleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLCounterSampleBufferBindings.SampleCount);
    }
    #endregion

    #region Resolving the counter sample buffer’s data - Methods

    /// <summary>
    /// Transforms samples of a GPU’s counter set from the driver’s internal format to a standard Metal data structure.
    /// </summary>
    public NSData ResolveCounterRange(NSRange range)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCounterSampleBufferBindings.ResolveCounterRange, range);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion
}

file static class MTLCounterSampleBufferBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector ResolveCounterRange = "resolveCounterRange:";

    public static readonly Selector SampleCount = "sampleCount";
}
