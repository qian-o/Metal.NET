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

    public MTLDevice Device
    {
        get => GetProperty(ref field, CAMetalLayerBindings.Device);
        set => SetProperty(ref field, CAMetalLayerBindings.SetDevice, value);
    }

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, CAMetalLayerBindings.PixelFormat);
        set => ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetPixelFormat, (nuint)value);
    }

    public Bool8 FramebufferOnly
    {
        get => ObjectiveC.MsgSendBool(NativePtr, CAMetalLayerBindings.FramebufferOnly);
        set => ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetFramebufferOnly, value);
    }

    public CGSize DrawableSize
    {
        get => ObjectiveC.MsgSendCGSize(NativePtr, CAMetalLayerBindings.DrawableSize);
        set => ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetDrawableSize, value);
    }

    public nuint MaximumDrawableCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, CAMetalLayerBindings.MaximumDrawableCount);
        set => ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetMaximumDrawableCount, value);
    }

    public Bool8 PresentsWithTransaction
    {
        get => ObjectiveC.MsgSendBool(NativePtr, CAMetalLayerBindings.PresentsWithTransaction);
        set => ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetPresentsWithTransaction, value);
    }

    public CGColorSpace Colorspace
    {
        get => GetProperty(ref field, CAMetalLayerBindings.Colorspace);
        set => SetProperty(ref field, CAMetalLayerBindings.SetColorspace, value);
    }

    public Bool8 WantsExtendedDynamicRangeContent
    {
        get => ObjectiveC.MsgSendBool(NativePtr, CAMetalLayerBindings.WantsExtendedDynamicRangeContent);
        set => ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetWantsExtendedDynamicRangeContent, value);
    }

    public Bool8 DisplaySyncEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, CAMetalLayerBindings.DisplaySyncEnabled);
        set => ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetDisplaySyncEnabled, value);
    }

    public Bool8 AllowsNextDrawableTimeout
    {
        get => ObjectiveC.MsgSendBool(NativePtr, CAMetalLayerBindings.AllowsNextDrawableTimeout);
        set => ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetAllowsNextDrawableTimeout, value);
    }

    public CAMetalDrawable NextDrawable
    {
        get => GetProperty(ref field, CAMetalLayerBindings.NextDrawable);
    }

    public MTLDevice Device
    {
        get => GetProperty(ref field, CAMetalLayerBindings.Device);
        set => SetProperty(ref field, CAMetalLayerBindings.SetDevice, value);
    }

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, CAMetalLayerBindings.PixelFormat);
        set => ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetPixelFormat, (nuint)value);
    }

    public Bool8 FramebufferOnly
    {
        get => ObjectiveC.MsgSendBool(NativePtr, CAMetalLayerBindings.FramebufferOnly);
        set => ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetFramebufferOnly, value);
    }

    public CGSize DrawableSize
    {
        get => ObjectiveC.MsgSendCGSize(NativePtr, CAMetalLayerBindings.DrawableSize);
        set => ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetDrawableSize, value);
    }

    public nuint MaximumDrawableCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, CAMetalLayerBindings.MaximumDrawableCount);
        set => ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetMaximumDrawableCount, value);
    }

    public Bool8 PresentsWithTransaction
    {
        get => ObjectiveC.MsgSendBool(NativePtr, CAMetalLayerBindings.PresentsWithTransaction);
        set => ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetPresentsWithTransaction, value);
    }

    public CGColorSpace Colorspace
    {
        get => GetProperty(ref field, CAMetalLayerBindings.Colorspace);
        set => SetProperty(ref field, CAMetalLayerBindings.SetColorspace, value);
    }

    public Bool8 WantsExtendedDynamicRangeContent
    {
        get => ObjectiveC.MsgSendBool(NativePtr, CAMetalLayerBindings.WantsExtendedDynamicRangeContent);
        set => ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetWantsExtendedDynamicRangeContent, value);
    }

    public Bool8 DisplaySyncEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, CAMetalLayerBindings.DisplaySyncEnabled);
        set => ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetDisplaySyncEnabled, value);
    }

    public Bool8 AllowsNextDrawableTimeout
    {
        get => ObjectiveC.MsgSendBool(NativePtr, CAMetalLayerBindings.AllowsNextDrawableTimeout);
        set => ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetAllowsNextDrawableTimeout, value);
    }

    public void SetDevice(MTLDevice device)
    {
        ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetDevice, device.NativePtr);
    }

    public void SetPixelFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetPixelFormat, (nuint)pixelFormat);
    }

    public void SetFramebufferOnly(bool framebufferOnly)
    {
        ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetFramebufferOnly, framebufferOnly);
    }

    public void SetDrawableSize(CGSize drawableSize)
    {
        ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetDrawableSize, drawableSize);
    }

    public void SetMaximumDrawableCount(nuint maximumDrawableCount)
    {
        ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetMaximumDrawableCount, maximumDrawableCount);
    }

    public void SetPresentsWithTransaction(bool presentsWithTransaction)
    {
        ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetPresentsWithTransaction, presentsWithTransaction);
    }

    public void SetColorspace(CGColorSpace colorspace)
    {
        ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetColorspace, colorspace.NativePtr);
    }

    public void SetWantsExtendedDynamicRangeContent(bool wantsExtendedDynamicRangeContent)
    {
        ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetWantsExtendedDynamicRangeContent, wantsExtendedDynamicRangeContent);
    }

    public void SetDisplaySyncEnabled(bool displaySyncEnabled)
    {
        ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetDisplaySyncEnabled, displaySyncEnabled);
    }

    public void SetAllowsNextDrawableTimeout(bool allowsNextDrawableTimeout)
    {
        ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetAllowsNextDrawableTimeout, allowsNextDrawableTimeout);
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

    public static readonly Selector MaximumDrawableCount = "maximumDrawableCount";

    public static readonly Selector NextDrawable = "nextDrawable";

    public static readonly Selector PixelFormat = "pixelFormat";

    public static readonly Selector PresentsWithTransaction = "presentsWithTransaction";

    public static readonly Selector SetAllowsNextDrawableTimeout = "setAllowsNextDrawableTimeout:";

    public static readonly Selector SetColorspace = "setColorspace:";

    public static readonly Selector SetDevice = "setDevice:";

    public static readonly Selector SetDisplaySyncEnabled = "setDisplaySyncEnabled:";

    public static readonly Selector SetDrawableSize = "setDrawableSize:";

    public static readonly Selector SetFramebufferOnly = "setFramebufferOnly:";

    public static readonly Selector SetMaximumDrawableCount = "setMaximumDrawableCount:";

    public static readonly Selector SetPixelFormat = "setPixelFormat:";

    public static readonly Selector SetPresentsWithTransaction = "setPresentsWithTransaction:";

    public static readonly Selector SetWantsExtendedDynamicRangeContent = "setWantsExtendedDynamicRangeContent:";

    public static readonly Selector WantsExtendedDynamicRangeContent = "wantsExtendedDynamicRangeContent";
}
