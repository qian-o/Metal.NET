namespace Metal.NET;

public class CAMetalLayer(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<CAMetalLayer>
{
    public static CAMetalLayer Null { get; } = new(0, false);

    public static CAMetalLayer Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public CAMetalLayer() : this(ObjectiveCRuntime.AllocInit(CAMetalLayerBindings.Class), true)
    {
        GC.ReRegisterForFinalize(this);
    }

    public Bool8 AllowsNextDrawableTimeout
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, CAMetalLayerBindings.AllowsNextDrawableTimeout);
        set => ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerBindings.SetAllowsNextDrawableTimeout, value);
    }

    public nint Colorspace
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, CAMetalLayerBindings.Colorspace);
        set => ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerBindings.SetColorspace, value);
    }

    public MTLDevice Device
    {
        get => GetProperty(ref field, CAMetalLayerBindings.Device);
        set => SetProperty(ref field, CAMetalLayerBindings.SetDevice, value);
    }

    public Bool8 DisplaySyncEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, CAMetalLayerBindings.DisplaySyncEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerBindings.SetDisplaySyncEnabled, value);
    }

    public CGSize DrawableSize
    {
        get => ObjectiveCRuntime.MsgSendCGSize(NativePtr, CAMetalLayerBindings.DrawableSize);
        set => ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerBindings.SetDrawableSize, value);
    }

    public Bool8 FramebufferOnly
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, CAMetalLayerBindings.FramebufferOnly);
        set => ObjectiveCRuntime.MsgSend(NativePtr, CAMetalLayerBindings.SetFramebufferOnly, value);
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

    public MTLResidencySet ResidencySet
    {
        get => GetProperty(ref field, CAMetalLayerBindings.ResidencySet);
    }

    public static CAMetalLayer Layer()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(CAMetalLayerBindings.Class, CAMetalLayerBindings.Layer);

        return new(nativePtr, true);
    }

    public CAMetalDrawable NextDrawable()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, CAMetalLayerBindings.NextDrawable);

        return new(nativePtr, true);
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
