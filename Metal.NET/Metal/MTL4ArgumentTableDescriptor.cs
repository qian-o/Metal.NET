namespace Metal.NET;

public class MTL4ArgumentTableDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4ArgumentTableDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4ArgumentTableDescriptorBindings.Class))
    {
    }

    public bool InitializeBindings
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4ArgumentTableDescriptorBindings.InitializeBindings);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableDescriptorBindings.SetInitializeBindings, (Bool8)value);
    }

    public NSString? Label
    {
        get => GetProperty(ref field, MTL4ArgumentTableDescriptorBindings.Label);
        set => SetProperty(ref field, MTL4ArgumentTableDescriptorBindings.SetLabel, value);
    }

    public nuint MaxBufferBindCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4ArgumentTableDescriptorBindings.MaxBufferBindCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableDescriptorBindings.SetMaxBufferBindCount, value);
    }

    public nuint MaxSamplerStateBindCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4ArgumentTableDescriptorBindings.MaxSamplerStateBindCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableDescriptorBindings.SetMaxSamplerStateBindCount, value);
    }

    public nuint MaxTextureBindCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4ArgumentTableDescriptorBindings.MaxTextureBindCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableDescriptorBindings.SetMaxTextureBindCount, value);
    }

    public bool SupportAttributeStrides
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4ArgumentTableDescriptorBindings.SupportAttributeStrides);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableDescriptorBindings.SetSupportAttributeStrides, (Bool8)value);
    }
}

file static class MTL4ArgumentTableDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4ArgumentTableDescriptor");

    public static readonly Selector InitializeBindings = "initializeBindings";

    public static readonly Selector Label = "label";

    public static readonly Selector MaxBufferBindCount = "maxBufferBindCount";

    public static readonly Selector MaxSamplerStateBindCount = "maxSamplerStateBindCount";

    public static readonly Selector MaxTextureBindCount = "maxTextureBindCount";

    public static readonly Selector SetInitializeBindings = "setInitializeBindings:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetMaxBufferBindCount = "setMaxBufferBindCount:";

    public static readonly Selector SetMaxSamplerStateBindCount = "setMaxSamplerStateBindCount:";

    public static readonly Selector SetMaxTextureBindCount = "setMaxTextureBindCount:";

    public static readonly Selector SetSupportAttributeStrides = "setSupportAttributeStrides:";

    public static readonly Selector SupportAttributeStrides = "supportAttributeStrides";
}
