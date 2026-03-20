namespace Metal.NET;

public class MTL4ArgumentTable(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4ArgumentTable>
{
    #region INativeObject
    public static new MTL4ArgumentTable Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4ArgumentTable New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTL4ArgumentTableBindings.Device);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTL4ArgumentTableBindings.Label);
    }

    public void SetAddress(nuint gpuAddress, nuint bindingIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableBindings.SetAddress_AtIndex, gpuAddress, bindingIndex);
    }

    public void SetAddress(nuint gpuAddress, nuint stride, nuint bindingIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableBindings.SetAddress_AttributeStride_AtIndex, gpuAddress, stride, bindingIndex);
    }

    public void SetResource(MTLResourceID resourceID, nuint bindingIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableBindings.SetResource_AtBufferIndex, resourceID, bindingIndex);
    }

    public void SetTexture(MTLResourceID resourceID, nuint bindingIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableBindings.SetTexture_AtIndex, resourceID, bindingIndex);
    }

    public void SetSamplerState(MTLResourceID resourceID, nuint bindingIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableBindings.SetSamplerState_AtIndex, resourceID, bindingIndex);
    }
}

file static class MTL4ArgumentTableBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector SetAddress_AtIndex = "setAddress:atIndex:";

    public static readonly Selector SetAddress_AttributeStride_AtIndex = "setAddress:attributeStride:atIndex:";

    public static readonly Selector SetResource_AtBufferIndex = "setResource:atBufferIndex:";

    public static readonly Selector SetSamplerState_AtIndex = "setSamplerState:atIndex:";

    public static readonly Selector SetTexture_AtIndex = "setTexture:atIndex:";
}
