namespace Metal.NET;

/// <summary>Groups parameters for the creation of a Metal argument table.</summary>
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

    #region Instance Properties - Properties

    /// <summary>Configures whether Metal initializes the bindings to nil values upon creation of argument table.</summary>
    public Bool8 InitializeBindings
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4ArgumentTableDescriptorBindings.InitializeBindings);
        set => ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableDescriptorBindings.SetInitializeBindings, value);
    }

    /// <summary>Assigns an optional label with the argument table for debug purposes.</summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTL4ArgumentTableDescriptorBindings.Label);
        set => SetProperty(ref field, MTL4ArgumentTableDescriptorBindings.SetLabel, value);
    }

    /// <summary>Determines the number of buffer-binding slots for the argument table.</summary>
    public nuint MaxBufferBindCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4ArgumentTableDescriptorBindings.MaxBufferBindCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableDescriptorBindings.SetMaxBufferBindCount, value);
    }

    /// <summary>Determines the number of sampler state-binding slots for the argument table.</summary>
    public nuint MaxSamplerStateBindCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4ArgumentTableDescriptorBindings.MaxSamplerStateBindCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableDescriptorBindings.SetMaxSamplerStateBindCount, value);
    }

    /// <summary>Determines the number of texture-binding slots for the argument table.</summary>
    public nuint MaxTextureBindCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4ArgumentTableDescriptorBindings.MaxTextureBindCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableDescriptorBindings.SetMaxTextureBindCount, value);
    }

    /// <summary>Controls whether Metal should reserve memory for attribute strides in the argument table.</summary>
    public Bool8 SupportAttributeStrides
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4ArgumentTableDescriptorBindings.SupportAttributeStrides);
        set => ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableDescriptorBindings.SetSupportAttributeStrides, value);
    }
    #endregion
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
