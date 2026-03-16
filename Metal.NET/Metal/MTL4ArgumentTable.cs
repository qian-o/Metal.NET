namespace Metal.NET;

/// <summary>Provides a mechanism to manage and provide resource bindings for buffers, textures, sampler states and other Metal resources.</summary>
public class MTL4ArgumentTable(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4ArgumentTable>
{
    #region INativeObject
    public static new MTL4ArgumentTable Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4ArgumentTable New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Instance Properties - Properties

    /// <summary>The device from which you created this argument table.</summary>
    public MTLDevice Device
    {
        get => GetProperty(ref field, MTL4ArgumentTableBindings.Device);
    }

    /// <summary>Assigns an optional label with this argument table for debugging purposes.</summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTL4ArgumentTableBindings.Label);
    }
    #endregion

    #region Instance Methods - Methods

    /// <summary>Binds a GPU address to a buffer binding slot, providing a dynamic vertex stride.</summary>
    public void SetAddress(nuint gpuAddress, nuint bindingIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableBindings.SetAddress, gpuAddress, bindingIndex);
    }

    /// <summary>Binds a GPU address to a buffer binding slot, providing a dynamic vertex stride.</summary>
    public void SetAddress(nuint gpuAddress, nuint stride, nuint bindingIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableBindings.SetAddressattributeStrideatIndex, gpuAddress, stride, bindingIndex);
    }

    /// <summary>Binds a resource to a buffer binding slot.</summary>
    public void SetResource(MTLResourceID resourceID, nuint bindingIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableBindings.SetResource, resourceID, bindingIndex);
    }

    /// <summary>Binds a sampler state to a sampler state binding slot.</summary>
    public void SetSamplerState(MTLResourceID resourceID, nuint bindingIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableBindings.SetSamplerState, resourceID, bindingIndex);
    }

    /// <summary>Binds a texture to a texture binding slot.</summary>
    public void SetTexture(MTLResourceID resourceID, nuint bindingIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableBindings.SetTexture, resourceID, bindingIndex);
    }
    #endregion
}

file static class MTL4ArgumentTableBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector SetAddress = "setAddress:atIndex:";

    public static readonly Selector SetAddressattributeStrideatIndex = "setAddress:attributeStride:atIndex:";

    public static readonly Selector SetResource = "setResource:atBufferIndex:";

    public static readonly Selector SetSamplerState = "setSamplerState:atIndex:";

    public static readonly Selector SetTexture = "setTexture:atIndex:";
}
