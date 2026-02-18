namespace Metal.NET;

public class MTL4ArgumentTableDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4ArgumentTableDescriptor");

    public MTL4ArgumentTableDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTL4ArgumentTableDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTL4ArgumentTableDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public Bool8 InitializeBindings
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4ArgumentTableDescriptorSelector.InitializeBindings);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableDescriptorSelector.SetInitializeBindings, value);
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArgumentTableDescriptorSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableDescriptorSelector.SetLabel, value.NativePtr);
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

    public Bool8 SupportAttributeStrides
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4ArgumentTableDescriptorSelector.SupportAttributeStrides);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableDescriptorSelector.SetSupportAttributeStrides, value);
    }

    public static implicit operator nint(MTL4ArgumentTableDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4ArgumentTableDescriptor(nint value)
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
}

file class MTL4ArgumentTableDescriptorSelector
{
    public static readonly Selector InitializeBindings = Selector.Register("initializeBindings");

    public static readonly Selector SetInitializeBindings = Selector.Register("setInitializeBindings:");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector MaxBufferBindCount = Selector.Register("maxBufferBindCount");

    public static readonly Selector SetMaxBufferBindCount = Selector.Register("setMaxBufferBindCount:");

    public static readonly Selector MaxSamplerStateBindCount = Selector.Register("maxSamplerStateBindCount");

    public static readonly Selector SetMaxSamplerStateBindCount = Selector.Register("setMaxSamplerStateBindCount:");

    public static readonly Selector MaxTextureBindCount = Selector.Register("maxTextureBindCount");

    public static readonly Selector SetMaxTextureBindCount = Selector.Register("setMaxTextureBindCount:");

    public static readonly Selector SupportAttributeStrides = Selector.Register("supportAttributeStrides");

    public static readonly Selector SetSupportAttributeStrides = Selector.Register("setSupportAttributeStrides:");
}
