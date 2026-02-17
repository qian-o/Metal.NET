namespace Metal.NET;

file class MTLCaptureDescriptorSelector
{
    public static readonly Selector SetCaptureObject_ = Selector.Register("setCaptureObject:");
    public static readonly Selector SetDestination_ = Selector.Register("setDestination:");
    public static readonly Selector SetOutputURL_ = Selector.Register("setOutputURL:");
}

public class MTLCaptureDescriptor : IDisposable
{
    public MTLCaptureDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLCaptureDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLCaptureDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLCaptureDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLCaptureDescriptor");

    public static MTLCaptureDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLCaptureDescriptor(ptr);
    }

    public void SetCaptureObject(nint captureObject)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCaptureDescriptorSelector.SetCaptureObject_, captureObject);
    }

    public void SetDestination(MTLCaptureDestination destination)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCaptureDescriptorSelector.SetDestination_, (nint)(uint)destination);
    }

    public void SetOutputURL(NSURL outputURL)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCaptureDescriptorSelector.SetOutputURL_, outputURL.NativePtr);
    }

}
