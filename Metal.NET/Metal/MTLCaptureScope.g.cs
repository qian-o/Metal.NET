namespace Metal.NET;

file class MTLCaptureScopeSelector
{
    public static readonly Selector SetLabel_ = Selector.Register("setLabel:");
    public static readonly Selector BeginScope = Selector.Register("beginScope");
    public static readonly Selector EndScope = Selector.Register("endScope");
}

public class MTLCaptureScope : IDisposable
{
    public MTLCaptureScope(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLCaptureScope()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLCaptureScope value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLCaptureScope(nint value)
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

    public void SetLabel(NSString pLabel)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCaptureScopeSelector.SetLabel_, pLabel.NativePtr);
    }

    public void BeginScope()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCaptureScopeSelector.BeginScope);
    }

    public void EndScope()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCaptureScopeSelector.EndScope);
    }

}
