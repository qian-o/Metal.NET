namespace Metal.NET;

public class MTLCaptureScope : IDisposable
{
    public MTLCaptureScope(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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

    public MTLDevice Device
    {
        get => new MTLDevice(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureScopeSelector.Device));
    }

    public NSString Label
    {
        get => new NSString(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureScopeSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureScopeSelector.SetLabel, value.NativePtr);
    }

    public MTLCommandQueue CommandQueue
    {
        get => new MTLCommandQueue(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureScopeSelector.CommandQueue));
    }

    public void BeginScope()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureScopeSelector.BeginScope);
    }

    public void EndScope()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureScopeSelector.EndScope);
    }

}

file class MTLCaptureScopeSelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector CommandQueue = Selector.Register("commandQueue");

    public static readonly Selector BeginScope = Selector.Register("beginScope");

    public static readonly Selector EndScope = Selector.Register("endScope");
}
