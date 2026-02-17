namespace Metal.NET;

file class MTLLogStateSelector
{
    public static readonly Selector AddLogHandler_ = Selector.Register("addLogHandler:");
}

public class MTLLogState : IDisposable
{
    public MTLLogState(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLLogState()
    {
        Release();
    }

    public nint NativePtr { get; }

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

    public void AddLogHandler(nint handler)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLogStateSelector.AddLogHandler_, handler);
    }

}
