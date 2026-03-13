namespace Metal.NET;

public class MTLLogState(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLLogState>
{
    #region INativeObject
    public static new MTLLogState Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLLogState New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public void AddLogHandler(MTLLogHandler block)
    {
        ObjectiveC.MsgSend(NativePtr, MTLLogStateBindings.AddLogHandler, block.NativePtr);
    }
}

file static class MTLLogStateBindings
{
    public static readonly Selector AddLogHandler = "addLogHandler:";
}
