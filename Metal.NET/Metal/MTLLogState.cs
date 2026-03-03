namespace Metal.NET;

public class MTLLogState(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLLogState>
{
    public static new MTLLogState Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLLogState Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public void AddLogHandler(MTLLogHandler block)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLLogStateBindings.AddLogHandler, block);
    }
}

file static class MTLLogStateBindings
{
    public static readonly Selector AddLogHandler = "addLogHandler:";
}
