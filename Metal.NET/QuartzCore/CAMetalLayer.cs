namespace Metal.NET;

public readonly struct CAMetalLayer(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public CAMetalLayer() : this(ObjectiveCRuntime.AllocInit(CAMetalLayerBindings.Class))
    {
    }

    public bool AllowsNextDrawableTimeout
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, CAMetalLayerBindings.AllowsNextDrawableTimeout);
        set => ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerBindings.SetAllowsNextDrawableTimeout, (Bool8)value);
    }

    public nint Colorspace
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, CAMetalLayerBindings.Colorspace);
        set => ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerBindings.SetColorspace, value);
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, CAMetalLayerBindings.Device);
            return ptr is not 0 ? new MTLDevice(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerBindings.SetDevice, value?.NativePtr ?? 0);
    }

    public bool DisplaySyncEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, CAMetalLayerBindings.DisplaySyncEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerBindings.SetDisplaySyncEnabled, (Bool8)value);
    }

    public CGSize DrawableSize
    {
        get => ObjectiveCRuntime.MsgSendCGSize(NativePtr, CAMetalLayerBindings.DrawableSize);
        set => ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerBindings.SetDrawableSize, value);
    }

    public bool FramebufferOnly
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, CAMetalLayerBindings.FramebufferOnly);
        set => ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerBindings.SetFramebufferOnly, (Bool8)value);
    }

    public nuint MaximumDrawableCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, CAMetalLayerBindings.MaximumDrawableCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerBindings.SetMaximumDrawableCount, value);
    }

    public CAMetalDrawable? NextDrawable
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, CAMetalLayerBindings.NextDrawable);
            return ptr is not 0 ? new CAMetalDrawable(ptr) : default;
        }
    }

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, CAMetalLayerBindings.PixelFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerBindings.SetPixelFormat, (nuint)value);
    }

    public MTLResidencySet? ResidencySet
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, CAMetalLayerBindings.ResidencySet);
            return ptr is not 0 ? new MTLResidencySet(ptr) : default;
        }
    }

    public static CAMetalLayer? Layer()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(CAMetalLayerBindings.Class, CAMetalLayerBindings.Layer);
        return ptr is not 0 ? new CAMetalLayer(ptr) : default;
    }
}

file static class CAMetalLayerBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("CAMetalLayer");

    public static readonly Selector AllowsNextDrawableTimeout = Selector.Register("allowsNextDrawableTimeout");

    public static readonly Selector Colorspace = Selector.Register("colorspace");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector DisplaySyncEnabled = Selector.Register("displaySyncEnabled");

    public static readonly Selector DrawableSize = Selector.Register("drawableSize");

    public static readonly Selector FramebufferOnly = Selector.Register("framebufferOnly");

    public static readonly Selector Layer = Selector.Register("layer");

    public static readonly Selector MaximumDrawableCount = Selector.Register("maximumDrawableCount");

    public static readonly Selector NextDrawable = Selector.Register("nextDrawable");

    public static readonly Selector PixelFormat = Selector.Register("pixelFormat");

    public static readonly Selector ResidencySet = Selector.Register("residencySet");

    public static readonly Selector SetAllowsNextDrawableTimeout = Selector.Register("setAllowsNextDrawableTimeout:");

    public static readonly Selector SetColorspace = Selector.Register("setColorspace:");

    public static readonly Selector SetDevice = Selector.Register("setDevice:");

    public static readonly Selector SetDisplaySyncEnabled = Selector.Register("setDisplaySyncEnabled:");

    public static readonly Selector SetDrawableSize = Selector.Register("setDrawableSize:");

    public static readonly Selector SetFramebufferOnly = Selector.Register("setFramebufferOnly:");

    public static readonly Selector SetMaximumDrawableCount = Selector.Register("setMaximumDrawableCount:");

    public static readonly Selector SetPixelFormat = Selector.Register("setPixelFormat:");
}
