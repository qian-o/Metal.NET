namespace Metal.NET;

public partial class MTLCaptureManager : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLCaptureManager");

    public MTLCaptureManager(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLCaptureScope? DefaultCaptureScope
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureManagerSelector.DefaultCaptureScope);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureManagerSelector.SetDefaultCaptureScope, value?.NativePtr ?? 0);
    }

    public bool IsCapturing
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCaptureManagerSelector.IsCapturing);
    }

    public MTLCaptureScope? NewCaptureScope(MTLDevice device)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureManagerSelector.NewCaptureScope, device.NativePtr);
        return ptr is not 0 ? new(ptr) : null;
    }

    public MTLCaptureScope? NewCaptureScope(MTLCommandQueue commandQueue)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureManagerSelector.NewCaptureScope, commandQueue.NativePtr);
        return ptr is not 0 ? new(ptr) : null;
    }

    public MTLCaptureScope? NewCaptureScope(MTL4CommandQueue commandQueue)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureManagerSelector.NewCaptureScope, commandQueue.NativePtr);
        return ptr is not 0 ? new(ptr) : null;
    }

    public static MTLCaptureManager? SharedCaptureManager()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(Class, MTLCaptureManagerSelector.SharedCaptureManager);
        return ptr is not 0 ? new(ptr) : null;
    }

    public bool StartCapture(MTLCaptureDescriptor descriptor, out NSError? error)
    {
        var result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCaptureManagerSelector.StartCapture, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new(errorPtr) : null;
        return result;
    }

    public void StartCapture(MTLDevice device)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureManagerSelector.StartCapture, device.NativePtr);
    }

    public void StartCapture(MTLCommandQueue commandQueue)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureManagerSelector.StartCapture, commandQueue.NativePtr);
    }

    public void StartCapture(MTLCaptureScope captureScope)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureManagerSelector.StartCapture, captureScope.NativePtr);
    }

    public void StopCapture()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureManagerSelector.StopCapture);
    }

    public bool SupportsDestination(MTLCaptureDestination destination)
    {
        return ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCaptureManagerSelector.SupportsDestination, (nint)destination);
    }
}

file static class MTLCaptureManagerSelector
{
    public static readonly Selector DefaultCaptureScope = Selector.Register("defaultCaptureScope");

    public static readonly Selector IsCapturing = Selector.Register("isCapturing");

    public static readonly Selector NewCaptureScope = Selector.Register("newCaptureScopeWithDevice:");

    public static readonly Selector SetDefaultCaptureScope = Selector.Register("setDefaultCaptureScope:");

    public static readonly Selector SharedCaptureManager = Selector.Register("sharedCaptureManager");

    public static readonly Selector StartCapture = Selector.Register("startCaptureWithDescriptor:error:");

    public static readonly Selector StopCapture = Selector.Register("stopCapture");

    public static readonly Selector SupportsDestination = Selector.Register("supportsDestination:");
}
