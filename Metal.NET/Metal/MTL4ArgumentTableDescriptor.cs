namespace Metal.NET;

public class MTL4ArgumentTableDescriptor : IDisposable
{
    public MTL4ArgumentTableDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTL4ArgumentTableDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

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

    public void SetInitializeBindings(Bool8 initializeBindings)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableDescriptorSelector.SetInitializeBindings, (nint)initializeBindings.Value);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableDescriptorSelector.SetLabel, label.NativePtr);
    }

    public void SetMaxBufferBindCount(uint maxBufferBindCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableDescriptorSelector.SetMaxBufferBindCount, (nint)maxBufferBindCount);
    }

    public void SetMaxSamplerStateBindCount(uint maxSamplerStateBindCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableDescriptorSelector.SetMaxSamplerStateBindCount, (nint)maxSamplerStateBindCount);
    }

    public void SetMaxTextureBindCount(uint maxTextureBindCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableDescriptorSelector.SetMaxTextureBindCount, (nint)maxTextureBindCount);
    }

    public void SetSupportAttributeStrides(Bool8 supportAttributeStrides)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArgumentTableDescriptorSelector.SetSupportAttributeStrides, (nint)supportAttributeStrides.Value);
    }

}

file class MTL4ArgumentTableDescriptorSelector
{
    public static readonly Selector SetInitializeBindings = Selector.Register("setInitializeBindings:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetMaxBufferBindCount = Selector.Register("setMaxBufferBindCount:");

    public static readonly Selector SetMaxSamplerStateBindCount = Selector.Register("setMaxSamplerStateBindCount:");

    public static readonly Selector SetMaxTextureBindCount = Selector.Register("setMaxTextureBindCount:");

    public static readonly Selector SetSupportAttributeStrides = Selector.Register("setSupportAttributeStrides:");
}
