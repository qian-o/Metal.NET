namespace Metal.NET;

public class MTLCaptureManager(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLCaptureManager() : this(ObjectiveCRuntime.AllocInit(MTLCaptureManagerBindings.Class))
    {
    }

    public MTLCaptureScope? DefaultCaptureScope
    {
        get => GetProperty(ref field, MTLCaptureManagerBindings.DefaultCaptureScope);
        set => SetProperty(ref field, MTLCaptureManagerBindings.SetDefaultCaptureScope, value);
    }

    public bool IsCapturing
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCaptureManagerBindings.IsCapturing);
    }

    public MTLCaptureScope? NewCaptureScope(MTLDevice device)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureManagerBindings.NewCaptureScope, device.NativePtr);
        return ptr is not 0 ? new MTLCaptureScope(ptr) : null;
    }

    public MTLCaptureScope? NewCaptureScope(MTLCommandQueue commandQueue)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureManagerBindings.NewCaptureScope, commandQueue.NativePtr);
        return ptr is not 0 ? new MTLCaptureScope(ptr) : null;
    }

    public MTLCaptureScope? NewCaptureScope(MTL4CommandQueue commandQueue)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureManagerBindings.NewCaptureScope, commandQueue.NativePtr);
        return ptr is not 0 ? new MTLCaptureScope(ptr) : null;
    }

    public static MTLCaptureManager? SharedCaptureManager()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLCaptureManagerBindings.Class, MTLCaptureManagerBindings.SharedCaptureManager);
        return ptr is not 0 ? new MTLCaptureManager(ptr) : null;
    }

    public bool StartCapture(MTLCaptureDescriptor descriptor, out NSError? error)
    {
        var result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCaptureManagerBindings.StartCapture, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;
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

    public static readonly Selector DefaultCaptureScope = "defaultCaptureScope";

    public static readonly Selector IsCapturing = "isCapturing";

    public static readonly Selector NewCaptureScope = "newCaptureScopeWithDevice:";

    public static readonly Selector SetDefaultCaptureScope = "setDefaultCaptureScope:";

    public static readonly Selector SharedCaptureManager = "sharedCaptureManager";

    public static readonly Selector StartCapture = "startCaptureWithDescriptor:error:";

    public static readonly Selector StopCapture = "stopCapture";

    public static readonly Selector SupportsDestination = "supportsDestination:";
}
