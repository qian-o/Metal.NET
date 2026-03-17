namespace Metal.NET;

/// <summary>
/// An encoder that writes GPU commands into a command buffer.
/// </summary>
public class MTLCommandEncoder(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLCommandEncoder>
{
    #region INativeObject
    public static new MTLCommandEncoder Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLCommandEncoder New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Identifying the command encoder - Properties

    /// <summary>
    /// The Metal device from which the command encoder was created.
    /// </summary>
    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLCommandEncoderBindings.Device);
    }

    /// <summary>
    /// A string that labels the command encoder.
    /// </summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLCommandEncoderBindings.Label);
        set => SetProperty(ref field, MTLCommandEncoderBindings.SetLabel, value);
    }
    #endregion

    #region Ending command encoding - Methods

    /// <summary>
    /// Declares that all command generation from the encoder is completed.
    /// </summary>
    public void EndEncoding()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandEncoderBindings.EndEncoding);
    }
    #endregion

    #region Annotating the command buffer with debug information - Methods

    /// <summary>
    /// Inserts a debug string into the captured frame data.
    /// </summary>
    public void InsertDebugSignpost(NSString @string)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandEncoderBindings.InsertDebugSignpost, @string.NativePtr);
    }

    /// <summary>
    /// Pushes a specific string onto a stack of debug group strings for the command encoder.
    /// </summary>
    public void PushDebugGroup(NSString @string)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandEncoderBindings.PushDebugGroup, @string.NativePtr);
    }

    /// <summary>
    /// Pops the latest string off of a stack of debug group strings for the command encoder.
    /// </summary>
    public void PopDebugGroup()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandEncoderBindings.PopDebugGroup);
    }
    #endregion

    #region Instance Methods - Methods

    /// <summary>
    /// Encodes a consumer barrier on work you commit to the same command queue.
    /// </summary>
    public void BarrierAfterQueueStages(MTLStages afterQueueStages, MTLStages beforeStages)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandEncoderBindings.BarrierAfterQueueStages, (nuint)afterQueueStages, (nuint)beforeStages);
    }
    #endregion
}

file static class MTLCommandEncoderBindings
{
    public static readonly Selector BarrierAfterQueueStages = "barrierAfterQueueStages:beforeStages:";

    public static readonly Selector Device = "device";

    public static readonly Selector EndEncoding = "endEncoding";

    public static readonly Selector InsertDebugSignpost = "insertDebugSignpost:";

    public static readonly Selector Label = "label";

    public static readonly Selector PopDebugGroup = "popDebugGroup";

    public static readonly Selector PushDebugGroup = "pushDebugGroup:";

    public static readonly Selector SetLabel = "setLabel:";
}
