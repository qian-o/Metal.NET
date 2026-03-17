namespace Metal.NET;

public class MTLCaptureManager(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLCaptureManager>
{
    #region INativeObject
    public static new MTLCaptureManager Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLCaptureManager New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLCaptureManager() : this(ObjectiveC.AllocInit(MTLCaptureManagerBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLCaptureScope DefaultCaptureScope
    {
        get => GetProperty(ref field, MTLCaptureManagerBindings.DefaultCaptureScope);
        set => SetProperty(ref field, MTLCaptureManagerBindings.SetDefaultCaptureScope, value);
    }

    public Bool8 IsCapturing
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLCaptureManagerBindings.IsCapturing);
    }

    public MTLCaptureScope DefaultCaptureScope
    {
        get => GetProperty(ref field, MTLCaptureManagerBindings.DefaultCaptureScope);
        set => SetProperty(ref field, MTLCaptureManagerBindings.SetDefaultCaptureScope, value);
    }

    public Bool8 IsCapturing
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLCaptureManagerBindings.IsCapturing);
    }

    public void SetDefaultCaptureScope(MTLCaptureScope defaultCaptureScope)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCaptureManagerBindings.SetDefaultCaptureScope, defaultCaptureScope.NativePtr);
    }

    public static MTLCaptureManager SharedCaptureManager()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLCaptureManagerBindings.Class, MTLCaptureManagerBindings.SharedCaptureManager);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLCaptureScope NewCaptureScopeWithDevice(MTLDevice device)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCaptureManagerBindings.NewCaptureScopeWithDevice, device.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLCaptureScope NewCaptureScopeWithCommandQueue(MTLCommandQueue commandQueue)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCaptureManagerBindings.NewCaptureScopeWithCommandQueue, commandQueue.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLCaptureScope NewCaptureScopeWithMTL4CommandQueue(MTL4CommandQueue commandQueue)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCaptureManagerBindings.NewCaptureScopeWithMTL4CommandQueue, commandQueue.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public bool SupportsDestination(MTLCaptureDestination destination)
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLCaptureManagerBindings.SupportsDestination, (nint)destination);
    }

    public bool StartCaptureWithDescriptor(MTLCaptureDescriptor descriptor, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLCaptureManagerBindings.StartCaptureWithDescriptor, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    /// <summary>
    /// Deprecated: Use startCaptureWithDescriptor:error: instead
    /// </summary>
    [Obsolete("Use startCaptureWithDescriptor:error: instead")]
    public void StartCaptureWithDevice(MTLDevice device)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCaptureManagerBindings.StartCaptureWithDevice, device.NativePtr);
    }

    /// <summary>
    /// Deprecated: Use startCaptureWithDescriptor:error: instead
    /// </summary>
    [Obsolete("Use startCaptureWithDescriptor:error: instead")]
    public void StartCaptureWithCommandQueue(MTLCommandQueue commandQueue)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCaptureManagerBindings.StartCaptureWithCommandQueue, commandQueue.NativePtr);
    }

    /// <summary>
    /// Deprecated: Use startCaptureWithDescriptor:error: instead
    /// </summary>
    [Obsolete("Use startCaptureWithDescriptor:error: instead")]
    public void StartCaptureWithScope(MTLCaptureScope captureScope)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCaptureManagerBindings.StartCaptureWithScope, captureScope.NativePtr);
    }

    public void StopCapture()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCaptureManagerBindings.StopCapture);
    }
}

file static class MTLCaptureManagerBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLCaptureManager");

    public static readonly Selector DefaultCaptureScope = "defaultCaptureScope";

    public static readonly Selector IsCapturing = "isCapturing";

    public static readonly Selector NewCaptureScopeWithCommandQueue = "newCaptureScopeWithCommandQueue:";

    public static readonly Selector NewCaptureScopeWithDevice = "newCaptureScopeWithDevice:";

    public static readonly Selector NewCaptureScopeWithMTL4CommandQueue = "newCaptureScopeWithMTL4CommandQueue:";

    public static readonly Selector SetDefaultCaptureScope = "setDefaultCaptureScope:";

    public static readonly Selector SharedCaptureManager = "sharedCaptureManager";

    public static readonly Selector StartCaptureWithCommandQueue = "startCaptureWithCommandQueue:";

    public static readonly Selector StartCaptureWithDescriptor = "startCaptureWithDescriptor:error:";

    public static readonly Selector StartCaptureWithDevice = "startCaptureWithDevice:";

    public static readonly Selector StartCaptureWithScope = "startCaptureWithScope:";

    public static readonly Selector StopCapture = "stopCapture";

    public static readonly Selector SupportsDestination = "supportsDestination:";
}
