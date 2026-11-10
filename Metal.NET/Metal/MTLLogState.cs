namespace Metal.NET;

public readonly struct MTLLogState(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLLogState value) => new(value.NativePtr);

    public MTLLogState Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void AddLogHandler(MTLAddLogHandlerBlock block)
    {
        ObjectiveC.MsgSend(NativePtr, MTLLogStateBindings.AddLogHandler, block.NativePtr);
    }
}

file static class MTLLogStateBindings
{
    public static readonly Selector AddLogHandler = "addLogHandler:";
}
