namespace Metal.NET;

/// <summary>An instance you use to capture Metal command data in your app.</summary>
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

    #region Creating a capture scope - Properties

    /// <summary>The capture scope to use when a capture is initiated in Xcode.</summary>
    public MTLCaptureScope DefaultCaptureScope
    {
        get => GetProperty(ref field, MTLCaptureManagerBindings.DefaultCaptureScope);
        set => SetProperty(ref field, MTLCaptureManagerBindings.SetDefaultCaptureScope, value);
    }
    #endregion

    #region Monitoring capture - Properties

    /// <summary>A Boolean value that indicates whether Metal commands are being captured.</summary>
    public Bool8 IsCapturing
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLCaptureManagerBindings.IsCapturing);
    }
    #endregion

    #region Obtaining the shared capture manager - Methods

    /// <summary>Provides the shared capture manager for your Metal app.</summary>
    public static MTLCaptureManager SharedCaptureManager()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLCaptureManagerBindings.Class, MTLCaptureManagerBindings.SharedCaptureManager);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Querying support for a capture destination - Methods

    /// <summary>Checks to see whether a particular capture destination is supported.</summary>
    public bool SupportsDestination(MTLCaptureDestination destination)
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLCaptureManagerBindings.SupportsDestination, (nint)destination);
    }
    #endregion

    #region Creating a capture scope - Methods

    /// <summary>Creates a capture scope for commands submitted to a specific device object.</summary>
    public MTLCaptureScope NewCaptureScope(MTLDevice device)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCaptureManagerBindings.NewCaptureScope, device.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>Creates a capture scope for commands submitted to a specific device object.</summary>
    public MTLCaptureScope NewCaptureScope(MTLCommandQueue commandQueue)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCaptureManagerBindings.NewCaptureScopeWithCommandQueue, commandQueue.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>Creates a capture scope for commands submitted to a specific device object.</summary>
    public MTLCaptureScope NewCaptureScope(MTL4CommandQueue commandQueue)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCaptureManagerBindings.NewCaptureScopeWithMTL4CommandQueue, commandQueue.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Starting capture - Methods

    /// <summary>Starts capturing any of your app’s Metal commands, with the capture session defined by a descriptor object.</summary>
    public bool StartCapture(MTLCaptureDescriptor descriptor, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLCaptureManagerBindings.StartCapture, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    /// <summary>Starts capturing any of your app’s Metal commands, with the capture session defined by a descriptor object.</summary>
    public void StartCapture(MTLDevice device)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCaptureManagerBindings.StartCaptureWithDevice, device.NativePtr);
    }

    /// <summary>Starts capturing any of your app’s Metal commands, with the capture session defined by a descriptor object.</summary>
    public void StartCapture(MTLCommandQueue commandQueue)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCaptureManagerBindings.StartCaptureWithCommandQueue, commandQueue.NativePtr);
    }

    /// <summary>Starts capturing any of your app’s Metal commands, with the capture session defined by a descriptor object.</summary>
    public void StartCapture(MTLCaptureScope captureScope)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCaptureManagerBindings.StartCaptureWithScope, captureScope.NativePtr);
    }
    #endregion

    #region Stopping capture - Methods

    /// <summary>Stops capturing Metal commands.</summary>
    public void StopCapture()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCaptureManagerBindings.StopCapture);
    }
    #endregion
}

file static class MTLCaptureManagerBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLCaptureManager");

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
