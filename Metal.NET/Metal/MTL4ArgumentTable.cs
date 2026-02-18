namespace Metal.NET;

public class MTL4ArgumentTable : IDisposable
{
    public MTL4ArgumentTable(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTL4ArgumentTable()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLDevice Device
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArgumentTableSelector.Device));
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArgumentTableSelector.Label));
    }

    public static implicit operator nint(MTL4ArgumentTable value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4ArgumentTable(nint value)
    {
        return new(value);
    }

    public void SetAddress(nuint gpuAddress, nuint bindingIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableSelector.SetAddressAttributeStrideAtIndex, gpuAddress, bindingIndex);
    }

    public void SetAddress(nuint gpuAddress, nuint stride, nuint bindingIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableSelector.SetAddressAttributeStrideAtIndex, gpuAddress, stride, bindingIndex);
    }

    public void SetResource(MTLResourceID resourceID, nuint bindingIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableSelector.SetResourceAtBufferIndex, resourceID, bindingIndex);
    }

    public void SetSamplerState(MTLResourceID resourceID, nuint bindingIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableSelector.SetSamplerStateAtIndex, resourceID, bindingIndex);
    }

    public void SetTexture(MTLResourceID resourceID, nuint bindingIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableSelector.SetTextureAtIndex, resourceID, bindingIndex);
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

    public static readonly Selector SetAddressAttributeStrideAtIndex = Selector.Register("setAddress:attributeStride:atIndex:");

    public static readonly Selector SetResourceAtBufferIndex = Selector.Register("setResource:atBufferIndex:");

    public static readonly Selector SetSamplerStateAtIndex = Selector.Register("setSamplerState:atIndex:");

    public static readonly Selector SetTextureAtIndex = Selector.Register("setTexture:atIndex:");
}
