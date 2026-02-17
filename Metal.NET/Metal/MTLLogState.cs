namespace Metal.NET;

public class MTLLogState : IDisposable
{
    public MTLLogState(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLLogState()
    {
        Release();
    }

    public nint NativePtr { get; }

    public void AddLogHandler(nint handler)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLLogStateSelector.AddLogHandler, handler);
    }

    public static implicit operator nint(MTLLogState value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLLogState(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

}

file class MTLLogStateSelector
{
    public static readonly Selector AddLogHandler = Selector.Register("addLogHandler:");
}
