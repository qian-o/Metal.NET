namespace Metal.NET;

public readonly struct MTLCaptureManager(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLCaptureManager value) => new(value.NativePtr);

    public MTLCaptureManager() : this(ObjectiveC.AllocInit(MTLCaptureManagerBindings.Class))
    {
    }

    public MTLCaptureManager Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLCaptureScope DefaultCaptureScope
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLCaptureManagerBindings.DefaultCaptureScope));
        set => ObjectiveC.MsgSend(NativePtr, MTLCaptureManagerBindings.SetDefaultCaptureScope, value.NativePtr);
    }

    public Bool8 IsCapturing
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLCaptureManagerBindings.IsCapturing);
    }

    public MTLCaptureScope MakeCaptureScope(MTLDevice device)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCaptureManagerBindings.NewCaptureScopeWithDevice, device.NativePtr);

        return new(nativePtr);
    }

    public MTLCaptureScope MakeCaptureScope(MTLCommandQueue commandQueue)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCaptureManagerBindings.NewCaptureScopeWithCommandQueue, commandQueue.NativePtr);

        return new(nativePtr);
    }

    public MTLCaptureScope MakeCaptureScope(MTL4CommandQueue commandQueue)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCaptureManagerBindings.NewCaptureScopeWithMTL4CommandQueue, commandQueue.NativePtr);

        return new(nativePtr);
    }

    public bool SupportsDestination(MTLCaptureDestination destination)
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLCaptureManagerBindings.SupportsDestination, (nint)destination);
    }

    public bool StartCapture(MTLCaptureDescriptor descriptor, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLCaptureManagerBindings.StartCaptureWithDescriptor_Error, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr);

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

        return new(nativePtr);
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
