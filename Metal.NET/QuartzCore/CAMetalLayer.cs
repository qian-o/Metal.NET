namespace Metal.NET;

public class CAMetalLayer(nint nativePtr) : NativeObject(nativePtr)
{
    public CAMetalLayer() : this(ObjectiveCRuntime.AllocInit(CAMetalLayerSelector.Class))
    {
    }

    public bool AllowsNextDrawableTimeout
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, CAMetalLayerSelector.AllowsNextDrawableTimeout);
        set => ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerSelector.SetAllowsNextDrawableTimeout, (Bool8)value);
    }

    public nint Colorspace
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, CAMetalLayerSelector.Colorspace);
        set => ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerSelector.SetColorspace, value);
    }

    public MTLDevice? Device
    {
        get => GetNullableObject<MTLDevice>(ObjectiveCRuntime.MsgSendPtr(NativePtr, CAMetalLayerSelector.Device));
        set => ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerSelector.SetDevice, value?.NativePtr ?? 0);
    }

    public bool DisplaySyncEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, CAMetalLayerSelector.DisplaySyncEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerSelector.SetDisplaySyncEnabled, (Bool8)value);
    }

    public CGSize DrawableSize
    {
        get => ObjectiveCRuntime.MsgSendCGSize(NativePtr, CAMetalLayerSelector.DrawableSize);
        set => ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerSelector.SetDrawableSize, value);
    }

    public bool FramebufferOnly
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, CAMetalLayerSelector.FramebufferOnly);
        set => ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerSelector.SetFramebufferOnly, (Bool8)value);
    }

    public nuint MaximumDrawableCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, CAMetalLayerSelector.MaximumDrawableCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerSelector.SetMaximumDrawableCount, value);
    }

    public CAMetalDrawable? NextDrawable
    {
        get => GetNullableObject<CAMetalDrawable>(ObjectiveCRuntime.MsgSendPtr(NativePtr, CAMetalLayerSelector.NextDrawable));
    }

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, CAMetalLayerSelector.PixelFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerSelector.SetPixelFormat, (nuint)value);
    }

    public MTLResidencySet? ResidencySet
    {
        get => GetNullableObject<MTLResidencySet>(ObjectiveCRuntime.MsgSendPtr(NativePtr, CAMetalLayerSelector.ResidencySet));
    }

    public static CAMetalLayer? Layer()
    {
        return GetNullableObject<CAMetalLayer>(ObjectiveCRuntime.MsgSendPtr(CAMetalLayerSelector.Class, CAMetalLayerSelector.Layer));
    }
}

file static class CAMetalLayerSelector
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
