namespace Metal.NET;

public class MTL4CommandBufferOptions : IDisposable
{
    public MTL4CommandBufferOptions(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTL4CommandBufferOptions()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4CommandBufferOptions value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4CommandBufferOptions(nint value)
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

    public void SetLogState(MTLLogState logState)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferOptionsSelector.SetLogState, logState.NativePtr);
    }

}

file class MTL4CommandBufferOptionsSelector
{
    public static readonly Selector SetLogState = Selector.Register("setLogState:");
}
