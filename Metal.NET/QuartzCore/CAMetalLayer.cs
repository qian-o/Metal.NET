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
        var ptr = ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.MsgSendPtr(ptr, Selector.Register("init"));

        return new CAMetalLayer(ptr);
    }

    public void SetDevice(MTLDevice device)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerSelector.SetDevice, device.NativePtr);
    }

    public void SetPixelFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerSelector.SetPixelFormat, (nint)(uint)pixelFormat);
    }

    public void SetFramebufferOnly(Bool8 framebufferOnly)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerSelector.SetFramebufferOnly, (nint)framebufferOnly.Value);
    }

    public void SetMaximumDrawableCount(uint maximumDrawableCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerSelector.SetMaximumDrawableCount, (nint)maximumDrawableCount);
    }

    public void SetDisplaySyncEnabled(Bool8 displaySyncEnabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerSelector.SetDisplaySyncEnabled, (nint)displaySyncEnabled.Value);
    }

    public void SetColorspace(int colorspace)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerSelector.SetColorspace, colorspace);
    }

    public void SetAllowsNextDrawableTimeout(Bool8 allowsNextDrawableTimeout)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerSelector.SetAllowsNextDrawableTimeout, (nint)allowsNextDrawableTimeout.Value);
    }

    public static CAMetalLayer Layer()
    {
        CAMetalLayer result = new(ObjectiveCRuntime.MsgSendPtr(s_class, CAMetalLayerSelector.Layer));

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
