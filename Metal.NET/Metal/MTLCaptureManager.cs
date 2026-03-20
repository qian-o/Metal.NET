namespace Metal.NET;

public partial class MTLCaptureManager(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLCaptureManager>
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

    public MTLCaptureScope MakeCaptureScope(MTLDevice device)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCaptureManagerBindings.NewCaptureScopeWithDevice, device.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLCaptureScope MakeCaptureScope(MTLCommandQueue commandQueue)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCaptureManagerBindings.NewCaptureScopeWithCommandQueue, commandQueue.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLCaptureScope MakeCaptureScope(MTL4CommandQueue commandQueue)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCaptureManagerBindings.NewCaptureScopeWithMTL4CommandQueue, commandQueue.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public bool SupportsDestination(MTLCaptureDestination destination)
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLCaptureManagerBindings.SupportsDestination, (nint)destination);
    }

    public bool StartCapture(MTLCaptureDescriptor descriptor, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLCaptureManagerBindings.StartCaptureWithDescriptor_Error, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    /// <summary>
    /// Deprecated: Use startCaptureWithDescriptor:error: instead
    /// </summary>
    [Obsolete("Use startCaptureWithDescriptor:error: instead")]
    public void StartCapture(MTLDevice device)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCaptureManagerBindings.StartCaptureWithDevice, device.NativePtr);
    }

    /// <summary>
    /// Deprecated: Use startCaptureWithDescriptor:error: instead
    /// </summary>
    [Obsolete("Use startCaptureWithDescriptor:error: instead")]
    public void StartCapture(MTLCommandQueue commandQueue)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCaptureManagerBindings.StartCaptureWithCommandQueue, commandQueue.NativePtr);
    }

    /// <summary>
    /// Deprecated: Use startCaptureWithDescriptor:error: instead
    /// </summary>
    [Obsolete("Use startCaptureWithDescriptor:error: instead")]
    public void StartCapture(MTLCaptureScope captureScope)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCaptureManagerBindings.StartCaptureWithScope, captureScope.NativePtr);
    }

    public void StopCapture()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCaptureManagerBindings.StopCapture);
    }

    public static MTLCaptureManager Shared()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLCaptureManagerBindings.Class, MTLCaptureManagerBindings.SharedCaptureManager);

        return new(nativePtr, NativeObjectOwnership.Owned);
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

    public static readonly Selector StartCaptureWithDescriptor_Error = "startCaptureWithDescriptor:error:";

    public static readonly Selector StartCaptureWithDevice = "startCaptureWithDevice:";

    public static readonly Selector StartCaptureWithScope = "startCaptureWithScope:";

    public static readonly Selector StopCapture = "stopCapture";

    public static readonly Selector SupportsDestination = "supportsDestination:";
}
