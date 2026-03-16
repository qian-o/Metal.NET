namespace Metal.NET;

/// <summary>A container that provides additional information about a runtime failure a GPU encounters as it runs the commands in a command buffer.</summary>
public class MTLCommandBufferEncoderInfo(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLCommandBufferEncoderInfo>
{
    #region INativeObject
    public static new MTLCommandBufferEncoderInfo Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLCommandBufferEncoderInfo New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Inspecting execution information - Properties

    /// <summary>The name of the encoder that generates the error information.</summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLCommandBufferEncoderInfoBindings.Label);
    }

    /// <summary>An array of debug signposts that Metal records as the GPU executes the commands of the encoder’s pass.</summary>
    public NSString[] DebugSignposts
    {
        get => GetArrayProperty<NSString>(MTLCommandBufferEncoderInfoBindings.DebugSignposts);
    }

    /// <summary>The execution status of the command encoder.</summary>
    public MTLCommandEncoderErrorState ErrorState
    {
        get => (MTLCommandEncoderErrorState)ObjectiveC.MsgSendLong(NativePtr, MTLCommandBufferEncoderInfoBindings.ErrorState);
    }
    #endregion
}

file static class MTLCommandBufferEncoderInfoBindings
{
    public static readonly Selector DebugSignposts = "debugSignposts";

    public static readonly Selector ErrorState = "errorState";

    public static readonly Selector Label = "label";
}
