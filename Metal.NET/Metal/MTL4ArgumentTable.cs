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
        ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableBindings.SetAddress, gpuAddress, bindingIndex);
    }

    public void SetAddress(nuint gpuAddress, nuint stride, nuint bindingIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableBindings.SetAddressAttributeStrideAtIndex, gpuAddress, stride, bindingIndex);
    }

    public void SetResource(MTLResourceID resourceID, nuint bindingIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableBindings.SetResource, resourceID, bindingIndex);
    }

    public void SetTexture(MTLResourceID resourceID, nuint bindingIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableBindings.SetTexture, resourceID, bindingIndex);
    }

    public void SetSamplerState(MTLResourceID resourceID, nuint bindingIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ArgumentTableBindings.SetSamplerState, resourceID, bindingIndex);
    }
}

file static class MTL4ArgumentTableBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector SetAddress = "setAddress:atIndex:";

    public static readonly Selector SetAddressAttributeStrideAtIndex = "setAddress:attributeStride:atIndex:";

    public static readonly Selector SetResource = "setResource:atBufferIndex:";

    public static readonly Selector SetSamplerState = "setSamplerState:atIndex:";

    public static readonly Selector SetTexture = "setTexture:atIndex:";
}
