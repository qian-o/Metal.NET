namespace Metal.NET;

public class MTL4ArgumentTableDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4ArgumentTableDescriptor>
{
    #region INativeObject
    public static new MTL4ArgumentTableDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4ArgumentTableDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4ArgumentTableDescriptor() : this(ObjectiveC.AllocInit(MTL4ArgumentTableDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public nuint MaxBufferBindCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4ArgumentTableDescriptorBindings.MaxBufferBindCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableDescriptorBindings.SetMaxBufferBindCount, value);
    }

    public nuint MaxTextureBindCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4ArgumentTableDescriptorBindings.MaxTextureBindCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableDescriptorBindings.SetMaxTextureBindCount, value);
    }

    public nuint MaxSamplerStateBindCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4ArgumentTableDescriptorBindings.MaxSamplerStateBindCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableDescriptorBindings.SetMaxSamplerStateBindCount, value);
    }

    public Bool8 InitializeBindings
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4ArgumentTableDescriptorBindings.InitializeBindings);
        set => ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableDescriptorBindings.SetInitializeBindings, value);
    }

    public Bool8 SupportAttributeStrides
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4ArgumentTableDescriptorBindings.SupportAttributeStrides);
        set => ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableDescriptorBindings.SetSupportAttributeStrides, value);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTL4ArgumentTableDescriptorBindings.Label);
        set => SetProperty(ref field, MTL4ArgumentTableDescriptorBindings.SetLabel, value);
    }

    public nuint MaxBufferBindCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4ArgumentTableDescriptorBindings.MaxBufferBindCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableDescriptorBindings.SetMaxBufferBindCount, value);
    }

    public nuint MaxTextureBindCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4ArgumentTableDescriptorBindings.MaxTextureBindCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableDescriptorBindings.SetMaxTextureBindCount, value);
    }

    public nuint MaxSamplerStateBindCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4ArgumentTableDescriptorBindings.MaxSamplerStateBindCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableDescriptorBindings.SetMaxSamplerStateBindCount, value);
    }

    public Bool8 InitializeBindings
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4ArgumentTableDescriptorBindings.InitializeBindings);
        set => ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableDescriptorBindings.SetInitializeBindings, value);
    }

    public Bool8 SupportAttributeStrides
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4ArgumentTableDescriptorBindings.SupportAttributeStrides);
        set => ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableDescriptorBindings.SetSupportAttributeStrides, value);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTL4ArgumentTableDescriptorBindings.Label);
        set => SetProperty(ref field, MTL4ArgumentTableDescriptorBindings.SetLabel, value);
    }

    public void SetMaxBufferBindCount(nuint maxBufferBindCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableDescriptorBindings.SetMaxBufferBindCount, maxBufferBindCount);
    }

    public void SetMaxTextureBindCount(nuint maxTextureBindCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableDescriptorBindings.SetMaxTextureBindCount, maxTextureBindCount);
    }

    public void SetMaxSamplerStateBindCount(nuint maxSamplerStateBindCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableDescriptorBindings.SetMaxSamplerStateBindCount, maxSamplerStateBindCount);
    }

    public void SetInitializeBindings(bool initializeBindings)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableDescriptorBindings.SetInitializeBindings, initializeBindings);
    }

    public void SetSupportAttributeStrides(bool supportAttributeStrides)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableDescriptorBindings.SetSupportAttributeStrides, supportAttributeStrides);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableDescriptorBindings.SetLabel, label.NativePtr);
    }
}

file static class MTL4ArgumentTableDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4ArgumentTableDescriptor");

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
