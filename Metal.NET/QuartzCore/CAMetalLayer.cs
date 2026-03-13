namespace Metal.NET;

public class CAMetalLayer(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<CAMetalLayer>
{
    #region INativeObject
    public static new CAMetalLayer Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new CAMetalLayer New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public CAMetalLayer() : this(ObjectiveC.AllocInit(CAMetalLayerBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public Bool8 AllowsNextDrawableTimeout
    {
        get => ObjectiveC.MsgSendBool(NativePtr, CAMetalLayerBindings.AllowsNextDrawableTimeout);
        set => ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetAllowsNextDrawableTimeout, value);
    }

    public CGColorSpace Colorspace
    {
        get => GetProperty(ref field, CAMetalLayerBindings.Colorspace);
        set => SetProperty(ref field, CAMetalLayerBindings.SetColorspace, value);
    }

    public MTLDevice Device
    {
        get => GetProperty(ref field, CAMetalLayerBindings.Device);
        set => SetProperty(ref field, CAMetalLayerBindings.SetDevice, value);
    }

    public Bool8 DisplaySyncEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, CAMetalLayerBindings.DisplaySyncEnabled);
        set => ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetDisplaySyncEnabled, value);
    }

    public CGSize DrawableSize
    {
        get => ObjectiveC.MsgSendCGSize(NativePtr, CAMetalLayerBindings.DrawableSize);
        set => ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetDrawableSize, value);
    }

    public Bool8 FramebufferOnly
    {
        get => ObjectiveC.MsgSendBool(NativePtr, CAMetalLayerBindings.FramebufferOnly);
        set => ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetFramebufferOnly, value);
    }

    public nuint MaximumDrawableCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, CAMetalLayerBindings.MaximumDrawableCount);
        set => ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetMaximumDrawableCount, value);
    }

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, CAMetalLayerBindings.PixelFormat);
        set => ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetPixelFormat, (nuint)value);
    }

    public MTLResidencySet ResidencySet
    {
        get => GetProperty(ref field, CAMetalLayerBindings.ResidencySet);
    }

    public static CAMetalLayer Layer()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(CAMetalLayerBindings.Class, CAMetalLayerBindings.Layer);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public CAMetalDrawable NextDrawable()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, CAMetalLayerBindings.NextDrawable);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class CAMetalLayerBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("CAMetalLayer");

    public static readonly Selector AllowsNextDrawableTimeout = "allowsNextDrawableTimeout";

    public static readonly Selector Colorspace = "colorspace";

    public static readonly Selector Device = "device";

    public static readonly Selector DisplaySyncEnabled = "displaySyncEnabled";

    public static readonly Selector DrawableSize = "drawableSize";

    public static readonly Selector FramebufferOnly = "framebufferOnly";

    public static readonly Selector Layer = "layer";

    public static readonly Selector MaximumDrawableCount = "maximumDrawableCount";

    public static readonly Selector NextDrawable = "nextDrawable";

    public static readonly Selector PixelFormat = "pixelFormat";

    public static readonly Selector ResidencySet = "residencySet";

    public static readonly Selector SetAllowsNextDrawableTimeout = "setAllowsNextDrawableTimeout:";

    public static readonly Selector SetColorspace = "setColorspace:";

    public static readonly Selector SetDevice = "setDevice:";

    public static readonly Selector SetDisplaySyncEnabled = "setDisplaySyncEnabled:";

    public static readonly Selector SetDrawableSize = "setDrawableSize:";

    public static readonly Selector SetFramebufferOnly = "setFramebufferOnly:";

    public static readonly Selector SetMaximumDrawableCount = "setMaximumDrawableCount:";

    public static readonly Selector SetPixelFormat = "setPixelFormat:";
}
