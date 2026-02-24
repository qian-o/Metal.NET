namespace Metal.NET;

public class CAMetalLayer(nint nativePtr) : NativeObject(nativePtr)
{
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
        get => GetProperty(ref field, CAMetalLayerBindings.Device);
        set => SetProperty(ref field, CAMetalLayerBindings.SetDevice, value);
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

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, CAMetalLayerBindings.PixelFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerBindings.SetPixelFormat, (nuint)value);
    }

    public MTLResidencySet? ResidencySet
    {
        get => GetProperty(ref field, CAMetalLayerBindings.ResidencySet);
    }

    public static CAMetalLayer? Layer()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(CAMetalLayerBindings.Class, CAMetalLayerBindings.Layer);

        return nativePtr is not 0 ? new(nativePtr) : null;
    }

    public CAMetalDrawable? NextDrawable()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, CAMetalLayerBindings.NextDrawable);

        return nativePtr is not 0 ? new(nativePtr) : null;
    }
}

file static class CAMetalLayerBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("CAMetalLayer");

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
