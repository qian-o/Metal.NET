namespace Metal.NET;

public class MTL4ArgumentTableDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTL4ArgumentTableDescriptor>
{
    public static MTL4ArgumentTableDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTL4ArgumentTableDescriptor Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTL4ArgumentTableDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4ArgumentTableDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public Bool8 InitializeBindings
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4ArgumentTableDescriptorBindings.InitializeBindings);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableDescriptorBindings.SetInitializeBindings, value);
    }

    public NSString Label
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

    public Bool8 SupportAttributeStrides
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4ArgumentTableDescriptorBindings.SupportAttributeStrides);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableDescriptorBindings.SetSupportAttributeStrides, value);
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
