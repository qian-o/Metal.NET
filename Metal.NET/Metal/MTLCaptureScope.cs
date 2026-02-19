namespace Metal.NET;

public readonly struct MTLCaptureScope(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLCommandQueue? CommandQueue
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureScopeBindings.CommandQueue);
            return ptr is not 0 ? new MTLCommandQueue(ptr) : default;
        }
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureScopeBindings.Device);
            return ptr is not 0 ? new MTLDevice(ptr) : default;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureScopeBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureScopeBindings.SetLabel, value?.NativePtr ?? 0);
    }

    public void BeginScope()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureScopeBindings.BeginScope);
    }

    public void EndScope()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureScopeBindings.EndScope);
    }
}

file static class MTLCaptureScopeBindings
{
    public static readonly Selector BeginScope = Selector.Register("beginScope");

    public static readonly Selector CommandQueue = Selector.Register("commandQueue");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector EndScope = Selector.Register("endScope");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
