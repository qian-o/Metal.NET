namespace Metal.NET;

public readonly struct MTL4ArgumentTableDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTL4ArgumentTableDescriptor value) => new(value.NativePtr);

    public MTL4ArgumentTableDescriptor() : this(ObjectiveC.AllocInit(MTL4ArgumentTableDescriptorBindings.Class))
    {
    }

    public MTL4ArgumentTableDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
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
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4ArgumentTableDescriptorBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableDescriptorBindings.SetLabel, value.NativePtr);
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
