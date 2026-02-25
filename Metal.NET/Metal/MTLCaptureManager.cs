namespace Metal.NET;

public class MTLCaptureManager(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLCaptureManager>
{
    public static MTLCaptureManager Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLCaptureManager Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLCaptureManager() : this(ObjectiveCRuntime.AllocInit(MTLCaptureManagerBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLCaptureScope DefaultCaptureScope
    {
        get => GetProperty(ref field, MTLCaptureManagerBindings.DefaultCaptureScope);
        set => SetProperty(ref field, MTLCaptureManagerBindings.SetDefaultCaptureScope, value);
    }

    public Bool8 IsCapturing
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCaptureManagerBindings.IsCapturing);
    }

    public MTLCaptureScope NewCaptureScope(MTLDevice device)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureManagerBindings.NewCaptureScope, device.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLCaptureScope NewCaptureScope(MTLCommandQueue commandQueue)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureManagerBindings.NewCaptureScopeWithCommandQueue, commandQueue.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLCaptureScope NewCaptureScope(MTL4CommandQueue commandQueue)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureManagerBindings.NewCaptureScopeWithMTL4CommandQueue, commandQueue.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static MTLCaptureManager SharedCaptureManager()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLCaptureManagerBindings.Class, MTLCaptureManagerBindings.SharedCaptureManager);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public bool StartCapture(MTLCaptureDescriptor descriptor, out NSError error)
    {
        bool result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCaptureManagerBindings.StartCapture, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Borrowed);

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
