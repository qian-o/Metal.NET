namespace Metal.NET;

file class CAMetalLayerSelector
{
    public static readonly Selector SetDevice_ = Selector.Register("setDevice:");
    public static readonly Selector SetPixelFormat_ = Selector.Register("setPixelFormat:");
    public static readonly Selector SetFramebufferOnly_ = Selector.Register("setFramebufferOnly:");
    public static readonly Selector SetMaximumDrawableCount_ = Selector.Register("setMaximumDrawableCount:");
    public static readonly Selector SetDisplaySyncEnabled_ = Selector.Register("setDisplaySyncEnabled:");
    public static readonly Selector SetColorspace_ = Selector.Register("setColorspace:");
    public static readonly Selector SetAllowsNextDrawableTimeout_ = Selector.Register("setAllowsNextDrawableTimeout:");
    public static readonly Selector Layer = Selector.Register("layer");
}

public class CAMetalLayer : IDisposable
{
    public CAMetalLayer(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, CAMetalLayerSelector.SetDevice_, device.NativePtr);
    }

    public void SetPixelFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, CAMetalLayerSelector.SetPixelFormat_, (nint)(uint)pixelFormat);
    }

    public void SetFramebufferOnly(Bool8 framebufferOnly)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, CAMetalLayerSelector.SetFramebufferOnly_, (nint)framebufferOnly.Value);
    }

    public void SetMaximumDrawableCount(nuint maximumDrawableCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, CAMetalLayerSelector.SetMaximumDrawableCount_, (nint)maximumDrawableCount);
    }

    public void SetDisplaySyncEnabled(Bool8 displaySyncEnabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, CAMetalLayerSelector.SetDisplaySyncEnabled_, (nint)displaySyncEnabled.Value);
    }

    public void SetColorspace(nint colorspace)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, CAMetalLayerSelector.SetColorspace_, colorspace);
    }

    public void SetAllowsNextDrawableTimeout(Bool8 allowsNextDrawableTimeout)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, CAMetalLayerSelector.SetAllowsNextDrawableTimeout_, (nint)allowsNextDrawableTimeout.Value);
    }

    public static CAMetalLayer Layer()
    {
        var result = new CAMetalLayer(ObjectiveCRuntime.intptr_objc_msgSend(s_class, CAMetalLayerSelector.Layer));

        return result;
    }

}
