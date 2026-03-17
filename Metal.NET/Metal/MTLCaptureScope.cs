namespace Metal.NET;

/// <summary>
/// A type that can programmatically customize a GPU frame capture.
/// </summary>
public class MTLCaptureScope(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLCaptureScope>
{
    #region INativeObject
    public static new MTLCaptureScope Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLCaptureScope New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Identifying the capture scope - Properties

    /// <summary>
    /// A string that helps you identify the capture scope.
    /// </summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLCaptureScopeBindings.Label);
        set => SetProperty(ref field, MTLCaptureScopeBindings.SetLabel, value);
    }

    /// <summary>
    /// The device object from which you created the capture scope.
    /// </summary>
    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLCaptureScopeBindings.Device);
    }

    /// <summary>
    /// The command queue that this capture scope uses to limit which commands are recorded.
    /// </summary>
    public MTLCommandQueue CommandQueue
    {
        get => GetProperty(ref field, MTLCaptureScopeBindings.CommandQueue);
    }
    #endregion

    #region Defining capture scope boundaries - Methods

    /// <summary>
    /// Tells Metal to begin recording command information.
    /// </summary>
    public void BeginScope()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCaptureScopeBindings.BeginScope);
    }

    /// <summary>
    /// Tells Metal to stop recording command information.
    /// </summary>
    public void EndScope()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCaptureScopeBindings.EndScope);
    }
    #endregion
}

file static class MTLCaptureScopeBindings
{
    public static readonly Selector BeginScope = "beginScope";

    public static readonly Selector CommandQueue = "commandQueue";

    public static readonly Selector Device = "device";

    public static readonly Selector EndScope = "endScope";

    public static readonly Selector Label = "label";

    public static readonly Selector SetLabel = "setLabel:";
}
