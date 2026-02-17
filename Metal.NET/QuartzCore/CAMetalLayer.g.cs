namespace Metal.NET;

public class CAMetalLayer : IDisposable
{
    public CAMetalLayer(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~CAMetalLayer()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(CAMetalLayer value)
    {
        return value.NativePtr;
    }

    public static implicit operator CAMetalLayer(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("CAMetalLayer");

    public static CAMetalLayer New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new CAMetalLayer(ptr);
    }

    public void SetDevice(MTLDevice device)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, CAMetalLayerSelector.SetDevice, device.NativePtr);
    }

    public void SetPixelFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, CAMetalLayerSelector.SetPixelFormat, (nint)(uint)pixelFormat);
    }

    public void SetFramebufferOnly(Bool8 framebufferOnly)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, CAMetalLayerSelector.SetFramebufferOnly, (nint)framebufferOnly.Value);
    }

    public void SetMaximumDrawableCount(uint maximumDrawableCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, CAMetalLayerSelector.SetMaximumDrawableCount, (nint)maximumDrawableCount);
    }

    public void SetDisplaySyncEnabled(Bool8 displaySyncEnabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, CAMetalLayerSelector.SetDisplaySyncEnabled, (nint)displaySyncEnabled.Value);
    }

    public void SetColorspace(int colorspace)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, CAMetalLayerSelector.SetColorspace, colorspace);
    }

    public void SetAllowsNextDrawableTimeout(Bool8 allowsNextDrawableTimeout)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, CAMetalLayerSelector.SetAllowsNextDrawableTimeout, (nint)allowsNextDrawableTimeout.Value);
    }

    public static CAMetalLayer Layer()
    {
        var result = new CAMetalLayer(ObjectiveCRuntime.intptr_objc_msgSend(s_class, CAMetalLayerSelector.Layer));

        return result;
    }

}

file class CAMetalLayerSelector
{
    public static readonly Selector SetDevice = Selector.Register("setDevice:");
    public static readonly Selector SetPixelFormat = Selector.Register("setPixelFormat:");
    public static readonly Selector SetFramebufferOnly = Selector.Register("setFramebufferOnly:");
    public static readonly Selector SetMaximumDrawableCount = Selector.Register("setMaximumDrawableCount:");
    public static readonly Selector SetDisplaySyncEnabled = Selector.Register("setDisplaySyncEnabled:");
    public static readonly Selector SetColorspace = Selector.Register("setColorspace:");
    public static readonly Selector SetAllowsNextDrawableTimeout = Selector.Register("setAllowsNextDrawableTimeout:");
    public static readonly Selector Layer = Selector.Register("layer");
}
