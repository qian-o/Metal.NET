namespace Metal.NET;

public class MTLFXSpatialScalerDescriptor : IDisposable
{
    public MTLFXSpatialScalerDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLFXSpatialScalerDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLFXSpatialScalerDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFXSpatialScalerDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLFXSpatialScalerDescriptor");

    public void SetColorTextureFormat(MTLPixelFormat format)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetColorTextureFormat, (nint)(uint)format);
    }

    public void SetOutputTextureFormat(MTLPixelFormat format)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetOutputTextureFormat, (nint)(uint)format);
    }

    public void SetInputWidth(uint width)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetInputWidth, (nint)width);
    }

    public void SetInputHeight(uint height)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetInputHeight, (nint)height);
    }

    public void SetOutputWidth(uint width)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetOutputWidth, (nint)width);
    }

    public void SetOutputHeight(uint height)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetOutputHeight, (nint)height);
    }

    public void SetColorProcessingMode(MTLFXSpatialScalerColorProcessingMode mode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetColorProcessingMode, (nint)(uint)mode);
    }

    public MTLFXSpatialScaler NewSpatialScaler(MTLDevice pDevice)
    {
        MTLFXSpatialScaler result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXSpatialScalerDescriptorSelector.NewSpatialScaler, pDevice.NativePtr));

        return result;
    }

    public MTLFXSpatialScaler NewSpatialScaler(MTLDevice pDevice, MTL4Compiler pCompiler)
    {
        MTLFXSpatialScaler result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXSpatialScalerDescriptorSelector.NewSpatialScalerPCompiler, pDevice.NativePtr, pCompiler.NativePtr));

        return result;
    }

    public static Bool8 SupportsDevice(MTLDevice pDevice)
    {
        bool result = (byte)ObjectiveCRuntime.MsgSendPtr(s_class, MTLFXSpatialScalerDescriptorSelector.SupportsDevice, pDevice.NativePtr) is not 0;

        return result;
    }

    public static Bool8 SupportsMetal4FX(MTLDevice pDevice)
    {
        bool result = (byte)ObjectiveCRuntime.MsgSendPtr(s_class, MTLFXSpatialScalerDescriptorSelector.SupportsMetal4FX, pDevice.NativePtr) is not 0;

        return result;
    }

}

file class MTLFXSpatialScalerDescriptorSelector
{
    public static readonly Selector SetColorTextureFormat = Selector.Register("setColorTextureFormat:");

    public static readonly Selector SetOutputTextureFormat = Selector.Register("setOutputTextureFormat:");

    public static readonly Selector SetInputWidth = Selector.Register("setInputWidth:");

    public static readonly Selector SetInputHeight = Selector.Register("setInputHeight:");

    public static readonly Selector SetOutputWidth = Selector.Register("setOutputWidth:");

    public static readonly Selector SetOutputHeight = Selector.Register("setOutputHeight:");

    public static readonly Selector SetColorProcessingMode = Selector.Register("setColorProcessingMode:");

    public static readonly Selector NewSpatialScaler = Selector.Register("newSpatialScaler:");

    public static readonly Selector NewSpatialScalerPCompiler = Selector.Register("newSpatialScaler:pCompiler:");

    public static readonly Selector SupportsDevice = Selector.Register("supportsDevice:");

    public static readonly Selector SupportsMetal4FX = Selector.Register("supportsMetal4FX:");
}
