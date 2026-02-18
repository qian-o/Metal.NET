namespace Metal.NET;

public partial class MTLCaptureScope : NativeObject
{
    public MTLCaptureScope(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureScopeSelector.Device);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureScopeSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureScopeSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public MTLCommandQueue? CommandQueue
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureScopeSelector.CommandQueue);
            return ptr is not 0 ? new(ptr) : null;
        }
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

file static class MTLCaptureScopeSelector
{
    public static readonly Selector BeginScope = Selector.Register("beginScope");

    public static readonly Selector CommandQueue = Selector.Register("commandQueue");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector EndScope = Selector.Register("endScope");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
