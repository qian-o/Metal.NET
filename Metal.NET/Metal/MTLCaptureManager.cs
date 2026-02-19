namespace Metal.NET;

public readonly struct MTLCaptureManager(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLCaptureManager() : this(ObjectiveCRuntime.AllocInit(MTLCaptureManagerBindings.Class))
    {
    }

    public MTLCaptureScope? DefaultCaptureScope
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureManagerBindings.DefaultCaptureScope);
            return ptr is not 0 ? new MTLCaptureScope(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureManagerBindings.SetDefaultCaptureScope, value?.NativePtr ?? 0);
    }

    public bool IsCapturing
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCaptureManagerBindings.IsCapturing);
    }

    public MTLCaptureScope? NewCaptureScope(MTLDevice device)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureManagerBindings.NewCaptureScope, device.NativePtr);
        return ptr is not 0 ? new MTLCaptureScope(ptr) : default;
    }

    public MTLCaptureScope? NewCaptureScope(MTLCommandQueue commandQueue)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureManagerBindings.NewCaptureScope, commandQueue.NativePtr);
        return ptr is not 0 ? new MTLCaptureScope(ptr) : default;
    }

    public MTLCaptureScope? NewCaptureScope(MTL4CommandQueue commandQueue)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureManagerBindings.NewCaptureScope, commandQueue.NativePtr);
        return ptr is not 0 ? new MTLCaptureScope(ptr) : default;
    }

    public static MTLCaptureManager? SharedCaptureManager()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLCaptureManagerBindings.Class, MTLCaptureManagerBindings.SharedCaptureManager);
        return ptr is not 0 ? new MTLCaptureManager(ptr) : default;
    }

    public bool StartCapture(MTLCaptureDescriptor descriptor, out NSError? error)
    {
        var result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCaptureManagerBindings.StartCapture, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return result;
    }

    public void StartCapture(MTLDevice device)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureManagerBindings.StartCapture, device.NativePtr);
    }

    public void StartCapture(MTLCommandQueue commandQueue)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureManagerBindings.StartCapture, commandQueue.NativePtr);
    }

    public void StartCapture(MTLCaptureScope captureScope)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureManagerBindings.StartCapture, captureScope.NativePtr);
    }

    public void StopCapture()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureManagerBindings.StopCapture);
    }

    public bool SupportsDestination(MTLCaptureDestination destination)
    {
        return ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCaptureManagerBindings.SupportsDestination, (nint)destination);
    }
}

file static class MTLCaptureManagerBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLCaptureManager");

    public static readonly Selector DefaultCaptureScope = Selector.Register("defaultCaptureScope");

    public static readonly Selector IsCapturing = Selector.Register("isCapturing");

    public static readonly Selector NewCaptureScope = Selector.Register("newCaptureScopeWithDevice:");

    public static readonly Selector SetDefaultCaptureScope = Selector.Register("setDefaultCaptureScope:");

    public static readonly Selector SharedCaptureManager = Selector.Register("sharedCaptureManager");

    public static readonly Selector StartCapture = Selector.Register("startCaptureWithDescriptor:error:");

    public static readonly Selector StopCapture = Selector.Register("stopCapture");

    public static readonly Selector SupportsDestination = Selector.Register("supportsDestination:");
}
