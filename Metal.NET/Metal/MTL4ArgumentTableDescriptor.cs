namespace Metal.NET;

public readonly struct MTL4ArgumentTableDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

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
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArgumentTableDescriptorBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableDescriptorBindings.SetLabel, value?.NativePtr ?? 0);
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

    public static readonly Selector InitializeBindings = Selector.Register("initializeBindings");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector MaxBufferBindCount = Selector.Register("maxBufferBindCount");

    public static readonly Selector MaxSamplerStateBindCount = Selector.Register("maxSamplerStateBindCount");

    public static readonly Selector MaxTextureBindCount = Selector.Register("maxTextureBindCount");

    public static readonly Selector SetInitializeBindings = Selector.Register("setInitializeBindings:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetMaxBufferBindCount = Selector.Register("setMaxBufferBindCount:");

    public static readonly Selector SetMaxSamplerStateBindCount = Selector.Register("setMaxSamplerStateBindCount:");

    public static readonly Selector SetMaxTextureBindCount = Selector.Register("setMaxTextureBindCount:");

    public static readonly Selector SetSupportAttributeStrides = Selector.Register("setSupportAttributeStrides:");

    public static readonly Selector SupportAttributeStrides = Selector.Register("supportAttributeStrides");
}
