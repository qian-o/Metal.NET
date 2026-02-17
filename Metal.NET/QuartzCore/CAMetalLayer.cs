namespace Metal.NET;

public class CAMetalLayer : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("CAMetalLayer");

    public CAMetalLayer(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    public CAMetalLayer() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~CAMetalLayer()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLDevice Device
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, CAMetalLayerSelector.Device));
        set => ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerSelector.SetDevice, value.NativePtr);
    }

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, CAMetalLayerSelector.PixelFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerSelector.SetPixelFormat, (uint)value);
    }

    public Bool8 FramebufferOnly
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, CAMetalLayerSelector.FramebufferOnly);
        set => ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerSelector.SetFramebufferOnly, value);
    }

    public CAMetalDrawable NextDrawable
    {
        get
        {
            return new(ObjectiveCRuntime.MsgSendPtr(NativePtr, CAMetalLayerSelector.NextDrawable));
        }
    }

    public nuint MaximumDrawableCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, CAMetalLayerSelector.MaximumDrawableCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerSelector.SetMaximumDrawableCount, value);
    }

    public Bool8 DisplaySyncEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, CAMetalLayerSelector.DisplaySyncEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerSelector.SetDisplaySyncEnabled, value);
    }

    public nint Colorspace
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, CAMetalLayerSelector.Colorspace);
        set => ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerSelector.SetColorspace, value);
    }

    public Bool8 AllowsNextDrawableTimeout
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, CAMetalLayerSelector.AllowsNextDrawableTimeout);
        set => ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerSelector.SetAllowsNextDrawableTimeout, value);
    }

    public MTLResidencySet ResidencySet
    {
        get
        {
            return new(ObjectiveCRuntime.MsgSendPtr(NativePtr, CAMetalLayerSelector.ResidencySet));
        }
    }

    public static implicit operator nint(CAMetalLayer value)
    {
        return value.NativePtr;
    }

    public static implicit operator CAMetalLayer(nint value)
    {
        return new(value);
    }

    public static CAMetalLayer Layer()
    {
        CAMetalLayer result = new(ObjectiveCRuntime.MsgSendPtr(Class, CAMetalLayerSelector.Layer));

        return result;
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
}

file class CAMetalLayerSelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector SetDevice = Selector.Register("setDevice:");

    public static readonly Selector PixelFormat = Selector.Register("pixelFormat");

    public static readonly Selector SetPixelFormat = Selector.Register("setPixelFormat:");

    public static readonly Selector FramebufferOnly = Selector.Register("framebufferOnly");

    public static readonly Selector SetFramebufferOnly = Selector.Register("setFramebufferOnly:");

    public static readonly Selector DrawableSize = Selector.Register("drawableSize");

    public static readonly Selector SetDrawableSize = Selector.Register("setDrawableSize:");

    public static readonly Selector NextDrawable = Selector.Register("nextDrawable");

    public static readonly Selector MaximumDrawableCount = Selector.Register("maximumDrawableCount");

    public static readonly Selector SetMaximumDrawableCount = Selector.Register("setMaximumDrawableCount:");

    public static readonly Selector DisplaySyncEnabled = Selector.Register("displaySyncEnabled");

    public static readonly Selector SetDisplaySyncEnabled = Selector.Register("setDisplaySyncEnabled:");

    public static readonly Selector Colorspace = Selector.Register("colorspace");

    public static readonly Selector SetColorspace = Selector.Register("setColorspace:");

    public static readonly Selector AllowsNextDrawableTimeout = Selector.Register("allowsNextDrawableTimeout");

    public static readonly Selector SetAllowsNextDrawableTimeout = Selector.Register("setAllowsNextDrawableTimeout:");

    public static readonly Selector ResidencySet = Selector.Register("residencySet");

    public static readonly Selector Layer = Selector.Register("layer");
}
