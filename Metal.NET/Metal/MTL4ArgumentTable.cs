namespace Metal.NET;

public partial class MTL4ArgumentTable : NativeObject
{
    public MTL4ArgumentTable(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArgumentTableSelector.Device);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArgumentTableSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public void SetAddress(nuint gpuAddress, nuint bindingIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableSelector.SetAddress, gpuAddress, bindingIndex);
    }

    public void SetAddress(nuint gpuAddress, nuint stride, nuint bindingIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableSelector.SetAddress, gpuAddress, stride, bindingIndex);
    }

    public void SetResource(MTLResourceID resourceID, nuint bindingIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableSelector.SetResource, resourceID, bindingIndex);
    }

    public void SetSamplerState(MTLResourceID resourceID, nuint bindingIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableSelector.SetSamplerState, resourceID, bindingIndex);
    }

    public void SetTexture(MTLResourceID resourceID, nuint bindingIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableSelector.SetTexture, resourceID, bindingIndex);
    }
}

file static class MTL4ArgumentTableSelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetAddress = Selector.Register("setAddress:atIndex:");

    public static readonly Selector SetResource = Selector.Register("setResource:atBufferIndex:");

    public static readonly Selector SetSamplerState = Selector.Register("setSamplerState:atIndex:");

    public static readonly Selector SetTexture = Selector.Register("setTexture:atIndex:");
}
