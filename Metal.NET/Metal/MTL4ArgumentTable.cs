namespace Metal.NET;

public class MTL4ArgumentTable(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArgumentTableBindings.Device);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLDevice(ptr);
            }

            return field;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArgumentTableBindings.Label);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSString(ptr);
            }

            return field;
        }
    }

    public void SetAddress(nuint gpuAddress, nuint bindingIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableBindings.SetAddress, gpuAddress, bindingIndex);
    }

    public void SetAddress(nuint gpuAddress, nuint stride, nuint bindingIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableBindings.SetAddress, gpuAddress, stride, bindingIndex);
    }

    public void SetResource(MTLResourceID resourceID, nuint bindingIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableBindings.SetResource, resourceID, bindingIndex);
    }

    public void SetSamplerState(MTLResourceID resourceID, nuint bindingIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableBindings.SetSamplerState, resourceID, bindingIndex);
    }

    public void SetTexture(MTLResourceID resourceID, nuint bindingIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableBindings.SetTexture, resourceID, bindingIndex);
    }
}

file static class MTL4ArgumentTableBindings
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetAddress = Selector.Register("setAddress:atIndex:");

    public static readonly Selector SetResource = Selector.Register("setResource:atBufferIndex:");

    public static readonly Selector SetSamplerState = Selector.Register("setSamplerState:atIndex:");

    public static readonly Selector SetTexture = Selector.Register("setTexture:atIndex:");
}
