namespace Metal.NET;

public class MTLCaptureManager(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLCaptureManager() : this(ObjectiveCRuntime.AllocInit(MTLCaptureManagerSelector.Class))
    {
    }

    public MTLCaptureScope? DefaultCaptureScope
    {
        get => GetNullableObject<MTLCaptureScope>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureManagerSelector.DefaultCaptureScope));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureManagerSelector.SetDefaultCaptureScope, value?.NativePtr ?? 0);
    }

    public bool IsCapturing
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCaptureManagerSelector.IsCapturing);
    }

    public MTLCaptureScope? NewCaptureScope(MTLDevice device)
    {
        return GetNullableObject<MTLCaptureScope>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureManagerSelector.NewCaptureScope, device.NativePtr));
    }

    public MTLCaptureScope? NewCaptureScope(MTLCommandQueue commandQueue)
    {
        return GetNullableObject<MTLCaptureScope>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureManagerSelector.NewCaptureScope, commandQueue.NativePtr));
    }

    public MTLCaptureScope? NewCaptureScope(MTL4CommandQueue commandQueue)
    {
        return GetNullableObject<MTLCaptureScope>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureManagerSelector.NewCaptureScope, commandQueue.NativePtr));
    }

    public static MTLCaptureManager? SharedCaptureManager()
    {
        return GetNullableObject<MTLCaptureManager>(ObjectiveCRuntime.MsgSendPtr(MTLCaptureManagerSelector.Class, MTLCaptureManagerSelector.SharedCaptureManager));
    }

    public bool StartCapture(MTLCaptureDescriptor descriptor, out NSError? error)
    {
        var result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCaptureManagerSelector.StartCapture, descriptor.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
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
