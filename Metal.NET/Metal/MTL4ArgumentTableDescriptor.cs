namespace Metal.NET;

public class MTL4ArgumentTableDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4ArgumentTableDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4ArgumentTableDescriptorSelector.Class))
    {
    }

    public bool InitializeBindings
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4ArgumentTableDescriptorSelector.InitializeBindings);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableDescriptorSelector.SetInitializeBindings, (Bool8)value);
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArgumentTableDescriptorSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableDescriptorSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public nuint MaxBufferBindCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4ArgumentTableDescriptorSelector.MaxBufferBindCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableDescriptorSelector.SetMaxBufferBindCount, value);
    }

    public nuint MaxSamplerStateBindCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4ArgumentTableDescriptorSelector.MaxSamplerStateBindCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableDescriptorSelector.SetMaxSamplerStateBindCount, value);
    }

    public nuint MaxTextureBindCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4ArgumentTableDescriptorSelector.MaxTextureBindCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableDescriptorSelector.SetMaxTextureBindCount, value);
    }

    public bool SupportAttributeStrides
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4ArgumentTableDescriptorSelector.SupportAttributeStrides);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableDescriptorSelector.SetSupportAttributeStrides, (Bool8)value);
    }
}

file static class MTL4ArgumentTableDescriptorSelector
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
