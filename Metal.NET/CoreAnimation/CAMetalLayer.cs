namespace Metal.NET;

public readonly struct CAMetalLayer(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(CAMetalLayer value) => new(value.NativePtr);

    public CAMetalLayer() : this(ObjectiveC.AllocInit(CAMetalLayerBindings.Class))
    {
    }

    public CAMetalLayer Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, CAMetalLayerBindings.Device));
        set => ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetDevice, value.NativePtr);
    }

    public MTLDevice PreferredDevice
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, CAMetalLayerBindings.PreferredDevice));
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
        get => new(ObjectiveC.MsgSendNInt(NativePtr, CAMetalLayerBindings.Colorspace));
        set => ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetColorspace, value.NativePtr);
    }

    public Bool8 WantsExtendedDynamicRangeContent
    {
        get => ObjectiveC.MsgSendBool(NativePtr, CAMetalLayerBindings.WantsExtendedDynamicRangeContent);
        set => ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetWantsExtendedDynamicRangeContent, value);
    }

    public CAEDRMetadata EDRMetadata
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, CAMetalLayerBindings.EDRMetadata));
        set => ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetEDRMetadata, value.NativePtr);
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

    public NSDictionary DeveloperHUDProperties
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, CAMetalLayerBindings.DeveloperHUDProperties));
        set => ObjectiveC.MsgSend(NativePtr, CAMetalLayerBindings.SetDeveloperHUDProperties, value.NativePtr);
    }

    public MTLResidencySet ResidencySet
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, CAMetalLayerBindings.ResidencySet));
    }

    public CAMetalDrawable NextDrawable()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, CAMetalLayerBindings.NextDrawable);

        return new(nativePtr);
    }
}

file static class CAMetalLayerBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("CAMetalLayer");

    public static readonly Selector AllowsNextDrawableTimeout = "allowsNextDrawableTimeout";

    public static readonly Selector Colorspace = "colorspace";

    public static readonly Selector DeveloperHUDProperties = "developerHUDProperties";

    public static readonly Selector Device = "device";

    public static readonly Selector DisplaySyncEnabled = "displaySyncEnabled";

    public static readonly Selector DrawableSize = "drawableSize";

    public static readonly Selector EDRMetadata = "EDRMetadata";

    public static readonly Selector FramebufferOnly = "framebufferOnly";

    public static readonly Selector MaximumDrawableCount = "maximumDrawableCount";

    public static readonly Selector NextDrawable = "nextDrawable";

    public static readonly Selector PixelFormat = "pixelFormat";

    public static readonly Selector PreferredDevice = "preferredDevice";

    public static readonly Selector PresentsWithTransaction = "presentsWithTransaction";

    public static readonly Selector ResidencySet = "residencySet";

    public static readonly Selector SetAllowsNextDrawableTimeout = "setAllowsNextDrawableTimeout:";

    public static readonly Selector SetColorspace = "setColorspace:";

    public static readonly Selector SetDeveloperHUDProperties = "setDeveloperHUDProperties:";

    public static readonly Selector SetDevice = "setDevice:";

    public static readonly Selector SetDisplaySyncEnabled = "setDisplaySyncEnabled:";

    public static readonly Selector SetDrawableSize = "setDrawableSize:";

    public static readonly Selector SetEDRMetadata = "setEDRMetadata:";

    public static readonly Selector SetFramebufferOnly = "setFramebufferOnly:";

    public static readonly Selector SetMaximumDrawableCount = "setMaximumDrawableCount:";

    public static readonly Selector SetPixelFormat = "setPixelFormat:";

    public static readonly Selector SetPresentsWithTransaction = "setPresentsWithTransaction:";

    public static readonly Selector SetWantsExtendedDynamicRangeContent = "setWantsExtendedDynamicRangeContent:";

    public static readonly Selector WantsExtendedDynamicRangeContent = "wantsExtendedDynamicRangeContent";
}
