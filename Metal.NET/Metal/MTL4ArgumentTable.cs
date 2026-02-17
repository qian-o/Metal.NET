namespace Metal.NET;

public class MTL4ArgumentTable : IDisposable
{
    public MTL4ArgumentTable(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTL4ArgumentTable()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLDevice Device => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArgumentTableSelector.Device));

    public NSString Label => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArgumentTableSelector.Label));

    public void SetAddress(uint gpuAddress, uint bindingIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableSelector.SetAddressBindingIndex, (nuint)gpuAddress, (nuint)bindingIndex);
    }

    public void SetAddress(uint gpuAddress, uint stride, uint bindingIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableSelector.SetAddressStrideBindingIndex, (nuint)gpuAddress, (nuint)stride, (nuint)bindingIndex);
    }

    public void SetResource(MTLResourceID resourceID, uint bindingIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableSelector.SetResourceBindingIndex, resourceID, (nuint)bindingIndex);
    }

    public void SetSamplerState(MTLResourceID resourceID, uint bindingIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableSelector.SetSamplerStateBindingIndex, resourceID, (nuint)bindingIndex);
    }

    public void SetTexture(MTLResourceID resourceID, uint bindingIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableSelector.SetTextureBindingIndex, resourceID, (nuint)bindingIndex);
    }

    public static implicit operator nint(MTL4ArgumentTable value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4ArgumentTable(nint value)
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

file class MTL4ArgumentTableSelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetAddressBindingIndex = Selector.Register("setAddress:bindingIndex:");

    public static readonly Selector SetAddressStrideBindingIndex = Selector.Register("setAddress:stride:bindingIndex:");

    public static readonly Selector SetResourceBindingIndex = Selector.Register("setResource:bindingIndex:");

    public static readonly Selector SetSamplerStateBindingIndex = Selector.Register("setSamplerState:bindingIndex:");

    public static readonly Selector SetTextureBindingIndex = Selector.Register("setTexture:bindingIndex:");
}
