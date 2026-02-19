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
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureManagerBindings.NewCaptureScope, device.NativePtr);

        return nativePtr is not 0 ? new(nativePtr) : null;
    }

    public MTLCaptureScope? NewCaptureScope(MTLCommandQueue commandQueue)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureManagerBindings.NewCaptureScopeWithCommandQueue, commandQueue.NativePtr);

        return nativePtr is not 0 ? new(nativePtr) : null;
    }

    public MTLCaptureScope? NewCaptureScope(MTL4CommandQueue commandQueue)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureManagerBindings.NewCaptureScopeWithMTL4CommandQueue, commandQueue.NativePtr);

        return nativePtr is not 0 ? new(nativePtr) : null;
    }

    public static MTLCaptureManager? SharedCaptureManager()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLCaptureManagerBindings.Class, MTLCaptureManagerBindings.SharedCaptureManager);

        if (nativePtr is 0)
        {
            return null;
        }

        ObjectiveCRuntime.Retain(nativePtr);

        return new(nativePtr);
    }

    public bool StartCapture(MTLCaptureDescriptor descriptor, out NSError? error)
    {
        var result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCaptureManagerBindings.StartCapture, descriptor.NativePtr, out nint errorPtr);

        if (errorPtr is not 0)
        {
            ObjectiveCRuntime.Retain(errorPtr);

            error = new(errorPtr);
        }
        else
        {
            error = null;
        }

        return result;
    }

    public void StartCapture(MTLDevice device)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureManagerBindings.StartCaptureWithDevice, device.NativePtr);
    }

    public void StartCapture(MTLCommandQueue commandQueue)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureManagerBindings.StartCaptureWithCommandQueue, commandQueue.NativePtr);
    }

    public void StartCapture(MTLCaptureScope captureScope)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureManagerBindings.StartCaptureWithScope, captureScope.NativePtr);
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

    public static readonly Selector NewCaptureScopeWithCommandQueue = "newCaptureScopeWithCommandQueue:";

    public static readonly Selector NewCaptureScopeWithMTL4CommandQueue = "newCaptureScopeWithMTL4CommandQueue:";

    public static readonly Selector SetDefaultCaptureScope = "setDefaultCaptureScope:";

    public static readonly Selector SharedCaptureManager = "sharedCaptureManager";

    public static readonly Selector StartCapture = "startCaptureWithDescriptor:error:";

    public static readonly Selector StartCaptureWithCommandQueue = "startCaptureWithCommandQueue:";

    public static readonly Selector StartCaptureWithDevice = "startCaptureWithDevice:";

    public static readonly Selector StartCaptureWithScope = "startCaptureWithScope:";

    public static readonly Selector StopCapture = "stopCapture";

    public static readonly Selector SupportsDestination = "supportsDestination:";
}
