namespace Metal.NET;

/// <summary>A container for shader log messages.</summary>
public class MTLLogState(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLLogState>
{
    #region INativeObject
    public static new MTLLogState Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLLogState New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Instance Methods - Methods

    /// <summary>Adds a log handler to customize the presentation of shader logging.</summary>
    public void AddLogHandler(MTLLogHandler block)
    {
        ObjectiveC.MsgSend(NativePtr, MTLLogStateBindings.AddLogHandler, block.NativePtr);
    }
    #endregion
}

file static class MTLLogStateBindings
{
    public static readonly Selector AddLogHandler = "addLogHandler:";
}
