namespace Metal.NET;

file class MTL4ArgumentTableDescriptorSelector
{
    public static readonly Selector SetInitializeBindings_ = Selector.Register("setInitializeBindings:");
    public static readonly Selector SetLabel_ = Selector.Register("setLabel:");
    public static readonly Selector SetMaxBufferBindCount_ = Selector.Register("setMaxBufferBindCount:");
    public static readonly Selector SetMaxSamplerStateBindCount_ = Selector.Register("setMaxSamplerStateBindCount:");
    public static readonly Selector SetMaxTextureBindCount_ = Selector.Register("setMaxTextureBindCount:");
    public static readonly Selector SetSupportAttributeStrides_ = Selector.Register("setSupportAttributeStrides:");
}

public class MTL4ArgumentTableDescriptor : IDisposable
{
    public MTL4ArgumentTableDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ArgumentTableDescriptorSelector.SetInitializeBindings_, (nint)initializeBindings.Value);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ArgumentTableDescriptorSelector.SetLabel_, label.NativePtr);
    }

    public void SetMaxBufferBindCount(nuint maxBufferBindCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ArgumentTableDescriptorSelector.SetMaxBufferBindCount_, (nint)maxBufferBindCount);
    }

    public void SetMaxSamplerStateBindCount(nuint maxSamplerStateBindCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ArgumentTableDescriptorSelector.SetMaxSamplerStateBindCount_, (nint)maxSamplerStateBindCount);
    }

    public void SetMaxTextureBindCount(nuint maxTextureBindCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ArgumentTableDescriptorSelector.SetMaxTextureBindCount_, (nint)maxTextureBindCount);
    }

    public void SetSupportAttributeStrides(Bool8 supportAttributeStrides)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ArgumentTableDescriptorSelector.SetSupportAttributeStrides_, (nint)supportAttributeStrides.Value);
    }

}
