namespace Metal.NET;

public class MTLCaptureManager : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLCaptureManager");

    public MTLCaptureManager(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLCaptureManager() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLCaptureManager()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLCaptureScope DefaultCaptureScope
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureManagerSelector.DefaultCaptureScope));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureManagerSelector.SetDefaultCaptureScope, value.NativePtr);
    }

    public Bool8 IsCapturing
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCaptureManagerSelector.IsCapturing);
    }

    public static implicit operator nint(MTLCaptureManager value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLCaptureManager(nint value)
    {
        return new(value);
    }

    public MTLCaptureScope NewCaptureScope(MTLDevice device)
    {
        MTLCaptureScope result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureManagerSelector.NewCaptureScopeWithMTL4CommandQueue, device.NativePtr));

        return result;
    }

    public MTLCaptureScope NewCaptureScope(MTLCommandQueue commandQueue)
    {
        MTLCaptureScope result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureManagerSelector.NewCaptureScopeWithMTL4CommandQueue, commandQueue.NativePtr));

        return result;
    }

    public MTLCaptureScope NewCaptureScope(MTL4CommandQueue commandQueue)
    {
        MTLCaptureScope result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureManagerSelector.NewCaptureScopeWithMTL4CommandQueue, commandQueue.NativePtr));

        return result;
    }

    public Bool8 StartCapture(MTLCaptureDescriptor descriptor, out NSError? error)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCaptureManagerSelector.StartCaptureWithScope, descriptor.NativePtr, out nint errorPtr);

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public void StartCapture(MTLDevice device)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureManagerSelector.StartCaptureWithScope, device.NativePtr);
    }

    public void StartCapture(MTLCommandQueue commandQueue)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureManagerSelector.StartCaptureWithScope, commandQueue.NativePtr);
    }

    public void StartCapture(MTLCaptureScope captureScope)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureManagerSelector.StartCaptureWithScope, captureScope.NativePtr);
    }

    public void StopCapture()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureManagerSelector.StopCapture);
    }

    public Bool8 SupportsDestination(MTLCaptureDestination destination)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCaptureManagerSelector.SupportsDestination, (ulong)destination);

        return result;
    }

    public static MTLCaptureManager SharedCaptureManager()
    {
        MTLCaptureManager result = new(ObjectiveCRuntime.MsgSendPtr(Class, MTLCaptureManagerSelector.SharedCaptureManager));

        return result;
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
}

file class MTLCaptureManagerSelector
{
    public static readonly Selector DefaultCaptureScope = Selector.Register("defaultCaptureScope");

    public static readonly Selector SetDefaultCaptureScope = Selector.Register("setDefaultCaptureScope:");

    public static readonly Selector IsCapturing = Selector.Register("isCapturing");

    public static readonly Selector NewCaptureScopeWithMTL4CommandQueue = Selector.Register("newCaptureScopeWithMTL4CommandQueue:");

    public static readonly Selector StartCaptureWithScope = Selector.Register("startCaptureWithScope:");

    public static readonly Selector StopCapture = Selector.Register("stopCapture");

    public static readonly Selector SupportsDestination = Selector.Register("supportsDestination:");

    public static readonly Selector SharedCaptureManager = Selector.Register("sharedCaptureManager");
}
