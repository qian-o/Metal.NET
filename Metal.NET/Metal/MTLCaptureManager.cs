namespace Metal.NET;

public class MTLCaptureManager : IDisposable
{
    public MTLCaptureManager(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLCaptureManager()
    {
        Release();
    }

    public nint NativePtr { get; }

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLCaptureManager");

    public MTLCaptureScope DefaultCaptureScope
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureManagerSelector.DefaultCaptureScope));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureManagerSelector.SetDefaultCaptureScope, value.NativePtr);
    }

    public Bool8 IsCapturing => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCaptureManagerSelector.IsCapturing);

    public MTLCaptureScope NewCaptureScope(MTLDevice device)
    {
        MTLCaptureScope result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureManagerSelector.NewCaptureScope, device.NativePtr));

        return result;
    }

    public MTLCaptureScope NewCaptureScope(MTLCommandQueue commandQueue)
    {
        MTLCaptureScope result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureManagerSelector.NewCaptureScope, commandQueue.NativePtr));

        return result;
    }

    public MTLCaptureScope NewCaptureScope(MTL4CommandQueue commandQueue)
    {
        MTLCaptureScope result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureManagerSelector.NewCaptureScope, commandQueue.NativePtr));

        return result;
    }

    public Bool8 StartCapture(MTLCaptureDescriptor descriptor, out NSError? error)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCaptureManagerSelector.StartCaptureError, descriptor.NativePtr, out nint errorPtr);

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

    public Bool8 SupportsDestination(MTLCaptureDestination destination)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCaptureManagerSelector.SupportsDestination, (uint)destination);

        return result;
    }

    public static implicit operator nint(MTLCaptureManager value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLCaptureManager(nint value)
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

    public static MTLCaptureManager SharedCaptureManager()
    {
        MTLCaptureManager result = new(ObjectiveCRuntime.MsgSendPtr(s_class, MTLCaptureManagerSelector.SharedCaptureManager));

        return result;
    }

}

file class MTLCaptureManagerSelector
{
    public static readonly Selector DefaultCaptureScope = Selector.Register("defaultCaptureScope");

    public static readonly Selector SetDefaultCaptureScope = Selector.Register("setDefaultCaptureScope:");

    public static readonly Selector IsCapturing = Selector.Register("isCapturing");

    public static readonly Selector NewCaptureScope = Selector.Register("newCaptureScope:");

    public static readonly Selector StartCaptureError = Selector.Register("startCapture:error:");

    public static readonly Selector StartCapture = Selector.Register("startCapture:");

    public static readonly Selector StopCapture = Selector.Register("stopCapture");

    public static readonly Selector SupportsDestination = Selector.Register("supportsDestination:");

    public static readonly Selector SharedCaptureManager = Selector.Register("sharedCaptureManager");
}
