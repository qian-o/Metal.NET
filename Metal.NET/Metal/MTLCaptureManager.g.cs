#nullable enable

namespace Metal.NET;

file class MTLCaptureManagerSelector
{
    public static readonly Selector NewCaptureScope_ = Selector.Register("newCaptureScope:");
    public static readonly Selector SetDefaultCaptureScope_ = Selector.Register("setDefaultCaptureScope:");
    public static readonly Selector StartCapture_error_ = Selector.Register("startCapture:error:");
    public static readonly Selector StartCapture_ = Selector.Register("startCapture:");
    public static readonly Selector StopCapture = Selector.Register("stopCapture");
    public static readonly Selector SupportsDestination_ = Selector.Register("supportsDestination:");
    public static readonly Selector SharedCaptureManager = Selector.Register("sharedCaptureManager");
}

public class MTLCaptureManager : IDisposable
{
    public MTLCaptureManager(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLCaptureManager()
    {
        Release();
    }

    public nint NativePtr { get; }

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLCaptureManager");

    public MTLCaptureScope NewCaptureScope(MTLDevice device)
    {
        var result = new MTLCaptureScope(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLCaptureManagerSelector.NewCaptureScope_, device.NativePtr));

        return result;
    }

    public MTLCaptureScope NewCaptureScope(MTLCommandQueue commandQueue)
    {
        var result = new MTLCaptureScope(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLCaptureManagerSelector.NewCaptureScope_, commandQueue.NativePtr));

        return result;
    }

    public MTLCaptureScope NewCaptureScope(MTL4CommandQueue commandQueue)
    {
        var result = new MTLCaptureScope(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLCaptureManagerSelector.NewCaptureScope_, commandQueue.NativePtr));

        return result;
    }

    public void SetDefaultCaptureScope(MTLCaptureScope defaultCaptureScope)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCaptureManagerSelector.SetDefaultCaptureScope_, defaultCaptureScope.NativePtr);
    }

    public Bool8 StartCapture(MTLCaptureDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLCaptureManagerSelector.StartCapture_error_, descriptor.NativePtr, out errorPtr) is not 0;
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public void StartCapture(MTLDevice device)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCaptureManagerSelector.StartCapture_, device.NativePtr);
    }

    public void StartCapture(MTLCommandQueue commandQueue)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCaptureManagerSelector.StartCapture_, commandQueue.NativePtr);
    }

    public void StartCapture(MTLCaptureScope captureScope)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCaptureManagerSelector.StartCapture_, captureScope.NativePtr);
    }

    public void StopCapture()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCaptureManagerSelector.StopCapture);
    }

    public Bool8 SupportsDestination(MTLCaptureDestination destination)
    {
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLCaptureManagerSelector.SupportsDestination_, (nint)(uint)destination) is not 0;

        return result;
    }

    public static MTLCaptureManager SharedCaptureManager()
    {
        var result = new MTLCaptureManager(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLCaptureManagerSelector.SharedCaptureManager));

        return result;
    }

}
